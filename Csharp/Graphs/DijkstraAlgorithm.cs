using System;
using System.Collections.Generic;
namespace Csharp.Graphs {
  public class AdjListNode {
    internal int Weight {get; set;}
    internal int Vertex {get; set;}
    public AdjListNode(int weight, int vertex) {
      this.Weight = weight;
      this.Vertex = vertex;
    }
  }
  public class Graph {
    internal LinkedList<AdjListNode>[] _adjList;
    public Graph(int V) {
      _adjList = new LinkedList<AdjListNode>[V];
      for( var i = 0; i < V; i++) {
        _adjList[i] = new LinkedList<AdjListNode>();
      }
    }
    public void AddEdge(int source, int destination, int weight) {
       var node = new AdjListNode(weight, destination);
      _adjList[source].AddLast(node);
    }
  }
  public class Heap {
    internal int _size;
    internal int _capacity;
    internal AdjListNode[] arr;
    public Heap(int capacity) {
      _capacity = capacity;
      arr = new AdjListNode[capacity];
    }
    public int GetLeftChild(int i) {
      var lc = 2 * i + 1;
      if(lc >= this._size) {
        return -1;
      }
      return lc;
    }

    public int GetRightChild(int i) {
      var rc = 2 * i + 2;
      if(rc >= this._size) {
        return -1;
      }
      return rc;
    }
    public int GetParent(int i) {
      if(i<=0) {
        return -1;
      }
      return (i-1)/2;
    }
    public void Heapify(int i) {
      var min = i;
      var lc = GetLeftChild(i);
      var rc = GetRightChild(i);
      if(lc != -1 && this.arr[min].Weight > this.arr[lc].Weight) {
        min = lc;
      }
      if(rc != -1 && this.arr[min].Weight > this.arr[rc].Weight) {
        min = rc;
      }
      if(min != i) {
        var temp = this.arr[min].Weight;
        this.arr[min].Weight = this.arr[i].Weight;
        this.arr[i].Weight = temp;
        Heapify(min);
      }
    }
    public AdjListNode ExtractMin() {
      if(this._size == 0) {
        return null;
      }
      var min = this.arr[0];
      this.arr[0] = this.arr[this._size - 1];
      --this._size;
      Heapify(0);
      return min;
    }
    public void InsertKey(int vertex, int weight) {
        var node = new AdjListNode(weight, vertex);
        this.arr[this._size] = node;
        this._size++;
        var i = this._size - 1;
        var parentOfI  = GetParent(i);
        if(parentOfI < 0) {
          return;
        }

        while( i >= 0 && this.arr[i].Weight < this.arr[parentOfI].Weight) {
          this.arr[i] = this.arr[parentOfI];
          i = parentOfI;
          parentOfI = GetParent(parentOfI);
          if(parentOfI < 0)  {
            break;
          }
        }
        this.arr[i] = node;
    }
    public void DecreaseKey(int vertex, int weight) {
         var node = new AdjListNode(weight, vertex);
         var index = -1;
        for(var i = 0; i< this._size; i++) {
          if(this.arr[i].Vertex == vertex) {
            this.arr[i].Weight = weight;
            index = i;
          }
        }
        var parentOfI  = GetParent(index);
        if(parentOfI < 0) {
          return;
        }

        while( index >= 0 && this.arr[index].Weight < this.arr[parentOfI].Weight) {
          this.arr[index] = this.arr[parentOfI];
          index = parentOfI;
          parentOfI = GetParent(parentOfI);
          if(parentOfI < 0)  {
            break;
          }
        }
        this.arr[index] = node;
    }
  }
  public class DijkstraAlgorithm {
    private int[] distance;
    private int[] path;
    private Heap h;

    private int _totalVertices;
    public DijkstraAlgorithm(int v) {
      _totalVertices = v;
      distance = new int[v];
      path = new int[v];
      for(var i = 0; i < v; i++) {
        distance[i] = int.MaxValue;
        path[i] = -1;
      }
      h = new Heap(v);
    }
    public void DoDijkstra(int startVertex, Graph g) {
       distance[startVertex] = 0;
       path[startVertex] = 0;
       h.InsertKey(startVertex, 0);
       while(!(h._size == 0)) {
         var temp = h.ExtractMin();
         foreach(var ver in g._adjList[temp.Vertex]) {
             var v = ver.Vertex;
             var d = distance[temp.Vertex] + ver.Weight;
             if(distance[v] == int.MaxValue) {
               distance[v] = d;
               path[v] = temp.Vertex;
               h.InsertKey(v, d);
             } else if(distance[v] > d){
               distance[v] = d;
               path[v] = temp.Vertex;
               h.DecreaseKey(v, d);
             };
         }
       }
       for(var k=0; k < _totalVertices; k++) {
         Console.WriteLine($"{k}-{path[k]}-{distance[k]}");
       }
    }
    public static void Main(String[] args) {
       var v =9;
      Graph g = new Graph(v);
      DijkstraAlgorithm da = new DijkstraAlgorithm(v);
      g.AddEdge( 0, 1, 4); 
      g.AddEdge( 0, 7, 8); 
      g.AddEdge( 1, 2, 8); 
      g.AddEdge( 1, 7, 11); 
      g.AddEdge( 2, 3, 7); 
      g.AddEdge( 2, 8, 2); 
      g.AddEdge( 2, 5, 4); 
      g.AddEdge( 3, 4, 9); 
      g.AddEdge( 3, 5, 14); 
      g.AddEdge( 4, 5, 10); 
      g.AddEdge( 5, 6, 2); 
      g.AddEdge( 6, 7, 1); 
      g.AddEdge( 6, 8, 6); 
      g.AddEdge( 7, 8, 7);
      da.DoDijkstra(0, g);
    }
  }
}