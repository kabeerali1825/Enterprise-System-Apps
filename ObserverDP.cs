using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_8
{
    internal class Observer_Design_Pattern
    {
        //Example-01-Observer Design Pattern
        public interface IObserver
        {
            void Update(float temperature);
        }

        public interface ISubject
        {
            void RegisterObserver(IObserver observer);
            void RemoveObserver(IObserver observer);
            void NotifyObservers();
        }

        public class WeatherData : ISubject
        {
            private List<IObserver> observers;
            private float temperature;

            public WeatherData()
            {
                observers = new List<IObserver>();
            }

            public void RegisterObserver(IObserver observer)
            {
                observers.Add(observer);
            }

            public void RemoveObserver(IObserver observer)
            {
                observers.Remove(observer);
            }

            public void NotifyObservers()
            {
                foreach (var observer in observers)
                {
                    observer.Update(temperature);
                }
            }

            public void SetTemperature(float temperature)
            {
                this.temperature = temperature;
                NotifyObservers();
            }
        }

        public class Display : IObserver
        {
            public void Update(float temperature)
            {
                Console.WriteLine($"Temperature updated: {temperature}");
            }
        }


        //Example-02-Observer Design Pattern
        public interface IInvestor
        {
            void Update(string stockSymbol, decimal stockPrice);
        }

        public class Stock
        {
            private string symbol;
            private decimal price;
            private List<IInvestor> investors;

            public Stock(string symbol, decimal price)
            {
                this.symbol = symbol;
                this.price = price;
                investors = new List<IInvestor>();
            }

            public void Attach(IInvestor investor)
            {
                investors.Add(investor);
            }

            public void Detach(IInvestor investor)
            {
                investors.Remove(investor);
            }

            public void Notify()
            {
                foreach (var investor in investors)
                {
                    investor.Update(symbol, price);
                }
            }

            public decimal Price
            {
                get { return price; }
                set
                {
                    if (price != value)
                    {
                        price = value;
                        Notify();
                    }
                }
            }
        }

        public class Investor : IInvestor
        {
            private string name;

            public Investor(string name)
            {
                this.name = name;
            }

            public void Update(string stockSymbol, decimal stockPrice)
            {
                Console.WriteLine($"{name} notified: {stockSymbol} price is now {stockPrice}");
            }
        }
    }
}
