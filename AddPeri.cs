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
        private Person perso;
        private string name;
        Configuracao conf = new Configuracao();
        public AddPeri(string nome)
        {
            InitializeComponent();
            comboBox1.Items.Add("Força");
            comboBox1.Items.Add("Inteligência");
            comboBox1.Items.Add("Agilidade");
            comboBox1.Items.Add("Presença");
            comboBox1.Items.Add("Vigor");
            comboBox1.SelectedIndex = 0;

            name = nome;
            perso = conf.BuscarChar(nome);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (perso != null)
            {
                string selecionado = comboBox1.SelectedItem.ToString();
                string nome = textBox1.Text.Trim();
                int bonus = int.Parse(textBox2.Text);
                Pericia pericia = new Pericia(nome, selecionado, bonus);
                perso.pericias.Add(pericia);
                conf.EditarPersonagem(name, perso);
                label4.Text = $"Pericia {nome} adicionada ao {name}";
            }

        }
    }
}
