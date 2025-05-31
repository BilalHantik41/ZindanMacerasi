using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZindanMacerasi
{
    public class ManaPotion : Item
    {
        public ManaPotion() : base("Mana İksiri")
        { }
        public override void Use(Character character)
        {
            int manaAmount = 20;
            character.MP = Math.Min(character.MaxMP, character.MP+ manaAmount);
            ConsoleHelper.WriteLine($"[Mana Doldu] {character.Name} mana iksiri içildi. {manaAmount} kadar manası yenilendi. ", ConsoleColor.Blue);
        }
    }
}
