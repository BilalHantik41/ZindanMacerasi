using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZindanMacerasi
{
    public class HealingSkill : Skill
    {
        public HealingSkill() : base("Healing", "Dont Move Healing Now.", 8) { }
        public override int Use(Character user, ICharacter target)
        {
            int healAmount = user.Level * 2;
            user.HP = Math.Min(user.MaxHP, user.HP + healAmount);

            ConsoleHelper.WriteColored($"[Healed] {user.Name} şifali sularla iyileşti ve {healAmount} Hp iyileşti.", ConsoleColor.Green);
            return 0;
        }

      

    }
}

