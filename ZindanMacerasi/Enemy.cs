using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZindanMacerasi
{
    public abstract class Enemy : Character
    {
        protected Enemy(string name, int maxHP, int maxMP, int level, int hp) : base(name, maxHP, maxMP, level, hp)
        {

        }

        public abstract void SpecialMove(Character target);

        
    }
}
