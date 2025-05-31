using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZindanMacerasi
{
    public abstract class Character : ICharacter
    {
        protected Character(string name, int maxHP, int maxMP, int level, int hp)
        {
            Name = name;
            MaxHP = maxHP;
            MaxMP = maxMP;
            Level = level;
            HP = hp;
        }
        public string Name { get; }

        public int HP { get; set; }

        public int MaxHP { get; protected set; }

        public int MP { get; set; }

        public int MaxMP { get; protected set; }

        public int Level { get; protected set; }

        protected Random Random { get; } = new Random();

        public List<Skill> Skills { get; } = new List<Skill>();

        


        public virtual void Attack(ICharacter target)
        {
            
            int damage = Random.Next(Level, Level * 2);
            target.TakeDamage(damage);
            ConsoleHelper.WriteColored($"[Saldırı] {Name}, {target.Name}' e {damage} hasar veriyor! POW! BAM!", ConsoleColor.Yellow);
            
        }

        public virtual void TakeDamage(int damage)
        {
            HP -= damage;
            ConsoleHelper.WriteColored($"[Hasar] {Name} {damage} hasar alıyor. Kalan HP: {HP}", ConsoleColor.Red);
            
        }

        public virtual void UseSkill(Skill skill, ICharacter target)
        {
            if (MP >= skill.MPCost)
            {
                MP -= skill.MPCost;
                int damage = skill.Use(this, target);
                ConsoleHelper.WriteColored($"[Skill] !!! {Name}'in {target.Name} 'e karşı {skill.SkillName} skill'ini kullandı. ", ConsoleColor.DarkCyan);

                if (damage > 0)
                {
                    target.TakeDamage(damage);

                }
                else
                {
                    ConsoleHelper.WriteColored($"[NotEnoughMana] !!! {Name}'in {skill.SkillName} kullanmak için yeterli manası yok. ", ConsoleColor.Blue);
                }
            }
        }
            

    }
    } 


    
