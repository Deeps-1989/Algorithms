using System;
using System.Collections.Generic;
namespace Csharp.BinaryTrees {
  public class DepthFirstTraversal {
  private Stack<BinaryTree> _stack;

  public DepthFirstTraversal() {
    _stack = new Stack<BinaryTree>();
  }
  public void DoDepthFirstTraversal(BinaryTree root) {
   if(root == null) {
     return;
   }
   _stack.Push(root);
   while(!(_stack.Count == 0)) {
     var temp = _stack.Pop();
     Console.WriteLine(temp.data);
     if(temp.left != null) {
       _stack.Push(temp.left);
     }
     if(temp.right!=null) {
       _stack.Push(temp.right);
     }
   }
  }
  public static void Main(string[] args) {
    var node1 = new BinaryTree(1);
    var node2 = new BinaryTree(2);
    var node3 = new BinaryTree(3);
    node1.left = node2;
    node1.right = node3; 
    var node4 = new BinaryTree(4);
    var node5 = new BinaryTree(5);
    node2.left = node4;
    node2.right = node5;
    DepthFirstTraversal traversal = new DepthFirstTraversal();
    traversal.DoDepthFirstTraversal(node1);
  }
}
}