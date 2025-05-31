using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ZindanMacerasi
{
    public class RestRoom : Room
    {
        public RestRoom(string name) : base(name) 
        {
            
        }
        protected override void PerformAction(Hero hero)
        {
            ConsoleHelper.WriteLine($"[Dinlenme] {Name},  huzurlu bir oda iyice dinlenin. ", ConsoleColor.Green);
            hero.HP = hero.MaxHP;
            hero.MP = hero.MaxMP;
            ConsoleHelper.WriteLine($"[DİNLENDİ] {Name}, karakteriniz yeterince dinlendi Marş Marş!!! ", ConsoleColor.Green);
        }
    }
}
