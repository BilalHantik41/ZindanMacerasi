using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZindanMacerasi
{
    public abstract class Skill
    {
        public string SkillName { get;}
        public string SkillDescription { get;}

        public int MPCost {get;}

        protected Skill(string skillName, string skillDescription, int mpCost   )
        {
            SkillName = skillName;
            SkillDescription = skillDescription;
            MPCost = mpCost;
        }

        public abstract int Use(Character user, ICharacter target);
    }
}
