using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_8
{
    internal class Template_Method_Design_Pattern
    {
        //Example-01-Template Method Design Pattern
        public abstract class CookingRecipe
        {
            public void PrepareRecipe()
            {
                PrepareIngredients();
                Cook();
                Serve();
            }

            protected abstract void PrepareIngredients();
            protected abstract void Cook();
            protected virtual void Serve()
            {
                Console.WriteLine("Serve in a plate.");
            }
        }

        // Concrete class implementing the recipe
        public class PastaRecipe : CookingRecipe
        {
            protected override void PrepareIngredients()
            {
                Console.WriteLine("Prepare pasta, sauce, and cheese.");
            }

            protected override void Cook()
            {
                Console.WriteLine("Boil the pasta, heat the sauce, and mix.");
            }

            protected override void Serve()
            {
                Console.WriteLine("Serve pasta on a plate, garnish with cheese.");
            }
        }

        // Concrete class implementing another recipe
        public class SandwichRecipe : CookingRecipe
        {
            protected override void PrepareIngredients()
            {
                Console.WriteLine("Prepare bread, vegetables, and filling.");
            }

            protected override void Cook()
            {
                Console.WriteLine("Assemble the sandwich and grill.");
            }
        }

        //Example-02-Template Method Design Pattern
        public abstract class OnlineOrderingProcess
        {
            public void ProcessOrder()
            {
                SelectProduct();
                AddToCart();
                MakePayment();
                ShipOrder();
            }

            protected abstract void SelectProduct();
            protected abstract void AddToCart();
            protected abstract void MakePayment();

            protected virtual void ShipOrder()
            {
                Console.WriteLine("Shipping the order.");
            }
        }

        // Concrete class for ordering electronics
        public class ElectronicsOrder : OnlineOrderingProcess
        {
            protected override void SelectProduct()
            {
                Console.WriteLine("Select electronics product.");
            }

            protected override void AddToCart()
            {
                Console.WriteLine("Add electronics to cart.");
            }

            protected override void MakePayment()
            {
                Console.WriteLine("Make payment for electronics.");
            }
        }

        // Concrete class for ordering clothing
        public class ClothingOrder : OnlineOrderingProcess
        {
            protected override void SelectProduct()
            {
                Console.WriteLine("Select clothing product.");
            }

            protected override void AddToCart()
            {
                Console.WriteLine("Add clothing to cart.");
            }

            protected override void MakePayment()
            {
                Console.WriteLine("Make payment for clothing.");
            }
        }

    }
}
