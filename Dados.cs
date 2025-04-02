using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace coisaboa
{
    public partial class Dados: Form
    {
        Random rand = new Random();
        public Dados()
        {
            InitializeComponent();
        }

        private int rolagem(int lados)
        {
            int dadoRolado = rand.Next(1, lados + 1);
            return dadoRolado;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string mensagem = "";
            for (int i = 0; i < (int)numericUpDown1.Value; i++)
            {
               int dado = rolagem(6);
                mensagem += $"Dado: {dado} ";
            }
            MessageBox.Show($"{mensagem}");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string mensagem = "";
            for (int i = 0; i < (int)numericUpDown2.Value; i++)
            {
                int dado = rolagem(8);
                mensagem += $"Dado: {dado} ";
            }
            MessageBox.Show($"{mensagem}");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string mensagem = "";
            for (int i = 0; i < (int)numericUpDown3.Value; i++)
            {
                int dado = rolagem(10);
                mensagem += $"Dado: {dado} ";
            }
            MessageBox.Show($"{mensagem}");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string mensagem = "";
            for (int i = 0; i < (int)numericUpDown4.Value; i++)
            {
                int dado = rolagem(12);
                mensagem += $"Dado: {dado} ";
            }
            MessageBox.Show($"{mensagem}");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string mensagem = "";
            for (int i = 0; i < (int)numericUpDown5.Value; i++)
            {
                int dado = rolagem(20);
                mensagem += $"Dado: {dado} ";
            }
            MessageBox.Show($"{mensagem}");
        }
    }
}
