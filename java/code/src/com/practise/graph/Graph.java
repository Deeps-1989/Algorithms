
// Graph.java
package com.practise.graph;

import java.util.List;
import java.util.ArrayList;
import java.util.Map;
import java.util.HashMap;
import java.util.Collection;

public class Graph<T> {
  private List<Edge<T>> allEdges;
  private Map<Long, Vertex<T>> verticesMap;
  private boolean isDirected;

  public Graph(boolean isDirected) {
    allEdges = new ArrayList<>();
    verticesMap = new HashMap<>();
    this.isDirected = isDirected;
  }

  public Collection<Vertex<T>> getAllVertices() {
    return verticesMap.values();
  }

  public void addEdge(long id1, long id2) {
    addEdge(id1, id2, 0);
  }

  public void addEdge(long id1, long id2, int weight) {
    Vertex<T> v1 = null;
    Vertex<T> v2 = null;

    if (verticesMap.containsKey(id1)) {
      v1 = verticesMap.get(id1);
    } else {
      v1 = new Vertex<T>(id1);
      verticesMap.put(id1, v1);
    }

    if (verticesMap.containsKey(id2)) {
      v2 = verticesMap.get(id2);
    } else {
      v2 = new Vertex<T>(id2);
      verticesMap.put(id2, v2);
    }

    Edge<T> edge = new Edge<T>(v1, v2, weight);
    allEdges.add(edge);
    v1.addAdjacentVertices(v2, edge);
    if (!isDirected) {
      v2.addAdjacentVertices(v2, edge);
    }
  }

  public String toString() {
    String result = "";
    for (Edge<T> edge : allEdges) {
      result += edge.v1.id + "--" + edge.v2.id + "\n";
    }
    return result;
  }

  class Vertex<U> {
    private long id;
    private U data;
    private List<Edge<U>> edges = new ArrayList<>();
    private List<Vertex<U>> adjacentVertices = new ArrayList<>();

    public Vertex(long id) {
      this.id = id;
    }

    public void setData(U data) {
      this.data = data;
    }

    public long getId() {
      return id;
    }

    public void addAdjacentVertices(Vertex<U> v, Edge<U> edge) {
      adjacentVertices.add(v);
      edges.add(edge);
    }

    public List<Vertex<U>> getAdjacentVertices() {
      return adjacentVertices;
    }
  }

  class Edge<V> {

    private Vertex<V> v1;
    private Vertex<V> v2;
    private int weight;

    public Edge(Vertex<V> v1, Vertex<V> v2, int weight) {
      this.v1 = v1;
      this.v2 = v2;
      this.weight = weight;
    }

    public Edge(Vertex<V> v1, Vertex<V> v2) {
      this.v1 = v1;
      this.v2 = v2;
    }
  }

  public static void main(String args[]) {
    Graph<Integer> graph = new Graph<>(true);
    graph.addEdge(1, 2);
    graph.addEdge(1, 3);
    graph.addEdge(2, 4);
    graph.addEdge(2, 5);
    graph.addEdge(4, 8);
    graph.addEdge(3, 6);
    graph.addEdge(3, 7);
    graph.addEdge(6, 9);
    System.out.println(graph);
  }

}