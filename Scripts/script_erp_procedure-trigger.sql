USE erp_advocacia;

DROP PROCEDURE IF EXISTS sp_cumprir_prazo;
DROP PROCEDURE IF EXISTS sp_iniciar_processo;
DROP PROCEDURE IF EXISTS sp_total_recebido_contrato;
DROP TRIGGER IF EXISTS trg_prazo_cumprido;
DROP TRIGGER IF EXISTS trg_validar_inicio_processo;
DROP TRIGGER IF EXISTS trg_unico_responsavel_principal;

DELIMITER //

CREATE PROCEDURE sp_cumprir_prazo(IN p_id_prazo INT, IN p_usuario_id INT)
BEGIN
    DECLARE v_alterados INT DEFAULT 0;
    DECLARE v_processo INT;
    DECLARE v_titulo VARCHAR(150);
    DECLARE v_data DATETIME;
    DECLARE v_status VARCHAR(20);
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    IF p_usuario_id IS NULL OR p_usuario_id <= 0 THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Usuario invalido para auditoria.';
    END IF;

    START TRANSACTION;

    UPDATE PRAZO_PROCESSUAL SET status = 'cumprido'
    WHERE id_prazo = p_id_prazo AND status = 'pendente';
    SET v_alterados = ROW_COUNT();

    IF v_alterados = 1 THEN
        SELECT processo_id, titulo, data_cumprimento, status INTO v_processo, v_titulo, v_data, v_status
        FROM PRAZO_PROCESSUAL WHERE id_prazo = p_id_prazo;

        IF v_data IS NULL OR v_status <> 'cumprido' THEN
            SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Data de cumprimento ausente. Verifique a trigger.';
        END IF;

        INSERT INTO MOVIMENTACAO (processo_id, usuario_id, data_hora, descricao)
        VALUES (v_processo, p_usuario_id, NOW(), CONCAT('Prazo cumprido: ', v_titulo, '.'));

        INSERT INTO AUDITORIA (usuario_id, acao, entidade, registro_id, detalhes)
        VALUES (p_usuario_id, 'CUMPRIR_PRAZO', 'PRAZO_PROCESSUAL', p_id_prazo,
                LEFT(CONCAT('Prazo cumprido: ', v_titulo), 255));
    END IF;

    COMMIT;
    SELECT v_alterados AS prazos_cumpridos;
END //

CREATE PROCEDURE sp_iniciar_processo(IN p_id_processo INT, IN p_usuario_id INT)
BEGIN
    DECLARE v_alterados INT DEFAULT 0;
    DECLARE v_numero VARCHAR(25);
    DECLARE v_mensagem VARCHAR(150);
    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    IF p_usuario_id IS NULL OR p_usuario_id <= 0 THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Usuario invalido para auditoria.';
    END IF;

    START TRANSACTION;

    UPDATE PROCESSO SET status = 'em_andamento'
    WHERE id_processo = p_id_processo AND status = 'rascunho'
      AND EXISTS (
          SELECT 1 FROM PROCESSO_ADVOGADO PA
          INNER JOIN USUARIO U ON PA.usuario_id = U.id_usuario
          WHERE PA.processo_id = p_id_processo
            AND U.perfil = 'advogado' AND U.ativo = TRUE
      );
    SET v_alterados = ROW_COUNT();

    IF v_alterados = 1 THEN
        IF NOT EXISTS (SELECT 1 FROM PROCESSO
                       WHERE id_processo = p_id_processo AND status = 'em_andamento') THEN
            SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Inicio do processo nao confirmado.';
        END IF;

        SELECT numero_cnj INTO v_numero FROM PROCESSO WHERE id_processo = p_id_processo;
        INSERT INTO MOVIMENTACAO (processo_id, usuario_id, data_hora, descricao)
        VALUES (p_id_processo, p_usuario_id, NOW(), 'Processo iniciado (status: em andamento).');

        INSERT INTO AUDITORIA (usuario_id, acao, entidade, registro_id, detalhes)
        VALUES (p_usuario_id, 'INICIAR_PROCESSO', 'PROCESSO', p_id_processo,
                LEFT(CONCAT('Processo iniciado: ', v_numero), 255));
        SET v_mensagem = 'Processo iniciado com sucesso.';
    ELSE
        SET v_mensagem = 'Processo nao iniciado. Confira o status e os advogados ativos e atualize a selecao.';
    END IF;

    COMMIT;
    SELECT v_mensagem AS mensagem, v_alterados AS processos_iniciados;
END //

CREATE PROCEDURE sp_total_recebido_contrato(
    IN p_id_contrato INT,
    OUT p_total DECIMAL(15,2)
)
BEGIN

    DECLARE v_contrato_existe INT;

    SELECT COUNT(*)
    INTO v_contrato_existe
    FROM CONTRATO_HONORARIOS
    WHERE id_contrato = p_id_contrato;

    IF v_contrato_existe = 0 THEN

        SET p_total = NULL;

    ELSE

        SELECT SUM(valor)
        INTO p_total
        FROM PAGAMENTO
        WHERE contrato_id = p_id_contrato;

        IF p_total IS NULL THEN
            SET p_total = 0;
        END IF;

    END IF;

END //

CREATE TRIGGER trg_prazo_cumprido
BEFORE UPDATE ON PRAZO_PROCESSUAL
FOR EACH ROW
BEGIN

    IF NEW.status = 'cumprido'
       AND OLD.status <> 'cumprido' THEN

        SET NEW.data_cumprimento = NOW();

    END IF;

END //

CREATE TRIGGER trg_validar_inicio_processo
BEFORE UPDATE ON PROCESSO
FOR EACH ROW
BEGIN

    DECLARE v_qtd_advogados INT;

    IF NEW.status = 'em_andamento'
       AND OLD.status <> 'em_andamento' THEN

        SELECT COUNT(*)
        INTO v_qtd_advogados
        FROM PROCESSO_ADVOGADO PA
        INNER JOIN USUARIO U
            ON PA.usuario_id = U.id_usuario
        WHERE PA.processo_id = NEW.id_processo
          AND U.perfil = 'advogado'
          AND U.ativo = TRUE;

        IF v_qtd_advogados = 0 OR OLD.status <> 'rascunho' THEN
            SET NEW.status = OLD.status;
        END IF;

    END IF;

END //

CREATE TRIGGER trg_unico_responsavel_principal
BEFORE INSERT ON PROCESSO_ADVOGADO
FOR EACH ROW
BEGIN

    DECLARE v_qtd_principal INT;

    IF NEW.responsavel_principal = TRUE THEN

        SELECT COUNT(*)
        INTO v_qtd_principal
        FROM PROCESSO_ADVOGADO
        WHERE processo_id = NEW.processo_id
          AND responsavel_principal = TRUE;

        IF v_qtd_principal > 0 THEN

            SET NEW.responsavel_principal = FALSE;

        END IF;

    END IF;

END //

DELIMITER ;
