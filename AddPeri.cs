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
    public partial class AddPeri: Form
    {
        public AddPeri()
        {
            InitializeComponent();
            comboBox1.Items.Add("Força");
            comboBox1.Items.Add("Inteligência");
            comboBox1.Items.Add("Agilidade");
            comboBox1.Items.Add("Ocultismo");
            comboBox1.Items.Add("Vigor");
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string selecionado = comboBox1.SelectedItem.ToString();
            string nome = textBox1.Text.Trim();
            int bonus = int.Parse(textBox2.Text);

            if (selecionado == "Força")
            {
                Pericia pericia = new Pericia(nome, selecionado, bonus);
            }
        }
    }
}
