using System;
using System.Collections.Generic;
using System.Text;


class Agent
{
    public Node startNode;
    public Node targetNode;
    
    public Agent(Cubo cubo, int xS, int yS, int zS, int xE, int yE, int zE)
    {
        startNode = cubo.getNodeFromCube(xS, yS, zS);
        targetNode = cubo.getNodeFromCube(xE, yE, zE);
    }
}

