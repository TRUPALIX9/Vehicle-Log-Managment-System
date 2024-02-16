namespace VLMS
{
    partial class Form2
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
            btnDownload = new Button();
            richTextBox1 = new RichTextBox();
            button1 = new Button();
            comboBoxFiles = new ComboBox();
            dataGridView1 = new DataGridView();
            btnNextJs = new Button();
            btn_aividVlms = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // btnDownload
            // 
            btnDownload.Location = new Point(457, 42);
            btnDownload.Name = "btnDownload";
            btnDownload.Size = new Size(75, 23);
            btnDownload.TabIndex = 0;
            btnDownload.Text = "Click me";
            btnDownload.UseVisualStyleBackColor = true;
            btnDownload.Click += GetServiceStartupPathButton_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(12, 63);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(410, 152);
            richTextBox1.TabIndex = 1;
            richTextBox1.Text = "";
            // 
            // button1
            // 
            button1.Enabled = false;
            button1.Location = new Point(457, 82);
            button1.Name = "button1";
            button1.Size = new Size(121, 23);
            button1.TabIndex = 2;
            button1.Text = "check For Update";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // comboBoxFiles
            // 
            comboBoxFiles.FormattingEnabled = true;
            comboBoxFiles.Items.AddRange(new object[] { "nextjs_anpr", "release/aividVlms" });
            comboBoxFiles.Location = new Point(12, 12);
            comboBoxFiles.Name = "comboBoxFiles";
            comboBoxFiles.Size = new Size(410, 23);
            comboBoxFiles.TabIndex = 3;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(37, 281);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(479, 150);
            dataGridView1.TabIndex = 4;
            // 
            // btnNextJs
            // 
            btnNextJs.Enabled = false;
            btnNextJs.Location = new Point(557, 308);
            btnNextJs.Name = "btnNextJs";
            btnNextJs.Size = new Size(126, 23);
            btnNextJs.TabIndex = 5;
            btnNextJs.Text = "Portal Update";
            btnNextJs.UseVisualStyleBackColor = true;
            // 
            // btn_aividVlms
            // 
            btn_aividVlms.Enabled = false;
            btn_aividVlms.Location = new Point(557, 346);
            btn_aividVlms.Name = "btn_aividVlms";
            btn_aividVlms.Size = new Size(126, 23);
            btn_aividVlms.TabIndex = 6;
            btn_aividVlms.Text = "Aivid bot Update";
            btn_aividVlms.UseVisualStyleBackColor = true;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1218, 453);
            Controls.Add(btn_aividVlms);
            Controls.Add(btnNextJs);
            Controls.Add(dataGridView1);
            Controls.Add(comboBoxFiles);
            Controls.Add(button1);
            Controls.Add(richTextBox1);
            Controls.Add(btnDownload);
            Name = "Form2";
            Text = "Form2";
            Load += Form2_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnDownload;
        private RichTextBox richTextBox1;
        private Button button1;
        private ComboBox comboBoxFiles;
        private DataGridView dataGridView1;
        private Button btnNextJs;
        private Button btn_aividVlms;
    }
}