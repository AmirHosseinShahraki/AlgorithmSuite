namespace DataStructures.Graphs;

public class UndirectedGraph<T> : BaseGraph<T> where T : notnull
{
    public override void AddEdge(T from, T to)
    {
        AddNodeIfNotExist(from);
        AddNodeIfNotExist(to);

        AdjacencyList[from].Add(to);
        AdjacencyList[to].Add(from);
    }
}