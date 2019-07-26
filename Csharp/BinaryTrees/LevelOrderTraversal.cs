using System;
using System.Collections.Generic;
namespace Csharp.BinaryTrees {
  public class LevelOrderTraversal {
    private Queue<BinaryTree> _q;
    public LevelOrderTraversal() {
      _q = new Queue<BinaryTree>();
    }

    public void DoLevelOrderTraversal(BinaryTree root) {
      if( root == null ) {
        return;
      }
      _q.Enqueue(root);
      while(!(_q.Count == 0)) {
        var temp = _q.Dequeue();
        Console.WriteLine(temp.data + " ");
        if(temp.left != null) {
          _q.Enqueue(temp.left);
        }
        if(temp.right != null) {
          _q.Enqueue(temp.right);
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
        var traversal = new LevelOrderTraversal();
        traversal.DoLevelOrderTraversal(node1);
    }

  }

}