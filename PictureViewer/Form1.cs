using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PictureViewer
{
    public partial class Form1 : Form
    {
        private Size _originalPicBoxSize;

        public Form1()
        {
            InitializeComponent();
            btClosePicture.Visible = false;
            //panel1.AutoScroll= true;
            richTextBox1.SelectAll();
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
            this.FormClosing += Form1_FormClosing1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = (AppSettings.LoadImageLocationProperty(Program._settingsFilePath));
            if (pictureBox1.ImageLocation != null)
            {
                pictureBox1.LoadCompleted += PboxPicture_LoadCompleted;
            }
                    
            _originalPicBoxSize = new Size(pictureBox1.Width, pictureBox1.Height);
            trackBar1.Minimum = _originalPicBoxSize.Width;
            trackBar1.Maximum = _originalPicBoxSize.Width * 4; // 4 = zoom 300%

            // set center position of picturebox inside panel  
            //pboxPicture.Left = (panel1.Width - _originalPicBoxSize.Width) / 2;
           // pboxPicture.Top = (panel1.Height - _originalPicBoxSize.Height) / 2;

            pictureBox1.Show();

            //label1.Text = _originalPicBoxSize.ToString();
        }


        private void Form1_FormClosing1(object sender, FormClosingEventArgs e)
        {
            AppSettings.SaveImageLocationProperty(pictureBox1.ImageLocation);
        }

        private void btOpenFile_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            try
            {
                var pictureFileDialog = new OpenFileDialog
                {
                    Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;...|All files (*.*)|*.*"
                };

                if (pictureFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pictureBox1.ImageLocation = pictureFileDialog.FileName;
                    pictureBox1.Show();
                    pictureBox1.LoadCompleted += PboxPicture_LoadCompleted;
                    _originalPicBoxSize = new Size(pictureBox1.Width, pictureBox1.Height);
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "UWAGA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PboxPicture_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            lbPath.Text = pictureBox1.ImageLocation;
            btClosePicture.Visible = true;
            richTextBox1.Text = ImageInfo.PrintImageProperties(pictureBox1.ImageLocation);
        }

        private void btClosePicture_Click(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = null;
            pictureBox1.Show();
            lbPath.Text = null;
            btClosePicture.Visible = false;
            richTextBox1.Clear();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            var newWidth = trackBar1.Value;
            var newHight = _originalPicBoxSize.Height + (trackBar1.Value - _originalPicBoxSize.Width);
            pictureBox1.Size = new Size(newWidth, newHight);
            pictureBox1.Left = (panel1.Width - pictureBox1.Width) / 2;         
            pictureBox1.Top = (panel1.Height - pictureBox1.Height) / 2;
           
            label2.Text = $"Zoom: {(trackBar1.Value * 100) / trackBar1.Minimum - 100}%";
        }
    }
}
