using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace What
{
    internal class Master
    {

        static Instance[,] map;
        static Player player = new Player();
        static Generator generator = new Generator();
        static Queue<string> messageQueue = new Queue<string>();
        public static void Main(string[] args)
        {
            player = new Player();
            GenerateWorld();

            while (true)
            {
                Console.Clear();
                Render(map);
                ConsoleKey key = Console.ReadKey().Key;
                switch (key)
                {
                    case ConsoleKey.W:
                        if (Move(player.position, player.position + (-1, 0)))
                            player.position += (-1, 0);
                        break;
                    case ConsoleKey.A:
                        if (Move(player.position, player.position + (0, -1)))
                            player.position += (0, -1);
                        break;
                    case ConsoleKey.S:
                        if (Move(player.position, player.position + (1, 0)))
                            player.position += (1, 0);
                        break;
                    case ConsoleKey.D:
                        if (Move(player.position, player.position + (0, 1)))
                            player.position += (0, 1);
                        break;
                }
            }

        }

        public static void GenerateWorld()
        {
            player.position.x = -1;
            player.position.y = -1;
            while (player.position.x == -1)
            {
                map = generator.GenerateWalls(30);
                generator.PlacePlayer(map, player);
                generator.PlaceEntities(map);
            }
        }

        static void Render(Instance[,] map)
        {
            for (int x = 0; x < map.GetLength(0); x++)
            {
                for (int y = 0; y < map.GetLength(1); y++)
                {
                    if (map[x, y] == null)
                    {
                        Console.Write("  ");
                        continue;
                    }
                    Console.ForegroundColor = map[x, y].color;
                    Console.Write(map[x, y].symbolLeft);
                    Console.Write(map[x, y].symbolRight);
                }
                if (messageQueue.Count != 0)
                {
                    Console.WriteLine(messageQueue.Dequeue());
                } else
                {
                    Console.WriteLine();
                }
            }
        }

        static bool Move(Point from, Point to)
        {
            if (map[to.x, to.y] == null)
            {
                map[to.x, to.y] = map[from.x, from.y];
                map[from.x, from.y] = null;
                return true;
            }
            string result = map[to.x, to.y].onHit();
            if (!string.IsNullOrWhiteSpace(result))
            {
                messageQueue.Enqueue(result);
            }
            return false;
        }

    }
}
