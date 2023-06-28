CREATE DATABASE IF NOT EXISTS projeto_final;

USE projeto_final;

CREATE TABLE IF NOT EXISTS produtos(
    cod INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    descricao varchar(255),
    cod_barras varchar(255),
    marca varchar(255),
    peso DECIMAL(11, 2),
    largura DECIMAL(11, 2),
    altura DECIMAL (11, 2),
    profundidade DECIMAL(11, 2),
    situacao boolean DEFAULT true,
    condicao boolean DEFAULT true,
    preco_venda DECIMAL(11, 2),
    quantidade_estoque DECIMAL(11, 2),
    dt_cadastro DATETIME DEFAULT NOW()
);

CREATE TABLE IF NOT EXISTS usuarios(
    cod INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    nome varchar(255),
    usuario varchar(20),
    senha varchar(255),
    situacao boolean NOT NULL DEFAULT true
);

CREATE TABLE IF NOT EXISTS clientes (
    cod INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    nome varchar(255),
    situacao boolean NOT NULL DEFAULT true,
    cpf varchar(20),
    rg varchar(20),
    genero varchar(255),
    dt_nascimento DATETIME,
    estado_civil varchar(255),
    profissao varchar(255),
    nacionalidade varchar(255),
    telefone varchar(20),
    celular varchar(20),
    whatsapp boolean,
    email varchar(255),
    endereco varchar(255),
    numero varchar(100),
    complemento varchar(255),
    bairro varchar(255),
    cidade varchar(255),
    uf varchar(2),
    cep varchar(20),
    observacoes varchar(255),
    dt_cadastro DATETIME DEFAULT NOW()
);


CREATE TABLE IF NOT EXISTS vendas(
    cod INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    dt_venda DATETIME,
    cod_cliente INT,
    cod_usuario INT,
    total_itens INT,
    sub_total DECIMAL(11, 2),
    desconto DECIMAL(11, 2),
    valor_total DECIMAL(11, 2),
    forma_pagamento VARCHAR(255),
    situacao VARCHAR(255),
    observacoes VARCHAR(255),
    FOREIGN KEY (cod_cliente) REFERENCES clientes(cod),
    FOREIGN KEY (cod_usuario) REFERENCES usuarios(cod)
);

CREATE TABLE IF NOT EXISTS itens_venda(
    cod INT NOT NULL PRIMARY KEY AUTO_INCREMENT,
    cod_venda INT,
    cod_produto INT,
    quantidade DECIMAL(11, 2),
    descricao varchar(255),
    vlr_unitario DECIMAL(11, 2),
    sub_total DECIMAL(11, 2),
    FOREIGN KEY (cod_venda) REFERENCES vendas(cod),
    FOREIGN KEY (cod_produto) REFERENCES produtos(cod)
);

