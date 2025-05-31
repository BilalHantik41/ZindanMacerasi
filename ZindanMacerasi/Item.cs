using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZindanMacerasi
{
    public abstract class Item
    {
        public string Name { get; }
        public string Description { get; }

        protected Item(string name)
        {
            Name = name;
            

        }
        public abstract void Use(Character character);
       
        public override bool Equals(object? obj)
        {
            if (obj is Item otherItem)
                return Name == otherItem.Name;
            return false;

        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}
