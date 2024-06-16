using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace What
{
    internal class Generator
    {

        Random random = new();
        Wall wallInstance = new Wall();

        public Instance[,] GenerateWalls(int size)
        {

            bool[,] boolMap = InitWalls(size);
            boolMap = IterateWalls(IterateWalls(IterateWalls(boolMap)));

            Instance[,] map = new Instance[size, size];

            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    if (boolMap[x, y])
                    {
                        map[x, y] = wallInstance;
                    } else
                    {
                        map[x, y] = null;
                    }
                }
            }
            return map;
        }

        private bool[,] InitWalls(int size)
        {
            bool[,] map = new bool[size, size];

            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    if (x == 0 || y == 0 || x == map.GetLength(0) - 1 || y == map.GetLength(1) - 1)
                    {
                        map[x, y] = true;
                        continue;
                    }
                    if (random.NextDouble() < 0.45)
                    {
                        map[x, y] = true;
                    }
                    else
                    {
                        map[x, y] = false;
                    }
                }
            }
            return map;
        }
        private bool[,] IterateWalls(bool[,] previousMap)
        {
            bool[,] newMap = new bool[previousMap.GetLength(0), previousMap.GetLength(1)];

            for (int x = 0; x < newMap.GetLength(0); x++)
            {
                for (int y = 0; y < newMap.GetLength(1); y++)
                {
                    int aliveNeighbors = NeighborWalls(previousMap, x, y);
                    if (aliveNeighbors > 4) newMap[x, y] = true;
                    else newMap[x, y] = false;
                }
            }
            return newMap;
        }

        private int NeighborWalls(bool[,] map, int x, int y)
        {
            int counter = 0;
            for (int dx = -1; dx < 2; dx++)
            {
                for (int dy = -1; dy < 2; dy++)
                {
                    if (x + dx < 0 || x + dx >= map.GetLength(0))
                    {
                        counter++;
                        continue;
                    }
                    if (y + dy < 0 || y + dy >= map.GetLength(1))
                    {
                        counter++;
                        continue;
                    }
                    if (map[x + dx, y + dy]) counter++;
                }
            }
            return counter;
        }

        public void PlacePlayer(Instance[,] map, Player player)
        {
            for (int x = 0; x < map.GetLength(0); x++)
            {
                for (int y = 0; y < map.GetLength(1); y++)
                {
                    if (map[x, y] == null)
                    {
                        int spaceSize = FloodFill(map, x, y, new bool[map.GetLength(0), map.GetLength(1)]);
                        if (spaceSize > map.GetLength(0) * map.GetLength(1) / 4)
                        {
                            map[x, y] = player;
                            player.position.x = x;
                            player.position.y = y;
                            return;
                        } else
                        {
                            Console.WriteLine("Failed attempt at: " + x + ", " + y);
                        }
                    }
                }
            }
        }

        private int FloodFill(Instance[,] map, int x, int y, bool[,] visited)
        {
            if (x < 0 || y < 0 || x >= map.GetLength(0) || y >= map.GetLength(1) || visited[x, y] || map[x, y] != null) return 0;
            visited[x, y] = true;
            return FloodFill(map, x - 1, y, visited) + FloodFill(map, x + 1, y, visited) + FloodFill(map, x, y - 1, visited) + FloodFill(map, x, y + 1, visited) + 1;
        }

        public void PlaceEntities(Instance[,] map)
        {
            Point randomPoint;

            do
            {
                randomPoint = Point.Random(map.GetLength(0), map.GetLength(1));
            } while (map[randomPoint.x, randomPoint.y] != null);

            map[randomPoint.x, randomPoint.y] = new Gate();

        }
        
    }
}
