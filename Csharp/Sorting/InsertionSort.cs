using System;
using System.Diagnostics;
namespace Csharp.Sorting {
  public class InsertionSort {
    public void DisplayArray(int[] arr) {
      var n = arr.Length;
      for(var i = 0; i < n; i++ ) {
        Console.Write(arr[i] + " ");
      }
      Console.WriteLine();
    }
    public void DoInsertionSort(int[] arr) {
      for ( var i = 0; i < arr.Length -1 ; i++ ) {
        var k = i + 1;
        var item = arr[k];
        var j = k;
        for (; j >= 1; ) {
          if ( arr[j-1] > item) {
              arr[j] = arr[j-1];
              j--;
          }
          else {
            break;
          }
        }
        if ( k != j ) {
          arr[j] = item;
        }
      }
    }
    public static void Main(String[] args) {
        var s = new Stopwatch();
        s.Start();
        var ins = new InsertionSort();
        var arr = new int[] {5,12,1,3,10, -1, -2, -3};
        Console.WriteLine("Before Sorting");
        ins.DisplayArray(arr);
        ins.DoInsertionSort(arr);
        Console.WriteLine("After Sorting");
        ins.DisplayArray(arr);
        s.Stop();
        Console.WriteLine($"Total time {s.ElapsedMilliseconds}ms");
    }
  }
}