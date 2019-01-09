using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            btnEncode.Click += (s, e) =>
            {
                var result = ShennonFano.Encode(txtSource.Text);

                txtTable.Text = JsonConvert.SerializeObject(result.Item2);
                txtResult.Text = result.Item1;
            };

            btnDecode.Click += (s, e) =>
            {
                if (string.IsNullOrEmpty(txtTable.Text)) { MessageBox.Show("Отсутствует таблица кодировки."); return; }
                if (txtSource.Text.Any(x => x != '0' && x != '1')) { MessageBox.Show("Данные не в бинарном виде."); return; }

                var symbols = new List<Symbol>();

                try
                {
                    symbols = JsonConvert.DeserializeObject<List<Symbol>>(txtTable.Text);
                }
                catch
                {
                    MessageBox.Show("Неверная таблица кодировки."); return;
                }


                txtResult.Text = ShennonFano.Decode(txtSource.Text, symbols);
            };
        }
    }
}
