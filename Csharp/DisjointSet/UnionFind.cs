using System;
using System.Collections.Generic;

namespace Csharp.DisjointSet {

  public class InternalNode {
    public InternalNode parent;
    public int rank;
    public int data;

    public InternalNode(int val) {
      data = val;
      parent = this;
    }
  }
  public class UnionFind {

    private IDictionary<int, InternalNode> map;

    public UnionFind(int x) {
      map = new Dictionary<int, InternalNode>();
    }
    public static void Main(string[] args) {
      UnionFind uf  = new UnionFind(5);
      uf.MakeSet(0);
      uf.MakeSet(1);
      uf.MakeSet(2);
      uf.MakeSet(3);
      uf.MakeSet(4);
      
      uf.Union(1,2);
      uf.Union(2,0);
      uf.Union(0,3);
      uf.Union(0,4);
      uf.Display();

    }

    public void MakeSet(int data) {
      var node = new InternalNode(data);
      map.Add(data, node);
    }

    public InternalNode FindSet(InternalNode node) {
      var parent = node.parent;
      if(node == parent) {
        return node;
      } 
      node.parent = FindSet(node.parent);
      return node.parent;
    }

    public void Union(int x, int y) {
      var node_x = map[x];
      var node_y = map[y];

      var parent_x = FindSet(node_x);
      var parent_y = FindSet(node_y);

      if(parent_x.data == parent_y.data) {
        return;
      }

      if(parent_x.rank <= parent_y.rank) {
        parent_x.parent = parent_y;
        parent_y.rank = (parent_x.rank == parent_y.rank) ? parent_x.rank + 1: parent_y.rank; 
      } else {
        parent_y.parent = parent_x;
      }
      Display();
    }
    public void Display() {
      foreach(var node in map.Values) {
        Console.Write(" data " + node.data  + " node parent " + node.parent.GetHashCode() +" rank " + node.rank);
        
      } 
      Console.WriteLine();
      
    }
  }
}