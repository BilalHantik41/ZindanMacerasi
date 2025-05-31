using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZindanMacerasi
{
    public class TreasureRoom : Room
    {

        private Item _treasure;
        public TreasureRoom(string name, Item treasure) : base(name)
        {
            _treasure = treasure;   
        }
        protected override void PerformAction(Hero hero)
        {
            ConsoleHelper.WriteLine($"[HAZİNE] Efsane {Name}'de  {_treasure.Name} adında bir sandık buldunuz. ", ConsoleColor.Yellow);
            hero.AddItemToInventory(_treasure);
        }
    }
}
