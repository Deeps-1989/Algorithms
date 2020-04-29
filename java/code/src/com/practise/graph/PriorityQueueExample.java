package com.practise.graph;

import java.util.Comparator;
import java.util.PriorityQueue;

public class PriorityQueueExample {
  public static void main(String args[]) {
    PriorityQueue<String> pq = new PriorityQueue<String>(3, new StringComparator());
    pq.add("10");
    pq.add("20");
    pq.add("30");

    while (!pq.isEmpty()) { 
      System.out.println(pq.poll()); 
    }
  }
}
  class StringComparator implements Comparator<String> {

    @Override
    public int compare(String s1, String s2) {
      System.out.println("s1 "+ s1 + ", s2 " + s2);
      return s2.compareTo(s1);
    }
  }