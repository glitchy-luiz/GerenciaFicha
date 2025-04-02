using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coisaboa
{
    public class Item
    {
        public string Name;
        public int Weight;
        public int Quantidy;
        public string Description;

        public Item(string name, int weight, int quantidy, string description)
        {
            Name = name;
            Weight = weight;
            Quantidy = quantidy;
            Description = description;
        }
    }
}
