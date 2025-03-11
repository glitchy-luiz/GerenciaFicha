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
    public partial class AddHabi: Form
    {
        private Person perso;
        private string name;
        Configuracao conf = new Configuracao();
        public AddHabi(string nome)
        {
            InitializeComponent();
            name = nome;
            perso = conf.BuscarChar(nome);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (perso != null)
            {
                Habi a = new Habi(textBox1.Text, textBox2.Text, textBox3.Text);
                perso.habilidades.Add(a);
                Configuracao configuracao = new Configuracao();
                configuracao.EditarPersonagem(name, perso);
                label4.Text = $"Habilidade {textBox1.Text} adicionada para o personagem {perso.Name}";
            }
        }
    }
}
