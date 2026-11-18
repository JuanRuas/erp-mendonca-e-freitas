# ERP Mendonça e Freitas

Sistema acadêmico para gestão de escritório de advocacia, desenvolvido em C# com Windows Forms e MySQL.

## Requisitos

- Windows, .NET 8 com Windows Forms e Visual Studio 2022 com suporte a desktop .NET.
- MySQL ou MariaDB com InnoDB e suporte às constraints, procedures e triggers dos scripts.
- NuGet MySqlConnector 2.6.2, declarado no projeto.
- Cliente SQL que aceite DELIMITER, como MySQL Workbench ou o cliente MySQL.

## Instalação em banco novo

**O primeiro script executa DROP DATABASE erp_advocacia e apaga todo banco existente com esse nome.** Use apenas em ambiente onde seja seguro recriá-lo; não execute no banco que contém dados a preservar.

1. Execute Scripts/script_erp_advocacia.sql para criar banco, tabelas e dados de demonstração.
2. Execute Scripts/script_erp_procedure-trigger.sql na mesma instância para criar as procedures e triggers.
3. Abra ERPAdvocacia/ERPAdvocacia.sln no Visual Studio. A solução erp-mendonca-e-freitas.slnx na raiz é o projeto histórico.
4. Ajuste a conexão em ERPAdvocacia/Data/ConexaoBD.cs conforme o MySQL local.
5. Restaure os pacotes NuGet, compile e execute com F5.

Para um banco existente, faça backup e revise separadamente as diferenças de esquema e objetos antes de atualizá-lo. O primeiro script não serve para atualização preservando dados. O segundo substitui as três procedures e as três triggers existentes com os mesmos nomes; revise dependências antes de aplicá-lo.

## Usuários de demonstração

Senha: 123456. O usuário inativo não consegue entrar.

| E-mail | Perfil |
|---|---|
| antonio@advocacia.com | advogado |
| denisson@advocacia.com | advogado |
| felipe@advocacia.com | secretario |
| gabriel@advocacia.com | estagiario |
| inativo@advocacia.com | estagiario inativo |

O advogado gerencia usuários, contratos, vínculos, início de processos e cumprimento de prazos. O secretário realiza cadastros operacionais e registra pagamentos. O estagiário registra movimentações. As permissões completas estão em ERPAdvocacia/Data/Permissoes.cs.

## Limitações

A senha usa SHA-256 sem salt e as contas de demonstração têm senha conhecida; são destinadas apenas a ambiente acadêmico isolado. A conexão padrão usa root local com senha vazia e deve ser ajustada ao ambiente. CPF/CNPJ é validado apenas pelo tamanho. A instalação limpa e os fluxos de integração devem ser testados no ambiente de destino. Evidências anteriores estão em Evidencias/.