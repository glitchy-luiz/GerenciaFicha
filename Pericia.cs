using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coisaboa
{
    public class Pericia
    {
        public string atribute;
        public int bonus;
        public string name;

        public Pericia(string nome, string atributo, int extra)
        {
            name = nome;
            atribute = atributo;
            bonus = extra;
        }
    }
}
