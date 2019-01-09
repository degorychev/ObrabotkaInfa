using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2
{
    static class BWTcompressor
    {
        public static string BWTEncode(string InMsg)
        {
            char EOMsg = 'ի';
            string OutMsg = "";
            List<string> ShiftTable = new List<string>();
            char lastchar;


            InMsg += EOMsg;
            int N = InMsg.Length;
            ShiftTable.Add(InMsg);

            for (int i =1; i<N; i++)
            {
                lastchar = InMsg.Last();
                InMsg = lastchar + InMsg.Substring(0, N-1);
                ShiftTable.Add(InMsg);
            }
            
            ShiftTable.Sort();

            for (int i = 0; i < N; i++)
                OutMsg += ShiftTable[i].Last();
            return OutMsg;
        }

        public static string BWTDecode(string InMsg)
        {
            string OutMsg = "";
            char EOMsg = 'ի';
            InMsg = InMsg.Replace("|", "ի");
            List<string> ShiftTable=new List<string>();
            int N = InMsg.Length;

            for (int i = 0; i < N; i++)
                ShiftTable.Add("");

            for (int i=0; i<N;i++)
            {
                for (int j = 0; j < N; j++)
                    ShiftTable[j] = InMsg[j] + ShiftTable[j];
                ShiftTable.Sort();
            }

            for (int i = 0; i < N; i++)
                if (ShiftTable[i].Last() == EOMsg)
                    OutMsg = ShiftTable[i];

            return OutMsg;
        }
    }
}
