using System.Collections.Generic;
using System;
namespace Csharp.Graphs
{
    public class IterativeBreadthFirstSearch
    {
        private const int _maxVertices = 5;       
        private bool[] _visited;
        private Queue<int> _queue;
        private int[ , ] adjMatrix;
        public IterativeBreadthFirstSearch() {
          adjMatrix = new int[_maxVertices, _maxVertices];
          _visited = new bool[_maxVertices];
          for(var i = 0; i< _maxVertices; i++) {
              for(var j = 0; j < _maxVertices; j++) {
                  adjMatrix[i, j] = 0;

              }
          }
          _queue = new Queue<int>();

        }
        public void AddEdge(int u, int v) {
            adjMatrix[u, v] = 1;
            adjMatrix[v, u] = 1;
        } 

        public void CreateGraph(int u, int v) {
                AddEdge(u, v);
        }
        public void display(int vertex) {
            Console.WriteLine(vertex);
        }
        public void Bfs(int vertex) {
             _visited[vertex] = true;
            _queue.Enqueue(vertex);
            display(vertex);
            while(!(_queue.Count == 0)) {
                var visitedVertex = _queue.Dequeue(); 
                var v = int.MinValue;
                while((v = getAdjVertex(visitedVertex)) != -1) {
                    _visited[v] = true;
                    _queue.Enqueue(v);
                    display(v);
                }

            }
        }

        public int getAdjVertex(int v) {
            for(var j = 0 ; j < _maxVertices; j++) {
                if(adjMatrix[v, j] == 1 && !_visited[j]) {
                    return j;
                }
            }
            return -1;
        }
        public void PrintAdjacencyMatrix() {
          for(var i = 0; i< _maxVertices; i++) {
              for(var j = 0; j < _maxVertices; j++) {
                  Console.Write(adjMatrix[i, j] + "\t");
              }
              Console.WriteLine();
          }
        }
        public static void Main(string[] args) {
            IterativeBreadthFirstSearch bfs = new IterativeBreadthFirstSearch();
            bfs.CreateGraph(0, 1);
            bfs.CreateGraph(0, 2);
            bfs.CreateGraph(2, 4);
            bfs.CreateGraph(1, 4);
            bfs.CreateGraph(1, 3);
            bfs.CreateGraph(2, 3);
            Console.WriteLine("Adjacency Matrix");
            bfs.PrintAdjacencyMatrix();
            Console.WriteLine("BFS of Graph");
            bfs.Bfs(0);
            
        }
    }
}