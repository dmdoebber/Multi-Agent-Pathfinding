using System;
using System.Collections.Generic;

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
            agents.Add(new Agent(cubo, 2, 0, 0, 7, 9, 9));
            agents.Add(new Agent(cubo, 3, 0, 0, 6, 9, 9));
            agents.Add(new Agent(cubo, 4, 0, 0, 5, 9, 9));
            agents.Add(new Agent(cubo, 5, 0, 0, 4, 9, 9));
            agents.Add(new Agent(cubo, 6, 0, 0, 3, 9, 9));
            agents.Add(new Agent(cubo, 7, 0, 0, 2, 9, 9));
            agents.Add(new Agent(cubo, 8, 0, 0, 1, 9, 9));
            agents.Add(new Agent(cubo, 9, 0, 0, 0, 9, 9));







            Console.ReadKey();
        }
    }
}
