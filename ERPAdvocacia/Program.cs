using ERPAdvocacia.UI;
namespace ERPAdvocacia
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new FrmPrazos());



            while (true)
            {
                using (FrmLogin login = new FrmLogin())
                {
                    if (login.ShowDialog() != DialogResult.OK)
                    {
                        break;
                    }
                }

                FrmPrincipal principal = new FrmPrincipal();
                Application.Run(principal);

                if (!principal.FezLogout)
                {
                    break;
                }
            }
        }
    }
}
