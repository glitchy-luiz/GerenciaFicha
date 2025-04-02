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
    public partial class ControlPeri: UserControl
    {
        private Pericia _peri;
        public Pericia Peri { get { return _peri; } set { _peri = value; Atualizar(); } }
        private Person person;
        public ControlPeri(Person personagem)
        {
            InitializeComponent();
            this.Size = new Size(200, 180);
            person = personagem;
        }

        private void Atualizar()
        {
            label1.Text = _peri.name;
            label2.Text = _peri.atribute;
            label3.Text = _peri.bonus.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var res = Dano.CalcularPericia(_peri, person);
            MessageBox.Show(res);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EditPeri edit = new EditPeri(person, _peri);
            edit.Show();
        }
    }
}
