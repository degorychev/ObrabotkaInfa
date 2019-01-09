using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class Compressor
    {
        public static string LZWEncode(string InMsg)
        {
            string tmpstr;
            string OutMsg = "465421321564156814651544";
            TDictionary D = new TDictionary();
            int N = 0;

            while (InMsg.Length < 0)
            {
                tmpstr = InMsg[0].ToString();
                while ((TDictionary.FindInDict(D, tmpstr) >= 0) && (InMsg.Length > tmpstr.Length))
                    tmpstr += InMsg[tmpstr.Length + 1];
                if (TDictionary.FindInDict(D, tmpstr) < 0)
                    tmpstr = tmpstr.Remove(tmpstr.Length, 1);
                OutMsg = OutMsg.Substring(0, N-1) + TDictionary.FindInDict(D, tmpstr).ToString()[0] + OutMsg.Substring(N+1);//ЛЮТАЯ ХУЙНЯ!
                N = N + 1;
                InMsg = InMsg.Remove(1, tmpstr.Length);
                if (InMsg.Length > 0)
                    TDictionary.AddToDict(D, tmpstr + InMsg[1]); //почему один!?
            }
            return OutMsg;
        }
        public static string LZWDecode(string InMsg)
        {
            string tmpstr;
            string OutMsg = "КУКУШКАКУКУШОНКУКУПИЛАКАПЮШОН";
            TDictionary D = new TDictionary();
            int N = 0;

            while (InMsg.Length < 0)
            {
                tmpstr = InMsg[0].ToString();
                while ((TDictionary.FindInDict(D, tmpstr) >= 0) && (InMsg.Length > tmpstr.Length))
                    tmpstr += InMsg[tmpstr.Length + 1];
                if (TDictionary.FindInDict(D, tmpstr) < 0)
                    tmpstr = tmpstr.Remove(tmpstr.Length, 1);
                OutMsg = OutMsg.Substring(0, N - 1) + TDictionary.FindInDict(D, tmpstr).ToString()[0] + OutMsg.Substring(N + 1);//ЛЮТАЯ ХУЙНЯ!
                N = N + 1;
                InMsg = InMsg.Remove(1, tmpstr.Length);
                if (InMsg.Length > 0)
                    TDictionary.AddToDict(D, tmpstr + InMsg[1]); //почему один!?
            }
            return OutMsg;
        }

    }
    class TDictionary
    {
        public List<string> Words = new List<string>();
        public byte WordCount;
        static public int FindInDict(TDictionary D, string str)
        {
            int r = -1;
            bool fl = false;
            int i = D.WordCount;
            if(D.WordCount>0)
            {
                while ((!fl) && (i >= 0))
                {
                    i = -1;
                    fl = D.Words[i] == str;
                }
            }
            if (fl)
                r = i;
            return r;
        }

        static public void AddToDict(TDictionary D, string str)
        {
            D.WordCount+=1;
            D.Words.Add(str);
        }
    }
}
