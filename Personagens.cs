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
    public partial class Personagens : Form
    {
        Configuracao conf = new Configuracao();
        public Personagens()
        {
            InitializeComponent();
            List<Person> listachars = new List<Person>();
            listachars = conf.CarregarChars();
            for (int i = 0; i < listachars.Count; i++)
            {
                listBox1.Items.Add($"Nome: {listachars[i].Name}, Vida: {listachars[i].Life}, Energia: {listachars[i].Energy}, Sanidade: {listachars[i].Sanity}");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            List<Person> listachars = new List<Person>();
            listachars = conf.CarregarChars();
            for (int i = 0; i < listachars.Count; i++)
            {
                listBox1.Items.Add($"Nome: {listachars[i].Name}, Vida: {listachars[i].Life}, Energia: {listachars[i].Energy}, Sanidade: {listachars[i].Sanity}");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel2.Controls.Clear();
            var person = conf.BuscarChar(textBox1.Text);
            if (person != null)
            {
                label2.Text = $"Nome: {person.Name}";
                label3.Text = $"Vida: {person.Life.ToString()}";
                label4.Text = $"Energia: {person.Energy.ToString()}";
                label5.Text = $"Força: {person.Strengh.ToString()}";
                label7.Text = $"Inteligência: {person.Inteligent.ToString()}";
                label8.Text = $"Agilidade: {person.Agility.ToString()}";
                label9.Text = $"Ocultismo: {person.Ocult.ToString()}";
                label10.Text = $"Vigor: {person.Endurecy.ToString()}";
                label11.Text = $"Sanidade: {person.Sanity.ToString()}";

                flowLayoutPanel1.AutoScroll = true;
                if (person.habilidades != null)
                {
                    foreach (var habilidade in person.habilidades)
                    {
                        UserControl1 pog = new UserControl1(person);
                        pog.Habi = habilidade;
                        flowLayoutPanel1.Controls.Add(pog);
                    }
                }

                flowLayoutPanel2.AutoScroll = true;
                if (person.pericias != null)
                {
                    foreach (var pericia in person.pericias)
                    {
                        ControlPeri tela = new ControlPeri(person);
                        tela.Peri = pericia;
                        flowLayoutPanel2.Controls.Add(tela);
                    }
                }
            }
            else
            {
                MessageBox.Show("Nenhum personagem foi encontrado!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
