using System;
namespace Csharp.LinkedLists {
  public class DoubleLinkedList {
    private LinkedListNode _head;

    public void InsertNodeAtBeginning(LinkedListNode root) {
      if ( _head == null ) {
        _head = root;
        return;
      }
      var curr = _head;
      root.next = curr;
      curr.prev = root;
      _head = root;
      
    }

    public LinkedListNode CreateDoubleLinkedListNode(int data) {
      var node = new LinkedListNode();
      node.data = data;
      return node;
    }
    public void DisplayLinkedListNode() {
      var current = _head;
      while(current.next != null) {
        Console.Write(current.data + " <--> ");
        current = current.next;
      }
      Console.WriteLine(current.data);
    }

    public void InsertAtEnd(LinkedListNode root) {
      if(_head == null) {
        _head = root;
        return;
      }
      var current = _head;
      while(current.next != null) {
        current = current.next;
      }
      current.next = root;
      root.prev = current;
    }

    public int GetLinkedListNodeLength() {
        var current = _head;
        var counter = 0;
        while(current != null) {
          current = current.next;
          counter++;
        }
        return counter;
    }

    public void InsertAtIthPosition(LinkedListNode root, int i) {
      var length = GetLinkedListNodeLength();
      if ( i > length ) {
        InsertAtEnd(root);
      } else if ( i <= 1) {
        InsertNodeAtBeginning(root);
      }
      else {
       var current = _head;
       var counter = 0;
       while(current != null && counter < i -1) {
           counter++;
           current = current.next;
       }
       var temp = current.next;
       current.next = root;
       root.prev = current;
       root.next = temp;
       temp.prev = root;
      }
    }
    public void TraverseBackwardFromFoundElement(LinkedListNode node, int key) {
      var current = _head; 
      
      while(current != null) {
        if(current.data == key) {
           break;
        }
        current = current.next;
      }
      while(current != _head) {
        Console.Write(current.data + "<--");
        current = current.prev;
      }
      Console.WriteLine(current.data);
    }
    public static void Main(String[] args) {
      DoubleLinkedList dll = new DoubleLinkedList();
      Console.WriteLine("Insert at beginning");
      var node = dll.CreateDoubleLinkedListNode(10);
      dll.InsertNodeAtBeginning(node);
      dll.DisplayLinkedListNode();
      Console.WriteLine("Insert at End");
      node = dll.CreateDoubleLinkedListNode(5);
      dll.InsertAtEnd(node);
      dll.DisplayLinkedListNode();
      Console.WriteLine("Insert at position 5");
      node = dll.CreateDoubleLinkedListNode(6);
      dll.InsertAtIthPosition(node, 5);
      dll.DisplayLinkedListNode();
      Console.WriteLine("Insert at position 1");
      node = dll.CreateDoubleLinkedListNode(1);
      dll.InsertAtIthPosition(node, 1);
      dll.DisplayLinkedListNode();
      Console.WriteLine("Insert at position 0");
      node = dll.CreateDoubleLinkedListNode(2);
      dll.InsertAtIthPosition(node, 0);
      dll.DisplayLinkedListNode();
      Console.WriteLine("Traverse backward after finding the element");
      dll.TraverseBackwardFromFoundElement(node, 5);
    }
  }
}