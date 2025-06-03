using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZindanMacerasi
{
    public class Goblin : Enemy
    {
        public Goblin(string name) : base(name, 30,10,1,30)
        {
            Skills.Add(new SneackAttackSkill());
        }
        public override void SpecialMove(Character target)
        {
            
            ConsoleHelper.WriteLine($"{Name} sinsi bir saldırı yapıyor. ", ConsoleColor.Red);
            int damage = Skills[0].Use(this, target);
            target.TakeDamage(damage);
        }


    }
}
