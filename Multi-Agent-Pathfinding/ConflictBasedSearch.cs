using System;
using System.Collections.Generic;
using System.Text;


class ConflictBasedSearch
{
    PathFinding lowlevel;
    readonly Cubo cubo;

    public ConflictBasedSearch(Cubo cubo)
    {
        this.cubo = cubo;
        lowlevel = new PathFinding(cubo);
    }

    public Tuple<List<Agent>, Node, int> ValidPath(List<List<Node>> solutions, List<Agent> agents)
    {   
        int max_path = -1;


        foreach (List<Node> solution in solutions)
            if (solution != null)
            {
                if (max_path < solution.Count)
                    max_path = solution.Count;
            }
            else
                return null;

        for(int i = 0; i < solutions.Count; i++) //solução agente 1
        {
            for(int j = 0; j < solutions.Count; j++) //solução agente 2
            {
                if (i == j) // se for o mesmo agente não compara
                    continue;
                
                for(int k = 0; k < max_path; k++)
                {
                    Node nk, nl;
                    bool v1 = false, v2 = false;

                    if (k < i) // verifica se passou do ultimo nó                      
                        nk = solutions[i][k];
                    else
                    {
                        nk = solutions[i][solutions[i].Count - 1];
                        v1 = true;
                        if (v2 == v1) break; 
                    }
                        
                    if (k < i) // verifica se passou do ultimo nó 
                        nl = solutions[j][k];
                    else
                    {
                        nl = solutions[j][solutions[j].Count - 1];
                        v2 = true;
                        if (v2 == v1) break;
                    }

                    if (nk == nl) // se os nós forem iguais
                    {
                        List<Agent> conflictingAgents = new List<Agent>();

                        conflictingAgents.Add(agents[i]);
                        conflictingAgents.Add(agents[j]);

                        Console.WriteLine("Conflict ( agent " + i + ", agent " + j + " node (" + nl.x + " , " + nl.y + " ," + nl.z + "), time " + k); 

                        return new Tuple<List<Agent>, Node, int>(conflictingAgents, nl, k);
                    }                       
                }
            }
        }
        return null;
    }


    public List<List<Node>> SolvePath(List<Agent> listAgents)
    {   
        List<NodeCT> openSet = new List<NodeCT>();

        NodeCT currentNode = new NodeCT();

        //R.constraints = 0
        currentNode.constraints.Clear();

        // R.solution = find individual paths using the low - level()
        foreach (Agent agent in listAgents)
        {
            currentNode.solution.Add(lowlevel.FindPath(agent.startNode, agent.targetNode, null));
            agent.solutionPosition = currentNode.solution.Count - 1;
            currentNode.individualCostPath.Add(agent.targetNode.fCost);            
        }

        //R.cost = SIC(R.solution)
        for (int i = 0; i < currentNode.individualCostPath.Count; i++)
            currentNode.cost += currentNode.individualCostPath[i];

        openSet.Add(currentNode);

        while(openSet.Count > 0)
        {
            currentNode = openSet[0];

            // P ← best node from OPEN // lowest solution cost
            foreach (NodeCT node in openSet)
                if (currentNode.cost < node.cost)
                    currentNode = node;

            //Validate the paths in P until a conflict occurs.
            Tuple<List<Agent>, Node, int> conflict = ValidPath(currentNode.solution, listAgents);

            // if P has no conflict then return P.solution // P is goal
            if (conflict == null)
                return currentNode.solution;

            // foreach agent ai in C do 
            foreach(Agent agent in conflict.Item1)
            {
                // A ← new node
                NodeCT newNode = new NodeCT();

                // A.constriants ← P.constriants + (ai, s, t)
                newNode.constraints.Add(new Tuple<Agent, Node, int>(agent, conflict.Item2, conflict.Item3));

                //A.solution ← P.solution.
                newNode.solution = currentNode.solution;
                newNode.individualCostPath = currentNode.individualCostPath;

                //Update A.solution by invoking low-level(ai)
                newNode.solution[agent.solutionPosition] = lowlevel.FindPath(agent.startNode, agent.targetNode, newNode.constraints);
                newNode.individualCostPath[agent.solutionPosition] = agent.targetNode.fCost;

                //A.cost = SIC(A.solution)
                newNode.cost = 0.0f;
                foreach (float value in newNode.individualCostPath)
                    newNode.cost += value;

                //Insert A to OPEN
                openSet.Add(newNode);
            }
            openSet.Remove(currentNode);
        }
        return null;
    }
}

    



