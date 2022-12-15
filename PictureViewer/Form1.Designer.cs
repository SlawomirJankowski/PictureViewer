namespace PictureViewer
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
        protected override void Dispose(bool disposing)
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
            this.btOpenFile = new System.Windows.Forms.Button();
            this.btClosePicture = new System.Windows.Forms.Button();
            this.lbPath = new System.Windows.Forms.Label();
            this.rtbImageProperties = new System.Windows.Forms.RichTextBox();
            this.trbZoom = new System.Windows.Forms.TrackBar();
            this.lbZoom = new System.Windows.Forms.Label();
            this.pbImage = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.trbZoom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btOpenFile
            // 
            this.btOpenFile.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btOpenFile.Location = new System.Drawing.Point(12, 13);
            this.btOpenFile.Name = "btOpenFile";
            this.btOpenFile.Size = new System.Drawing.Size(175, 32);
            this.btOpenFile.TabIndex = 0;
            this.btOpenFile.Text = "Wczytaj zdjęcie";
            this.btOpenFile.UseVisualStyleBackColor = true;
            this.btOpenFile.Click += new System.EventHandler(this.btOpenFile_Click);
            // 
            // btClosePicture
            // 
            this.btClosePicture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btClosePicture.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btClosePicture.Location = new System.Drawing.Point(1007, 13);
            this.btClosePicture.Name = "btClosePicture";
            this.btClosePicture.Size = new System.Drawing.Size(165, 32);
            this.btClosePicture.TabIndex = 1;
            this.btClosePicture.Text = "Zamknij zdjęcie";
            this.btClosePicture.UseVisualStyleBackColor = true;
            this.btClosePicture.Click += new System.EventHandler(this.btClosePicture_Click);
            // 
            // lbPath
            // 
            this.lbPath.AutoSize = true;
            this.lbPath.ForeColor = System.Drawing.Color.DarkRed;
            this.lbPath.Location = new System.Drawing.Point(13, 63);
            this.lbPath.Name = "lbPath";
            this.lbPath.Size = new System.Drawing.Size(0, 13);
            this.lbPath.TabIndex = 3;
            // 
            // richTextBox1
            // 
            this.rtbImageProperties.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbImageProperties.BackColor = System.Drawing.Color.LemonChiffon;
            this.rtbImageProperties.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rtbImageProperties.ForeColor = System.Drawing.Color.DarkBlue;
            this.rtbImageProperties.HideSelection = false;
            this.rtbImageProperties.Location = new System.Drawing.Point(12, 695);
            this.rtbImageProperties.Name = "richTextBox1";
            this.rtbImageProperties.ReadOnly = true;
            this.rtbImageProperties.Size = new System.Drawing.Size(1160, 104);
            this.rtbImageProperties.TabIndex = 4;
            this.rtbImageProperties.Text = "";
            // 
            // trackBar1
            // 
            this.trbZoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.trbZoom.Location = new System.Drawing.Point(422, 13);
            this.trbZoom.Name = "trackBar1";
            this.trbZoom.Size = new System.Drawing.Size(355, 17);
            this.trbZoom.TabIndex = 5;
            this.trbZoom.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // lbZoom
            // 
            this.lbZoom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.lbZoom.AutoSize = true;
            this.lbZoom.ForeColor = System.Drawing.Color.ForestGreen;
            this.lbZoom.Location = new System.Drawing.Point(580, 45);
            this.lbZoom.Name = "lbZoom";
            this.lbZoom.Size = new System.Drawing.Size(54, 13);
            this.lbZoom.TabIndex = 8;
            this.lbZoom.Text = "Zoom: 0%";
            // 
            // pictureBox1
            // 
            this.pbImage.Location = new System.Drawing.Point(61, 34);
            this.pbImage.Name = "pictureBox1";
            this.pbImage.Size = new System.Drawing.Size(1036, 529);
            this.pbImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbImage.TabIndex = 0;
            this.pbImage.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Controls.Add(this.pbImage);
            this.panel1.Location = new System.Drawing.Point(12, 88);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1159, 597);
            this.panel1.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1184, 811);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbZoom);
            this.Controls.Add(this.trbZoom);
            this.Controls.Add(this.rtbImageProperties);
            this.Controls.Add(this.lbPath);
            this.Controls.Add(this.btClosePicture);
            this.Controls.Add(this.btOpenFile);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.MaximumSize = new System.Drawing.Size(1200, 850);
            this.MinimumSize = new System.Drawing.Size(1200, 850);
            this.Name = "Form1";
            this.Text = "Picture Viewer";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trbZoom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImage)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btOpenFile;
        private System.Windows.Forms.Button btClosePicture;
        private System.Windows.Forms.Label lbPath;
        private System.Windows.Forms.RichTextBox rtbImageProperties;
        private System.Windows.Forms.TrackBar trbZoom;
        private System.Windows.Forms.Label lbZoom;
        private System.Windows.Forms.PictureBox pbImage;
        private System.Windows.Forms.Panel panel1;
    }
}

