using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace What
{
    internal class Point
    {
        public int x;
        public int y;
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public static Point operator +(Point p1, Point p2)
            => new Point(p1.x + p2.x, p1.y + p2.y);
        public static Point operator +(Point p1, (int x, int y) p2)
            => new Point(p1.x + p2.x, p1.y + p2.y);

        public static Point Random(int limitX, int limitY)
        {
            Random random = new Random();
            return new Point(random.Next(0, limitX), random.Next(0, limitY));
        }
    }
}
