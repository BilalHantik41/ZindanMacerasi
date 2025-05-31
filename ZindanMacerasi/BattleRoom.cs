using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ZindanMacerasi
{
    public class BattleRoom : Room
    {
        private Enemy _enemy;
        public event Func<Hero, Enemy, bool> OnBattle;
        public BattleRoom(string name, Enemy enemy) : base(name)
        {
            _enemy = enemy;
        }

        protected override void PerformAction(Hero hero)
        {
            ConsoleHelper.WriteLine($"[Savaş] {Name}' da bir kapı açtınız. Karşınızda {_enemy.Name} çıktı. Onu Öldürmeniz gerekiyor..!!", ConsoleColor.White);
            bool battleResult = OnBattle?.Invoke(hero, _enemy) ?? false; // ?? eğer buradan null değer dönerse sağdakini atar 
            if (battleResult)
            {
                ConsoleHelper.WriteLine($"[KAZANDINIZ] {_enemy.Name}'i yendiniz.. ", ConsoleColor.Blue);
            }
            else
            {
                ConsoleHelper.WriteLine($"[YENİLDİNİZ] {_enemy.Name} sizi ezip geçti.. ", ConsoleColor.Blue);
            }
        }
    }
}
