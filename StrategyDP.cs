using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_8
{
   
    internal class Strategy_Design_Pattern
    {
        //Example-01-Strategy Design Pattern
        public interface ISortStrategy
        {
            void Sort(List<int> numbers);
        }

        public class BubbleSortStrategy : ISortStrategy
        {
            public void Sort(List<int> numbers)
            {
                Console.WriteLine("Sorting using Bubble Sort");
               
            }
        }

        public class QuickSortStrategy : ISortStrategy
        {
            public void Sort(List<int> numbers)
            {
                Console.WriteLine("Sorting using Quick Sort");
               
            }
        }

        public class MergeSortStrategy : ISortStrategy
        {
            public void Sort(List<int> numbers)
            {
                Console.WriteLine("Sorting using Merge Sort");
                
            }
        }

        public class Sorter
        {
            private ISortStrategy _sortStrategy;

            public void SetSortStrategy(ISortStrategy sortStrategy)
            {
                _sortStrategy = sortStrategy;
            }

            public void SortList(List<int> numbers)
            {
                _sortStrategy.Sort(numbers);
            }
        }
        //Example-02-Strategy Design Pattern
        public interface IPaymentStrategy
        {
            void Pay(double amount);
        }

        public class CreditCardPayment : IPaymentStrategy
        {
            private readonly string cardNumber;
            private readonly string expiryDate;
            private readonly string cvv;

            public CreditCardPayment(string cardNumber, string expiryDate, string cvv)
            {
                this.cardNumber = cardNumber;
                this.expiryDate = expiryDate;
                this.cvv = cvv;
            }

            public void Pay(double amount)
            {
                Console.WriteLine($"Paid {amount} using Credit Card");
                
            }
        }

        public class PayPalPayment : IPaymentStrategy
        {
            private readonly string email;
            private readonly string password;

            public PayPalPayment(string email, string password)
            {
                this.email = email;
                this.password = password;
            }

            public void Pay(double amount)
            {
                Console.WriteLine($"Paid {amount} using PayPal");
             
            }
        }

        public class BitcoinPayment : IPaymentStrategy
        {
            private readonly string bitcoinAddress;

            public BitcoinPayment(string bitcoinAddress)
            {
                this.bitcoinAddress = bitcoinAddress;
            }

            public void Pay(double amount)
            {
                Console.WriteLine($"Paid {amount} using Bitcoin");
          
            }
        }

        public class PaymentProcessor
        {
            private IPaymentStrategy _paymentStrategy;

            public void SetPaymentStrategy(IPaymentStrategy paymentStrategy)
            {
                _paymentStrategy = paymentStrategy;
            }

            public void ProcessPayment(double amount)
            {
                _paymentStrategy.Pay(amount);
            }
        }
    }
}
