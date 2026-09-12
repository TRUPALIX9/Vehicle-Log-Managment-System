using System.Windows.Forms;

namespace VLMS.User_Controls
{
    partial class UpdateControl
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
            btn_Update = new Krypton.Toolkit.KryptonButton();
            btn_uninstall = new Krypton.Toolkit.KryptonButton();
            kryptonRichTextBox1 = new Krypton.Toolkit.KryptonRichTextBox();
            progressBar = new ProgressBar();
            lbl_processTitle = new Label();
            comboBox1 = new ComboBox();
            SuspendLayout();
            // 
            // btn_Update
            // 
            btn_Update.AutoSize = true;
            btn_Update.ButtonStyle = Krypton.Toolkit.ButtonStyle.Custom1;
            btn_Update.CornerRoundingRadius = 3F;
            btn_Update.Enabled = false;
            btn_Update.ImeMode = ImeMode.NoControl;
            btn_Update.Location = new Point(738, 27);
            btn_Update.Name = "btn_Update";
            btn_Update.OverrideDefault.Back.Color1 = SystemColors.Highlight;
            btn_Update.OverrideDefault.Back.Color2 = SystemColors.Highlight;
            btn_Update.OverrideFocus.Back.Color1 = SystemColors.MenuHighlight;
            btn_Update.OverrideFocus.Back.Color2 = SystemColors.MenuHighlight;
            btn_Update.OverrideFocus.Border.Color1 = Color.Gray;
            btn_Update.OverrideFocus.Border.DrawBorders = Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom | Krypton.Toolkit.PaletteDrawBorders.Left | Krypton.Toolkit.PaletteDrawBorders.Right;
            btn_Update.OverrideFocus.Content.ShortText.Color1 = SystemColors.ControlLightLight;
            btn_Update.PaletteMode = Krypton.Toolkit.PaletteMode.Office2010BlackDarkMode;
            btn_Update.Size = new Size(90, 26);
            btn_Update.StateCommon.Back.Color1 = SystemColors.Highlight;
            btn_Update.StateCommon.Back.Color2 = SystemColors.Highlight;
            btn_Update.StateCommon.Border.DrawBorders = Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom | Krypton.Toolkit.PaletteDrawBorders.Left | Krypton.Toolkit.PaletteDrawBorders.Right;
            btn_Update.StateCommon.Border.Rounding = 3F;
            btn_Update.StateCommon.Content.AdjacentGap = 1;
            btn_Update.StateCommon.Content.DrawFocus = Krypton.Toolkit.InheritBool.False;
            btn_Update.StateCommon.Content.ShortText.Color1 = SystemColors.ControlLightLight;
            btn_Update.StateCommon.Content.ShortText.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btn_Update.StateDisabled.Back.Color1 = Color.LightGray;
            btn_Update.StateDisabled.Back.Color2 = Color.LightGray;
            btn_Update.StateDisabled.Border.Color1 = Color.FromArgb(64, 64, 64);
            btn_Update.StateDisabled.Border.Color2 = Color.FromArgb(64, 64, 64);
            btn_Update.StateDisabled.Border.DrawBorders = Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom | Krypton.Toolkit.PaletteDrawBorders.Left | Krypton.Toolkit.PaletteDrawBorders.Right;
            btn_Update.StateDisabled.Content.ShortText.Color1 = Color.DimGray;
            btn_Update.StateDisabled.Content.ShortText.Color2 = Color.DimGray;
            btn_Update.StateNormal.Back.Color1 = SystemColors.Highlight;
            btn_Update.StateNormal.Back.Color2 = SystemColors.Highlight;
            btn_Update.StatePressed.Back.Color1 = Color.Blue;
            btn_Update.StatePressed.Back.Draw = Krypton.Toolkit.InheritBool.True;
            btn_Update.StatePressed.Content.ShortText.Color1 = Color.White;
            btn_Update.StateTracking.Back.Draw = Krypton.Toolkit.InheritBool.True;
            btn_Update.StateTracking.Border.Draw = Krypton.Toolkit.InheritBool.True;
            btn_Update.StateTracking.Border.DrawBorders = Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom | Krypton.Toolkit.PaletteDrawBorders.Left | Krypton.Toolkit.PaletteDrawBorders.Right;
            btn_Update.StateTracking.Content.Draw = Krypton.Toolkit.InheritBool.True;
            btn_Update.StateTracking.Content.DrawFocus = Krypton.Toolkit.InheritBool.True;
            btn_Update.TabIndex = 18;
            btn_Update.Values.ImageTransparentColor = Color.Black;
            btn_Update.Values.Text = "Update";
            btn_Update.Click += btn_Update_Click;
            // 
            // btn_uninstall
            // 
            btn_uninstall.AutoSize = true;
            btn_uninstall.ButtonStyle = Krypton.Toolkit.ButtonStyle.Custom1;
            btn_uninstall.CornerRoundingRadius = 3F;
            btn_uninstall.ImeMode = ImeMode.NoControl;
            btn_uninstall.Location = new Point(738, 290);
            btn_uninstall.Name = "btn_uninstall";
            btn_uninstall.OverrideDefault.Back.Color1 = SystemColors.Highlight;
            btn_uninstall.OverrideDefault.Back.Color2 = SystemColors.Highlight;
            btn_uninstall.OverrideFocus.Back.Color1 = SystemColors.MenuHighlight;
            btn_uninstall.OverrideFocus.Back.Color2 = SystemColors.MenuHighlight;
            btn_uninstall.OverrideFocus.Border.Color1 = Color.Gray;
            btn_uninstall.OverrideFocus.Border.DrawBorders = Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom | Krypton.Toolkit.PaletteDrawBorders.Left | Krypton.Toolkit.PaletteDrawBorders.Right;
            btn_uninstall.OverrideFocus.Content.ShortText.Color1 = SystemColors.ControlLightLight;
            btn_uninstall.PaletteMode = Krypton.Toolkit.PaletteMode.Office2010BlackDarkMode;
            btn_uninstall.Size = new Size(90, 26);
            btn_uninstall.StateCommon.Back.Color1 = Color.IndianRed;
            btn_uninstall.StateCommon.Back.Color2 = Color.IndianRed;
            btn_uninstall.StateCommon.Border.DrawBorders = Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom | Krypton.Toolkit.PaletteDrawBorders.Left | Krypton.Toolkit.PaletteDrawBorders.Right;
            btn_uninstall.StateCommon.Border.Rounding = 3F;
            btn_uninstall.StateCommon.Content.AdjacentGap = 1;
            btn_uninstall.StateCommon.Content.DrawFocus = Krypton.Toolkit.InheritBool.False;
            btn_uninstall.StateCommon.Content.ShortText.Color1 = SystemColors.ControlLightLight;
            btn_uninstall.StateCommon.Content.ShortText.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btn_uninstall.StateDisabled.Back.Color1 = Color.LightGray;
            btn_uninstall.StateDisabled.Back.Color2 = Color.LightGray;
            btn_uninstall.StateDisabled.Border.Color1 = Color.FromArgb(64, 64, 64);
            btn_uninstall.StateDisabled.Border.Color2 = Color.FromArgb(64, 64, 64);
            btn_uninstall.StateDisabled.Border.DrawBorders = Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom | Krypton.Toolkit.PaletteDrawBorders.Left | Krypton.Toolkit.PaletteDrawBorders.Right;
            btn_uninstall.StateDisabled.Content.ShortText.Color1 = Color.DimGray;
            btn_uninstall.StateDisabled.Content.ShortText.Color2 = Color.DimGray;
            btn_uninstall.StateNormal.Back.Color1 = Color.Firebrick;
            btn_uninstall.StateNormal.Back.Color2 = Color.Firebrick;
            btn_uninstall.StatePressed.Back.Color1 = Color.Blue;
            btn_uninstall.StatePressed.Back.Draw = Krypton.Toolkit.InheritBool.True;
            btn_uninstall.StatePressed.Content.ShortText.Color1 = Color.White;
            btn_uninstall.StateTracking.Back.Draw = Krypton.Toolkit.InheritBool.True;
            btn_uninstall.StateTracking.Border.Draw = Krypton.Toolkit.InheritBool.True;
            btn_uninstall.StateTracking.Border.DrawBorders = Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom | Krypton.Toolkit.PaletteDrawBorders.Left | Krypton.Toolkit.PaletteDrawBorders.Right;
            btn_uninstall.StateTracking.Content.Draw = Krypton.Toolkit.InheritBool.True;
            btn_uninstall.StateTracking.Content.DrawFocus = Krypton.Toolkit.InheritBool.True;
            btn_uninstall.TabIndex = 19;
            btn_uninstall.Values.ImageTransparentColor = Color.Black;
            btn_uninstall.Values.Text = "Uninstall";
            btn_uninstall.Click += btn_uninstall_Click;
            // 
            // kryptonRichTextBox1
            // 
            kryptonRichTextBox1.Location = new Point(72, 211);
            kryptonRichTextBox1.Name = "kryptonRichTextBox1";
            kryptonRichTextBox1.Size = new Size(642, 136);
            kryptonRichTextBox1.TabIndex = 20;
            kryptonRichTextBox1.Text = "";
            // 
            // progressBar
            // 
            progressBar.Location = new Point(232, 80);
            progressBar.Name = "progressBar";
            progressBar.Size = new Size(506, 23);
            progressBar.TabIndex = 21;
            // 
            // lbl_processTitle
            // 
            lbl_processTitle.AutoSize = true;
            lbl_processTitle.Location = new Point(72, 27);
            lbl_processTitle.Name = "lbl_processTitle";
            lbl_processTitle.Size = new Size(19, 15);
            lbl_processTitle.TabIndex = 22;
            lbl_processTitle.Text = "";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(232, 51);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(179, 23);
            comboBox1.TabIndex = 23;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // UpdateControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(comboBox1);
            Controls.Add(lbl_processTitle);
            Controls.Add(progressBar);
            Controls.Add(kryptonRichTextBox1);
            Controls.Add(btn_uninstall);
            Controls.Add(btn_Update);
            Name = "UpdateControl";
            Size = new Size(900, 375);
            Load += UpdateControl_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Krypton.Toolkit.KryptonButton btn_Update;
        private Krypton.Toolkit.KryptonButton btn_uninstall;
        private Krypton.Toolkit.KryptonRichTextBox kryptonRichTextBox1;
        private ProgressBar progressBar1;
        private ProgressBar progressBar;
        private Label lbl_processTitle;
        private ComboBox comboBox1;
    }
}
