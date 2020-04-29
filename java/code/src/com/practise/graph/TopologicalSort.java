// topological sort
package com.practise.graph;

import java.util.Collection;
import java.util.HashSet;
import java.util.Set;
import java.util.Stack;

public class TopologicalSort<T> {
  private Set<Long> visited;
  private Stack<Graph<T>.Vertex<T>> stack;

  public TopologicalSort() {
    visited = new HashSet<>();
    stack = new Stack<>();
  }

  public void doTopoSort(Graph<T> g) {
    Collection<Graph<T>.Vertex<T>> vertex = g.getAllVertices();
    for (Graph<T>.Vertex<T> v : vertex) {
      if (visited.contains(v.getId())) {
        continue;
      }
      TopoUtil(v, visited, stack);
    }

    while (!stack.isEmpty()) {
      System.out.println(stack.pop().getId());

    }

  }

  public void TopoUtil(Graph<T>.Vertex<T> vertex, Set<Long> visited, Stack<Graph<T>.Vertex<T>> stack) {
    if (visited.contains(vertex.getId())) {
      return;
    }
    visited.add(vertex.getId());
    for (Graph<T>.Vertex<T> v : vertex.getAdjacentVertices()) {
      TopoUtil(v, visited, stack);
    }
    stack.push(vertex);

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
    TopologicalSort<Integer> sort = new TopologicalSort<>();
    sort.doTopoSort(graph);
  }

}