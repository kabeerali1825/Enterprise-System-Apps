using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_8
{
    internal class Visitor_Design_Pattern
    {
        //Example-01-Visitor Design Pattern
        // Element interface
        public interface IShoppingItem
        {
            void Accept(IShoppingCartVisitor visitor);
        }

        // Concrete elements
        public class Book : IShoppingItem
        {
            public double Price { get; set; }

            public Book(double price)
            {
                Price = price;
            }

            public void Accept(IShoppingCartVisitor visitor)
            {
                visitor.Visit(this);
            }
        }

        public class Fruit : IShoppingItem
        {
            public double Weight { get; set; }

            public Fruit(double weight)
            {
                Weight = weight;
            }

            public void Accept(IShoppingCartVisitor visitor)
            {
                visitor.Visit(this);
            }
        }

        // Visitor interface
        public interface IShoppingCartVisitor
        {
            void Visit(Book book);
            void Visit(Fruit fruit);
        }

        // Concrete visitor
        public class ShoppingCartVisitor : IShoppingCartVisitor
        {
            public double TotalPrice { get; private set; }

            public void Visit(Book book)
            {
                TotalPrice += book.Price * 0.05; // 5% VAT for books
            }

            public void Visit(Fruit fruit)
            {
                TotalPrice += fruit.Weight * 2; // $2 per kg for fruits
            }
        }
        //Example-02-Visitor Design Pattern
        // Element interface
        public interface IElement
        {
            void Accept(IVisitor visitor);
        }

        // Concrete elements
        public class TextElement : IElement
        {
            public void Accept(IVisitor visitor)
            {
                visitor.Visit(this);
            }
        }

        public class ImageElement : IElement
        {
            public void Accept(IVisitor visitor)
            {
                visitor.Visit(this);
            }
        }

        // Visitor interface
        public interface IVisitor
        {
            void Visit(TextElement element);
            void Visit(ImageElement element);
        }

        // Concrete visitor
        public class DocumentVisitor : IVisitor
        {
            public void Visit(TextElement element)
            {
                Console.WriteLine("Visited text element");
            }

            public void Visit(ImageElement element)
            {
                Console.WriteLine("Visited image element");
            }
        }

    }
}
