using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MineField_SL
{
    public partial class Form2SS : Form
    {
        public Form2SS()
        {
            InitializeComponent();
        }

        private void Form2SS_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            Form1 Game = new Form1();
            this.Hide();
            Game.Show();
        }
    }
}
