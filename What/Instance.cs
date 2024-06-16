using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace What
{
    internal abstract class Instance
    {
        public char symbolRight;
        public char symbolLeft;
        public ConsoleColor color = ConsoleColor.Gray;
        public abstract string onHit();
        public abstract string onTurn();
    }
}
