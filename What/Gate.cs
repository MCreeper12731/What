using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace What
{
    internal class Gate : Instance
    {

        public Gate()
        {
            symbolLeft = '[';
            symbolRight = ']';
            color = ConsoleColor.Yellow;
        }
        public override string onHit()
        {
            Master.GenerateWorld();
            return "You enter deeper into the dungeon";
        }

        public override string onTurn()
        {
            return "";
        }
    }
}
