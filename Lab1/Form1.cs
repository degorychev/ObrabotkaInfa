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

namespace Lab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        LinkedList<ZByte> bufer;


        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("===================================");
            string input = textBox1.Text;
            byte[] inputByte = ASCIIEncoding.ASCII.GetBytes(input);//Исходный массив байт
            Console.WriteLine("Исходная строка: " + input.PadRight(51).Remove(50) + "... длина:" + input.Length + " \nКоличество байт: " + inputByte.Count());
            bufer = comressor.compress(inputByte);//Получаем набор байтов

            //Далее формируется наглядный вывод
            string outputstr = "";
            foreach (ZByte byt in bufer)
            {
                outputstr += byt.ToString();//Смотрим весь список и создаем строку, смотри реализацию ToString()
            }

            Console.WriteLine("Сжатая строка: " + outputstr.PadRight(51).Remove(50) + "... \n" + bufer.Count() + "\"Сжатых\" байтов");
            textBox2.Text = outputstr;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string input = textBox2.Text;
            textBox1.Text = ASCIIEncoding.ASCII.GetString(comressor.decompress(bufer));//Делаем строку из набора байтов
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Console.WriteLine("===================================");
            try
            {
                OpenFileDialog ofd = new OpenFileDialog();
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    Bitmap input = new Bitmap(ofd.FileName);
                    using (var stream = new MemoryStream())
                    {
                        input.Save(stream, System.Drawing.Imaging.ImageFormat.Bmp);
                        byte[] inputByte = stream.ToArray();
                        Console.WriteLine("Загрузили изображение, объем: " + inputByte.Count() + " байт");
                        bufer = comressor.compress(inputByte);
                        Console.WriteLine("Сжали изображение, объем: " + bufer.Count() + "\"Сжатых\" байт");
                        string outputstr = "";
                        foreach (ZByte byt in bufer)
                        {
                            outputstr += byt.ToString();//Смотрим весь список и создаем строку, смотри реализацию ToString()
                        }
                        textBox2.Text = outputstr;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
