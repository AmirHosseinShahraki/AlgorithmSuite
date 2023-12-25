namespace DataStructures.Graphs;

public abstract class BaseGraph<T> where T : notnull
{
    protected readonly Dictionary<T, HashSet<T>> AdjacencyList = new();

    public bool HasNode(T node)
    {
        return AdjacencyList.ContainsKey(node);
    }

    public void AddNode(T node)
    {
        if (AdjacencyList.ContainsKey(node))
        {
            throw new ArgumentException("An element with the same key already exists.", nameof(node));
        }

        AdjacencyList[node] = new HashSet<T>();
    }

    protected void AddNodeIfNotExist(T node)
    {
        if (!HasNode(node))
        {
            AddNode(node);
        }
    }

    public IEnumerable<T> GetNeighbors(T vertex)
    {
        if (AdjacencyList.TryGetValue(vertex, out HashSet<T>? neighbors))
        {
            return neighbors;
        }

        return Enumerable.Empty<T>();
    }

    public abstract void AddEdge(T from, T to);
}