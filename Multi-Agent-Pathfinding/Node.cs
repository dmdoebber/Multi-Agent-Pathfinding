using System;
using System.Collections.Generic;
using System.Text;


class Node
{
    public int x, y, z;
    public float gCost, hCost;
    public bool walkable;

    public Node parent;

    public float fCost{ get { return gCost + hCost; } }

    public Node(int x, int y, int z, bool walkable, int gCost)
    {
        this.x = x;
        this.y = y;
        this.z = z;
        this.gCost = gCost;
        this.walkable = walkable;
    }
}

