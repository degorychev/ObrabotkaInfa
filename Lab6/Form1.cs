using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Diagnostics;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private Bitmap image;
        Graphics gr;
        Pen pen;



        public Form1()
        {
            InitializeComponent();
            pen = new Pen(Color.Black);
        }

        private void OpenImageButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            if(opf.ShowDialog() == DialogResult.OK)
            {
                image = new Bitmap(opf.FileName, true);
                gr = Graphics.FromImage(image);
                MyPictureBox.Image = image;
            }
        }

        private void PictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                int newX = (image.Width / MyPictureBox.Width) * (e.X+MyPictureBox.Left);
                int newY = (image.Height / MyPictureBox.Height) * (e.Y+MyPictureBox.Top); 
                Rectangle rect = new Rectangle(newX, newY, 1, 1);
                if(radioButton1.Checked)
                {
                    rect.Width = 1;
                    rect.Height = 1;
                }
                else if (radioButton2.Checked)
                {
                    rect.Width = 3;
                    rect.Height = 3;
                }
                else if (radioButton3.Checked)
                {
                    rect.Width = 6;
                    rect.Height = 6;
                }

                gr.FillRectangle(pen.Brush, rect);
                MyPictureBox.Image = image;
            }
        }

        private void SaveAsButton_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            if(sfd.ShowDialog()==DialogResult.OK)
            {
                MyPictureBox.Image.Save(sfd.FileName, ImageFormat.Bmp);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ColorDialog cd = new ColorDialog();
            if(cd.ShowDialog() == DialogResult.OK)
            {
                pen = new Pen(cd.Color);
            }
        }
    }
}
