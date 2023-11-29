using System;
using System.Collections;
using System.Collections.Generic;
using static Assignment_8.Chain_Of_Responsibility_Design_Pattern;
using static Assignment_8.Command_Design_Pattern;
using static Assignment_8.Memento_Design_Pattern;
using static Assignment_8.Observer_Design_Pattern;
using static Assignment_8.State_Design_Pattern;
using static Assignment_8.Strategy_Design_Pattern;
using static Assignment_8.Interpreter_Design_Pattern;
using static Assignment_8.Iterator_Design_Pattern;
using static Assignment_8.Mediator_Design_Pattern;
using static Assignment_8.Template_Method_Design_Pattern;
using static Assignment_8.Visitor_Design_Pattern;

//BITF20M018-KABEER ALI BEHARVIROL DESIGN PATTERN ASSIGNMENT08
namespace Assignment_8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("********Template Method Design Patterns*********");
             //Template Method-01
            Console.WriteLine("Ordering Electronics:");
            OnlineOrderingProcess electronicsOrder = new ElectronicsOrder();
            electronicsOrder.ProcessOrder();
            Console.WriteLine("\nOrdering Clothing:");
            OnlineOrderingProcess clothingOrder = new ClothingOrder();
            clothingOrder.ProcessOrder();
            Console.WriteLine();
            //Template Method-Example02
            Console.WriteLine("Making Pasta:");
            CookingRecipe pasta = new PastaRecipe();
            pasta.PrepareRecipe();
            Console.WriteLine("\nMaking Sandwich:");
            CookingRecipe sandwich = new SandwichRecipe();
            sandwich.PrepareRecipe();
           Console.WriteLine();



            Console.WriteLine("********Mediator Method Design Patterns*********");
            //Mediator Method-01
            IAirTrafficControl airTrafficControl = new AirTrafficControl();
            IFlight flight1 = new Flight(airTrafficControl, "ABC123");
            IFlight flight2 = new Flight(airTrafficControl, "XYZ789");
            flight1.SendMessage("Requesting landing clearance.");
            Console.WriteLine();
            //Mediator Method-02
            IChatMediator chatMediator = new ChatRoom();
            IUser user1 = new User(chatMediator, "User1");
            IUser user2 = new User(chatMediator, "User2");
            IUser user3 = new User(chatMediator, "User3");
            user1.Send("Hello, everyone!");
            Console.WriteLine();
            

            Console.WriteLine("********Chain of Responsibity Design Patterns*********");
            //Chain of Responsibity-01
            // Creating the chain of approvers
            Approver clerk = new Clerk();
            Approver manager = new Manager();
            Approver director = new Director();
            clerk.SetSuccessor(manager);
            manager.SetSuccessor(director);
            // Handling purchase requests
            Purchase purchase1 = new Purchase(80, "Office supplies");
            clerk.ProcessRequest(purchase1);
            Purchase purchase2 = new Purchase(500, "New printer");
            clerk.ProcessRequest(purchase2);
            Purchase purchase3 = new Purchase(6000, "Conference table");
            clerk.ProcessRequest(purchase3);
            Console.WriteLine();
            //Chain of Responsibity-02
            Logger consoleLogger = new ConsoleLogger(LogLevel.INFO);
            Logger fileLogger = new FileLogger(LogLevel.DEBUG);
            Logger emailLogger = new EmailLogger(LogLevel.ERROR);
            consoleLogger.SetNextLogger(fileLogger);
            fileLogger.SetNextLogger(emailLogger);
            consoleLogger.LogMessage(LogLevel.DEBUG, "Debugging information");
            consoleLogger.LogMessage(LogLevel.ERROR, "An error occurred");
            consoleLogger.LogMessage(LogLevel.INFO, "Informational message");
            Console.WriteLine();

            Console.WriteLine("********Observer  Design Patterns*********");
            //Observer design pattern-01
            WeatherData weatherData = new WeatherData();
            Display display1 = new Display();
            Display display2 = new Display();
            weatherData.RegisterObserver(display1);
            weatherData.RegisterObserver(display2);
            weatherData.SetTemperature(25.0f);
            weatherData.RemoveObserver(display1);
            weatherData.SetTemperature(30.0f);
            Console.WriteLine();

            //Observer design pattern-02
            Stock appleStock = new Stock("AAPL", 150.0m);
            Investor investor1 = new Investor("John");
            Investor investor2 = new Investor("Alice");
            appleStock.Attach(investor1);
            appleStock.Attach(investor2);
            appleStock.Price = 155.0m;
            appleStock.Detach(investor1 );
            appleStock.Price = 160.0m;
            Console.WriteLine();
            Console.WriteLine("********Strategy   Design Patterns*********");
            //Strategy Design Pattern-01
            List<int> numbersToSort = new List<int> { 7, 2, 5, 1, 9, 3 };
            Sorter sorter = new Sorter();

            sorter.SetSortStrategy(new BubbleSortStrategy());
            sorter.SortList(numbersToSort);

            sorter.SetSortStrategy(new QuickSortStrategy());
            sorter.SortList(numbersToSort);

            sorter.SetSortStrategy(new MergeSortStrategy());
            sorter.SortList(numbersToSort);
            Console.WriteLine();
            //Strategy Design Pattern-02
            PaymentProcessor paymentProcessor = new PaymentProcessor();

            paymentProcessor.SetPaymentStrategy(new CreditCardPayment("1234 5678 9012 3456", "12/25", "123"));
            paymentProcessor.ProcessPayment(100.0);

            paymentProcessor.SetPaymentStrategy(new PayPalPayment("example@example.com", "password123"));
            paymentProcessor.ProcessPayment(50.0);

            paymentProcessor.SetPaymentStrategy(new BitcoinPayment("1234567890abcdef"));
            paymentProcessor.ProcessPayment(75.0);
            Console.WriteLine();
            Console.WriteLine("********Command   Design Patterns*********");
            //Command design pattern-01
            Television tv = new Television();
            ICommand1 turnOn = new TurnOnCommand(tv);
            ICommand1 turnOff = new TurnOffCommand(tv);

            RemoteControl remote = new RemoteControl();
            remote.AddCommand(turnOn);
            remote.AddCommand(turnOff);

            remote.ExecuteCommands();

            Console.WriteLine();


            //Command design Pattern-02
            TextEditor editor = new TextEditor();
            ICommand2 addTextCommand = new AddTextCommand(editor, "Hello ");
            ICommand2 removeTextCommand = new RemoveTextCommand(editor, 5);
            CommandInvoker invoker = new CommandInvoker();
            invoker.ExecuteCommand(addTextCommand);
            invoker.ExecuteCommand(removeTextCommand);
            invoker.UndoLastCommand();
            invoker.UndoLastCommand();
            Console.WriteLine();
            Console.WriteLine("********State   Design Patterns*********");
            // State Design Pattern-01
            TrafficLight trafficLight = new TrafficLight();

            trafficLight.Change(); // Red to Green
            trafficLight.Change(); // Green to Red

            Console.WriteLine();

            // State Design Pattern-02
            Fan fan = new Fan();

            fan.PullChain(); // Off to Low
            fan.PullChain(); // Low to Medium
            fan.PullChain(); // Medium to High
            fan.PullChain(); // High to Off

            Console.WriteLine();
            Console.WriteLine("********Visitor   Design Patterns*********");
            //Visitor design pattern-01
            List<IShoppingItem> items = new List<IShoppingItem>
            {
                 new Book(30),
                 new Fruit(2.5)
            };

            ShoppingCartVisitor visitor1 = new ShoppingCartVisitor();
            foreach (var item in items)
            {
                item.Accept(visitor1);
            }

            Console.WriteLine($"Total Price: {visitor1.TotalPrice}");
            Console.WriteLine();


            //Visitor design pattern-02
            List<IElement> elements = new List<IElement>
        {
            new TextElement(),
            new ImageElement()
        };

            DocumentVisitor visitor2 = new DocumentVisitor();
            foreach (var element in elements)
            {
                element.Accept(visitor2);
            }
            Console.WriteLine();

            Console.WriteLine("********Interpreter   Design Patterns*********");
            //Interpreter Design patterns
            //Interpreter design pattern-01
            IExpression expression1 = new SubtractionExpression(
                   new AdditionExpression(new NumberExpression(10), new NumberExpression(5)),
                   new NumberExpression(2));

            int result = expression1.Interpret();
            Console.WriteLine("Result: " + result); // Output: 13


            Console.WriteLine();

            //Interpreter design pattern-02
            var context = new RomanContext { Input = "MCMLXXVIII" }; // 1978

            List<IRomanExpression> expressions = new List<IRomanExpression>
            {
            new ThousandExpression(),
            new HundredExpression(),
            };

            foreach (var expression in expressions)
            {
                expression.Interpret(context);
            }

            Console.WriteLine("Result: " + context.Output);
            Console.WriteLine();
            Console.WriteLine("********Iterator   Design Patterns*********");
            //Iterative Design patterns
            //Iterative design pattern-01
            ConcreteCollection collection1 = new ConcreteCollection();
            collection1.AddItem("Item 1");
            collection1.AddItem("Item 2");
            collection1.AddItem("Item 3");

            IIterator iterator1 = collection1.CreateIterator();

            while (iterator1.HasNext())
            {
                object item = iterator1.Next();
                Console.WriteLine(item);
            }
            Console.WriteLine();

            //Iterative design pattern-02
            CustomCollectionManual collection2 = new CustomCollectionManual();
            collection2.Add("Apple");
            collection2.Add("Banana");
            collection2.Add("Orange");
            IEnumerator iterator2 = collection2.GetEnumerator();
            while (iterator2.MoveNext())
            {
                Console.WriteLine(iterator2.Current);
            }
            Console.WriteLine();


            Console.WriteLine("********Memento   Design Patterns*********");
            //Memento Design Patterns
            //Memento design pattern-01
            TextEditorV2 editor2 = new TextEditorV2();
            editor2.Text = "Initial text";
            TextEditorMementoV2 initialMemento = editor2.Save();
            editor2.UpdateHistory(initialMemento);
            editor2.Text = "Modified text";
            TextEditorMementoV2 modifiedMemento = editor2.Save();
            editor2.UpdateHistory(modifiedMemento);
            editor2.Text = "New modification";
            editor2.Restore(editor2.Undo()); // Restoring to "Modified text"
            Console.WriteLine();

            //Memento design pattern-02
            TextEditorM editorM = new TextEditorM();
            Caretaker caretaker = new Caretaker();

            // Working with the editor
            editorM.Text = "Initial text";
            caretaker.Memento = editorM.Save(); // Saving state

            editorM.Text = "Modified text";
            editorM.Restore(caretaker.Memento); // Restoring state

            Console.WriteLine();
        }
    }
}
