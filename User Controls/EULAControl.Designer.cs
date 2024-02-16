namespace VLMS
{
    partial class EULAControl
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
        private void InitializeComponent()
        {
            btn_next = new Krypton.Toolkit.KryptonButton();
            checkBox1 = new CheckBox();
            richTextBoxEula = new Krypton.Toolkit.KryptonRichTextBox();
            lblNoticesAndLicensese = new Label();
            SuspendLayout();
            // 
            // btn_next
            // 
            btn_next.AutoSize = true;
            btn_next.ButtonStyle = Krypton.Toolkit.ButtonStyle.Custom1;
            btn_next.CornerRoundingRadius = 3F;
            btn_next.Enabled = false;
            btn_next.ImeMode = ImeMode.NoControl;
            btn_next.Location = new Point(775, 336);
            btn_next.Name = "btn_next";
            btn_next.OverrideDefault.Back.Color1 = SystemColors.Highlight;
            btn_next.OverrideDefault.Back.Color2 = SystemColors.Highlight;
            btn_next.OverrideFocus.Back.Color1 = SystemColors.MenuHighlight;
            btn_next.OverrideFocus.Back.Color2 = SystemColors.MenuHighlight;
            btn_next.OverrideFocus.Border.Color1 = Color.Gray;
            btn_next.OverrideFocus.Border.DrawBorders = Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom | Krypton.Toolkit.PaletteDrawBorders.Left | Krypton.Toolkit.PaletteDrawBorders.Right;
            btn_next.OverrideFocus.Content.ShortText.Color1 = SystemColors.ControlLightLight;
            btn_next.PaletteMode = Krypton.Toolkit.PaletteMode.Office2010BlackDarkMode;
            btn_next.Size = new Size(90, 26);
            btn_next.StateCommon.Back.Color1 = SystemColors.Highlight;
            btn_next.StateCommon.Back.Color2 = SystemColors.Highlight;
            btn_next.StateCommon.Border.DrawBorders = Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom | Krypton.Toolkit.PaletteDrawBorders.Left | Krypton.Toolkit.PaletteDrawBorders.Right;
            btn_next.StateCommon.Border.Rounding = 3F;
            btn_next.StateCommon.Content.AdjacentGap = 1;
            btn_next.StateCommon.Content.DrawFocus = Krypton.Toolkit.InheritBool.False;
            btn_next.StateCommon.Content.ShortText.Color1 = SystemColors.ControlLightLight;
            btn_next.StateCommon.Content.ShortText.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btn_next.StateDisabled.Back.Color1 = Color.LightGray;
            btn_next.StateDisabled.Back.Color2 = Color.LightGray;
            btn_next.StateDisabled.Border.Color1 = Color.FromArgb(64, 64, 64);
            btn_next.StateDisabled.Border.Color2 = Color.FromArgb(64, 64, 64);
            btn_next.StateDisabled.Border.DrawBorders = Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom | Krypton.Toolkit.PaletteDrawBorders.Left | Krypton.Toolkit.PaletteDrawBorders.Right;
            btn_next.StateDisabled.Content.ShortText.Color1 = Color.DimGray;
            btn_next.StateDisabled.Content.ShortText.Color2 = Color.DimGray;
            btn_next.StateNormal.Back.Color1 = SystemColors.Highlight;
            btn_next.StateNormal.Back.Color2 = SystemColors.Highlight;
            btn_next.StatePressed.Back.Color1 = Color.Blue;
            btn_next.StatePressed.Back.Draw = Krypton.Toolkit.InheritBool.True;
            btn_next.StatePressed.Content.ShortText.Color1 = Color.White;
            btn_next.StateTracking.Back.Draw = Krypton.Toolkit.InheritBool.True;
            btn_next.StateTracking.Border.Draw = Krypton.Toolkit.InheritBool.True;
            btn_next.StateTracking.Border.DrawBorders = Krypton.Toolkit.PaletteDrawBorders.Top | Krypton.Toolkit.PaletteDrawBorders.Bottom | Krypton.Toolkit.PaletteDrawBorders.Left | Krypton.Toolkit.PaletteDrawBorders.Right;
            btn_next.StateTracking.Content.Draw = Krypton.Toolkit.InheritBool.True;
            btn_next.StateTracking.Content.DrawFocus = Krypton.Toolkit.InheritBool.True;
            btn_next.TabIndex = 16;
            btn_next.Values.ImageTransparentColor = Color.Black;
            btn_next.Values.Text = "Next";
            btn_next.Click += btn_next_Click;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Font = new Font("Arial", 10F, FontStyle.Bold, GraphicsUnit.Point);
            checkBox1.ForeColor = Color.Black;
            checkBox1.ImeMode = ImeMode.NoControl;
            checkBox1.Location = new Point(33, 342);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(248, 20);
            checkBox1.TabIndex = 15;
            checkBox1.Text = "I accept the terms && conditions.";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // richTextBoxEula
            // 
            richTextBoxEula.Location = new Point(33, 60);
            richTextBoxEula.Margin = new Padding(0);
            richTextBoxEula.Name = "richTextBoxEula";
            richTextBoxEula.ReadOnly = true;
            richTextBoxEula.Size = new Size(832, 269);
            richTextBoxEula.StateActive.Back.Color1 = SystemColors.ButtonHighlight;
            richTextBoxEula.StateCommon.Content.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            richTextBoxEula.TabIndex = 14;
            richTextBoxEula.Text = "";
            // 
            // lblNoticesAndLicensese
            // 
            lblNoticesAndLicensese.AutoSize = true;
            lblNoticesAndLicensese.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblNoticesAndLicensese.ForeColor = Color.Black;
            lblNoticesAndLicensese.ImeMode = ImeMode.NoControl;
            lblNoticesAndLicensese.Location = new Point(282, 16);
            lblNoticesAndLicensese.Margin = new Padding(0);
            lblNoticesAndLicensese.Name = "lblNoticesAndLicensese";
            lblNoticesAndLicensese.Size = new Size(318, 25);
            lblNoticesAndLicensese.TabIndex = 13;
            lblNoticesAndLicensese.Text = "Applicable notices and license terms";
            lblNoticesAndLicensese.TextAlign = ContentAlignment.BottomCenter;
            // 
            // UserControl1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(btn_next);
            Controls.Add(checkBox1);
            Controls.Add(richTextBoxEula);
            Controls.Add(lblNoticesAndLicensese);
            Name = "UserControl1";
            Size = new Size(900, 375);
            Load += UserControl1_Load;
            ResumeLayout(false);
            PerformLayout();
        }
        private Krypton.Toolkit.KryptonButton btn_next;
        private CheckBox checkBox1;
        private Krypton.Toolkit.KryptonRichTextBox richTextBoxEula;
        private Label lblNoticesAndLicensese;
    }
}
