namespace Csharp.BinaryTrees {
  public class BinaryTree {
      public BinaryTree(int data) {
        this.data = data;
      }
      public BinaryTree left {get; set;}
      public BinaryTree right { get; set;}
      public int data {get; set;}
    }
}