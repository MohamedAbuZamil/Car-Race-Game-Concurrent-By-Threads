using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Car_Racing_Game_MOO_ICT
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Single_Player_Click(object sender, EventArgs e)
        {
            Form1 singlePlayerForm = new Form1();
            singlePlayerForm.Show();
        }

      
    }
}
