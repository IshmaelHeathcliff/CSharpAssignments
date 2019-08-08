using System;

namespace APT
{
    class Program
    {
        static void Main(string[] args)
        {
            AbstractList<int> adt = new AbstractList<int>(1);
            adt.Add(2);
            adt.Add(3);
            Console.WriteLine(adt.GetValue(0));
            Console.WriteLine(adt.GetValue(1));
            Console.WriteLine(adt.GetValue(2));
            Console.ReadKey();
        }
    }

    class AbstractList<T> where T : new()
    {
        private T val;
        private AbstractList<T> next;
        public T Value
        {
            get { return this.val; }
            set { this.val = value; }
        }

        public AbstractList<T> Next
        {
            get { return this.next; }
            set { this.next = value; }
        }


        public AbstractList() : this(new T()) { }

        public AbstractList(T v)
        {
            this.val = v;
            this.next = null;
        }

        public void Add(T v)
        {
            AbstractList<T> current = this;
            while (current.Next != null)
            {
                current = current.Next;
            }
            AbstractList<T> nextValue = new AbstractList<T>(v);
            current.Next = nextValue;
        }

        public T GetValue(int index)
        {
            AbstractList<T> current = this;
            for (int i=0; i < index; i++)
            {
                current = current.Next;
            }

            return current.Value;
        }
    }

}
