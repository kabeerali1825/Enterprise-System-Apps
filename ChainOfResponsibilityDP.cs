using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_8
{
    internal class Chain_Of_Responsibility_Design_Pattern
    {
        //Example-01- Chain of Responsibility Design Pattern
        public abstract class Approver
        {
            protected Approver successor;

            public void SetSuccessor(Approver successor)
            {
                this.successor = successor;
            }

            public abstract void ProcessRequest(Purchase purchase);
        }

        public class Purchase
        {
            public double Amount { get; set; }
            public string Purpose { get; set; }

            public Purchase(double amount, string purpose)
            {
                Amount = amount;
                Purpose = purpose;
            }
        }

        public class Clerk : Approver
        {
            public override void ProcessRequest(Purchase purchase)
            {
                if (purchase.Amount <= 100)
                    Console.WriteLine($"Clerk approves purchase of {purchase.Purpose}");
                else if (successor != null)
                    successor.ProcessRequest(purchase);
            }
        }

        public class Manager : Approver
        {
            public override void ProcessRequest(Purchase purchase)
            {
                if (purchase.Amount <= 1000)
                    Console.WriteLine($"Manager approves purchase of {purchase.Purpose}");
                else if (successor != null)
                    successor.ProcessRequest(purchase);
            }
        }

        public class Director : Approver
        {
            public override void ProcessRequest(Purchase purchase)
            {
                if (purchase.Amount <= 5000)
                    Console.WriteLine($"Director approves purchase of {purchase.Purpose}");
                else
                    Console.WriteLine($"Purchase of {purchase.Purpose} requires higher authority");
            }
        }

        //Example-02
        public abstract class Logger
        {
            protected Logger nextLogger;
            protected LogLevel logLevel;

            public void SetNextLogger(Logger nextLogger)
            {
                this.nextLogger = nextLogger;
            }

            public void LogMessage(LogLevel level, string message)
            {
                if (logLevel <= level)
                    WriteMessage(message);

                if (nextLogger != null)
                    nextLogger.LogMessage(level, message);
            }

            protected abstract void WriteMessage(string message);
        }

        public enum LogLevel
        {
            INFO,
            DEBUG,
            ERROR
        }

        public class ConsoleLogger : Logger
        {
            public ConsoleLogger(LogLevel logLevel)
            {
                this.logLevel = logLevel;
            }

            protected override void WriteMessage(string message)
            {
                Console.WriteLine($"Console logger: {message}");
            }
        }

        public class FileLogger : Logger
        {
            public FileLogger(LogLevel logLevel)
            {
                this.logLevel = logLevel;
            }

            protected override void WriteMessage(string message)
            {
                Console.WriteLine($"File logger: {message}");
            }
        }

        public class EmailLogger : Logger
        {
            public EmailLogger(LogLevel logLevel)
            {
                this.logLevel = logLevel;
            }

            protected override void WriteMessage(string message)
            {
                Console.WriteLine($"Email logger: {message}");
            }
        }

    }
}
