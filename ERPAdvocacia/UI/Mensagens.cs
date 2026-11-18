using System;
using System.Windows.Forms;
using MySqlConnector;

namespace ERPAdvocacia.UI
{
                                                                             
                                                                                 
                                             
    public static class Mensagens
    {
        public static string Traduzir(Exception ex)
        {
            if (ex is MySqlException)
            {
                MySqlException erro = (MySqlException)ex;
                int codigo = (int)erro.ErrorCode;
                string texto = erro.Message;

                                                          
                if (codigo == 1062)
                {
                    if (texto.Contains("cpf_cnpj")) return "Já existe um cliente cadastrado com esse CPF/CNPJ.";
                    if (texto.Contains("numero_cnj")) return "Já existe um processo cadastrado com esse número CNJ.";
                    if (texto.Contains("email")) return "Já existe um usuário cadastrado com esse e-mail.";
                    if (texto.Contains("oab")) return "Já existe um usuário cadastrado com essa OAB.";
                    if (texto.Contains("PRIMARY")) return "Esse advogado já está vinculado a este processo.";
                    if (texto.Contains("processo_id")) return "Esse processo já possui um contrato de honorários.";
                    return "Já existe um registro com esses dados.";
                }

                                                  
                if (codigo == 1451) return "Este registro está sendo usado em outro cadastro e não pode ser alterado/removido.";
                if (codigo == 1452) return "Um dos itens selecionados não existe mais. Atualize a tela e tente novamente.";

                                                 
                if (codigo == 1048) return "Existe um campo obrigatório sem preenchimento.";

                                                                    
                if (codigo == 4025 || codigo == 3819) return "Algum valor informado não é permitido pelas regras do sistema. Confira os campos.";

                                                                                                                     
                if (codigo == 1042 || codigo == 2002 || codigo == 2003)
                    return "Não foi possível conectar ao banco de dados. Verifique se o MySQL está em execução.";
                if (codigo == 1045)
                    return "O MySQL recusou o acesso. Confira usuário e senha em Data/ConexaoBD.cs.";
                if (codigo == 1049)
                    return "O banco erp_advocacia não foi encontrado. Execute o script SQL primeiro.";
            }

            return "Ocorreu um erro: " + ex.Message;
        }

                                                                                    
        public static void Erro(string operacao, Exception ex)
        {
            MessageBox.Show(
                "Não foi possível " + operacao + ".\n\n" + Traduzir(ex),
                "Erro",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        public static void Aviso(string texto)
        {
            MessageBox.Show(texto, "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void Sucesso(string texto)
        {
            MessageBox.Show(texto, "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static bool Confirmar(string pergunta)
        {
            return MessageBox.Show(pergunta, "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes;
        }
    }
}
