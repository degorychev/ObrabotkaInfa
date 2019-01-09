using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    static public class comressor
    {
        public static LinkedList<ZByte> compress(byte[] input)
        {
            LinkedList<ZByte> output = new LinkedList<ZByte>();//Связный список сжатых байтов
            int count = 0;
            byte currentbyte = input[0];

            //Перечисляем все байты
            foreach(byte byt in input)
            {
                if (currentbyte == byt)//Если байт повторился
                    count++;
                else//Новый байт
                {
                    output.AddLast(new ZByte(currentbyte, count));//Закинули в конец списка новый объект сжатого байта
                    currentbyte = byt;
                    count = 1;
                }
            }
            output.AddLast(new ZByte(currentbyte, count));//В конце остается забытый хвост
            
            return output;
        }
        public static byte[] decompress(LinkedList<ZByte> input)
        {
            List<byte[]> output = new List<byte[]>();
            int bytecount = 0;
            //Перебираем все сжатый байты
            foreach(ZByte byt in input)
            {
                bytecount += byt.countIter;//Счетчик количества исходных байтов

                byte[] original = new byte[byt.countIter];//Выделяем под них помять
                for (int i = 0; i < byt.countIter; i++)
                    original[i] = byt.curByte;//занимаем весь массив байтов исходным байтом, который повторяется
                output.Add(original);//Добавляем в список полученный массив одинаковых байтов
            }
            int j = 0;
            byte[] outputbyte = new byte[bytecount];//Выделяем память под ВСЕ нужные байты
            foreach (byte[] massbyte in output)//Массив байтов в списке массивов байтов
                foreach (byte onebyte in massbyte)//Байт в массиве байтов
                {
                    outputbyte[j] = onebyte;//Ставим на это место нужный байт
                    j++;//Счетчик
                }
            return outputbyte;
        }
    }
    //Чудо класс, который представляет "сжатый байт"
    public class ZByte
    {
        public byte curByte;//Оригинальный байт
        public int countIter;//Каличество его повторений

        /// <summary>
        /// Конструктор сжатого байта
        /// </summary>
        /// <param name="byt">Оригинальный байт</param>
        /// <param name="count">Количество повторений байта</param>
        public ZByte(byte byt, int count)
        {
            curByte = byt;
            countIter = count;
        }

        public override string  ToString()
        {
            return countIter.ToString() + "(" + curByte.ToString() + ")";
        }
    }
}
