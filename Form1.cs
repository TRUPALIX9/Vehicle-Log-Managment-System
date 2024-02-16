using Microsoft.Win32;
using VLMS.Class;

namespace VLMS
{
    public partial class Form1 : Form
    {
        #region Inisilizer and global variables and Form Load

        public Form1()
        {
            InitializeComponent();
            eulaControl1.NextButtonClicked += UserControl1_NextButtonClicked;
        }
        private bool mouseDown;
        private Point lastLocation;


        private void Form1_Load( object sender, EventArgs e )
        {

            if (SetIsInstalledSetting())
            {
                ShowUserControl(UpdateContol);
                string basePath = UpdateManager.GetServiceStartupPath("MongoDB");
            }
        }
        #endregion

        #region Event Handlers

        private void UserControl1_NextButtonClicked( object sender, EventArgs e )
        {
            ShowUserControl(InstallerControl1);
        }

        private void button1_Click( object sender, EventArgs e )
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void titleBarPanel_MouseDown( object sender, MouseEventArgs e )
        {
            mouseDown = true;
            lastLocation = e.Location;
        }

        private void titleBarPanel_MouseMove( object sender, MouseEventArgs e )
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void titleBarPanel_MouseUp( object sender, MouseEventArgs e )
        {
            mouseDown = false;
        }

        private void btn_close_Click( object sender, EventArgs e )
        {
            Application.Exit();
        }
        #endregion

        #region Helpers 
        private void ShowUserControl( UserControl control )
        {
            MainPanel.Controls.Clear();
            MainPanel.Controls.Add(control);
            control.Dock = DockStyle.Fill;
        }
        public static bool SetIsInstalledSetting()
        {
            string[] serviceNamae = { "aividVLMSBot", "aividPortal", "MongoDB", "mosquitto" };
            bool areAllServicesPresent = ServiceManager.AreAllServicesPresent(serviceNamae);

            if (areAllServicesPresent)
            {
                Properties.Settings.Default.isInstalled = true;
                Properties.Settings.Default.Save();
                return true;
            }
            else
            {
                Properties.Settings.Default.isInstalled = false;
                Properties.Settings.Default.Save();
                return false;
            }
        }


        #endregion
    }
}