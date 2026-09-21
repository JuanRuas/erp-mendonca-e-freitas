DROP DATABASE IF EXISTS erp_advocacia;
CREATE DATABASE erp_advocacia;
USE erp_advocacia;

CREATE TABLE USUARIO (
    id_usuario INT AUTO_INCREMENT PRIMARY KEY,
    nome VARCHAR(150) NOT NULL,
    email VARCHAR(150) NOT NULL UNIQUE,
    senha_hash VARCHAR(255) NOT NULL,
    perfil VARCHAR(20) NOT NULL CHECK (perfil IN ('advogado', 'secretario', 'estagiario')),
    oab VARCHAR(20) UNIQUE,
    ativo BOOLEAN NOT NULL DEFAULT TRUE
);

CREATE TABLE CLIENTE (
    id_cliente INT AUTO_INCREMENT PRIMARY KEY,
    nome_razao_social VARCHAR(150) NOT NULL,
    cpf_cnpj VARCHAR(18) NOT NULL UNIQUE,
    telefone VARCHAR(20),
    email VARCHAR(150),
    endereco VARCHAR(255),
    ativo BOOLEAN NOT NULL DEFAULT TRUE
);

CREATE TABLE PROCESSO (
    id_processo INT AUTO_INCREMENT PRIMARY KEY,
    cliente_id INT NOT NULL,
    numero_cnj VARCHAR(25) NOT NULL UNIQUE,
    vara VARCHAR(100),
    comarca VARCHAR(100),
    status VARCHAR(20) NOT NULL CHECK (status IN ('rascunho', 'em_andamento', 'suspenso', 'encerrado')),
    data_abertura DATE NOT NULL,
    valor_causa DECIMAL(15,2) CHECK (valor_causa IS NULL OR valor_causa >= 0),
    FOREIGN KEY (cliente_id) REFERENCES CLIENTE(id_cliente) ON DELETE RESTRICT
);

CREATE TABLE PROCESSO_ADVOGADO (
    processo_id INT NOT NULL,
    usuario_id INT NOT NULL,
    responsavel_principal BOOLEAN NOT NULL DEFAULT FALSE,
    PRIMARY KEY (processo_id, usuario_id),
    FOREIGN KEY (processo_id) REFERENCES PROCESSO(id_processo) ON DELETE CASCADE,
    FOREIGN KEY (usuario_id) REFERENCES USUARIO(id_usuario)
);

CREATE TABLE MOVIMENTACAO (
    id_movimentacao INT AUTO_INCREMENT PRIMARY KEY,
    processo_id INT NOT NULL,
    usuario_id INT NOT NULL,
    data_hora DATETIME NOT NULL,
    descricao TEXT NOT NULL,
    FOREIGN KEY (processo_id) REFERENCES PROCESSO(id_processo) ON DELETE CASCADE,
    FOREIGN KEY (usuario_id) REFERENCES USUARIO(id_usuario)
);

CREATE TABLE PRAZO_PROCESSUAL (
    id_prazo INT AUTO_INCREMENT PRIMARY KEY,
    processo_id INT NOT NULL,
    responsavel_id INT NOT NULL,
    titulo VARCHAR(150) NOT NULL,
    descricao TEXT,
    data_vencimento DATETIME NOT NULL,
    status VARCHAR(20) NOT NULL CHECK (status IN ('pendente', 'cumprido', 'cancelado')),
    data_cumprimento DATETIME,
    FOREIGN KEY (processo_id) REFERENCES PROCESSO(id_processo) ON DELETE CASCADE,
    FOREIGN KEY (responsavel_id) REFERENCES USUARIO(id_usuario)
);

CREATE TABLE CONTRATO_HONORARIOS (
    id_contrato INT AUTO_INCREMENT PRIMARY KEY,
    processo_id INT NOT NULL UNIQUE,
    tipo VARCHAR(10) NOT NULL CHECK (tipo IN ('fixo', 'mensal', 'exito')),
    valor_referencia DECIMAL(15,2) CHECK (valor_referencia IS NULL OR valor_referencia >= 0),
    percentual_exito DECIMAL(5,2) CHECK (tipo <> 'exito' OR (percentual_exito IS NOT NULL AND percentual_exito >= 20 AND percentual_exito <= 30)),
    data_assinatura DATE NOT NULL,
    status VARCHAR(20) NOT NULL CHECK (status IN ('ativo', 'encerrado', 'cancelado')),
    FOREIGN KEY (processo_id) REFERENCES PROCESSO(id_processo)
);

CREATE TABLE PAGAMENTO (
    id_pagamento INT AUTO_INCREMENT PRIMARY KEY,
    contrato_id INT NOT NULL,
    valor DECIMAL(15,2) NOT NULL CHECK (valor > 0),
    data_pagamento DATE NOT NULL,
    forma_pagamento VARCHAR(20) NOT NULL CHECK (forma_pagamento IN ('pix', 'dinheiro', 'cartao', 'transferencia', 'outro')),
    observacao VARCHAR(255),
    FOREIGN KEY (contrato_id) REFERENCES CONTRATO_HONORARIOS(id_contrato) ON DELETE RESTRICT
);




INSERT INTO USUARIO (id_usuario, nome, email, senha_hash, perfil, oab, ativo) VALUES
(1, 'Antonio Borges', 'antonio@advocacia.com', 'hash1', 'advogado', 'MG123456', TRUE),
(2, 'Denisson Guedes', 'denisson@advocacia.com', 'hash2', 'advogado', 'MG654321', TRUE),
(3, 'Felipe Martins', 'felipe@advocacia.com', 'hash3', 'secretario', NULL, TRUE),
(4, 'Gabriel Ambrosio', 'gabriel@advocacia.com', 'hash4', 'estagiario', NULL, TRUE);

INSERT INTO CLIENTE (id_cliente, nome_razao_social, cpf_cnpj, telefone, email, endereco, ativo) VALUES
(1, 'João da Silva', '12345678901', '(34) 99999-1111', 'joao@email.com', 'Rua A, 100, Frutal-MG', TRUE),
(2, 'Empresa XYZ Ltda', '12345678000199', '(34) 3333-2222', 'contato@xyz.com', 'Av. B, 200, Frutal-MG', TRUE);

INSERT INTO PROCESSO (id_processo, cliente_id, numero_cnj, vara, comarca, status, data_abertura, valor_causa) VALUES
(1, 1, '0001234-56.2026.8.13.0123', '1ª Vara Cível', 'Frutal', 'em_andamento', '2026-02-10', 50000.00),
(2, 2, '0009876-54.2026.8.13.0123', '2ª Vara Trabalhista', 'Frutal', 'rascunho', '2026-03-05', 120000.00);

INSERT INTO PROCESSO_ADVOGADO (processo_id, usuario_id, responsavel_principal) VALUES
(1, 1, TRUE),
(2, 2, TRUE);

INSERT INTO MOVIMENTACAO (id_movimentacao, processo_id, usuario_id, data_hora, descricao) VALUES
(1, 1, 1, '2026-02-11 10:00:00', 'Distribuição do processo.'),
(2, 1, 3, '2026-02-15 14:30:00', 'Juntada de documentos.'),
(3, 2, 2, '2026-03-06 09:15:00', 'Petição inicial elaborada.');

INSERT INTO PRAZO_PROCESSUAL (id_prazo, processo_id, responsavel_id, titulo, descricao, data_vencimento, status, data_cumprimento) VALUES
(1, 1, 1, 'Contestação', 'Prazo para contestar.', '2026-03-10 23:59:59', 'pendente', NULL),
(2, 2, 2, 'Audiência inicial', 'Comparecer à audiência.', '2026-04-01 08:30:00', 'pendente', NULL);

INSERT INTO CONTRATO_HONORARIOS (id_contrato, processo_id, tipo, valor_referencia, percentual_exito, data_assinatura, status) VALUES
(1, 1, 'fixo', 5000.00, NULL, '2026-02-10', 'ativo'),
(2, 2, 'exito', NULL, 25.00, '2026-03-05', 'ativo');

INSERT INTO PAGAMENTO (id_pagamento, contrato_id, valor, data_pagamento, forma_pagamento, observacao) VALUES
(1, 1, 2500.00, '2026-02-15', 'pix', 'Entrada de honorários.'),
(2, 1, 2500.00, '2026-03-15', 'transferencia', 'Segunda parcela.');


SELECT * FROM CLIENTE;