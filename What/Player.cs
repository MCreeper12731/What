using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace What
{
    internal class Player : Instance
    {

        public Point position;
        public int health;
        public int armor;
        public int gold;
        //public Item weapon;
        //public Item armor;
        public Player()
        {
            symbolLeft = '<';
            symbolRight = '>';
            color = ConsoleColor.Green;
            position = new Point(-1, -1);
            health = 10;
            armor = 0;
            gold = 0;
        }

        public override string onHit()
        {
            return "";
        }

        public override string onTurn()
        {
            throw new NotImplementedException();
        }
    }
}
