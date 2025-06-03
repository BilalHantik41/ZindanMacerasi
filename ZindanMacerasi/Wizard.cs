using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ZindanMacerasi
{
    public class Wizard : Enemy
    {
        public Wizard(string name) : base(name,50,100,5, 50)
        {
            Skills.Add(new IceBall());
        }

        public override void SpecialMove(Character target)
        {
            ConsoleHelper.WriteLine($"{Name} buz topu fırlatılıyor. ", ConsoleColor.DarkBlue);
            int damage = Skills[0].Use(this, target);
            target.TakeDamage(damage);
        }
    }
}
