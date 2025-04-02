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
    public partial class Inventario: Form
    {
        Configuracao conf = new Configuracao();
        private string nome;
        public Inventario(string nome)
        {
            InitializeComponent();
            this.nome = nome;
            buscaItens();
        }

        private void buscaItens()
        {
            var personagem = conf.BuscarChar(nome);
            label1.Text = personagem.itens.Count.ToString();

            if (personagem != null)
            {
                flowLayoutPanel1.Controls.Clear();
                flowLayoutPanel1.AutoScroll = true;
                if (personagem.itens != null)
                {
                    foreach (var item in personagem.itens)
                    {
                        ControlItem pog = new ControlItem(personagem);
                        pog.Item = item;
                        flowLayoutPanel1.Controls.Add(pog);
                    }
                }
            }
            else
            {
                MessageBox.Show("erro ao buscar char");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddItem add = new AddItem(nome);
            add.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            buscaItens();
        }
    }
}
