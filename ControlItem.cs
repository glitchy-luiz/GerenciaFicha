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
    public partial class ControlItem: UserControl
    {
        private Person person;
        private Item _item;
        public Item Item { get { return _item; } set { _item = value; Atualizar(); } }
        public ControlItem(Person personagem)
        {
            InitializeComponent();
            this.Size = new Size(200, 180);
            person = personagem;
        }

        private void Atualizar()
        {
            label1.Text = _item.Name;
            label2.Text = _item.Description;
            label3.Text = $"Peso: {_item.Weight}";
            label4.Text = $"Qtd: {_item.Quantidy}";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _item.Quantidy -= 1;
            Configuracao conf = new Configuracao();
            conf.EditarPersonagem(person.Name, person);

            if(_item.Quantidy <= 0)
            {
                var item = person.itens.FirstOrDefault(p => p.Equals(Item));
                person.itens.Remove(item);
                conf.EditarPersonagem(person.Name, person);
            }
        }
    }
}
