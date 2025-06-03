using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZindanMacerasi
{
    public class DragonLord : Enemy
    {
        public DragonLord(string name) : base(name, 500, 200 , 10,500) 
        {
            Skills.Add(new DragonBreath());
        }
        public override void SpecialMove(Character target)
        {
            ConsoleHelper.WriteLine($"{Name} yüksek hasarlı ejderha nefesini üflüyor!!!. ", ConsoleColor.DarkRed);
            int damage = Skills[0].Use(this, target);
            target.TakeDamage(damage);

        }
    }
}
