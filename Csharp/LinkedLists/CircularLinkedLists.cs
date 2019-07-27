using System;
namespace Csharp.LinkedLists {
  public class CircularLinkedLists {
    private LinkedListNode _head;
    public void InsertAtBeginning(LinkedListNode root) {
         if ( _head == null ) {
            _head  = root;
            root.next = root;
         }
         var current = _head;
         while(current.next != _head) {
             current = current.next;
         }
        var temp = _head;
        root.next = temp;
        current.next = root;
        _head = root;
    }
    public LinkedListNode CreateNode(int data) {
      var node = new LinkedListNode();
      node.data = data;
      return node;
    }
    public void DeleteNode(int data) {
      if(_head == null) {
        return;
      }

      var prev = _head;
      var current = _head;
      
      // if node to be delted is single node 
      if(current.next == current) {
        _head = null;
        return;
      }

      while ( current.data != data ) {
        prev = current;
        current = current.next;
      }

     // if node to be deleted is first node
     if ( _head.data == data ) {
        // we don't have details of predecessor of node to be deleted
        // to get predecessor iterate to last node
        while( current.next != _head) {
          current = current.next;
        }
        current.next = _head.next;
        _head = _head.next;
       
      } else {
        prev.next = current.next;
        current = null; 
      }
    }
    public void DisplayNode() {
      if ( _head == null ) {
        return;
      }
      var current = _head;
      while ( current.next != _head ) {
        Console.Write(current.data + " -->");
        current = current.next;
      }
      Console.WriteLine(current.data);
    }
    public static void Main(String[] args) {
      var cll = new CircularLinkedLists();
      var node = cll.CreateNode(10);
      cll.InsertAtBeginning(node);
      cll.DisplayNode();
      cll.DeleteNode(10);
      cll.DisplayNode();
    }
  }
}