using System;
namespace Csharp.DynamicProgramming {
  public class MaxNonAdjacentSum {
    public static void Main(String[] args) {
      MaxNonAdjacentSum nonAdjSum = new MaxNonAdjacentSum();
      int[] input = new int[] {4,1,1,4,2,1};
      nonAdjSum.CalculateUsingFlag(input);
      nonAdjSum.CalculateDp(input);
    }
    public void CalculateUsingFlag(int[] input) {
      // use two flags
      int incl = input[0];
      int excl = 0;
      for(int i = 1; i < input.Length; i++) {
        int temp = incl;
        incl = Math.Max(excl + input[i], incl);
        excl = temp;
      }
      Console.WriteLine($"Using flags the result is {incl}");
    }

    public void CalculateDp(int[] input) {
      int n = input.Length;
      int[] dp = new int[n];
      dp[0] = input[0];
      dp[1] = Math.Max(input[1], dp[0]);
      for(int i = 2; i < n; i++) {
        dp[i] = Math.Max(input[i] + dp[i-2], dp[i-1]);
      }
      Console.WriteLine($"Using Dp the result is {dp[n-1]}");
    }
  }
}