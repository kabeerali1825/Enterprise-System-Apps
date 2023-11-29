using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_8
{
   
    internal class Iterator_Design_Pattern
    {
        //Example-01-Iterator Design Pattern
        // Aggregate interface
        public interface IAbstractCollection
        {
            IIterator CreateIterator();
        }

        // Iterator interface
        public interface IIterator
        {
            bool HasNext();
            object Next();
        }

        // Concrete aggregate
        public class ConcreteCollection : IAbstractCollection
        {
            private readonly List<object> items = new List<object>();

            public void AddItem(object item)
            {
                items.Add(item);
            }

            public IIterator CreateIterator()
            {
                return new ConcreteIterator(this);
            }

            public int Count()
            {
                return items.Count;
            }

            public object GetItem(int index)
            {
                return items[index];
            }
        }

        // Concrete iterator
        public class ConcreteIterator : IIterator
        {
            private readonly ConcreteCollection collection;
            private int index = 0;

            public ConcreteIterator(ConcreteCollection collection)
            {
                this.collection = collection;
            }

            public bool HasNext()
            {
                return index < collection.Count();
            }

            public object Next()
            {
                if (HasNext())
                {
                    object obj = collection.GetItem(index);
                    index++;
                    return obj;
                }
                else
                {
                    throw new InvalidOperationException("End of collection reached");
                }
            }
        }


        //Example-02-Iterator Design Pattern
        // Custom collection with manual iterator
        public class CustomCollectionManual : IEnumerable
        {
            private readonly List<string> data = new List<string>();

            public void Add(string value)
            {
                data.Add(value);
            }

            // Manual iterator implementation
            public IEnumerator GetEnumerator()
            {
                return new CustomIterator(data);
            }

            // Custom iterator class implementing IEnumerator
            private class CustomIterator : IEnumerator
            {
                private readonly List<string> collection;
                private int position = -1;

                public CustomIterator(List<string> collection)
                {
                    this.collection = collection;
                }

                public bool MoveNext()
                {
                    position++;
                    return position < collection.Count;
                }

                public void Reset()
                {
                    position = -1;
                }

                public object Current => collection[position];
            }
        }
    }
}
