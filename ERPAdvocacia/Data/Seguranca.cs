using System;
using System.Security.Cryptography;
using System.Text;

namespace ERPAdvocacia.Data
{
    public static class Seguranca
    {
                                                                            
                                                                                  
                                                                     
          
                                                                              
                                                                 
        public static string GerarHash(string senha)
        {
            byte[] bytes = SHA256.HashData(Encoding.UTF8.GetBytes(senha));
            return Convert.ToHexString(bytes).ToLowerInvariant();
        }
    }
}
