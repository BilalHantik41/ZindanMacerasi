using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ZindanMacerasi
{
    public class Hero : Character
    {
        public Hero(string name, int maxHp, int maxMP, int level, int hp) : base(name, maxHp, maxMP, level, hp)
        {


        }

        public Hero(string name) : base(name, 100, 50, 1, 150)
        {
            Skills.Add(new FireballSkill());
            Skills.Add(new HealingSkill());
        }
        public int Experience { get; private set; }
        public List<Item> Inventory { get; } = new List<Item>();

        public void AddItemToInventory(Item item)
        {
            Inventory.Add(item);
            ConsoleHelper.WriteLine($"[Eşya] {Name} yeni eşya kazandı. {item.Name} çantaya eklendi. ", ConsoleColor.DarkBlue);
        }

        public void UseItem(Item item)
        {
            if (Inventory.Contains(item))
            {
                item.Use(this);
                Inventory.Remove(item);

            }
            else
            {
                ConsoleHelper.WriteLine($"[Hata] {Name} in inventorysinde {item.Name} eşyası kalmamış. ", ConsoleColor.Red);
            }
        }

        public void GainExperience(int exp)
        {
            Experience += exp;
            ConsoleHelper.WriteLine($"[Deneyim] {Name} {exp} deneyim puanı kazanıldı...", ConsoleColor.Green);

            if (Experience >= 100 * Level)
            {
                LevelUp();
            }
        }
        public void LevelUp()
        {
            Level++;
            MaxHP += 20;
            MaxHP += 10;

            HP = MaxHP;
            MP = MaxMP;
            Experience -= 100 * (Level - 1);
            ConsoleHelper.WriteLine($"[Seviye Atladı] {Name} seviye atladı.", ConsoleColor.Magenta);

        }
    }
}
