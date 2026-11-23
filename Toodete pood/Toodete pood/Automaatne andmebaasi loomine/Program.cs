using Microsoft.Data.SqlClient;

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
            catch (SqlException ex) when (ex.Number == 1801)
            {
                // Viga 1801 "Database 'Tooded_DB' already exists": LocalDB-s on andmebaas kirjas,
                // aga seda ei saa avada (nt .mdf fail on kustutatud). Siis aitab ainult uue andmebaasi tegemine.
                var vastus = MessageBox.Show(
                    Keel.T("Andmebaas Tooded_DB on katki ja seda ei saa avada.\nKas kustutada see ja teha uus? (vanad andmed kaovad)"),
                    Keel.T("Andmebaas"), MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (vastus != DialogResult.Yes) return;

                try
                {
                    AlgAndmed.KustutaAndmebaas();
                    AlgAndmed.Loo();
                }
                catch (Exception ex2)
                {
                    MessageBox.Show(Keel.T("Andmebaasiga ühendamine ei õnnestunud:") + "\n" + ex2.Message);
                    return;
                }
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