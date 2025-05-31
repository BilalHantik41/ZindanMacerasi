using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZindanMacerasi
{
    public class IceBall : Skill
    {
        public IceBall() : base("Buz Saldırısı", "Yoğun Buz Topu Saldırısı", 5)
        {
            
        }
        public override int Use(Character user, ICharacter target)
        {
            return user.Level * 6 + new Random().Next(3, 7);
        }
    }
}
