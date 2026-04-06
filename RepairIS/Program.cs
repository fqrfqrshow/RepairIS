using System;
using System.Windows.Forms;
using RepairIS.Forms;

namespace RepairIS
{
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());  // Запускаем форму авторизации
        }
    }
}