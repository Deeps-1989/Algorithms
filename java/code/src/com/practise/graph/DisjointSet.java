package com.practise.graph;

import java.util.Map;
import java.util.HashMap;

public class DisjointSet {

  private Map<Long, Node> map = new HashMap<>();

  class Node {
    long id;
    int rank;
    Node parent;
  }

  public void makeSet(long id) {
    Node node1 = new Node();
    node1.id = id;
    node1.rank = 0;
    node1.parent = node1;
    map.put(id, node1);
  }

  public Node findSet(long id) {
    Node v = map.get(id);
    Node parent = v.parent;
    if (v == parent) {
      return parent;
    }
    v.parent = findSet(parent.id);
    return v;
  }

  public void union(long id1, long id2) {

    Node par1 = findSet(id1);
    Node par2 = findSet(id2);

    if (par1 != par2) {
      Node v1 = map.get(id1);
      Node v2 = map.get(id2);
      if (par1.rank >= par2.rank) {
        v2.parent = par1;
        par1.rank += 1;
      } else {
        v1.parent = par2;
        par2.rank += 1;

      }
    }
  }

  public static void main(String args[]) {
    DisjointSet ds = new DisjointSet();
    ds.makeSet(1);
    ds.makeSet(2);
    ds.makeSet(3);
    ds.makeSet(4);
    ds.makeSet(5);
    ds.makeSet(6);
    ds.makeSet(7);

    ds.union(1, 2);
    ds.union(2, 3);
    ds.union(4, 5);
    ds.union(6, 7);
    ds.union(5, 6);
    ds.union(3, 7);

    System.out.println(ds.findSet(1).id);
    System.out.println(ds.findSet(2).id);
    System.out.println(ds.findSet(3).id);
    System.out.println(ds.findSet(4).id);
    System.out.println(ds.findSet(5).id);
    System.out.println(ds.findSet(6).id);
    System.out.println(ds.findSet(7).id);

  }

}