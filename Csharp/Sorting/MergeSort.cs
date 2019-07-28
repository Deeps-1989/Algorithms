using System;
namespace Csharp.Sorting {
  public class MergeSort {
    public void DisplayArray(int[] arr) {
      var n = arr.Length;
      for(var i = 0; i < n; i++ ) {
        Console.Write(arr[i] + " ");
      }
      Console.WriteLine();
    }
    public void DoMergePartition(int[] arr, int low, int high) {
      if(low < high) {
        var mid = (low + high)/2;
        DoMergePartition(arr, low, mid);
        DoMergePartition(arr, mid + 1, high);
        Merge(arr, low, mid, high);
      }
    }
    
    public void Merge(int[] arr, int low, int mid, int high) {
      var n1 = mid - low + 1;
      var n2 = high - mid;
      var lowMidArray = new int[n1];
      var midHighArray = new int[n2]; 
      var i = 0;
      var j = 0;
      for(i = 0; i < n1; i++) {
       lowMidArray[i] = arr[i+low];
      }
      for(j = 0; j < n2; j++) {
       midHighArray[j] = arr[mid+1+j];
      }
      i = 0; 
      j = 0;
      var k = low;
      for( ; i < n1 && j < n2;) {
          if ( lowMidArray[i] <= midHighArray[j] ) {
            arr[k] = lowMidArray[i];
            k++;
            i++;
          } else {
            arr[k] = midHighArray[j];
            j++;
            k++;
          }
      }
        for( var l = i; l < n1; l++, k++) {
          arr[k] = lowMidArray[l];
        }
      
        for ( var l = j; l < n2; l++, k++) {
          arr[k] = midHighArray[l];
        
      }
      
    }

    public static void Main(String[] args) {
     var ms = new MergeSort();
     var arr = new int[] {5, 12, 1, 3, 10};
     Console.WriteLine("Before performing merge sorting");
     ms.DisplayArray(arr);
     ms.DoMergePartition(arr, 0, arr.Length -1) ;
     Console.WriteLine("After performing merge sorting");
     ms.DisplayArray(arr);
    }
  }
}