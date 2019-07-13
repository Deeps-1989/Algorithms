using System.Collections.Generic;
using System;
namespace Csharp.Graphs {
  public class IterativeDepthFirstSearch 
  {
    private const int _maxVertices = 5;
    private int[,] _adjMatrix;
    private bool[] _visited;
    private Stack<int> _stack;

    public IterativeDepthFirstSearch() {
      _stack = new Stack<int>();
      _visited = new bool[_maxVertices];
      _adjMatrix = new int[_maxVertices, _maxVertices];
      for(var i = 0; i  < _maxVertices; i++) {
        for(var j = 0; j < _maxVertices; j++) {
            _adjMatrix[i,j] = 0; 
        }
      }
    }
    public void AddEdge(int u, int v) {
      _adjMatrix[u, v] = 1;
      _adjMatrix[v, u] = 1; 
    }
    
    public void DisplayVertex(int u) {
      Console.WriteLine(u);
    }
    public void Dfs(int vertex) {
      _visited[vertex] = true;
      _stack.Push(vertex);
      DisplayVertex(vertex);  
      while(!(_stack.Count == 0)) {
          var currentVertex = _stack.Pop();
          var adjVertex = GetAdjVertex(currentVertex);
          if(adjVertex != -1) {
            _visited[adjVertex] = true;
            DisplayVertex(adjVertex);
            _stack.Push(adjVertex);
          }
      }
    }
    public void PrintAdjacencyMatrix() {
      for(var i = 0; i  < _maxVertices; i++) {
        for(var j = 0; j < _maxVertices; j++) {
           Console.Write(_adjMatrix[i,j] + "\t"); 
        }
        Console.WriteLine();
      }
    }
    public int GetAdjVertex(int v) {
      for(var j = 0; j < _maxVertices; j++) {
          if(_adjMatrix[v, j] == 1 && !_visited[j]) {
            return j;
          } 
      }
      return -1;
    }
    public void CreateGraph(int u, int v) {
      AddEdge(u, v);
    }

    public static void Main(string[] args) {
       IterativeDepthFirstSearch dfs = new IterativeDepthFirstSearch();
        dfs.CreateGraph(0, 1);
        dfs.CreateGraph(0, 2);
        dfs.CreateGraph(2, 4);
        dfs.CreateGraph(1, 4);
        dfs.CreateGraph(1, 3);
        dfs.CreateGraph(2, 3);
        Console.WriteLine("Adjacency Matrix");
        dfs.PrintAdjacencyMatrix();
        Console.WriteLine("BFS of Graph");
        dfs.Dfs(0);
    }

  }
}