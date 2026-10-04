INSERT INTO PROCESSO (cliente_id,numero_cnj,vara,comarca,status,data_abertura,valor_causa) VALUES
(1,'0001111-22.2026.8.13.0123','3ª Vara Cível','Frutal','rascunho','2026-09-28',30000.00);

DELIMITER //

CREATE PROCEDURE sp_cumprir_prazo(
    IN p_id_prazo INT
)
BEGIN

    UPDATE PRAZO_PROCESSUAL
    SET status = 'cumprido'
    WHERE id_prazo = p_id_prazo;

END //

DELIMITER ;

call sp_cumprir_prazo(2);

DELIMITER //

CREATE TRIGGER trg_prazo_cumprido
BEFORE UPDATE ON PRAZO_PROCESSUAL
FOR EACH ROW
BEGIN

    IF NEW.status = 'cumprido'
       AND OLD.status <> 'cumprido' THEN

        SET NEW.data_cumprimento = NOW();

    END IF;

END //

DELIMITER ;

SELECT
    id_prazo,
    titulo,
    status,
    data_cumprimento
FROM PRAZO_PROCESSUAL
WHERE id_prazo = 2;

DROP PROCEDURE IF EXISTS sp_iniciar_processo;

DELIMITER //

CREATE PROCEDURE sp_iniciar_processo(
    IN p_id_processo INT
)
BEGIN

    DECLARE v_processo_existe INT;
    DECLARE v_qtd_advogados INT;

    SELECT COUNT(*)
    INTO v_processo_existe
    FROM PROCESSO
    WHERE id_processo = p_id_processo;

    SELECT COUNT(*)
    INTO v_qtd_advogados
    FROM PROCESSO_ADVOGADO PA
    INNER JOIN USUARIO U
        ON PA.usuario_id = U.id_usuario
    WHERE PA.processo_id = p_id_processo
      AND U.perfil = 'advogado'
      AND U.ativo = TRUE;

    IF v_processo_existe = 0 THEN

        SELECT 'Processo nao encontrado.' AS mensagem;

    ELSEIF v_qtd_advogados = 0 THEN

        SELECT 'O processo nao possui advogado ativo vinculado.' AS mensagem;

    ELSE

        UPDATE PROCESSO
        SET status = 'em_andamento'
        WHERE id_processo = p_id_processo;

        SELECT 'Processo iniciado com sucesso.' AS mensagem;

    END IF;

END //

DELIMITER ;

CALL sp_iniciar_processo(2);
    
SELECT
    id_processo,
    numero_cnj,
    status
FROM PROCESSO
WHERE id_processo = 2;

CALL sp_iniciar_processo(150000);

CALL sp_iniciar_processo(3);

DROP PROCEDURE IF EXISTS sp_total_recebido_contrato;

DELIMITER //

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

DELIMITER ;

CALL sp_total_recebido_contrato(1,@total);

CALL sp_total_recebido_contrato(2,@total);

CALL sp_total_recebido_contrato(100,@total);

select @total;

DROP TRIGGER IF EXISTS trg_unico_responsavel_principal;

DELIMITER //

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