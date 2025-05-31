using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZindanMacerasi
{
    public class FireballSkill : Skill
    {
        public FireballSkill() : base("FireBall", "Ateş Topu Fırlatır.", 5)
        {

        }
        public override int Use(Character user, ICharacter target)
        {
            return user.Level * 3;
        }
    }
}
