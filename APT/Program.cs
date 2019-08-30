using System;
using System.Collections;
using System.Collections.Generic;

namespace APT
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadKey();
        }
    }

    class Node<T>
    {
        public T Value { get; set; }
        public Node<T> Next { get; set; }

        public Node() : this(default) { }
        public Node(T v) : this(v, null) { }
        public Node(T v, Node<T> node)
        {
            this.Value = v;
            this.Next = node;
        }
    }

    class SLList<T> : IList<T>
    {
        private Node<T> head;
        public Node<T> Head
        { get { return head; }
          set { head = value; }
        }

        public SLList(T data)
        {
            head = new Node<T>(data);
        }

        public T this[int index]
        {
            get => this.GetValueAt(index);
            set => this.SetValueAt(index, value);
        }

        private T GetValueAt(int index)
        {
            Node<T> current = head;
            if (index == 0) return current.Value;
            while (current.Next != null)
            {
                index--;
                current = current.Next;
                if (index == 0) return current.Value;
            }
            throw new IndexOutOfRangeException();
        }

        private void SetValueAt(int index, T data)
        {
            Node<T> current = head;
            if (index == 0) current.Value = data;
            while(current.Next != null)
            {
                index--;
                current = current.Next;
                if (index == 0) current.Value = data;
            }
            throw new IndexOutOfRangeException();
        }

        public int Count => throw new NotImplementedException();

        public bool IsReadOnly => throw new NotImplementedException();

        public void Add(T v)
        {
            Node<T> current = Head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            Node<T> nextValue = new Node<T>(v);
            current.Next = nextValue;
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public int IndexOf(T item)
        {
            throw new NotImplementedException();
        }

        public void Insert(int index, T item)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public void RemoveAt(int index)
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

}
