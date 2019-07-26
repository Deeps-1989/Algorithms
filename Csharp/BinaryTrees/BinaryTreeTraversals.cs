using System;
namespace Csharp.BinaryTrees {
    public class InorderTraversal {
      public void DisplayTree(int data) {
        Console.WriteLine(data); 
      }

      public void DoTraversal(BinaryTree root) {
        if(root == null) {
          return;
        }
        
        DoTraversal(root.left);
        DisplayTree(root.data);
        DoTraversal(root.right);

      }
    }
    public class BinaryTreeTraversals {
      public static void Main(String[] args) {
        var node1 = new BinaryTree(1);
        var node2 = new BinaryTree(2);
        var node3 = new BinaryTree(3);
        node1.left = node2;
        node1.right = node3; 
        var node4 = new BinaryTree(4);
        var node5 = new BinaryTree(5);
        node2.left = node4;
        node2.right = node5;
        Console.WriteLine(@"Traverse using recursion
        1. Inorder Traversal
        2. Preorder Traversal
        3. PostorderTraversal");
        var input = int.Parse(Console.ReadLine());
        switch(input) {
          case 1:
            var inorderTraversal = new InorderTraversal();
            Console.WriteLine("Performing inorder traversal");
            inorderTraversal.DoTraversal(node1);
            break;
          case 2: 
            var preorderTraversal = new PreorderTraversal();
            Console.WriteLine("Performing preorder traversal");
            preorderTraversal.DoPreorderTraversal(node1);
            break;
          case 3: 
            var postorderTraversal = new PostorderTraversal();
            Console.WriteLine("Performing postorder traversal");
            postorderTraversal.DoPostorderTraversal(node1);
            break; 
          default:
          throw new Exception();
            
        }
      } 
    }
    public class PreorderTraversal {
      public void DisplayTree(int data) {
        Console.WriteLine(data); 
      }
      public void DoPreorderTraversal(BinaryTree root) {
        if( root == null ) {
          return;
        }
        DisplayTree(root.data);
        DoPreorderTraversal(root.left);
        DoPreorderTraversal(root.right);
      }
    }
    public class PostorderTraversal {
      public void DisplayTree(int data) {
        Console.WriteLine(data); 
      }
      public void DoPostorderTraversal(BinaryTree root) {
        if( root == null ) {
          return;
        }
        DoPostorderTraversal(root.left);
        DoPostorderTraversal(root.right);
        DisplayTree(root.data);
      }
    }

}