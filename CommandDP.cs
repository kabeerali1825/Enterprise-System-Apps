using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_8
{
    internal class Command_Design_Pattern
    {
        //Example-01-Command Design Pattern
        // Command interface
        public interface ICommand1
        {
            void Execute();
        }

        // Receiver (the object the commands are operating on)
        public class Television
        {
            public void TurnOn()
            {
                Console.WriteLine("TV is turned ON");
            }

            public void TurnOff()
            {
                Console.WriteLine("TV is turned OFF");
            }
        }

        // Concrete command classes
        public class TurnOnCommand : ICommand1
        {
            private readonly Television tv;

            public TurnOnCommand(Television tv)
            {
                this.tv = tv;
            }

            public void Execute()
            {
                tv.TurnOn();
            }
        }

        public class TurnOffCommand : ICommand1
        {
            private readonly Television tv;

            public TurnOffCommand(Television tv)
            {
                this.tv = tv;
            }

            public void Execute()
            {
                tv.TurnOff();
            }
        }

        // Invoker
        public class RemoteControl
        {
            private readonly List<ICommand1> commands;

            public RemoteControl()
            {
                commands = new List<ICommand1>();
            }

            public void AddCommand(ICommand1 command)
            {
                commands.Add(command);
            }

            public void ExecuteCommands()
            {
                foreach (var command in commands)
                {
                    command.Execute();
                }
                commands.Clear();
            }
        }


        //Example-02-Command Design Pattern
        // Command interface
        public interface ICommand2
        {
            void Execute();
            void Undo();
        }

        // Receiver
        public class TextEditor
        {
            private string text = "";

            public void AddText(string textToAdd)
            {
                text += textToAdd;
                Console.WriteLine("Added text: " + textToAdd);
            }

            public void RemoveText(int length)
            {
                if (length <= text.Length)
                {
                    string removed = text.Substring(text.Length - length);
                    text = text.Remove(text.Length - length);
                    Console.WriteLine("Removed text: " + removed);
                }
                else
                {
                    Console.WriteLine("Nothing to remove.");
                }
            }

            public void ShowText()
            {
                Console.WriteLine("Current Text: " + text);
            }
        }

        // Concrete command classes
        public class AddTextCommand : ICommand2
        {
            private readonly TextEditor textEditor;
            private readonly string textToAdd;

            public AddTextCommand(TextEditor textEditor, string textToAdd)
            {
                this.textEditor = textEditor;
                this.textToAdd = textToAdd;
            }

            public void Execute()
            {
                textEditor.AddText(textToAdd);
            }

            public void Undo()
            {
                textEditor.RemoveText(textToAdd.Length);
            }
        }

        public class RemoveTextCommand : ICommand2
        {
            private readonly TextEditor textEditor;
            private readonly int removedLength;

            public RemoveTextCommand(TextEditor textEditor, int removedLength)
            {
                this.textEditor = textEditor;
                this.removedLength = removedLength;
            }

            public void Execute()
            {
                textEditor.RemoveText(removedLength);
            }

            public void Undo()
            {
                // Redo the removed text by adding it back
                textEditor.ShowText();
            }
        }

        // Invoker
        public class CommandInvoker
        {
            private readonly Stack<ICommand2> history = new Stack<ICommand2>();

            public void ExecuteCommand(ICommand2 command)
            {
                history.Push(command);
                command.Execute();
            }

            public void UndoLastCommand()
            {
                if (history.Count > 0)
                {
                    ICommand2 lastCommand = history.Pop();
                    lastCommand.Undo();
                }
                else
                {
                    Console.WriteLine("No more commands to undo.");
                }
            }
        }

        
    }
}
