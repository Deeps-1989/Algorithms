using System;

namespace Csharp.DynamicProgramming {

  public class SubRectangleSum {
    public static void Main(string[] args) {
    int[,] matrix = new int[,] {
      {2,0,-3,4},
      {6,3,2,-1},
      {5,4,7,3},
      {2,-6,8,1}
    };
    int m = matrix.GetUpperBound(0) + 1; 
    int n = matrix.GetUpperBound(1) + 1; 
    int[,] relativeSum = new int[m + 1, n + 1]; 
    SubRectangleSum srs = new SubRectangleSum();
    srs.CalculateRelativeSum(relativeSum, matrix);
    srs.Print(relativeSum);
    int sum = srs.GetSum(0,1,2,3, relativeSum);
    Console.WriteLine($"Sum is {sum}");
    }

    public int GetSum(int r1, int c1, int r2, int c2, int[,] dp) {

        return dp[r2+1, c2+1] - dp[r2+1, c1] - dp[r1, c2+1] + dp [r1, c1];
    }
  
  public void CalculateRelativeSum(int[,] dp, int[,] matrix) {

    for(int i = 0; i <= dp.GetUpperBound(0); i++) {

      for(int j = 0; j <= dp.GetUpperBound(1); j++) {
        if(j == 0 || i == 0) {
          Console.WriteLine(i + " " + j);
          dp[i,j] = 0;
          continue; 
        }
        dp[i,j] = dp[i,j-1] + dp[i-1,j] + matrix[i-1,j-1] - dp[i-1,j-1];
      }
    }
  }

  public void Print(int[,] dp) {
    for(int i = 0; i <= dp.GetUpperBound(0); i++) {
      for(int j = 0; j <= dp.GetUpperBound(1); j++) {
        Console.Write(dp[i,j] + " ");
      }
      Console.WriteLine();
    }
  }
}
}