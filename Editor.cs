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
    public partial class Editor : Form
    {
        public Editor()
        {
            InitializeComponent();
        }

        string nome = "";
        Configuracao conf = new Configuracao();
        private void button1_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            var personagem = conf.BuscarChar(textBox4.Text);
            if (personagem != null)
            {
                foreach (Control controle in this.Controls)
                {
                    controle.Visible = true;
                }

                nome = personagem.Name;
                textBox1.Text = personagem.Name;
                textBox2.Text = personagem.Life.ToString();
                textBox3.Text = personagem.Strengh.ToString();
                textBox5.Text = personagem.Energy.ToString();
                textBox6.Text = personagem.Sanity.ToString();
                textBox7.Text = personagem.Inteligent.ToString();
                textBox8.Text = personagem.Agility.ToString();
                textBox9.Text = personagem.Ocult.ToString();
                textBox10.Text = personagem.Endurecy.ToString();

                flowLayoutPanel1.AutoScroll = true;
                if(personagem.habilidades != null)
                {
                    foreach (var habilidade in personagem.habilidades)
                    {
                        UserControl1 pog = new UserControl1(personagem);
                        pog.Habi = habilidade;
                        flowLayoutPanel1.Controls.Add(pog);
                    }
                }
            }
            else
            {
                MessageBox.Show("Personagem não encontrado");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var personagem = conf.BuscarChar(textBox4.Text);
            
            if (personagem != null)
            {
                foreach (var person in conf.CarregarChars())
                {
                    if (person.Name == personagem.Name)
                    {
                        nome = textBox1.Text;
                        person.Name = textBox1.Text;
                        person.Life = int.Parse(textBox2.Text);
                        person.Strengh = int.Parse(textBox3.Text);
                        person.Energy = int.Parse(textBox5.Text);
                        person.Sanity = int.Parse(textBox6.Text);
                        person.Inteligent = int.Parse(textBox7.Text);
                        person.Agility = int.Parse(textBox8.Text);
                        person.Ocult = int.Parse(textBox9.Text);
                        person.Endurecy = int.Parse(textBox10.Text);
                        conf.EditarPersonagem(nome, person);
                        MessageBox.Show($"Alterações salvas para o {nome}");
                    }
                }
            }
            else
            {
                MessageBox.Show("erro ao buscar char");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddHabi add = new AddHabi(nome);
            add.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
                $"Tem certeza de que deseja Excluir o personagem {nome}?",
                "Confirmação",                        
                MessageBoxButtons.YesNo,              
                MessageBoxIcon.Question               
            );

            if (resultado == DialogResult.Yes)
            {
                var person = conf.BuscarChar(nome);
                conf.ExcluirPersonagem(nome);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}
