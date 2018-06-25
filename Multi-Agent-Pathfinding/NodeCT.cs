using System;
using System.Collections.Generic;
using System.Text;

class NodeCT
{
    public List<List<Node>> solution = new List<List<Node>>();
    public List<Tuple<Agent, Node, int>> constraints = new List<Tuple<Agent, Node, int>>();
    public List<float> individualCostPath = new List<float>();
    public float cost = 0;
}

