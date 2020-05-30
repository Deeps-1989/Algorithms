using System;

namespace Csharp.DynamicProgramming {

  public class Box : IComparable<Box> {

    public int Length { get; set; }

    public int Width { get; set; }

    public int Height { get; set; }

    public Box(int length, int width, int height) {
      this.Length = length;
      this.Width = width;
      this.Height = height;
    }

    public static Box CreateSize(int length, int width, int height) {

      if(length >= width) {
        return new Box(length, width, height);
      } else {
        return new Box(width, length, height);
      }
    }

    public int CompareTo(Box input) {
      if(this.Length * this.Width < input.Length * input.Width) {
        return 1;
      } else { return -1; }
    }
  }
  public class BoxStackingProblem {
    public static void Main(String[] args){
      BoxStackingProblem bsp = new BoxStackingProblem();
      var b1 = new Box(1,2,4);
      var b2 = new Box(3,2,5);
      Box[] input = new Box[] {b1, b2};
      bsp.GetMaxHeight(input);
    }

    public void GetMaxHeight(Box[] input) {
      // Get all different combonation of boxes
      Box[] allRotations = new Box[input.Length * 3];
      GetAllRotations(input, allRotations);
      for(int i = 0; i < allRotations.Length; i++) {
        Console.WriteLine(allRotations[i].Length + " " + allRotations[i].Width + " " + allRotations[i].Height);
      }
      //Sort the boxes based on length * width
      Array.Sort(allRotations);
      Console.WriteLine("After Sorting");
      for(int i = 0; i < allRotations.Length; i++) {
        Console.WriteLine(allRotations[i].Length + " " + allRotations[i].Width + " " + allRotations[i].Height);
      }

      int[] maxHeight = new int[allRotations.Length];
      int[] boxStack = new int[allRotations.Length];
      maxHeight[0] = allRotations[0].Height;
      boxStack[0] = 0;
      int maximumHeightAttainable = -1;
      int index = -1;
      for(int i = 1; i < allRotations.Length; i++)  {
        maxHeight[i] = allRotations[i].Height;
        boxStack[i] = i;
        for(int j  = 0; j < i;j++) {
          if(allRotations[i].Length < allRotations[j].Length && 
          allRotations[i].Width < allRotations[j].Width) {
            maxHeight[i] = Math.Max(maxHeight[i], maxHeight[j] + allRotations[i].Height);
            boxStack[i] = j;
            if(maxHeight[i] > maximumHeightAttainable) {
              maximumHeightAttainable = maxHeight[i];
              index = i;
            }
          }
        }
      }
      Console.WriteLine($"Maximum height is {maximumHeightAttainable}");
      Console.WriteLine("Boc stack from top to bottom are");
      Console.Write($" {index} ");
      while(index != boxStack[index]) {
          Console.Write($" {boxStack[index]} ");
          index = boxStack[index];
      }
    }

    public void GetAllRotations(Box[] input, Box[] allRotations) {
      int index = 0;
      for(int i = 0; i < input.Length; i++) {
        allRotations[index++] = Box.CreateSize(input[i].Length, input[i].Width, input[i].Height);
        allRotations[index++] = Box.CreateSize(input[i].Width, input[i].Height, input[i].Length);
        allRotations[index++] = Box.CreateSize(input[i].Height, input[i].Length, input[i].Width);
      }
    }
  }
}