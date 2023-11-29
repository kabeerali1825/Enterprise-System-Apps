using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_8
{
    internal class Interpreter_Design_Pattern
    {
        //Example-01- Interpreter Design Pattern
        // Abstract expression
        public interface IExpression
        {
            int Interpret();
        }

        // Terminal expression
        public class NumberExpression : IExpression
        {
            private readonly int number;

            public NumberExpression(int number)
            {
                this.number = number;
            }

            public int Interpret()
            {
                return number;
            }
        }

        // Non-terminal expression
        public class AdditionExpression : IExpression
        {
            private readonly IExpression left;
            private readonly IExpression right;

            public AdditionExpression(IExpression left, IExpression right)
            {
                this.left = left;
                this.right = right;
            }

            public int Interpret()
            {
                return left.Interpret() + right.Interpret();
            }
        }

        public class SubtractionExpression : IExpression
        {
            private readonly IExpression left;
            private readonly IExpression right;

            public SubtractionExpression(IExpression left, IExpression right)
            {
                this.left = left;
                this.right = right;
            }

            public int Interpret()
            {
                return left.Interpret() - right.Interpret();
            }
        }



        //Example-02- Interpreter Design Pattern
        // Context
        public class RomanContext
        {
            public string Input { get; set; }
            public int Output { get; set; }
        }

        // Abstract expression
        public interface IRomanExpression
        {
            void Interpret(RomanContext context);
        }

        // Terminal expression
        public class ThousandExpression : IRomanExpression
        {
            public void Interpret(RomanContext context)
            {
                if (context.Input.StartsWith("M"))
                {
                    context.Output += 1000;
                    context.Input = context.Input.Substring(1);
                }
            }
        }

        // Non-terminal expression
        public class HundredExpression : IRomanExpression
        {
            public void Interpret(RomanContext context)
            {
                if (context.Input.StartsWith("CM"))
                {
                    context.Output += 900;
                    context.Input = context.Input.Substring(2);
                }
                else if (context.Input.StartsWith("CD"))
                {
                    context.Output += 400;
                    context.Input = context.Input.Substring(2);
                }
                else if (context.Input.StartsWith("D"))
                {
                    context.Output += 500;
                    context.Input = context.Input.Substring(1);
                }
                else if (context.Input.StartsWith("C"))
                {
                    context.Output += 100;
                    context.Input = context.Input.Substring(1);
                }
            }
        }

       
    }
}
