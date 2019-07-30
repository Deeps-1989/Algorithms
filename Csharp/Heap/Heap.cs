namespace Csharp.Heap {
  public class Heap {
    public string HeapType {get; set;}
    public int[] Array {get; set;}
    public int Count {get; set;}
    public int Capacity {get; set;}
    
    public Heap(string heap_type, int count, int capacity, int[] array) {
      this.HeapType = heap_type;
      this.Count = count;
      this.Capacity = capacity;
      this.Array = array;
    }
  }
}