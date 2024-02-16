using System.Diagnostics;
using System.Reflection;
using System.Security.Principal;

namespace VLMS
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
            AdminRelauncher();
        }

        private static void AdminRelauncher()
        {
            if (!IsRunAsAdmin())
            {
                ProcessStartInfo proc = new ProcessStartInfo();
                proc.UseShellExecute = true;
                proc.WorkingDirectory = Environment.CurrentDirectory;
                proc.FileName = Assembly.GetEntryAssembly().Location.Replace(".dll", ".exe");
                proc.Verb = "runas";

                try
                {
                    Process.Start(proc);
                    Environment.Exit(1);
                }
                catch (Exception ex)
                {MessageBox.Show("This Application must be run as an administrator! \n\n","Information",MessageBoxButtons.OK,MessageBoxIcon.Exclamation );
                }
            }
            else
            {
                // We are running as administrator
                ApplicationConfiguration.Initialize();
                Application.Run(new Form1());

            }
        }
   
        private static bool IsRunAsAdmin()
        {
            try
            {
                WindowsIdentity id = WindowsIdentity.GetCurrent();
                WindowsPrincipal principal = new WindowsPrincipal(id);
                return principal.IsInRole(WindowsBuiltInRole.Administrator);
            }
            catch (Exception)
            {
                return false;
            }
        }

    }
}