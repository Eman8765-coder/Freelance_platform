using Freelance_Platform.Forms;
using Freelance_Platform.Database;

namespace Freelance_Platform
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            DatabaseInitializer.Initialize();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Application.Run(new LoginForm());
        }
    }
}