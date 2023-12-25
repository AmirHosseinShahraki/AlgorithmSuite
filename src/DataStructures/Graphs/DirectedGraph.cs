namespace DataStructures.Graphs;

public class DirectedGraph<T> : BaseGraph<T> where T : notnull
{
    public override void AddEdge(T from, T to)
    {
        AddNodeIfNotExist(from);
        AddNodeIfNotExist(to);

        AdjacencyList[from].Add(to);
    }
}