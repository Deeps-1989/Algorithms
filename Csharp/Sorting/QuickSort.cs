using System; 
namespace Csharp.Sorting {
  public class QuickSort {
    public int DoQuickSort(int[] arr, int low, int high){
      var pivot = arr[high];
      Console.WriteLine($"pivot {pivot}");
      var i = -1;
      var j = high - 1;
      for(var k=low; i < j && k < arr.Length;) {

        while ( arr[k] <= pivot && k < high) {
          i++;
          k++;
        }
        while ( arr[j] > pivot) {
          j--;
        }
        Console.WriteLine($"i {i}, j {j}");
        if(arr[k] > arr[j]) {
          Console.WriteLine("Exchsanging");
          var temp = arr[k];
          arr[k] = arr[j];
          arr[j] = temp;
          i++;
        } 
      }
      var q = arr[i+1];
      arr[i+1] = arr[high];
      arr[high] = q;
      return i+1;
    }
    public void DoPartition(int[] arr, int low, int high) {
      if(low < high) {

        int pi = DoQuickSort(arr, low, high);
        Console.WriteLine("pi", pi);
        DoPartition(arr, low, pi - 1);
        DoPartition(arr, pi + 1, high);
      }

    }

    public void DisplayArray(int[] arr) {
      var n = arr.Length;
      for(var i = 0; i < n; i++ ) {
        Console.Write(arr[i] + " ");
      }
      Console.WriteLine();
    }

    public static void Main(String[] args) {
      var qs = new QuickSort();
      var arr = new int[] {5, 12, 1, 3, 10};
      Console.WriteLine("Before performing quick sorting");
      qs.DisplayArray(arr);
      qs.DoPartition(arr, 0, arr.Length -1) ;
      Console.WriteLine("After performing quick sorting");
      qs.DisplayArray(arr);
          
    }
  }
}