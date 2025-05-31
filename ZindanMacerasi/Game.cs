using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace ZindanMacerasi
{
    public class Game
    {
        private Hero _hero;
        private List<Room> _rooms;
        private DragonLord _dragonLord;

        public Game()
        {
            InitializeGame();

        }
        private void InitializeGame()
        {
            _hero = new Hero("Akatera");
            _rooms = new List<Room>
            {
                CreateBattleRoom("DarkRoom", new Goblin("Sinsi Goblin")),
                new TreasureRoom("Eski Hazine Odası", new HealthPotion()),
                new RestRoom("Huzurlu Bahçe"),
                CreateBattleRoom("Ateş Çukuru", new Troll("Koca Kafa")),
                new TreasureRoom("Gizli Chest", new ManaPotion()),
                new RestRoom("Şifali Pınar"),
                CreateBattleRoom("Büyücünün Kulesi", new Wizard("Kötü Büyücü"))


            };
            _dragonLord = new DragonLord("BÖYÜK EJDER");

        }
        private BattleRoom CreateBattleRoom(string name, Enemy enemy)
        {
            var battleRoom = new BattleRoom(name, enemy);
            battleRoom.OnBattle += Battle;
            return battleRoom;

        }
        
        public void Start()
        {
            ConsoleHelper.WriteColored($"====== ZİNDAN MACERASINA HOŞ GELDİNİZ ======", ConsoleColor.Blue);
            ConsoleHelper.WriteColored($"Siz {_hero.Name}, zindan da başarılar canım", ConsoleColor.Blue);
            foreach (var room in _rooms)
            {
                if (_hero.HP <= 0)
                {
                    ConsoleHelper.WriteColored($"[OYUN BİTTİ] Maalesef yenildiniz. GO NEXT TIME ", ConsoleColor.Red);
                    return;

                }
                else
                {
                    room.Enter(_hero);
                    DisplayHeroStatus();
                }
            }
            if (_hero.HP > 0)
            {
                FinalBossBattle();
            }
        }
             private bool Battle(Hero hero, Enemy enemy)
        {
            while (hero.HP > 0 && enemy.HP > 0)
            {
                PerformTurn(hero, enemy);
                if (enemy.HP > 0)
                {
                    PerformTurn(enemy, hero);
                }

            }
            if (enemy.HP <= 0)
            {
                ConsoleHelper.WriteColored($"[KAZANDINIZ.!!] {enemy.Name} yendiniz. Büyük Bir zafer Kazandınız..", ConsoleColor.Blue);
                hero.GainExperience(enemy.Level * 20);
                return true;

            }
            return false;
        }
        private void PerformTurn(ICharacter attacker, ICharacter defender)
        {
            ConsoleHelper.WriteColored($"\n[SIRA] {attacker.Name}'in sırası..!!", ConsoleColor.Green);
            ConsoleHelper.WriteColored($"HP {attacker.HP}/ {attacker.MaxHP}, MP {attacker.MP}/{attacker.MaxMP}", ConsoleColor.Cyan);
            if (attacker is Hero hero)
            {
                PerformHeroTurn(hero, defender);
            }
            else if (attacker is Enemy enemy)
            {
                PerformEnemyTurn(enemy, defender);
            }
        }
        private void PerformHeroTurn(Hero hero, ICharacter enemy)
        {
            ConsoleHelper.WriteColored("\nNe Yapmak İstersiniz?", ConsoleColor.Green);
            ConsoleHelper.WriteColored("\n1. Saldır", ConsoleColor.Red);
            ConsoleHelper.WriteColored("\n2. Beceri Kullan", ConsoleColor.Yellow);
            ConsoleHelper.WriteColored("\n3. Eşya Kullan", ConsoleColor.Blue);

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    hero.Attack(enemy);
                    break;
                case "2":
                    ChooseAndUseSkill(hero, enemy);
                    break;
                case "3":
                    ChooseAndUseItem(hero);
                    break;

                default:
                    ConsoleHelper.WriteColored($"[Hata] geçersiz bir seçim yaptınız. Sıranızı basit atack yaparak geçtiniz.", ConsoleColor.Red);
                    hero.Attack(enemy);
                    break;
            }
        }

            private void PerformEnemyTurn(Enemy enemy, ICharacter hero)
        {
            enemy.SpecialMove(hero as Character);

        }

        private void ChooseAndUseSkill(Hero hero, ICharacter enemy)
        {
            ConsoleHelper.WriteColored("\nHangi Beceriyi Kullanmak İstersiniz?\n", ConsoleColor.Blue);
            for (int i = 0; i < hero.Skills.Count; i++)
            {
                ConsoleHelper.WriteColored($"{i + 1}. {hero.Skills[i].SkillName} (MP Cost: {hero.Skills[i].MPCost})", ConsoleColor.Green);
            }
            if (int.TryParse(Console.ReadLine(), out int skillChoice) && skillChoice > 0 && skillChoice <= hero.Skills.Count)
            {
                hero.UseSkill(hero.Skills[skillChoice - 1], enemy);
            }
            else
            {
                ConsoleHelper.WriteColored($"[HATA] geçersiz beceri seçimi. Varsıyalan saldırı Yapıldı.", ConsoleColor.DarkGray);
                hero.Attack(enemy);

            }
        }
        private void ChooseAndUseItem(Hero hero)
        {
            if (!hero.Inventory.Any())
            {
                ConsoleHelper.WriteColored("\n[HATA] çantanızda kullanmak için bir item yok..!!\n", ConsoleColor.Red);
                return;
            }

            ConsoleHelper.WriteColored("\nHangi Eşyayı Kullanmak istersiniz?\n", ConsoleColor.Cyan);
            for (int i = 0; i < hero.Inventory.Count; i++)
            {
                ConsoleHelper.WriteColored($"{i + 1}. {hero.Inventory[i].Name}", ConsoleColor.Green);
            }
            if (int.TryParse(Console.ReadLine(), out int itemChoice) && itemChoice > 0 && itemChoice <= hero.Inventory.Count)
            {
                Item chosenItem = hero.Inventory[itemChoice - 1];
                hero.UseItem(chosenItem);

            }
            else
            {
                ConsoleHelper.WriteColored($"[HATA] Eşya Seçerken Hata yaptınız.. ", ConsoleColor.Red);

            }


        }
        private void DisplayHeroStatus()
        {
            ConsoleHelper.WriteColored("\\n ------- Kahraman Durumu ------\n", ConsoleColor.Blue);
            ConsoleHelper.WriteColored($"\nSeviye: {_hero.Level}\n", ConsoleColor.Green);
            ConsoleHelper.WriteColored($"\nHP: {_hero.HP}\n", ConsoleColor.Green);
            ConsoleHelper.WriteColored($"\nMp: {_hero.MP}\n", ConsoleColor.Green);
            ConsoleHelper.WriteColored($"\nExp: {_hero.Experience}\n", ConsoleColor.Green);
            ConsoleHelper.WriteColored($"\nInventory: {string.Join(",", _hero.Inventory.Select(i => i.Name))}\n", ConsoleColor.Cyan);
        }

        private void FinalBossBattle()
        {
            ConsoleHelper.WriteColored($"\n[SON BOSS] SON ODADASINIZ. ORTAM ÇOK TEHLİKELİ DİKKAT ET. {_dragonLord}'a Selam ÇAK BAKIYIM\n", ConsoleColor.Red);
            Battle(_hero, _dragonLord);

            bool victorious = Battle(_hero, _dragonLord);
            if (victorious)
            {
                ConsoleHelper.WriteColored($"\n[ZAFER] TEBRİK EDERİM. EJDERHA'yı Kediye Çevirdin..\n", ConsoleColor.Blue);
            }
            else
            {
                ConsoleHelper.WriteColored($"\n[KAYBETTİNİZ] ORTAM TEHLİKELİ DEMİŞTİM.\n", ConsoleColor.Red);
            }
        }
    }
}
