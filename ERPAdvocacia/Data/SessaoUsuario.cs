using System;

namespace ERPAdvocacia.Data
{
                                                              
                                                                   
                                                                       
    public static class SessaoUsuario
    {
        public static int IdUsuario { get; private set; }
        public static string Nome { get; set; } = "";
        public static string Perfil { get; private set; } = "";

        public static bool EstaLogado
        {
            get { return IdUsuario > 0; }
        }

        public static void Iniciar(int idUsuario, string nome, string perfil)
        {
            IdUsuario = idUsuario;
            Nome = nome;
            Perfil = perfil;
        }

        public static void Encerrar()
        {
            IdUsuario = 0;
            Nome = "";
            Perfil = "";
        }
    }
}
