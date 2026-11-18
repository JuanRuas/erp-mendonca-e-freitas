using System;
using System.Collections.Generic;

namespace ERPAdvocacia.Data
{
                                                        
                                                                                             
                                 
    public enum Acao
    {
        CadastrarCliente,
        AlterarCliente,
        DesativarCliente,

        CadastrarProcesso,
        AlterarProcesso,
        VincularAdvogado,
        IniciarProcesso,

        CadastrarPrazo,
        AlterarPrazo,
        CumprirPrazo,

        RegistrarMovimentacao,

        ConsultarFinanceiro,                                                       
        GerenciarHonorarios,                                
        RegistrarPagamento,

        GerenciarUsuarios,
        ConsultarAuditoria
    }

                                                                                                
                                                            
    public static class Permissoes
    {
        private static readonly Dictionary<string, Acao[]> matriz = new Dictionary<string, Acao[]>
        {
            {
                "advogado", new Acao[]
                {
                    Acao.CadastrarCliente, Acao.AlterarCliente, Acao.DesativarCliente,
                    Acao.CadastrarProcesso, Acao.AlterarProcesso, Acao.VincularAdvogado, Acao.IniciarProcesso,
                    Acao.CadastrarPrazo, Acao.AlterarPrazo, Acao.CumprirPrazo,
                    Acao.RegistrarMovimentacao,
                    Acao.ConsultarFinanceiro, Acao.GerenciarHonorarios, Acao.RegistrarPagamento,
                    Acao.GerenciarUsuarios, Acao.ConsultarAuditoria
                }
            },
            {
                "secretario", new Acao[]
                {
                    Acao.CadastrarCliente, Acao.AlterarCliente, Acao.DesativarCliente,
                    Acao.CadastrarProcesso, Acao.AlterarProcesso,
                    Acao.CadastrarPrazo, Acao.AlterarPrazo,
                    Acao.RegistrarMovimentacao,
                    Acao.ConsultarFinanceiro, Acao.RegistrarPagamento
                }
            },
            {
                "estagiario", new Acao[]
                {
                    Acao.RegistrarMovimentacao
                }
            }
        };

                                                                     
        public static bool Pode(Acao acao)
        {
            return Pode(SessaoUsuario.Perfil, acao);
        }

                                                                                          
        public static bool Pode(string perfil, Acao acao)
        {
            if (string.IsNullOrEmpty(perfil) || !matriz.ContainsKey(perfil))
            {
                return false;
            }

            return Array.IndexOf(matriz[perfil], acao) >= 0;
        }
    }
}
