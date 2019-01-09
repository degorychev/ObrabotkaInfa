using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab8
{
    public partial class teacher : Form
    {
        public char verdikt;
        public teacher(char WhatIsIt)
        {
            InitializeComponent();
            OutputPar.Text = WhatIsIt.ToString();
            verdikt = WhatIsIt;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            verdikt = OutputPar.Text[0];
            this.Close();
        }

        private void OutputPar_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                verdikt = OutputPar.Text[0];
                this.Close();
            }
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

    }
}
