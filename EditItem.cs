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
    public partial class EditItem: Form
    {
        private Item item;
        private Person person;
        Configuracao conf = new Configuracao();
        public EditItem(Item item, Person person)
        {
            InitializeComponent();
            this.item = item;
            this.person = person;
            textBox1.Text = item.Name;
            textBox3.Text = item.Weight.ToString();
            textBox4.Text = item.Quantidy.ToString();
            textBox2.Text = item.Description;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            item.Name = textBox1.Text;
            item.Weight = int.Parse(textBox3.Text);
            item.Quantidy = int.Parse(textBox4.Text);
            item.Description = textBox2.Text;
            conf.EditarPersonagem(person.Name, person);
            MessageBox.Show("item editado com sucesso");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
                $"Tem certeza de que deseja Excluir o item {item.Name} do personagem {person.Name}?",
                "Confirmação",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );
            if (resultado == DialogResult.Yes)
            {
                var itema = person.itens.FirstOrDefault(p => p.Equals(item));
                person.itens.Remove(itema);
                conf.EditarPersonagem(person.Name, person);
                MessageBox.Show("item excluido");
                this.Close();
            }
        }
    }
}
