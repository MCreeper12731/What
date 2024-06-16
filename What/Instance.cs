using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace What
{
    internal abstract class Instance
    {
        public char symbol;
        public abstract String onHit();
        public abstract String onTurn();
    }
}
