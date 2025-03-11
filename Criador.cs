using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace coisaboa
{
    public partial class Criador : Form
    {
        public Criador()
        {
            InitializeComponent();
        }

        Configuracao conf = new Configuracao();
        private void button1_Click(object sender, EventArgs e)
        {
            string nome = textBox1.Text;
            if (conf.BuscarChar(nome) == null)
            {
                if (Validacao())
                {
                    int vida = int.Parse(textBox2.Text);
                    int energia = int.Parse(textBox4.Text);
                    int sanidade = int.Parse(textBox5.Text);
                    int forca = int.Parse(textBox3.Text);
                    int inteligencia = int.Parse(textBox6.Text);
                    int agilidade = int.Parse(textBox7.Text);
                    int ocultismo = int.Parse(textBox8.Text);
                    int vigor = int.Parse(textBox9.Text);
                    Person person = new Person(nome, vida, energia, sanidade, forca, inteligencia, agilidade, ocultismo, vigor);
                    conf.AdicionarChar(person);
                    MessageBox.Show($"O personagem {nome} foi adicionado");
                }
            }
            else
            {
                MessageBox.Show($"Personagem com nome {nome} já existente");
            }
        }

        private bool Validacao()
        {
            List<System.Windows.Forms.TextBox> textBoxes = new List<System.Windows.Forms.TextBox>{ textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8, textBox9 };

            foreach (var textBox in textBoxes)
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    MessageBox.Show("Preencha todos os campos.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (!int.TryParse(textBox.Text, out _))
                {
                    MessageBox.Show($"O valor em {textBox.Name} não é um número inteiro.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }

            return true;
        }
    }
}
