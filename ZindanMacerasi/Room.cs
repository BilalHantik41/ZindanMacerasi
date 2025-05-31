using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ZindanMacerasi
{
    public abstract class Room
    {
        public  string Name { get; protected set; }
        public event Action<Hero> OnEnter;
        public event Action<Hero> OnExit;
        protected Room(string name)
        {
            Name = name;    
        }
        public virtual void Enter(Hero hero)
        {   ConsoleHelper.WriteLine($"[ODA] {hero.Name}, {Name} odasına giriyor.", ConsoleColor.Green);
            OnEnter?.Invoke(hero);
            PerformAction(hero);
            OnExit?.Invoke(hero);

        }
        protected abstract void PerformAction(Hero hero);

    }
}
