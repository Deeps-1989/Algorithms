using System;
namespace Csharp.LinkedLists {
  public class SingleLinkedList {
    
    private LinkedListNode _head;
    public LinkedListNode CreateLinkedListNode(int data) {
        var node = new LinkedListNode();      
        node.data = data;
        return node;

    }
    public void InsertNodeAtBeginning(LinkedListNode root) {
      if(_head == null) {
        _head = root;
        return;
      }
      var temp = _head;
      root.next = temp;
      _head = root;
    }
    public void InsertNodeAtEnd(LinkedListNode root) {
      if(_head == null) {
        _head = root;
        return;
      }
      var curr = _head;
      while(curr.next != null) {
        curr = curr.next;
      } 
      curr.next = root;
    }
    public int GetLengthOfLinkedList() {
      var current = _head;
      var count = 0;
      while( current != null ) {
         count++;
        current = current.next;
      }
      return count;
    }
    public void InsertAtIPosition(LinkedListNode root, int i) {
        var k = i;
        var count = GetLengthOfLinkedList();
        if ( i  > count ) {
          InsertNodeAtEnd(root);
        } 
        else if ( i <= 0 || i == 1) {
          InsertNodeAtBeginning(root);
        }
        else {
            var current = _head;
            var counter = 1;
            while ( current != null && counter < i-1 ) {
               counter++;
               current = current.next;
            }
            var temp = current.next;
            current.next = root;
            root.next = temp;
        }
    }
    public void DisplayLinkedListNode() {
      var curr = _head;
      while(curr.next != null) {
        Console.Write(curr.data + "-->");
        curr = curr.next;
      }
      Console.WriteLine(curr.data);
    }
    public static void Main(String[] args) {
      SingleLinkedList sll = new SingleLinkedList();
      Console.WriteLine("Insert at beginning");
      var node = sll.CreateLinkedListNode(10);
      sll.InsertNodeAtBeginning(node);
      sll.DisplayLinkedListNode();
      Console.WriteLine("Insert at beginning");
      node = sll.CreateLinkedListNode(20);
      sll.InsertNodeAtBeginning(node);
      sll.DisplayLinkedListNode();
      Console.WriteLine("Insert at end");
      node = sll.CreateLinkedListNode(30);
      sll.InsertNodeAtEnd(node);
      sll.DisplayLinkedListNode();
      Console.WriteLine("Insert at position 5");
      node = sll.CreateLinkedListNode(25);
      sll.InsertAtIPosition(node, 5);
      sll.DisplayLinkedListNode();
      Console.WriteLine("Insert at position 0");
      node = sll.CreateLinkedListNode(1);
      sll.InsertAtIPosition(node, 0);
      sll.DisplayLinkedListNode();
      Console.WriteLine("Insert at position -1");
      node = sll.CreateLinkedListNode(2);
      sll.InsertAtIPosition(node, -1);
      sll.DisplayLinkedListNode();
      Console.WriteLine("Insert at position 6");
      node = sll.CreateLinkedListNode(45);
      sll.InsertAtIPosition(node, 6);
      sll.DisplayLinkedListNode();

    }
  }
}