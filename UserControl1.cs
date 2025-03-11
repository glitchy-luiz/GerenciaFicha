using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace coisaboa
{
    public partial class UserControl1: UserControl
    {
        private Habi _habi;
        public Habi Habi { get { return _habi; } set { _habi = value; Atualizar(); } }
        private Person person;
        public UserControl1(Person personagem)
        {
            InitializeComponent();
            this.Size = new Size(400, 150);
            person = personagem;
        }

        private void Atualizar()
        {
            label1.Text = _habi.Name;
            label2.Text = _habi.Dano;
            label3.Text = _habi.Desc;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            var res = Dano.CalcularDano(label2.Text);
            MessageBox.Show(res);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EditHabi edit = new EditHabi(person, _habi);
            edit.Show();
        }
    }
}
