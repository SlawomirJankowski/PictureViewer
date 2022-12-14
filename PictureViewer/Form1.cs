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
        private int _xPos;
        private int _yPos;
        private bool _dragging;

        public Form1()
        {
            InitializeComponent();
            btClosePicture.Visible = false;
            trackBar1.Enabled = false;

            richTextBox1.SelectAll();
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
           
            // register mouse events
            pictureBox1.MouseUp += PictureBox1_MouseUp;
            pictureBox1.MouseDown += PictureBox1_MouseDown;
            pictureBox1.MouseMove += PictureBox1_MouseMove;

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
            SetPictureBoxPosition(_originalPicBoxSize.Width, _originalPicBoxSize.Height);

            pictureBox1.Show();

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

                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "UWAGA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PboxPicture_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            _originalPicBoxSize = new Size(pictureBox1.Width, pictureBox1.Height);
            lbPath.Text = pictureBox1.ImageLocation;
            btClosePicture.Visible = true;
            trackBar1.Enabled = true;
            richTextBox1.Text = ImageInfo.PrintImageProperties(pictureBox1.ImageLocation);

        }

        private void btClosePicture_Click(object sender, EventArgs e)
        {
            pictureBox1.ImageLocation = null;
            pictureBox1.Show();
            lbPath.Text = null;
            btClosePicture.Visible = false;
            trackBar1.Enabled = false;
            trackBar1.Value = trackBar1.Minimum;
            lbZoom.Text = "Zoom: 0%";
            richTextBox1.Clear();
            pictureBox1.Size = new Size(_originalPicBoxSize.Width, _originalPicBoxSize.Height);
            SetPictureBoxPosition(_originalPicBoxSize.Width, _originalPicBoxSize.Height);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            var newWidth = trackBar1.Value;
            var newHight = _originalPicBoxSize.Height + (trackBar1.Value - _originalPicBoxSize.Width);
            pictureBox1.Size = new Size(newWidth, newHight);
            SetPictureBoxPosition(pictureBox1.Width, pictureBox1.Height);         
            lbZoom.Text = $"Zoom: {(trackBar1.Value * 100) / trackBar1.Minimum - 100}%";
        }

        private void SetPictureBoxPosition(int pictureboxWidth, int pictureboxHeight)
        {
            pictureBox1.Left = (panel1.Width - pictureboxWidth) / 2;
            pictureBox1.Top = (panel1.Height - pictureboxHeight) / 2;
        }


        // mouse dragging events
        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_dragging || !(sender is PictureBox pbox)) return;
            pbox.Top = e.Y + pbox.Top - _yPos;
            pbox.Left = e.X + pbox.Left - _xPos;
        }

        private void PictureBox1_MouseDown(object sender, MouseEventArgs e) // wciśnięty lewy przycisk
        {
            if (e.Button != MouseButtons.Left) return;
            _dragging = true;
            _xPos = e.X;
            _yPos = e.Y;
        }    
        private void PictureBox1_MouseUp(object sender, MouseEventArgs e) // puszczony lewy przycisk
        {
            if (!(sender is PictureBox)) return;
            _dragging = false;
        }
    }
}
