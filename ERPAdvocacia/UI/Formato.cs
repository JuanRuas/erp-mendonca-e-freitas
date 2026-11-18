using System;
using System.Text;

namespace ERPAdvocacia.UI
{
                                                             
    public static class Formato
    {
                                            
        public static string SomenteDigitos(string texto)
        {
            if (string.IsNullOrEmpty(texto))
            {
                return "";
            }

            StringBuilder sb = new StringBuilder();

            foreach (char c in texto)
            {
                if (char.IsDigit(c))
                {
                    sb.Append(c);
                }
            }

            return sb.ToString();
        }

                                                                                        
        public static string CpfCnpj(string texto)
        {
            string d = SomenteDigitos(texto);

            if (d.Length == 11)
            {
                return d.Substring(0, 3) + "." + d.Substring(3, 3) + "." + d.Substring(6, 3) + "-" + d.Substring(9, 2);
            }

            if (d.Length == 14)
            {
                return d.Substring(0, 2) + "." + d.Substring(2, 3) + "." + d.Substring(5, 3) + "/" + d.Substring(8, 4) + "-" + d.Substring(12, 2);
            }

            return texto;
        }

                                                                                                               
        public static string Telefone(string texto)
        {
            string d = SomenteDigitos(texto);

            if (d.Length == 11)
            {
                return "(" + d.Substring(0, 2) + ") " + d.Substring(2, 5) + "-" + d.Substring(7, 4);
            }

            if (d.Length == 10)
            {
                return "(" + d.Substring(0, 2) + ") " + d.Substring(2, 4) + "-" + d.Substring(6, 4);
            }

            return texto;
        }

                                                        
                                                                                        
                                                               
        public static bool CpfCnpjTemTamanhoValido(string texto)
        {
            int tamanho = SomenteDigitos(texto).Length;
            return tamanho == 11 || tamanho == 14;
        }

                                                                                         
        public static bool EmailValido(string texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
            {
                return false;
            }

            int arroba = texto.IndexOf('@');
            int ponto = texto.LastIndexOf('.');

            return arroba > 0 && ponto > arroba + 1 && ponto < texto.Length - 1 && !texto.Contains(" ");
        }
    }
}
