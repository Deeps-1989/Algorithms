using System;

namespace Csharp.DynamicProgramming {

  public class LongestBitonicSubsequence {
    public static void Main(String[] args) {
      LongestBitonicSubsequence lbs = new LongestBitonicSubsequence();
      int[] arr = new int[] {1,3,2,0,5,4,-1};
      int[] lis = new int[arr.Length]; 
      int[] lisFromEnd = new int[arr.Length];
      lbs.CalculateLisFromBeginning(arr, lis);
      lbs.CalculateLisFromEnd(arr, lisFromEnd);
      var index = -1;
      for(int i = 1; i < lis.Length; i++) {
        if(lis[i] > lis[0] && lis[i] == lisFromEnd[i]) {
          index = i;
          break;
        }
      }
      Console.WriteLine(index);
    }

    public void CalculateLisFromBeginning(int[] arr, int[] lis) {
      for(int i = 0; i < lis.Length; i++ ) {
        lis[i] = 1;
      }

      for(var i = 0; i < arr.Length; i++) {
        for(var j = i + 1; j < arr.Length; j++) {
          if(arr[i] < arr [j] && lis[i] + 1 > lis[j]) {
            lis[j] = lis[i] + 1;
          }
        }
      } 
      Print(lis);
    }

    public void CalculateLisFromEnd(int[] arr, int[] lis) {
      for(int i = 0; i < lis.Length; i++ ) {
        lis[i] = 1;
      }

      for(var i = arr.Length-1; i >= 0; i--) {
        for(var j = i - 1; j >= 0; j--) {
          if(arr[i] < arr [j] && lis[i] + 1 > lis[j]) {
            lis[j] = lis[i] + 1;
          }
        }
      } 
      Print(lis);
    }

    public void Print(int[] a) {
      for(int i = 0; i < a.Length; i++ ) {
        Console.Write(a[i] + " ");
      }
      Console.WriteLine();
    }
  }
}