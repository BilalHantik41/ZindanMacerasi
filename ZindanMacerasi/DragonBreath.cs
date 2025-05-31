using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZindanMacerasi
{
    public class DragonBreath : Skill
    {
        public DragonBreath() : base("Ejderha Nefesi", "Ejderha Nefesini Üflüyor." ,25)
        {
            
        }

        public override int Use(Character user, ICharacter target)
        {
            return user.Level * 6 + new Random().Next(10,40);    
        }
    }
}
