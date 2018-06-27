using System;
using System.Collections.Generic;
using System.Text;

class PathFinding
{
    Cubo cubo;

    public PathFinding(Cubo cubo)
    {
        this.cubo = cubo;
    }

    public List<Node> FindPath(Node startNode, Node targetNode, List<Tuple<Agent, Node, int>> constraints)
    {
        if(startNode == null) { Console.Write("Invalid start point! \n"); return null; }
        if(targetNode == null) { Console.Write("Ivalid end point! \n"); return null; }

        startNode.walkable = true;
        targetNode.walkable = true;

        List<Node> openSet = new List<Node>();
        HashSet<Node> closedSet = new HashSet<Node>();

        openSet.Add(startNode);

        while(openSet.Count > 0)
        {
            Node currentNode = openSet[0];

            for (int i = 1; i < openSet.Count; i++)
                if (openSet[i].fCost < currentNode.fCost || openSet[i].fCost == currentNode.fCost && openSet[i].hCost < currentNode.hCost)
                    currentNode = openSet[i];

            openSet.Remove(currentNode);
            closedSet.Add(currentNode);

            if(currentNode == targetNode)
            {
                List<Node> path = new List<Node>();
                for (Node currNode = targetNode; currNode != startNode; currNode = currNode.parent)
                    path.Add(currNode);
                path.Add(startNode);
                path.Reverse();

                return path;
            }

            foreach (Node neighbour in cubo.getNeighbours(currentNode))
            {
                bool haveContraint = false;
                if (constraints != null)
                    haveContraint = constraints.Exists(node => node.Item2 == neighbour);
                
                if (!neighbour.walkable || closedSet.Contains(neighbour) || haveContraint)
                    continue;

                float newMovementeCostToNeighbour = currentNode.gCost + neighbour.gCost;

                if (newMovementeCostToNeighbour < neighbour.gCost || !openSet.Contains(neighbour))
                {
                    neighbour.gCost = newMovementeCostToNeighbour;
                    neighbour.hCost = getDistance(neighbour, targetNode);
                    neighbour.parent = currentNode;

                    if (!openSet.Contains(neighbour))
                        openSet.Add(neighbour);
                }
            }
        }
        Console.Write("\ncaminho não encontrado!");
        return null;
    }

    public int getDistance(Node nStart, Node nEnd)
    {
        return Convert.ToInt32(Math.Sqrt(Math.Pow(nStart.x - nEnd.x, 2) + Math.Pow(nStart.y - nEnd.y, 2) + Math.Pow(nStart.z - nEnd.z, 2)));
    }
}

