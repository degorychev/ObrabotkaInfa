using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = BWTcompressor.BWTEncode(textBox1.Text);//Пеестановка
            Console.WriteLine(str);
            byte[] massbt = ASCIIEncoding.ASCII.GetBytes(str);
            var bytes = Lab1.comressor.compress(massbt);//Через ссылку обращение к классу из первой лабы

            foreach (var byt in bytes)
                Console.Write(byt.countIter + "(" + byt.curByte + ")");
            Console.WriteLine();

            var Decoded = Lab1.comressor.decompress(bytes);

            string decodstr = ASCIIEncoding.ASCII.GetString(Decoded);

            Console.WriteLine(BWTcompressor.BWTDecode(decodstr));
        }
    }
}
