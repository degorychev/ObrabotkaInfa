using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Drawing2D;

namespace lab8
{
    public partial class Form1 : Form
    {
        neuron[] neuro_web;
        
        public Form1()
        {
            InitializeComponent();

            neuro_web = new neuron[33];
            int i = 0;
            for (char s = 'А'; s<='Я'; s++)
            {
                if (i == 6)
                {
                    neuro_web[i] = new neuron('Ё');
                    i++;
                }
                neuro_web[i] = new neuron(s);
                i++;
            }

            FileListUpdate();
            NeuronUpdate();
        }

        private void FileListUpdate()
        {
            FileList.Items.Clear();
            DirectoryInfo dir = new DirectoryInfo("scan");
            var files = dir.GetFiles();
            var buff = files.OrderBy(file => file.Name).ToList();
            files = buff.ToArray();
            foreach (var file in files)
            {
                if (file.Name.EndsWith(".bmp"))
                    FileList.Items.Add(file);
            }
        }

        private void Swap()
        {

        }

        private void NeuronUpdate()
        {
            NeuronList.Items.Clear();
            foreach (var neur in neuro_web)
            {
                ListViewItem lvi = new ListViewItem(neur.ToString().PadRight(80));
                lvi.BackColor = selectColor(neur.output);
                NeuronList.Items.Add(lvi);
            }
        }

        private Color selectColor(int weight)
        {
            
            var red = 0;
            var blue = 0;
            var green = 0;
            HsvModel.HsvToRgb(weight / 2, 1, 1, out red, out green, out blue);

            return Color.FromArgb(50, red, green, blue);
        }

        private void FileList_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (var neur in neuro_web)
                neur.output = 0;
            try
            {
                FileInfo file = (FileInfo)FileList.SelectedItem;
                Bitmap bmp = new Bitmap(file.FullName);
                ShowBMP.Image = resizeImage(bmp, ShowBMP.Height, ShowBMP.Width);
                foreach (neuron neu in neuro_web)
                    neu.Scan(bmp);
                NeuronUpdate();

                char st = GetMaxWeight();
                teacher tbox = new teacher(st);

                if (checkBoxLearn.Checked)
                {

                    tbox.ShowDialog();
                    neuro_web[GetCharInt(tbox.verdikt)].IsYou();
                    if (st != tbox.verdikt)
                        neuro_web[GetCharInt(st)].IsNotYou();
                }

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private char GetMaxWeight()
        {
            int max = 0;
            char outp = 'A';
            foreach (var neuron in neuro_web)
            {
                if(max<=neuron.output)
                {
                    max = neuron.output;
                    outp = neuron.name;
                }
            }
            return outp;
        }

        private int GetCharInt(char inp)
        {
            int i = 0;
            for (char s = 'А'; s <= 'Я'; s++)
            {
                if (inp == 'Ё') return 6;
                if (i == 6) i++;
                if (inp == s)
                    return i;
                i++;
            }
            return 0;
        }

        private static Image resizeImage(Image image, int new_height, int new_width)
        {
            Bitmap new_image = new Bitmap(new_width, new_height);
            Graphics g = Graphics.FromImage((Image)new_image);
            g.InterpolationMode = InterpolationMode.NearestNeighbor;
            g.DrawImage(image, 0, 0, new_width, new_height);
            return new_image;
        }

        private void NeuronList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkBoxLearn_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
