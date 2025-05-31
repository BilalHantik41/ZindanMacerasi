using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZindanMacerasi
{
    public class SneackAttackSkill : Skill
    {
        public SneackAttackSkill() : base("Sinsi Saldırı", "Sinsice Arkadan Critik Vurur.", 5)
        {

        }
    
        public override int Use(Character user, ICharacter target)
        {
            return user.Level * 2 + new Random().Next(1,6);
        }
    }
}
