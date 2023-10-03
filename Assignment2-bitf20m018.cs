using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_2
{
    class Program
    {
        static string ConcatenateNames(string first, string last)
        {
            string res = first + " " + last;
            return res;
        }

        static string FetchingSubstring(string input)
        {
            if (input.Length <= 5)
            {
                return input;
            }
            else
            {
                return input.Substring(input.Length - 5);
            }
        }

        static string GetTemperatureMessage()
        {
            double temperature;
            string city;

            Console.WriteLine("Please enter the current temperature (in degrees Celsius):");
            double.TryParse(Console.ReadLine(), out temperature); 

            Console.WriteLine("Please enter the name of your city:");
            city = Console.ReadLine();

            return $"The temperature in {city} is {temperature} degrees Celsius.";
        }
        static void ArrayIterationForEachLoop(string[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine(array[i]);
            }
        }
        static void ArrayIterationForEach(string[] array)
        {
            foreach (string item in array)
            {
                Console.Write(item + ", ");
            }
            Console.WriteLine(); 
        }

        static int CalculateSum(int[] array)
        {
            int sum = 0;
            int index = 0;

            do
            {
                sum += array[index];
                index++;
            } while (index < array.Length);

            return sum;
        }

        static int ToFindMaxValue(int[] array)
        {
            if (array.Length == 0)
            {
                throw new ArgumentException("Array must not be empty");
            }

            int maxValue = array[0]; 

            int index = 1;

            while (index < array.Length)
            {
                if (array[index] > maxValue)
                {
                    maxValue = array[index];
                }

                index++;
            }

            return maxValue;
        }

        static void ReverseTheArray(int[] array)
        {
            int left = 0;
            int right = array.Length - 1;

            while (left < right)
            {
             
                int temp = array[left];
                array[left] = array[right];
                array[right] = temp;

                left++;
                right--;
            }
        }
        static int BoxUnboxAnInteger(int value)
        {
            // Boxing: Convert the integer into an object
            object boxedValue = value;

            // Unboxing: Convert the object back to an integer
            int unboxedValue = (int)boxedValue;

            return unboxedValue;
        }
        static double BoxUnboxADouble(double value)
        {
            // Boxing: Convert the double into an object
            object boxedValue = value;

            // Unboxing: Convert the object back to a double
            double unboxedValue = (double)boxedValue;

            return unboxedValue;
        }
        static void Main(string[] args)
        {

            //Task-01
            Console.WriteLine("Please enter your first name:");
            string fName = Console.ReadLine();
            Console.WriteLine("Please enter your last name:");
            string lName = Console.ReadLine();
            string fullName = ConcatenateNames(fName, lName);
            Console.WriteLine("Your full name is: " + fullName);
            Console.WriteLine();

            //Task-02
            Console.WriteLine("Please enter a sentence to find substring:");
            string sentence = Console.ReadLine();
            string lastFiveCharacters = FetchingSubstring(sentence);
            Console.WriteLine("Last 5 characters: " + lastFiveCharacters);
            Console.WriteLine();


            //Task-03
            string message = GetTemperatureMessage();
            Console.WriteLine(message);
            Console.WriteLine();

            //Task-04
            int[] numbers = new int[5];
            numbers[0] = 1;
            numbers[1] = 2;
            numbers[2] = 3;
            numbers[3] = 4;
            numbers[4] = 5;
            Console.WriteLine("Elements of the 'numbers' array:");
            foreach (int number in numbers)
            {
                Console.WriteLine(number);
            }
            Console.WriteLine();

            //Task-05
            //a
            string[] fruits = { "Apple", "Banana", "Orange", "Grapes", "Strawberry" };
            Console.WriteLine("Using a for loop:");
            ArrayIterationForEachLoop(fruits);
            Console.WriteLine();
            //b
            string[] colors = { "Red", "Blue", "Green", "Yellow", "Orange" };
            Console.WriteLine("Using a foreach loop:");
            ArrayIterationForEach(colors);
            Console.WriteLine();




            //Task-06

            int[] scores = new int[10];
            Random random = new Random();
            for (int i = 0; i < scores.Length; i++)
            {
                scores[i] = random.Next(30, 100);
            }
            int sum = CalculateSum(scores);
            Console.WriteLine("Test Scores are:");
            foreach (int score in scores)
            {
                Console.Write(score + " ");
            }
            Console.WriteLine("\nTotal Sum: " + sum);
            Console.WriteLine();


            //Task-07
            int[] values = { 34, 56, 12, 78, 45, 90, 23, 67, 89, 55 };
            int maxValue = ToFindMaxValue(values);
            Console.WriteLine("The maximum value in the array is: " + maxValue);
            Console.WriteLine();

            //Task-08
            int[] numbers1= { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            ReverseTheArray(numbers1);

            Console.WriteLine("Reversed Array:");
            foreach (int numb in numbers1)
            {
                Console.Write(numb + " ");
            }
            Console.WriteLine();

            //Task-9
            // a.Boxing and Unboxing an Integer:
            int x = 72;
            int y = BoxUnboxAnInteger(x);
            Console.WriteLine("Original integer (x): " + x);
            Console.WriteLine("Unboxed integer (y): " + y);
            Console.WriteLine();
            // a.Boxing and Unboxing a Double:
            double doubleVal = 3.174159;
            double unboxedVal = BoxUnboxADouble(doubleVal);
            Console.WriteLine("Original double (doubleValue): " + doubleVal);
            Console.WriteLine("Unboxed double (unboxedValue): " + unboxedVal);
            Console.WriteLine();

            //TASK-10
            //a.Box and Unbox in an Array of Integers:

            int[] Arr = { 5, 10, 15, 20, 25 };

            for (int i = 0; i < Arr.Length; i++)
            {
                // Box the current integer value
                object boxedValue = Arr[i];
                int unboxedValue = (int)boxedValue;

                // Calculate the square of the unboxed integer
                int squaredValue = unboxedValue * unboxedValue;

                // Display both the original integer and its squared value
                Console.WriteLine($"Original Integer: {unboxedValue}, Squared Value: {squaredValue}");
            }
            Console.WriteLine();

            //b.Boxing and Unboxing in a Generic List with Different Value Types:

            List<object> mixedList = new List<object>();

            // Adding elements of different value types
            mixedList.Add(42);       // int
            mixedList.Add(3.14159);  // double
            mixedList.Add('A');      // char

            Console.WriteLine("Elements in the List:");

            foreach (var item in mixedList)
            {
                Console.WriteLine($"Element: {item}, Type: {item.GetType()}");
            }
            Console.WriteLine();


            //Task-11

            //a. Using the dynamic keyword to assign different types to a variable:
            dynamic myVariable;
            myVariable = 42;
            Console.WriteLine("myVariable (integer): " + myVariable);
            myVariable = "Hello, Dynamic!";
            Console.WriteLine("myVariable (string): " + myVariable);
            Console.WriteLine();
            Console.WriteLine();

            //b. Assigning different types to a dynamic variable and using GetType() to display their types:
            dynamic myVariable2;
            myVariable2 = 42;
            Console.WriteLine("myVariable2 (integer) Type: " + myVariable2.GetType());
            myVariable2 = 3.14159;
            Console.WriteLine("myVariable2 (double) Type: " + myVariable2.GetType());
            myVariable2 = DateTime.Now;
            Console.WriteLine("myVariable2 (DateTime) Type: " + myVariable2.GetType());
            myVariable2 = "Dynamic";
            Console.WriteLine("myVariable2 (string) Type: " + myVariable2.GetType());
        }
    }
}
