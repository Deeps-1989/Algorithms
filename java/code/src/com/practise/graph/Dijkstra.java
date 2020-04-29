package com.practise.graph;

import java.util.ArrayList;
import java.util.Comparator;
import java.util.HashSet;
import java.util.Iterator;
import java.util.LinkedList;
import java.util.List;
import java.util.PriorityQueue;

public class Dijkstra {
  private final PriorityQueue<Node> pq;
  private final int[] distance;
  private final int[] parent;
  private final int V;
  private HashSet<Integer> set;
  public Dijkstra(final int V) {
    this.V = V;
    distance = new int[V];
    parent = new int[V];
    pq = new PriorityQueue<Node>(V, new NodeComparator());
    for (int i = 0; i < V; i++) {
      distance[i] = Integer.MAX_VALUE;
      parent[i] = -1;
    }
    set = new HashSet<>(); 
  }

  public void shortestPathFromSource(DijkstraGraph g, int s) {
    Node startNode = new Node(s, 0);
    distance[s] = 0;
    pq.add(startNode);
    while(!pq.isEmpty()) {
      int v = pq.remove().dest;
      set.add(v);
      System.out.println("v is " + v);
      for(Node n : g.getAllAdjecentVertex(v))  {
        if(set.contains(n.dest)) {
          System.out.println("pq contsins n "  + n.dest);
          continue;
        }
        int neigh = n.dest;
        int cost = n.cost;
        if(distance[neigh] > distance[v] + cost) {
          distance[neigh] = distance[v] + cost;
          // this can add 2 elements if in case distance of existing element in PQ changes
          // it wont make any effect since it will insert same element with updated priority
          // so when extracting that duplicate element only element with minimum priority will be extracted 
          // but it can will tkae extra space
          pq.add(n);
        }
      }
      System.out.println("Elements in pq after processing  " + v);
      Iterator<Node> it = pq.iterator();
      while(it.hasNext()) {
        Node x = it.next();
        System.out.println(x.dest + " -- " + x.cost);
      }
    }
  }

  public void displayDistance(int s) {
    for(int i = 0; i < V; i ++) {
      System.out.println( s + " -- " + i + " is " + distance[i]);
    }
  }

  public static void main(final String args[]) {
    DijkstraGraph dg = new DijkstraGraph(true, 6);
    dg.addEdge(0,1,1);
    dg.addEdge(1,4,4);
    dg.addEdge(0,3,2);
    dg.addEdge(3,4,1);
    dg.addEdge(0,2,3);
    dg.addEdge(2,5,1);
    dg.addEdge(5,4,6);
    Dijkstra d = new Dijkstra(6);
    d.shortestPathFromSource(dg, 0);
    d.displayDistance(0);
  }

}

class DijkstraGraph {

  private final boolean isDirected;
  private final LinkedList<Node>[] adjList;
  DijkstraGraph(boolean isDirected, int V) {
    this.isDirected  = isDirected;
    adjList = new LinkedList[V];
    for(int i = 0; i < V; i++) {
      adjList[i] = new LinkedList<>();
    }
  }

  public void addEdge(int u, int v, int weight) {
    Node node1 = new Node(v, weight);
    adjList[u].add(node1);
    if(!isDirected) {
      Node node2 = new Node(u, weight);
      adjList[v].add(node2);
    }
  }

  public List<Node> getAllAdjecentVertex(int u) {
    List<Node> list = new ArrayList<Node>();

    Iterator<Node> it = adjList[u].iterator();
    while(it.hasNext()) {
      list.add(it.next());
    }
    return list;
  }

}

class Node {
  int dest;
  int cost;
  public Node (int dest, int weight) {
    this.dest = dest;
    this.cost = weight;
  }
}
class NodeComparator implements Comparator<Node> {

  @Override
  public int compare(Node n1, Node n2) {
    if(n1.cost < n2.cost) {
      return -1;
    } else if(n1.cost > n2.cost) {
      return 1;
    }
    return 0;
  }
}