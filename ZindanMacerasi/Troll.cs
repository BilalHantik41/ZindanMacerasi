using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZindanMacerasi
{
    public  class Troll : Enemy
    {
        public Troll(string name) :base(name, 100,20,3,100)
        {
            Skills.Add(new SmashSkill());    
        }
        public override void SpecialMove(Character target)
        {
            ConsoleHelper.WriteLine($"{Name} güçlü bir ezme saldırısı yapıyor. ", ConsoleColor.DarkRed);
            Skills[0].Use(this, target);
        }
    }
}
