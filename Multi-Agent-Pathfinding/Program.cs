using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Multi_Agent_Pathfinding
{
    class Program
    {
        static void Main(string[] args)
        {
            Cubo cubo = new Cubo(10);

            List<Agent> agents = new List<Agent>();

            agents.Add(new Agent(cubo, 0, 0, 0, 9, 9, 9));
            agents.Add(new Agent(cubo, 1, 0, 0, 8, 9, 9));
            agents.Add(new Agent(cubo, 1, 0, 2, 7, 9, 9));
            agents.Add(new Agent(cubo, 2, 0, 2, 6, 9, 9));
            agents.Add(new Agent(cubo, 2, 0, 3, 5, 9, 9));
            agents.Add(new Agent(cubo, 2, 0, 5, 4, 9, 9));
            agents.Add(new Agent(cubo, 3, 0, 5, 3, 9, 9));
            agents.Add(new Agent(cubo, 4, 0, 5, 2, 9, 9));
            agents.Add(new Agent(cubo, 4, 0, 6, 1, 9, 9));
            agents.Add(new Agent(cubo, 4, 1, 6, 0, 9, 9));

            ConflictBasedSearch cbs = new ConflictBasedSearch(cubo);

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            List<List<Node>> solutions = cbs.SolvePath(agents);

            stopWatch.Stop();

            Console.WriteLine("\nRunTime (milliseconds) " + stopWatch.ElapsedMilliseconds);


            if (solutions != null)
            {
                int max_path = -1;
                foreach (List<Node> solution in solutions)
                {
                    if (solution == null) break;

                    if (max_path < solution.Count)
                        max_path = solution.Count;
                }

                Console.SetWindowPosition(0, 0);
                Console.SetWindowSize(Console.LargestWindowWidth-20, Console.LargestWindowHeight-10);
                Console.WriteLine();

                for (int i = 0; i < solutions.Count; i++)              
                    Console.Write("Agent  ("+i+")\t");

                for(int linha = 0; linha < max_path; linha++)
                {
                    Console.WriteLine();
                    for (int coluna = 0; coluna < solutions.Count; coluna++)
                    {
                        if (solutions[coluna] == null) break;
                        if (linha < solutions[coluna].Count)
                            Console.Write("(" + solutions[coluna][linha].x + " , " + solutions[coluna][linha].y + " ," + solutions[coluna][linha].z + ")   \t");
                        else
                            Console.Write("             \t");
                    }
                }
            }
            Console.ReadKey();
        }
    }
}
