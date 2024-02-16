using VLMS.User_Controls;

namespace VLMS
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            titleBarPanel = new Panel();
            button1 = new Button();
            lbl_title = new Label();
            btn_close = new Button();
            bottomPanel = new Panel();
            versionLabel = new Label();
            copyrightLabel = new Label();
            kryptonCustomPaletteBase1 = new Krypton.Toolkit.KryptonCustomPaletteBase(components);
            MainPanel = new Panel();
            titleBarPanel.SuspendLayout();
            bottomPanel.SuspendLayout();
            SuspendLayout();
            // 
            // titleBarPanel
            // 
            titleBarPanel.BackColor = Color.FromArgb(0, 146, 203);
            titleBarPanel.BorderStyle = BorderStyle.FixedSingle;
            titleBarPanel.Controls.Add(button1);
            titleBarPanel.Controls.Add(lbl_title);
            titleBarPanel.Controls.Add(btn_close);
            titleBarPanel.Cursor = Cursors.SizeAll;
            titleBarPanel.Dock = DockStyle.Top;
            titleBarPanel.Location = new Point(0, 0);
            titleBarPanel.Name = "titleBarPanel";
            titleBarPanel.Size = new Size(900, 28);
            titleBarPanel.TabIndex = 7;
            titleBarPanel.MouseDown += titleBarPanel_MouseDown;
            titleBarPanel.MouseMove += titleBarPanel_MouseMove;
            titleBarPanel.MouseUp += titleBarPanel_MouseUp;
            // 
            // button1
            // 
            button1.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            button1.BackColor = Color.FromArgb(0, 146, 203);
            button1.BackgroundImageLayout = ImageLayout.None;
            button1.Cursor = Cursors.Hand;
            button1.Dock = DockStyle.Right;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            button1.ForeColor = Color.FromArgb(0, 146, 203);
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.ImeMode = ImeMode.NoControl;
            button1.Location = new Point(830, 0);
            button1.Name = "button1";
            button1.Padding = new Padding(10);
            button1.Size = new Size(37, 26);
            button1.TabIndex = 4;
            button1.Text = "-";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // lbl_title
            // 
            lbl_title.Dock = DockStyle.Left;
            lbl_title.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Bold, GraphicsUnit.Point);
            lbl_title.ForeColor = Color.Honeydew;
            lbl_title.Image = (Image)resources.GetObject("lbl_title.Image");
            lbl_title.ImageAlign = ContentAlignment.TopLeft;
            lbl_title.ImeMode = ImeMode.NoControl;
            lbl_title.LiveSetting = System.Windows.Forms.Automation.AutomationLiveSetting.Polite;
            lbl_title.Location = new Point(0, 0);
            lbl_title.Margin = new Padding(0);
            lbl_title.Name = "lbl_title";
            lbl_title.RightToLeft = RightToLeft.No;
            lbl_title.Size = new Size(296, 26);
            lbl_title.TabIndex = 3;
            lbl_title.Text = "AIVID Vehicle Log Managment System ";
            lbl_title.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btn_close
            // 
            btn_close.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            btn_close.BackColor = Color.FromArgb(0, 146, 203);
            btn_close.BackgroundImageLayout = ImageLayout.None;
            btn_close.Cursor = Cursors.Hand;
            btn_close.Dock = DockStyle.Right;
            btn_close.FlatStyle = FlatStyle.Flat;
            btn_close.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btn_close.ForeColor = Color.FromArgb(0, 146, 203);
            btn_close.Image = (Image)resources.GetObject("btn_close.Image");
            btn_close.ImeMode = ImeMode.NoControl;
            btn_close.Location = new Point(867, 0);
            btn_close.Name = "btn_close";
            btn_close.Padding = new Padding(10);
            btn_close.Size = new Size(31, 26);
            btn_close.TabIndex = 0;
            btn_close.UseVisualStyleBackColor = false;
            btn_close.Click += btn_close_Click;
            // 
            // bottomPanel
            // 
            bottomPanel.BorderStyle = BorderStyle.FixedSingle;
            bottomPanel.Controls.Add(versionLabel);
            bottomPanel.Controls.Add(copyrightLabel);
            bottomPanel.Dock = DockStyle.Bottom;
            bottomPanel.Location = new Point(0, 410);
            bottomPanel.Name = "bottomPanel";
            bottomPanel.Size = new Size(900, 26);
            bottomPanel.TabIndex = 8;
            // 
            // versionLabel
            // 
            versionLabel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            versionLabel.AutoSize = true;
            versionLabel.BackColor = Color.Transparent;
            versionLabel.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Regular, GraphicsUnit.Point);
            versionLabel.ForeColor = Color.Black;
            versionLabel.ImageAlign = ContentAlignment.MiddleLeft;
            versionLabel.ImeMode = ImeMode.NoControl;
            versionLabel.LiveSetting = System.Windows.Forms.Automation.AutomationLiveSetting.Polite;
            versionLabel.Location = new Point(732, 2);
            versionLabel.Margin = new Padding(0);
            versionLabel.Name = "versionLabel";
            versionLabel.RightToLeft = RightToLeft.No;
            versionLabel.Size = new Size(168, 21);
            versionLabel.TabIndex = 4;
            versionLabel.Text = "Version : V1R1 (1.0.18)";
            versionLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // copyrightLabel
            // 
            copyrightLabel.AutoSize = true;
            copyrightLabel.BackColor = Color.Transparent;
            copyrightLabel.Dock = DockStyle.Left;
            copyrightLabel.Font = new Font("Segoe UI Emoji", 12F, FontStyle.Regular, GraphicsUnit.Point);
            copyrightLabel.ForeColor = Color.Black;
            copyrightLabel.ImageAlign = ContentAlignment.MiddleLeft;
            copyrightLabel.ImeMode = ImeMode.NoControl;
            copyrightLabel.LiveSetting = System.Windows.Forms.Automation.AutomationLiveSetting.Polite;
            copyrightLabel.Location = new Point(0, 0);
            copyrightLabel.Margin = new Padding(0);
            copyrightLabel.Name = "copyrightLabel";
            copyrightLabel.RightToLeft = RightToLeft.No;
            copyrightLabel.Size = new Size(341, 21);
            copyrightLabel.TabIndex = 3;
            copyrightLabel.Text = "© 2023 - All Rights Reserved AIVIDTechVision.";
            copyrightLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // kryptonCustomPaletteBase1
            // 
            kryptonCustomPaletteBase1.BaseFont = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            kryptonCustomPaletteBase1.BaseFontSize = 9F;
            kryptonCustomPaletteBase1.BasePaletteType = Krypton.Toolkit.BasePaletteType.Custom;
            kryptonCustomPaletteBase1.ButtonStyles.ButtonCustom1.OverrideDefault.Back.Color1 = Color.Black;
            kryptonCustomPaletteBase1.ButtonStyles.ButtonCustom1.OverrideDefault.Back.Color2 = Color.Lime;
            kryptonCustomPaletteBase1.ButtonStyles.ButtonCustom1.OverrideDefault.Back.ColorAlign = Krypton.Toolkit.PaletteRectangleAlign.Control;
            kryptonCustomPaletteBase1.ButtonStyles.ButtonCustom1.OverrideFocus.Back.Color1 = Color.FromArgb(192, 192, 255);
            kryptonCustomPaletteBase1.ButtonStyles.ButtonCustom1.OverrideFocus.Back.Color2 = Color.FromArgb(128, 255, 128);
            kryptonCustomPaletteBase1.ButtonStyles.ButtonCustom1.StateCheckedNormal.Back.Color1 = Color.FromArgb(128, 255, 128);
            kryptonCustomPaletteBase1.ButtonStyles.ButtonCustom1.StateCommon.Back.Color1 = Color.Lime;
            kryptonCustomPaletteBase1.ButtonStyles.ButtonCustom1.StateCommon.Back.Color2 = Color.FromArgb(128, 128, 255);
            kryptonCustomPaletteBase1.ButtonStyles.ButtonCustom1.StateCommon.Back.Draw = Krypton.Toolkit.InheritBool.True;
            kryptonCustomPaletteBase1.ButtonStyles.ButtonCustom1.StateNormal.Back.Color1 = Color.FromArgb(192, 255, 192);
            kryptonCustomPaletteBase1.ButtonStyles.ButtonCustom1.StateNormal.Back.Color2 = Color.FromArgb(0, 192, 192);
            kryptonCustomPaletteBase1.ThemeName = "";
            kryptonCustomPaletteBase1.UseKryptonFileDialogs = true;
            // 
            // MainPanel
            // 
            MainPanel.BorderStyle = BorderStyle.FixedSingle;
            MainPanel.Dock = DockStyle.Fill;
            MainPanel.Location = new Point(0, 28);
            MainPanel.Name = "MainPanel";
            MainPanel.Size = new Size(900, 382);
            MainPanel.TabIndex = 11;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BackColor = Color.White;
            ClientSize = new Size(900, 436);
            Controls.Add(MainPanel);
            Controls.Add(titleBarPanel);
            Controls.Add(bottomPanel);
            ForeColor = SystemColors.ScrollBar;
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Form1_Load;
            titleBarPanel.ResumeLayout(false);
            bottomPanel.ResumeLayout(false);
            bottomPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Panel titleBarPanel;
        private Label lbl_title;
        private Button btn_close;
        private Panel bottomPanel;
        private Label versionLabel;
        private Label copyrightLabel;
        private Krypton.Toolkit.KryptonCustomPaletteBase kryptonCustomPaletteBase1;
        private Panel MainPanel;
        private Button button1;
        private EULAControl eulaControl1;
        private InstallerControl InstallerControl1;
        private UpdateControl UpdateContol;

    }
}