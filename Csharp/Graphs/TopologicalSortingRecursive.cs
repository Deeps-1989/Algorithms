using System;
using System.Collections.Generic;

namespace Csharp.Graphs {

public class TopologicalSortingRecursive {
  private HashSet<int> set;
  private Stack<int> stack;

  private InternalGraph g;
  public static void Main(string[] args) {
    int v =8;
    Console.WriteLine("In main");
    TopologicalSortingRecursive tsr = new TopologicalSortingRecursive(v);
    tsr.TopoSort(v);
  }
  public TopologicalSortingRecursive(int v) {
    set = new HashSet<int>();
    stack = new Stack<int>();
    g = new InternalGraph(v, true);
    g.AddEdge(0,2); 
    g.AddEdge(1,2);
    g.AddEdge(2,4);
    g.AddEdge(2,5);
    g.AddEdge(4,6);
    g.AddEdge(5,6);
    g.AddEdge(6,7);
    g.AddEdge(6,3);

  }

  public void TopoSort(int v) {
    for(var i = 0; i < v; i++) {
      Console.WriteLine($"check for {i}");
      if(set.Contains(i)) {
        continue;
      }
      TopoSortUtil(i);

    }
    while(!(stack.Count == 0)) {
      Console.WriteLine(stack.Pop());
    }
  }

  public void TopoSortUtil(int start) {
    if(!set.Contains(start)) {
      set.Add(start);
    }

    foreach(var n in g.GetAllNeighbors(start)) {
      Console.WriteLine($"in topo sort util {n}");
      if(!set.Contains(n)) {
      TopoSortUtil(n);
     
      }
       

      
    }
    stack.Push(start); 
  
  }
}

class InternalGraph {
  private int V;
  private bool isDirected;
  private LinkedList<int>[] list;

  public InternalGraph(int v, bool isDirected) {
    this.V = v;
    this.isDirected = isDirected;
    list = new LinkedList<int>[v];
    for(var i = 0; i<v; i++) {
      list[i] = new LinkedList<int>();
    }
  }

  public void AddEdge(int u, int v) {
    list[u].AddLast(v);
    if(!isDirected) {
      list[v].AddLast(u);
    }
  }

  public IEnumerable<int> GetAllNeighbors(int u) {
    
    int[] arr = new int[list[u].Count];
    list[u].CopyTo(arr, 0);
    return new List<int>(arr);
  }



}
}