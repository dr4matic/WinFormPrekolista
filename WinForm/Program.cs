using WinForm.Forms;

namespace WinForm
{
    internal static class Program
    {
        private static ApplicationContext _context;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            _context = new ApplicationContext();
            _context.MainForm = new Login();
            Application.Run(_context);

            
        }
    }
}