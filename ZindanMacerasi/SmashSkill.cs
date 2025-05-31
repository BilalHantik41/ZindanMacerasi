using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZindanMacerasi
{
    public class SmashSkill : Skill

    {
        public SmashSkill() : base("Ezici Darbe", "Zıplayıp Kafasına Vurur.", 8)
        {
            
        }

        public override int Use(Character user, ICharacter target)
        {
            return user.Level * 7;
        }
    }
}
