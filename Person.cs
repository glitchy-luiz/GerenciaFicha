using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coisaboa
{
    public class Person
    {
        public int Id;
        public string Name;
        public int Life;
        public int Energy;
        public int Sanity;

        public int Strengh;
        public int Inteligent;
        public int Agility;
        public int Ocult;
        public int Endurecy;

        public List<Habi> habilidades = new List<Habi> { };
        public List<Pericia> pericias = new List<Pericia> { };
        public Person(string nome, int vida, int energia, int sanidade, int forca, int inteli, int agilidade, int ocultismo, int vigor) 
        {
            Name = nome;
            Life = vida;
            Energy = energia;
            Sanity = sanidade;
            Strengh = forca;
            Inteligent = inteli;
            Agility = agilidade;
            Ocult = ocultismo;
            Endurecy = vigor;
        }
    }
}
