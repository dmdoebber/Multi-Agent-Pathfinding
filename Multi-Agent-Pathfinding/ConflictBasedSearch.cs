using System;
using System.Collections.Generic;
using System.Text;


class ConflictBasedSearch
{
    PathFinding lowlevel;
    Cubo cubo;

    public ConflictBasedSearch(Cubo cubo)
    {
        this.cubo = cubo;
        lowlevel = new PathFinding(cubo);
    }

    public Tuple<Agent, Agent, Node, int> ValidPath(List<List<Node>> solutions, List<Agent> agents)
    {
        Tuple<Agent, Agent, Node, int> conflict = null;
        
        int max_path = -1;

        foreach (List<Node> solution in solutions)
            if (max_path < solution.Count)
                max_path = solution.Count;

        for(int i = 0; i < max_path; i++)
        {
            for(int j = 0; j < max_path; j++)
            {
                if (i == j) continue;
                

            }
        }





        





        return conflict;
    }


    public List<List<Node>> SolvePath(List<Agent> listAgents, Cubo cubo)
    {   
        List<NodeCT> openSet = new List<NodeCT>();

        NodeCT currentNode = new NodeCT();

        //R.constraints = 0
        currentNode.constraints.Clear();

        // R.solution = find individual paths using the low - level()
        foreach (Agent agent in listAgents)
        {
            currentNode.solution.Add(lowlevel.FindPath(agent.startNode, agent.targetNode));
            currentNode.individualCostPath.Add(agent.targetNode.fCost);            
        }

        //R.cost = SIC(R.solution)
        for (int i = 0; i < currentNode.individualCostPath.Count; i++)
            currentNode.cost += currentNode.individualCostPath[i];

        openSet.Add(currentNode);

        while(openSet.Count > 0)
        {
            currentNode = openSet[0];

            foreach (NodeCT node in openSet)
                if (currentNode.cost < node.cost)
                    currentNode = node;

            





        }
        
       



        
       





        return null;
    }


    
}

    



