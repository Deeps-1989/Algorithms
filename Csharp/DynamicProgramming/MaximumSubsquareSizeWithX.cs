using System;

namespace Csharp.DynamicProgramming {
  public class MaximumSubsquareSizeWithX {
    public static void Main(String[] args) {
      
      MaximumSubsquareSizeWithX ss = new MaximumSubsquareSizeWithX();
      Char[,] matrix = new Char[,] {
        {'O', 'O', 'O', 'O', 'X'},
        {'X', 'O', 'X', 'X', 'X'},
        {'X', 'O', 'X', 'O', 'X'},
        {'X', 'X', 'X', 'X', 'O'},
        {'O', 'O', 'X', 'X', 'O'}
      };
      int m = matrix.GetUpperBound(0) + 1;
      int n = matrix.GetUpperBound(1) + 1;
      Point[,] dp = new Point[m+1 , n+1];
      ss.CalculateSubSquareSize(dp, matrix);
      Console.WriteLine(dp.GetUpperBound(0));
      ss.Print(dp);
      ss.CalculateSizeOfArray(dp);
    }

    public void CalculateSubSquareSize(Point[,] dp, Char[,] matrix) {
      for(int i = 0; i <= dp.GetUpperBound(0); i++) {
        for(int j = 0; j <= dp.GetUpperBound(1); j++) {
          if(i == 0 || j == 0 || matrix[i-1, j-1] == 'O') {
            dp[i,j] = new Point(0,0);
            continue;
          }
          int xfromTop = dp[i-1, j].Top;
          int xFromLeft = dp[i, j-1].Left;
          dp[i,j] = new Point(xfromTop+1, xFromLeft+1);
        }
      }
    }
    
    public void Print(Point[,] dp) {
      for(int i = 0; i <= dp.GetUpperBound(0); i++) {
        for(int j = 0; j <= dp.GetUpperBound(1); j++) {
          Console.Write(dp[i,j].Top + "," + dp[i,j].Left + " ");
        }
        Console.WriteLine();
      }
    }

    public void CalculateSizeOfArray(Point[,] dp) {
      int MaxSize = int.MinValue;
      int pointx = -1;
      int pointy = -1; 
      for(int i = dp.GetUpperBound(0); i >= 0; i--) {
        for(int j = dp.GetUpperBound(1); j >= 0; j--) {
          Point p = dp[i,j];
          
          int min = Math.Min(p.Top, p.Left);
          if(min == 0) {
            continue;
          }
          while(min >= 1) {
            int moveLeft = j - min + 1;
            int moveTop = i - min + 1;
            if(moveLeft >= 0) {
              Point p1 = dp[i, moveLeft];
              if(p1.Top < min) {
                --min;
                continue;
              }
            } 
            if(moveTop >= 0) {
              Point p2 = dp[moveTop, j];
              if(p2.Left < min) {
                --min;
                continue;
              }
            }
            if(MaxSize < min) {
            MaxSize = min;
            pointx = i;
            pointy = j;
            }
            --min;
          }

        }
      }
      Console.WriteLine($"MaxSize is {MaxSize}");
      Console.WriteLine($"Starting Points are X: {pointx - MaxSize} Y: {pointy- MaxSize}");
       Console.WriteLine($"Ending Points are X: {pointx - 1} Y: {pointy - 1}");
    }
  }

  public class Point {
    public int Top { get; set; }
    public int Left { get; set; }
    public Point(int x, int y) {
      Top = x;
      Left = y;
    }
  }
}