using Microsoft.Win32;
using VLMS.Class;
using VLMS.User_Controls;

namespace VLMS
{
    public partial class Form1 : Form
    {
        #region Inisilizer and global variables and Form Load

        public Form1()
        {
            InitializeComponent();
            // The step controls are not created by the designer, so create them here
            // before wiring events; otherwise startup throws a NullReferenceException.
            eulaControl1 = new EULAControl();
            InstallerControl1 = new InstallerControl();
            UpdateContol = new UpdateControl();
            eulaControl1.NextButtonClicked += UserControl1_NextButtonClicked;
        }
        private bool mouseDown;
        private Point lastLocation;


        private void Form1_Load( object sender, EventArgs e )
        {

            if (SetIsInstalledSetting())
            {
                // Resolve the real install path first: the Update step reads config.json from it on load.
                UpdateManager.GetServiceStartupPath("MongoDB");
                ShowUserControl(UpdateContol);
            }
            else
            {
                ShowUserControl(eulaControl1);
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
            string[] serviceNamae = Global.serviceNames;
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