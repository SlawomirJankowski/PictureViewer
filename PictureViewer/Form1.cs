using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

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
            trbZoom.Enabled = false;

            lbZoom.ForeColor = Color.DarkGray;

            rtbImageProperties.SelectAll();
            rtbImageProperties.SelectionAlignment = HorizontalAlignment.Center;
           
            // register mouse events
            pbImage.MouseUp += PictureBox1_MouseUp;
            pbImage.MouseDown += PictureBox1_MouseDown;
            pbImage.MouseMove += PictureBox1_MouseMove;

            this.FormClosing += Form1_FormClosing1;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pbImage.ImageLocation = AppSettings.LoadImageLocationProperty(Program.SettingsFilePath);
            if (pbImage.ImageLocation != null)
            {
                pbImage.LoadCompleted += PboxPicture_LoadCompleted;
            }
                     
            _originalPicBoxSize = new Size(pbImage.Width, pbImage.Height);
            SetPictureBoxPosition(_originalPicBoxSize.Width, _originalPicBoxSize.Height);// set center position of picturebox inside panel
            pbImage.Show();
            trbZoom.Minimum = _originalPicBoxSize.Width;
            trbZoom.Maximum = _originalPicBoxSize.Width * 4; // 4 = zoom 300%
            
        }

        private void Form1_FormClosing1(object sender, FormClosingEventArgs e)
        {
            AppSettings.SaveImageLocationProperty(pbImage.ImageLocation);
        }

        private void btOpenFile_Click(object sender, EventArgs e)
        {
            rtbImageProperties.Clear();
            try
            {
                var pictureFileDialog = new OpenFileDialog
                {
                    Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;...|All files (*.*)|*.*"
                };

                if (pictureFileDialog.ShowDialog() == DialogResult.OK)
                {
                    pbImage.ImageLocation = pictureFileDialog.FileName;
                    pbImage.Show();
                    pbImage.LoadCompleted += PboxPicture_LoadCompleted;
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message, "UWAGA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PboxPicture_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            _originalPicBoxSize = new Size(pbImage.Width, pbImage.Height);
            lbPath.Text = pbImage.ImageLocation;
            lbZoom.ForeColor = Color.ForestGreen;
            btClosePicture.Visible = true;
            trbZoom.Enabled = true;
            rtbImageProperties.Text = ImageInfo.ShowImageProperties(pbImage.ImageLocation);

        }

        private void btClosePicture_Click(object sender, EventArgs e)
        {
            pbImage.ImageLocation = null;
            pbImage.Size = new Size(_originalPicBoxSize.Width, _originalPicBoxSize.Height);
            SetPictureBoxPosition(_originalPicBoxSize.Width, _originalPicBoxSize.Height);
            pbImage.Show();
            lbPath.Text = null;
            lbZoom.Text = "Zoom: 0%";
            lbZoom.ForeColor = Color.DarkGray;
            btClosePicture.Visible = false;
            trbZoom.Enabled = false;
            trbZoom.Value = trbZoom.Minimum;
            rtbImageProperties.Clear();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            var newWidth = trbZoom.Value;
            var newHight = _originalPicBoxSize.Height + (trbZoom.Value - _originalPicBoxSize.Width);
            pbImage.Size = new Size(newWidth, newHight);
            SetPictureBoxPosition(pbImage.Width, pbImage.Height);         
            lbZoom.Text = $"Zoom: {(trbZoom.Value * 100) / trbZoom.Minimum - 100}%";
        }

        private void SetPictureBoxPosition(int pictureboxWidth, int pictureboxHeight)
        {
            pbImage.Left = (panel1.Width - pictureboxWidth) / 2;
            pbImage.Top = (panel1.Height - pictureboxHeight) / 2;
        }

        #region Mouse dragging events
        private void PictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_dragging || !(sender is PictureBox pbox)) return;
            pbox.Top = e.Y + pbox.Top - _yPos;
            pbox.Left = e.X + pbox.Left - _xPos;
        }

        private void PictureBox1_MouseDown(object sender, MouseEventArgs e) // Left mouse button pressed
        {
            if (e.Button != MouseButtons.Left) return;
            _dragging = true;
            _xPos = e.X;
            _yPos = e.Y;
        }    
        private void PictureBox1_MouseUp(object sender, MouseEventArgs e) // Left mouse button released
        {
            if (!(sender is PictureBox)) return;
            _dragging = false;
        }
        #endregion       
    }
}
