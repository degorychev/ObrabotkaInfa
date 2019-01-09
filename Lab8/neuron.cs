using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;

namespace lab8
{
    class neuron
    {
        public char name; //буква
        int[,] input = new int[30, 30];//входной массив
        public int output;//что решил нейрон
        int[,] memory = new int[30, 30]; //предыдущий опыт

        public neuron(char simv)
        {
            name = simv;
            output = 0;
            init_bitmap(simv);
        }

        public void IsYou()
        {
            for (int x = 0; x < 30; x++)
                for (int y = 0; y < 30; y++)
                {
                    int n = memory[x, y];
                    int m = input[x, y];

                    if (m < 250)
                        if (Math.Abs(m - n) > 10)
                            memory[x, y] = (int)Math.Round((double)((n + (n + m) / 2) / 2));

                }
            SaveBitmap();
        }
        public void IsNotYou()
        {
            for (int x = 0; x < 30; x++)
                for (int y = 0; y < 30; y++)
                {
                    int n = memory[x, y];
                    int m = input[x, y];

                    if (m < 250)
                        if(memory[x, y]<=250)
                            memory[x, y] += 5;

                        //if (Math.Abs(m - n) > 10)
                        //    memory[x, y] = (int)Math.Round((double)((n + (n - m) / 2) / 2));

                }
            SaveBitmap();
        }
        public void Scan(Bitmap BMinput)
        {
            for (int x = 0; x < 30; x++)
                for (int y = 0; y < 30; y++)
                {
                    Color clr = BMinput.GetPixel(x, y);
                    int l = (int)Math.Round((double)(clr.R + clr.G + clr.B) / 3);
                    input[x, y] = l;


                    int n = memory[x, y];
                    int m = input[x, y];

                    if (Math.Abs(m - n) < 120)// Порог разницы цвета
                        if (m < 250)// Кроме того, не будем учитывать белые пиксели, чтобы не получать лишних баллов в весах
                            output++;

                    //Ниже какой то быдлокод на паскале (?)
                    /*
                    if (m != 0)
                    {
                        if (m < 250)
                            n = (int)Math.Round((double)((n + (n + m) / 2) / 2));
                        memory[x, y] = n;
                    }
                    else
                        if (n != 0)
                            if (m < 250)
                                n = (int)Math.Round((double)((n + (n + m) / 2) / 2));
                    memory[x, y] = n;
                    */
                }
        }



        private void init_bitmap(char simv)
        {
            if (File.Exists("res/" + simv.ToString() + ".bmp"))
            {
                Bitmap mem = new Bitmap("res/" + simv.ToString() + ".bmp");
                LoadMemory(mem);
                mem.Dispose();
            }
            else
            {
                Bitmap mem = new Bitmap(30, 30);
                for (int x = 0; x < 30; x++)
                    for (int y = 0; y < 30; y++)
                        mem.SetPixel(x, y, Color.White);
                if(!Directory.Exists("res"))
                    Directory.CreateDirectory("res");
                mem.Save("res/" + simv.ToString() + ".bmp");
                LoadMemory(mem);
            }
        }

        private void SaveBitmap()
        {
            Bitmap mem = new Bitmap(30, 30);
            for (int x = 0; x < 30; x++)
                for (int y = 0; y < 30; y++)
                    mem.SetPixel(x, y, Color.FromArgb(memory[x, y], memory[x, y], memory[x, y]));
            string path = "res/" + name.ToString() + ".bmp";
            mem.Save(path);
        }

        private void LoadMemory(Bitmap mem)
        {
            for(int x=0; x<30; x++)
                for(int y=0; y<30; y++)
                {
                    Color clr = mem.GetPixel(x, y);
                    int l = (int)Math.Round((double)(clr.R + clr.G + clr.B) / 3);
                    memory[x, y] = l;
                }
        }

        public override string ToString()
        {
            return name.ToString() + " = " + output;
        }
    }
}
