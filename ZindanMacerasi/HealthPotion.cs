using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZindanMacerasi
{
    public class HealthPotion : Item
    {
        public HealthPotion() :base("Can İksiri")
        {
        }

        public override void Use(Character character)
        {
            int healAmount = 30;
            character.HP = Math.Min(character.MaxHP, character.HP + healAmount);
            ConsoleHelper.WriteLine($"[İyileşme] {character.Name} can iksiri içildi. {healAmount} kadar canı iyileşti. ", ConsoleColor.Green);



        }
    }
}
