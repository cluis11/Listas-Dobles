using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listas_Dobles
{

    public class Node
    {
        public int Value { get; set; }
        public Node Next { get; set; }
        public Node Prev { get; set; }

        public Node(int value)
        {
            Value = value;
            Next = null;
            Prev = null;
        }
    }


    public class DoubleLinkedList : IList
    {
        private Node head;
        private Node middle;
        private int size;

        public DoubleLinkedList()
        {
            head = null;
            size = 0;
        }

        public void InsertInOrder(int value)
        {
            Node newNode = new Node(value);
            if (head == null)
            {
                head = newNode;
                middle = newNode; 
            }
            else
            {
                Node current = head;
                if (value < head.Value)
                {
                    newNode.Next = head;
                    head.Prev = newNode;
                    head = newNode;
                }
                else
                {
                    while (current.Next != null && current.Next.Value < value)
                    {
                        current = current.Next;
                    }
                    newNode.Next = current.Next;
                    if (current.Next != null)
                    {
                        current.Next.Prev = newNode;
                    }
                    current.Next = newNode;
                    newNode.Prev = current;
                }
                if (size % 2 == 0)
                {
                    middle = middle.Next;
                }
            }

            size++;
        }

        public void Insert(int value)
        {
            Node newNode = new Node(value);
            if (head == null)
            {
                head = newNode;
                middle = newNode; 
            }
            else
            {
                Node current = head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
                newNode.Prev = current;
                if (size % 2 == 0) 
                {
                    middle = middle.Next;
                }
            }
            size++;
        }


        public int DeleteFirst()
        {
            if (head == null)
                throw new InvalidOperationException("List is empty.");

            int value = head.Value;
            head = head.Next;

            if (head != null)
                head.Prev = null;

            // Actualizar el nodo central
            if (size % 2 == 1)
            {
                middle = middle.Next;
            }

            size--;
            return value;
        }

        public int DeleteLast()
        {
            if (head == null)
                throw new InvalidOperationException("List is empty.");
            Node current = head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            int value = current.Value;
            if (current.Prev != null)
            {
                current.Prev.Next = null;
            }
            else
            {
                head = null;
            }
            if (size % 2 == 0)
            {
                middle = middle.Prev;
            }
            size--;
            return value;
        }

        public bool DeleteValue(int value)
        {
            if (head == null)
                return false; 
            Node current = head;
            if (current.Value == value)
            {
                DeleteFirst();
                return true;
            }
            while (current != null && current.Value != value)
            {
                current = current.Next;
            }
            if (current == null)
                return false; 
            if (current.Prev != null)
                current.Prev.Next = current.Next;
            if (current.Next != null)
                current.Next.Prev = current.Prev;
            if (size % 2 == 1 && current.Value <= middle.Value)
            {
                middle = middle.Prev;
            }
            else if (size % 2 == 0 && current.Value > middle.Value)
            {
                middle = middle.Next;
            }
            size--;
            return true;
        }


        public int GetMiddle()
        {
            if (middle == null)
                throw new InvalidOperationException("List is empty.");

            return middle.Value;
        }

        public void MergeSorted(IList listA, IList listB, SortDirection direction)
        {
        }
    }

}
