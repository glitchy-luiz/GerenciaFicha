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
    public partial class AddItem: Form
    {
        private Person person;
        private string name;
        Configuracao conf = new Configuracao();
        public AddItem(string nome)
        {
            InitializeComponent();
            this.name = nome;
            this.person = conf.BuscarChar(nome);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var nome = textBox1.Text;
            var peso = int.Parse(textBox3.Text);
            var quantidade = int.Parse(textBox4.Text);
            var descricao = textBox2.Text;

            Item item = new Item(nome, peso, quantidade, descricao);
            person.itens.Add(item);
            conf.EditarPersonagem(name, person);
            MessageBox.Show("Item adicionado com sucesso!");
        }
    }
}
