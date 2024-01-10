using DataStructures.Graphs;

namespace DataStructures.UnitTests;

public class UndirectedGraphTests
{
    [Fact]
    public void HasNode_NodeDoesNotExists_ReturnsFalse()
    {
        // Arrange
        var undirectedGraph = new UndirectedGraph<string>();
        const string node = "NotExistingNode";

        // Act 
        bool result = undirectedGraph.HasNode(node);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void HasNode_NodeExists_ReturnsTrue()
    {
        // Arrange
        var undirectedGraph = new UndirectedGraph<string>();
        const string node = "ExistingNode";

        // Act 
        undirectedGraph.AddNode(node);
        bool result = undirectedGraph.HasNode(node);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void HasNode_NullNode_ReturnsFalse()
    {
        // Arrange
        var undirectedGraph = new UndirectedGraph<string>();
        string? nullValue = null;

        // Act 
        Action action = () => undirectedGraph.HasNode(nullValue!);

        // Assert
        action.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void AddNode_NewNode_AddsNodeSuccessfully()
    {
        // Arrange
        var undirectedGraph = new UndirectedGraph<string>();
        const string node = "NewNode";

        // Act
        Action action = () => undirectedGraph.AddNode(node);

        // Assert
        action.Should().NotThrow();
        node.Contains(node).Should().BeTrue();
    }

    [Fact]
    public void AddNode_DuplicateNode_ThrowsException()
    {
        // Arrange
        var undirectedGraph = new UndirectedGraph<string>();
        const string duplicateNode = "DuplicateNode";
        undirectedGraph.AddNode(duplicateNode);

        // Act
        Action action = () => undirectedGraph.AddNode(duplicateNode);

        // Assert
        action.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void AddEdge_AddsNodeToNeighborsList()
    {
        // Arrange
        var undirectedGraph = new UndirectedGraph<string>();
        const string from = "from";
        const string to = "to";

        // Act
        undirectedGraph.AddEdge(from, to);

        // Assert
        undirectedGraph.GetNeighbors(from).Should().Contain(to);
    }

    [Fact]
    public void AddEdge_AddsNeighborsToBothTargetAndSource()
    {
        // Arrange
        var undirectedGraph = new UndirectedGraph<string>();
        const string from = "from";
        const string to = "to";

        // Act
        undirectedGraph.AddEdge(from, to);

        // Assert
        undirectedGraph.GetNeighbors(from).Should().Contain(to);
        undirectedGraph.GetNeighbors(to).Should().Contain(from);
    }
}