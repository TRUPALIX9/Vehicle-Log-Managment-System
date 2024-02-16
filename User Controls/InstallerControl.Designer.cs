namespace VLMS
{
    partial class InstallerControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lbl_title = new Label();
            lbl_logs = new Label();
            lbl_step = new Label();
            progressBar = new Krypton.Toolkit.KryptonProgressBar();
            richTextBox = new Krypton.Toolkit.KryptonRichTextBox();
            folderBrowserDialog1 = new FolderBrowserDialog();
            btn_continue_finish = new Krypton.Toolkit.KryptonButton();
            panel_installtion = new Panel();
            lbl_installLocation = new Label();
            btn_fileDialog = new Button();
            textBox1 = new TextBox();
            panel_installtion.SuspendLayout();
            SuspendLayout();
            // 
            // lbl_title
            // 
            lbl_title.AutoSize = true;
            lbl_title.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_title.ForeColor = Color.Black;
            lbl_title.ImeMode = ImeMode.NoControl;
            lbl_title.Location = new Point(293, 12);
            lbl_title.Margin = new Padding(0);
            lbl_title.Name = "lbl_title";
            lbl_title.Size = new Size(309, 25);
            lbl_title.TabIndex = 15;
            lbl_title.Text = "Installing AIVID VLMS, Please wait...";
            // 
            // lbl_logs
            // 
            lbl_logs.AutoSize = true;
            lbl_logs.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_logs.ForeColor = Color.Black;
            lbl_logs.ImeMode = ImeMode.NoControl;
            lbl_logs.Location = new Point(35, 144);
            lbl_logs.Margin = new Padding(0);
            lbl_logs.Name = "lbl_logs";
            lbl_logs.Size = new Size(115, 25);
            lbl_logs.TabIndex = 16;
            lbl_logs.Text = "Logs Output";
            // 
            // lbl_step
            // 
            lbl_step.AutoSize = true;
            lbl_step.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_step.ForeColor = Color.Black;
            lbl_step.ImeMode = ImeMode.NoControl;
            lbl_step.Location = new Point(29, 46);
            lbl_step.Margin = new Padding(0);
            lbl_step.Name = "lbl_step";
            lbl_step.Size = new Size(24, 25);
            lbl_step.TabIndex = 17;
            lbl_step.Text = "...";
            // 
            // progressBar
            // 
            progressBar.Location = new Point(35, 74);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(831, 22);
            progressBar.StateCommon.Back.Color1 = Color.LimeGreen;
            progressBar.StateCommon.Back.Color2 = SystemColors.ButtonHighlight;
            progressBar.StateCommon.Content.ShortText.Color1 = Color.Black;
            progressBar.StateCommon.Content.ShortText.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point);
            progressBar.StateDisabled.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.OneNote;
            progressBar.StateNormal.Back.ColorStyle = Krypton.Toolkit.PaletteColorStyle.OneNote;
            progressBar.Step = 100;
            progressBar.TabIndex = 18;
            progressBar.Text = "0%";
            progressBar.UseValueAsText = true;
            progressBar.Values.Text = "0%";
            // 
            // richTextBox
            // 
            richTextBox.Location = new Point(35, 181);
            richTextBox.Name = "richTextBox";
            richTextBox.Size = new Size(831, 151);
            richTextBox.TabIndex = 19;
            richTextBox.Text = "";
            // 
            // btn_continue_finish
            // 
            btn_continue_finish.AutoSize = true;
            btn_continue_finish.ButtonStyle = Krypton.Toolkit.ButtonStyle.Custom1;
            btn_continue_finish.CornerRoundingRadius = 3F;
            btn_continue_finish.ImeMode = ImeMode.NoControl;
            btn_continue_finish.Location = new Point(776, 338);
            btn_continue_finish.Name = "btn_continue_finish";
            btn_continue_finish.OverrideDefault.Back.Color1 = SystemColors.Highlight;
            btn_continue_finish.OverrideDefault.Back.Color2 = SystemColors.Highlight;
            btn_continue_finish.PaletteMode = Krypton.Toolkit.PaletteMode.Office2010BlackDarkMode;
            btn_continue_finish.Size = new Size(90, 26);
            btn_continue_finish.StateCommon.Back.Color1 = SystemColors.Highlight;
            btn_continue_finish.StateCommon.Back.Color2 = SystemColors.Highlight;
            btn_continue_finish.StateCommon.Border.DrawBorders = Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom | Krypton.Toolkit.PaletteDrawBorders.Left | Krypton.Toolkit.PaletteDrawBorders.Right;
            btn_continue_finish.StateCommon.Border.Rounding = 3F;
            btn_continue_finish.StateCommon.Content.AdjacentGap = 1;
            btn_continue_finish.StateCommon.Content.DrawFocus = Krypton.Toolkit.InheritBool.False;
            btn_continue_finish.StateCommon.Content.ShortText.Color1 = SystemColors.ControlLightLight;
            btn_continue_finish.StateCommon.Content.ShortText.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btn_continue_finish.StateDisabled.Back.Color1 = Color.LightGray;
            btn_continue_finish.StateDisabled.Back.Color2 = Color.LightGray;
            btn_continue_finish.StateDisabled.Border.Color1 = Color.FromArgb(64, 64, 64);
            btn_continue_finish.StateDisabled.Border.Color2 = Color.FromArgb(64, 64, 64);
            btn_continue_finish.StateDisabled.Border.DrawBorders = Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom | Krypton.Toolkit.PaletteDrawBorders.Left | Krypton.Toolkit.PaletteDrawBorders.Right;
            btn_continue_finish.StateDisabled.Content.ShortText.Color1 = Color.DimGray;
            btn_continue_finish.StateDisabled.Content.ShortText.Color2 = Color.DimGray;
            btn_continue_finish.StateNormal.Back.Color1 = SystemColors.Highlight;
            btn_continue_finish.StateNormal.Back.Color2 = SystemColors.Highlight;
            btn_continue_finish.StatePressed.Back.Draw = Krypton.Toolkit.InheritBool.False;
            btn_continue_finish.StateTracking.Back.Draw = Krypton.Toolkit.InheritBool.True;
            btn_continue_finish.StateTracking.Border.Draw = Krypton.Toolkit.InheritBool.True;
            btn_continue_finish.StateTracking.Border.DrawBorders = Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom | Krypton.Toolkit.PaletteDrawBorders.Left | Krypton.Toolkit.PaletteDrawBorders.Right;
            btn_continue_finish.StateTracking.Content.Draw = Krypton.Toolkit.InheritBool.True;
            btn_continue_finish.StateTracking.Content.DrawFocus = Krypton.Toolkit.InheritBool.True;
            btn_continue_finish.TabIndex = 25;
            btn_continue_finish.Values.ImageTransparentColor = Color.Black;
            btn_continue_finish.Values.Text = "Continue";
            btn_continue_finish.Click += btn_next_Click;
            // 
            // panel_installtion
            // 
            panel_installtion.Controls.Add(lbl_installLocation);
            panel_installtion.Controls.Add(btn_fileDialog);
            panel_installtion.Controls.Add(textBox1);
            panel_installtion.Location = new Point(29, 102);
            panel_installtion.Name = "panel_installtion";
            panel_installtion.Size = new Size(850, 39);
            panel_installtion.TabIndex = 26;
            // 
            // lbl_installLocation
            // 
            lbl_installLocation.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            lbl_installLocation.AutoSize = true;
            lbl_installLocation.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            lbl_installLocation.ForeColor = Color.Black;
            lbl_installLocation.ImeMode = ImeMode.NoControl;
            lbl_installLocation.Location = new Point(7, 7);
            lbl_installLocation.Margin = new Padding(0);
            lbl_installLocation.Name = "lbl_installLocation";
            lbl_installLocation.Size = new Size(182, 25);
            lbl_installLocation.TabIndex = 27;
            lbl_installLocation.Text = "Installation Location";
            // 
            // btn_fileDialog
            // 
            btn_fileDialog.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            btn_fileDialog.Location = new Point(803, 6);
            btn_fileDialog.Margin = new Padding(0);
            btn_fileDialog.Name = "btn_fileDialog";
            btn_fileDialog.Size = new Size(41, 26);
            btn_fileDialog.TabIndex = 26;
            btn_fileDialog.Text = "...";
            btn_fileDialog.UseVisualStyleBackColor = true;
            btn_fileDialog.Click += button2_Click;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
            textBox1.Location = new Point(215, 7);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(585, 25);
            textBox1.TabIndex = 25;
            // 
            // UserControl2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel_installtion);
            Controls.Add(btn_continue_finish);
            Controls.Add(richTextBox);
            Controls.Add(progressBar);
            Controls.Add(lbl_step);
            Controls.Add(lbl_logs);
            Controls.Add(lbl_title);
            Name = "UserControl2";
            Size = new Size(900, 375);
            Load += UserControl2_Load;
            panel_installtion.ResumeLayout(false);
            panel_installtion.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbl_title;
        private Label lbl_logs;
        private Label lbl_step;
        private Krypton.Toolkit.KryptonProgressBar progressBar;
        private Krypton.Toolkit.KryptonRichTextBox richTextBox;
        private FolderBrowserDialog folderBrowserDialog1;
        private Krypton.Toolkit.KryptonButton btn_continue_finish;
        private Panel panel_installtion;
        private Label lbl_installLocation;
        private Button btn_fileDialog;
        private TextBox textBox1;
    }
}
