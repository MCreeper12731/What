using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace What
{
    internal class Wall : Instance
    {
        public Wall()
        {
            symbolLeft = '█';
            symbolRight = '█';
        }
        public override string onHit()
        {
            return "Stop hitting yourself";
        }
        public override string onTurn()
        {
            return "";
        }

    }
}
