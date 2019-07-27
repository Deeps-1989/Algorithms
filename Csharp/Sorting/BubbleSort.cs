using System;
namespace Csharp.Sorting {
  public class BubbleSort {
    
    public void DoBubbleSort(int[] arr) {
      
      for ( var i = 0; i < arr.Length - 1; i++ ) {
        for ( var j = 0; j < arr.Length - i - 1; j++ ) {
          if (  arr[j] > arr[j+1] )  {
                var temp = arr[j];
                arr[j] = arr[j+1];
                arr[j+1] = temp;
          }
        }
      }
    }
    public void DisplayArray(int[] arr) {
      for(var i= 0; i < arr.Length; i++) {
        Console.Write(arr[i] + " ");
      }
      Console.WriteLine();
    }
    public static void Main(String[] args) {
      var bs = new BubbleSort();
      var arr = new int[] {2, 10, 3, 4};
      Console.WriteLine("Display before sorting");
      bs.DisplayArray(arr);
      bs.DoBubbleSort(arr);
      Console.WriteLine("Display after sorting");
      bs.DisplayArray(arr);
    }
  }
}