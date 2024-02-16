using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xceed.Words.NET;

namespace VLMS
{
    public partial class EULAControl : UserControl
    {
        public EULAControl()
        {
            InitializeComponent();
        }
        public event EventHandler NextButtonClicked;
        private void checkBox1_CheckedChanged( object sender, EventArgs e )
        {
            if (checkBox1.Checked)
            {
                btn_next.Enabled = true;
            }
            else
            {
                btn_next.Enabled = false;
            }
        }

        private void UserControl1_Load( object sender, EventArgs e )
        {

            LoadDocxFile(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Setups", "EULA.docx"));

        }
        private void LoadDocxFile( string filePath )
        {
            try
            {
                using (var doc = DocX.Load(filePath))
                {
                    richTextBoxEula.Clear();

                    // Extract paragraphs and add them to the RichTextBox with line breaks
                    foreach (var paragraph in doc.Paragraphs)
                    {
                        if (paragraph.Text == paragraph.Text.ToUpper() && paragraph.Text.Length > 0)
                        {
                            richTextBoxEula.SelectionFont = new Font("Segoe UI", 10, FontStyle.Bold);
                            richTextBoxEula.AppendText("- " + paragraph.Text + "\n");
                            richTextBoxEula.SelectionFont = new Font("Segoe UI", 9, FontStyle.Regular);
                        }
                        else
                        {
                            richTextBoxEula.AppendText(paragraph.Text + "\n");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                // Handle exceptions (file not found, invalid format, etc.)
                MessageBox.Show($"Error loading DOCX file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btn_next_Click( object sender, EventArgs e )
        {

            NextButtonClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
