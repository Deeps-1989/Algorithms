using System;

namespace Csharp.DynamicProgramming {
  public class MaxSumIncreasingSubSequence {
    public static void Main(String[] args) {
      MaxSumIncreasingSubSequence subSequence = new MaxSumIncreasingSubSequence();
      int[] input = new int[] {4,6,1,3,8,4,6};
      subSequence.GetSumSubSequence(input);
    }
    public void GetSumSubSequence(int[] input) {
      int n = input.Length;
      int[] sum = new int[n];
      int[] actualSubsequence = new int[n];
      for(int i = 0; i < n; i++) {
        sum[i] = input[i];
        actualSubsequence[i] = i;
      }

      for(int i = 1; i < n; i++) {
        for(int j = 0; j < i; j++) {
          if(input[i] > input[j] && sum[j] + input[i] > sum[i]) {
            sum[i] = sum[j] + input[i];
            actualSubsequence[i] = j;
          }
        }
      }
      int maxSum = int.MinValue;
      int index = -1;
      for(int i = 0; i < n; i++) {
        if(sum[i] > maxSum) {
          maxSum = sum[i];
          index = i;
        }
      }
      Console.WriteLine(maxSum);
      while(actualSubsequence[index] != index) {
        Console.WriteLine(input[index]);
        index = actualSubsequence[index];
      }
      Console.WriteLine(input[index]);
    }
  }
}