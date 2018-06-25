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



        }
        
       



        
       





        return null;
    }


    
}

    



