using System;
using System.Collections.Generic;
using System.Text;


class Cubo
{
    public Node[,,] cubo { get; private set; }
    private int size;

    public Cubo(int size)
    {
        this.size = size;
        criarCubo();
    }

    public void criarCubo()
    {
        int peso = 0;
        bool walkable;
        Random rnd = new Random();
        cubo = new Node[size, size, size];

        for(int x = 0; x < size; x++)
            for(int y = 0; y < size; y++)
                for(int z = 0; z < size; z++)
                {
                    if (rnd.Next(4) == 1)
                        walkable = false;
                    else
                    {
                        walkable = true;
                        peso = rnd.Next(1, 10);
                    }
                    cubo[x, y, z] = new Node(x, y, z, walkable, peso);
                }    
    }

    public List<Node> getNeighbours(Node node)
    {
        List<Node> neighbours = new List<Node>();

        if (node.x + 1 < size) neighbours.Add(cubo[node.x + 1, node.y, node.z]);
        if (node.x - 1 >= 0)   neighbours.Add(cubo[node.x - 1, node.y, node.z]);
        if (node.y + 1 < size) neighbours.Add(cubo[node.x, node.y + 1, node.z]);
        if (node.y - 1 >= 0)   neighbours.Add(cubo[node.x, node.y - 1, node.z]);
        if (node.z + 1 < size) neighbours.Add(cubo[node.x, node.y, node.z + 1]);
        if (node.z - 1 >= 0)   neighbours.Add(cubo[node.x, node.y, node.z - 1]);

        return neighbours;
    }

    public Node getNodeFromCube(int x, int y, int z)
    {
        if ((x < size && x >= 0) && (y < size && y >= 0) && (z < size && z >= 0))
            return cubo[x, y, z];
        return null;
    }
}
