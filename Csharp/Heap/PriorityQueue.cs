using System;
using System.Collections.Generic;
namespace Csharp.Heap {
  public class PriorityQueue {
    private Heap heap;
    public PriorityQueue( int size, int[] arr, string heap_type ) {
      heap = new Heap(heap_type, size, size, arr);
    }
    public int Parent( int i ) {
      if( i <= 0 && i >= heap.Count ) {
        return -1;
      }
      return (i-1)/2;
    }
    public int GetLeftChild( int i ) {
      var left = 2*i + 1;
      if(i < 0 || left >= heap.Count) {
        return -1;
      }
      return left;
    }
    public int GetRightChild( int i ) {
      var right = 2*i + 2;
      if(i < 0 || right >= heap.Count) {
        return -1;
      }
      return right;
    }
    public void Heapify(int i) {
      // O(log n)
      var min = i;
      var lc = GetLeftChild(i);
      var rc = GetRightChild(i);
      if( lc != -1  && heap.Array[min] > heap.Array[lc]) {
        min = lc;
      }
      if(rc != -1 && heap.Array[min] > heap.Array[rc]) {
        min = rc;
      }
      if(min != i) {
           var temp = heap.Array[min];
           heap.Array[min] = heap.Array[i];
           heap.Array[i] = temp;
           Heapify(min);
      }
    }
    public void BuildHeap() {
      // O(n) - Upper bound
      var heapCount = (heap.Count -1)/2;
      for( var i = heapCount; i >= 0; i-- ) {
        Heapify(i);
      }
    }
    public void DisplayHeap() {
      for(int i = 0; i < heap.Count; i++) {
        Console.Write(heap.Array[i] + " ");
      }
      Console.WriteLine();
    }
    public void HeapSort(int[] arr) {
      BuildHeap();
      var oldSize = heap.Count; 
      for(var i = arr.Length-1; i>0; i--) {
        var temp = heap.Array[0];
        heap.Array[0] = heap.Array[heap.Count - 1];
        heap.Array[heap.Count - 1] = temp;
        heap.Count--;
        Heapify(0);
      }
      heap.Count = oldSize;
    }
    public int FindMin() {
      if(heap.Count == 0) {
        return -1;
      }
      return heap.Array[0];
    }
    public void ResizeHeap() {
      var arr_old = new int[heap.Capacity];
      for(var i = 0; i < arr_old.Length; i++ ) {
        arr_old[i] = heap.Array[i];
      }
      heap.Array = new int[heap.Capacity *2];
      for(var i = 0; i < arr_old.Length; i++ ) {
         heap.Array[i] = arr_old[i];
      }
      heap.Capacity *= 2;
    }
    public void InsertData(int key) {
      
      if(heap.Count >= heap.Capacity) {
        ResizeHeap();
      }
      heap.Count +=1;
      var n = heap.Count;
      Console.WriteLine("n" + n);
      heap.Array[n-1] = key;
      var  i = (n-1);
      Console.WriteLine("n -1 ele" + heap.Array[i]);
      var parentOfI = Parent(i);
      Console.WriteLine("parentOfI" + parentOfI);
      while(parentOfI >= 0 && heap.Array[i] > heap.Array[parentOfI]) {
        heap.Array[i]  = heap.Array[parentOfI];
         i = parentOfI;
         parentOfI = Parent(i);        
      }
      heap.Array[i] = key;
    }
    public static void Main(String[] args) {
      var arr = new int[] {2, 1, 3, 4, 5, 6, 7};
      PriorityQueue pq = new PriorityQueue(arr.Length, arr, "min_heap");
      pq.HeapSort(arr);
      pq.DisplayHeap();
      pq.InsertData(0);
      pq.DisplayHeap();
      
    }

  }
}