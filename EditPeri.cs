using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace coisaboa
{
    public partial class EditPeri: Form
    {
        Configuracao conf = new Configuracao();
        private Pericia peri;
        private Person person;
        public EditPeri(Person personagem, Pericia pericia)
        {
            InitializeComponent();
            peri = pericia;
            person = personagem;
            textBox1.Text = peri.name;
            textBox2.Text = peri.bonus.ToString();
            comboBox1.Items.Add("Força");
            comboBox1.Items.Add("Inteligência");
            comboBox1.Items.Add("Agilidade");
            comboBox1.Items.Add("Presença");
            comboBox1.Items.Add("Vigor");
            comboBox1.SelectedItem = peri.atribute;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var pericia = person.pericias.FirstOrDefault(p => p.Equals(peri));
            pericia.name = textBox1.Text;
            pericia.bonus = int.Parse(textBox2.Text);
            pericia.atribute = comboBox1.SelectedItem.ToString();
            conf.EditarPersonagem(person.Name, person);
            label4.Text = $"Pericia {pericia.name} editada com sucesso!";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
                $"Tem certeza de que deseja Excluir a pericia {peri.name} do personagem {person.Name}?",
                "Confirmação",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
            if (resultado == DialogResult.Yes)
            {
                var pericia = person.pericias.FirstOrDefault(p => p.Equals(peri));
                person.pericias.Remove(pericia);
                conf.EditarPersonagem(person.Name, person);
                label4.Text = $"Habilidade Excluida";
                this.Close();
            }
        }
    }
}
