using System;
namespace Csharp.DynamicProgramming {
  public class TotalWaysToReachMatrixEnd {
    public static void Main(String[] args) {
      int[,] matrix =  new int[,] {
        {1,2,3,4},
        {5,6,7,8},
        {9,10,11,12},
        {13,14,15,16}
      };
      TotalWaysToReachMatrixEnd tw = new TotalWaysToReachMatrixEnd();
      tw.CalculateTotalWays(matrix);
    }
    
    public void CalculateTotalWays(int[,] matrix) {
      int m = matrix.GetUpperBound(0);
      int n = matrix.GetUpperBound(1);
      int[,] dp = new int[m+1,n+1];
      for(int i = 0; i <= m; i++) {
        for(int j = 0; j <= n; j++) {
          if(i == 0 || j == 0) {
            dp[i,j] = 1;
            continue;
          }
          dp[i,j] = dp[i-1,j] + dp[i,j-1];
        }
      }
      Console.WriteLine($"Total ways to reach end {dp[m,n]}");
    }
  }
}