using DataStructures.Graphs;

namespace DataStructures.UnitTests;

public class DirectedGraphTests
{
    [Fact]
    public void HasNode_NodeDoesNotExists_ReturnsFalse()
    {
        // Arrange
        var directedGraph = new DirectedGraph<string>();
        const string node = "NotExistingNode";

        // Act 
        bool result = directedGraph.HasNode(node);

        // Assert
        result.Should().BeFalse();
    }

    [Fact]
    public void HasNode_NodeExists_ReturnsTrue()
    {
        // Arrange
        var directedGraph = new DirectedGraph<string>();
        const string node = "ExistingNode";

        // Act 
        directedGraph.AddNode(node);
        bool result = directedGraph.HasNode(node);

        // Assert
        result.Should().BeTrue();
    }

    [Fact]
    public void HasNode_NullNode_ReturnsFalse()
    {
        // Arrange
        var directedGraph = new DirectedGraph<string>();
        string? nullValue = null;

        // Act 
        Action action = () => directedGraph.HasNode(nullValue!);

        // Assert
        action.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void AddNode_NewNode_AddsNodeSuccessfully()
    {
        // Arrange
        var directedGraph = new DirectedGraph<string>();
        const string node = "NewNode";

        // Act
        Action action = () => directedGraph.AddNode(node);

        // Assert
        action.Should().NotThrow();
        node.Contains(node).Should().BeTrue();
    }

    [Fact]
    public void AddNode_DuplicateNode_ThrowsException()
    {
        // Arrange
        var directedGraph = new DirectedGraph<string>();
        const string duplicateNode = "DuplicateNode";
        directedGraph.AddNode(duplicateNode);

        // Act
        Action action = () => directedGraph.AddNode(duplicateNode);

        // Assert
        action.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void AddEdge_AddsNodeToNeighborsList()
    {
        // Arrange
        var directedGraph = new DirectedGraph<string>();
        const string from = "from";
        const string to = "to";

        // Act
        directedGraph.AddEdge(from, to);

        // Assert
        directedGraph.GetNeighbors(from).Should().Contain(to);
    }

    [Fact]
    public void AddEdge_OnlyAddsTargetToSourceNeighbors()
    {
        // Arrange
        var directedGraph = new DirectedGraph<string>();
        const string from = "from";
        const string to = "to";

        // Act
        directedGraph.AddEdge(from, to);

        // Assert
        directedGraph.GetNeighbors(to).Should().NotContain(from);
    }
}