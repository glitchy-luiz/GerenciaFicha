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
    public partial class EditHabi: Form
    {
        Configuracao conf = new Configuracao();
        private Habi habi;
        private Person person;
        public EditHabi(Person personagem, Habi habilidade)
        {
            InitializeComponent();
            habi = habilidade;
            person = personagem;
            textBox1.Text = habi.Name;
            textBox2.Text = habi.Desc;
            textBox3.Text = habi.Dano;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var habilidade = person.habilidades.FirstOrDefault(p => p.Equals(habi));
            habilidade.Name = textBox1.Text;
            habilidade.Desc = textBox2.Text;
            habilidade.Dano = textBox3.Text;
            conf.EditarPersonagem(person.Name, person);
            label4.Text = $"Habilidade {habi.Name} editada com sucesso!";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
                $"Tem certeza de que deseja Excluir a habilidade {habi.Name} do personagem {person.Name}?",
                "Confirmação",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
            if (resultado == DialogResult.Yes)
            {
                var habilidade = person.habilidades.FirstOrDefault(p => p.Equals(habi));
                person.habilidades.Remove(habilidade);
                conf.EditarPersonagem(person.Name, person);
                label4.Text = $"Habilidade Excluida";
            }
        }
    }
}
