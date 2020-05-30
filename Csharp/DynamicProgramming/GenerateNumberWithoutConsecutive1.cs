using System;

namespace Csharp.DynamicProgramming {
  public class GenerateNumberWithout1 {
    public static void Main(String[] args) {
      int n = 4;
      int a = 1;
      int b = 2;
      int c = -1;
      for(int i =2; i<= n; i++) {
        c = a + b;
        a = b;
        b = c;
      }
      Console.WriteLine(b);
    }
  }
}