using Microsoft.EntityFrameworkCore;
using Storage;
using Storage.Entitys;
using WinForm.Engine;
using WinForm.Forms;

namespace WinForm
{
    internal static class Program
    {
        private static UIApplicationContext _context;
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            TestDataBase();
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            _context = new UIApplicationContext();
            _context.MainForm = new MainForm(_context);
            Application.Run(_context);

            
        }

        private static void TestDataBase()
        {
            var options = new DbContextOptionsBuilder<GameDataBaseContext>();
            options.UseSqlite("Data Source=hello.db");

            var dbContext = new GameDataBaseContext(options.Options);

            dbContext.Database.EnsureCreated(); 
            dbContext.Database.Migrate();

            /*for(var i = 0; i< 10; i++)
            {
                dbContext.Set<UserInfo>().Add(new UserInfo($"User {i}"));
            }

            dbContext.SaveChanges();*/

            var user = dbContext.Set<UserInfo>()
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == 5);

            user = user with { score = 1000 };
            dbContext.Set<UserInfo>().Update(user);
            dbContext.SaveChanges();

            var users = dbContext.Set<UserInfo>()
                .ToList();
            if (users != null)
            {

            }
        }
    }
}