namespace Automaatne_andmebaasi_loomine
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

            // Andmebaas ja algandmed tehakse ainult üks kord, enne esimese akna avamist
            try
            {
                AlgAndmed.Loo();
            }
            catch (Exception ex)
            {
                MessageBox.Show(Keel.T("Andmebaasiga ühendamine ei õnnestunud:") + "\n" + ex.Message);
                return;
            }

            Application.Run(new LoginForm());
        }
    }
}