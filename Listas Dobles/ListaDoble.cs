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


    public class DoubleList : IList
    {
        private Node head;
        private Node middle;
        private int size;

        public DoubleList()
        {
            head = null;
            middle = null;
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
            }
            size++;
            middle = head;
            for (int i = 0; i < (size / 2); i++) 
            {
                middle = middle.Next;
            }
            
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
            }
            size++;
            if (size % 2 == 0)
            {
                middle = middle.Next;
            }
        }


        public int DeleteFirst()
        {
            try
            {
                if (head == null)
                {
                    throw new InvalidOperationException("List is empty.");
                }
                int value = head.Value;  
                head = head.Next;  
                if (head != null)
                {
                    head.Prev = null;
                }
                if (size % 2 == 1)
                {
                    middle = middle.Next;
                }
                size--;  
                return value;  
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);  
                return -1;  
            }
        }


        public int DeleteLast()
        {
            try
            {
                if (head == null)
                {
                    throw new InvalidOperationException("List is empty.");
                }

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
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);  
                return -1;  
            }
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

        public void MergeSorted(IList listB, SortDirection direction)
        {
        }

        public static void MergeSorted(DoubleList listA, DoubleList listB, SortDirection direction)
        {
            if (listA == null || listB == null)
            {
                throw new ArgumentNullException("List cannot be null.");
            }

            Node currentB = listB.head;
            while (currentB != null)
            {
                listA.InsertInOrder(currentB.Value);
                currentB = currentB.Next;
            }

            if (direction == SortDirection.Descending)
            {
                listA.Invert();
            }
        }



        public void Invert()
        {
            try
            {
                if (head == null)
                {
                    throw new InvalidOperationException("List is empty.");
                }
                Node current = head;
                Node temp = null;
                while (current != null)
                {
                    temp = current.Prev;
                    current.Prev = current.Next;
                    current.Next = temp;
                    current = current.Prev;
                }
                if (temp != null)
                {
                    head = temp.Prev;
                }
                if (size % 2 == 0)
                {
                    middle = middle.Next;
                }
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message); 
            }
        }


        public static DoubleList Invert(DoubleList list)
        {
            try
            {
                if (list == null)
                {
                    throw new ArgumentNullException(nameof(list), "The list parameter cannot be null.");
                }

                list.Invert();
                return list;
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
                return new DoubleList();
            }
        }


        public void PrintList() 
        {
            if (head == null)
                throw new InvalidOperationException("List is empty.");
            else 
            {
                Node current = head;
                while (current != null)
                {
                    Console.WriteLine(current.Value);
                    current = current.Next;
                }
            }
        }


    }

}
