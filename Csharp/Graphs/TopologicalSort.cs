using System;
using System.Collections.Generic;
namespace Csharp.Graphs {
  public class TopologicalSort {

      private int[,] _adjMatrix;
      private int[] _indegree;

      private bool[] _visited;

      private Stack<int> _stack;
      private const int _maxVertices = 6;

      public TopologicalSort() {
            _adjMatrix = new int[_maxVertices,_maxVertices];
            _indegree = new int[_maxVertices];
            _stack = new Stack<int>();
            _visited = new bool[_maxVertices];
            for(var i = 0; i<_maxVertices; i++) {
              for(var j = 0; j<_maxVertices;j++) {
                _adjMatrix[i,j] = 0;
              }
            }
      }

      public void AddEdge(int u, int v) {
        _adjMatrix[u, v] = 1;
        _indegree[v]++;
      }
      public void CreateGraph(int u, int v) {
          AddEdge(u, v);
      }

      public void TopologicalSorting() {
         for(var i = 0; i < _maxVertices; i++ ) {
           if(_indegree[i] == 0) {
             _stack.Push(i);
             _visited[i] = true;
           }
         }
         
         while(!(_stack.Count == 0)) {
           var currVertex = _stack.Pop();
           display(currVertex);
           var q = int.MinValue;
           while((q = getAdjVertex(currVertex)) != -1) {
            --_indegree[q];
           
           if(_indegree[q] == 0) {
             _visited[q] = true;
             _stack.Push(q);
           }
           }
        }
      }
      public void display(int u) {
        Console.WriteLine(u);
      }
      public int getAdjVertex(int u) {
        for(var j = 0; j < _maxVertices; j++) {
        if(_adjMatrix[u, j] == 1 && _indegree[j] == 0 ) {
          return j;
         }
        }
        return -1;
      }
      public static void Main(String[] args) {
         TopologicalSort ts = new TopologicalSort();
         ts.CreateGraph(5, 0);
         ts.CreateGraph(4, 0);
         ts.CreateGraph(5, 2);
         ts.CreateGraph(4, 1);
         ts.CreateGraph(2, 3);
         ts.CreateGraph(3, 1);
         ts.TopologicalSorting();

      }
  }
}
