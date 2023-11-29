using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_8
{
    internal class Memento_Design_Pattern
    {
        //Example-01- Memento Design Pattern
        // Originator - TextEditor
        public class TextEditorM
        {
            private string text;

            public string Text
            {
                get => text;
                set
                {
                    text = value;
                    Console.WriteLine($"Current Text: {text}");
                }
            }

            public TextEditorMemento Save()
            {
                return new TextEditorMemento(text);
            }

            public void Restore(TextEditorMemento memento)
            {
                text = memento.GetSavedText();
                Console.WriteLine($"Restored Text: {text}");
            }
        }

        // Memento - TextEditorMemento
        public class TextEditorMemento
        {
            private readonly string text;

            public TextEditorMemento(string text)
            {
                this.text = text;
            }

            public string GetSavedText()
            {
                return text;
            }
        }

        // Caretaker
        public class Caretaker
        {
            public TextEditorMemento Memento { get; set; }
        }


        //Example-02- Memento Design Pattern
        // Originator - TextEditor
        public class TextEditorV2
        {
            private string text;
            private readonly Stack<TextEditorMementoV2> history = new Stack<TextEditorMementoV2>();

            public string Text
            {
                get => text;
                set
                {
                    text = value;
                    Console.WriteLine($"Current Text: {text}");
                }
            }

            public TextEditorMementoV2 Save()
            {
                return new TextEditorMementoV2(text);
            }

            public void Restore(TextEditorMementoV2 memento)
            {
                text = memento.GetSavedText();
                Console.WriteLine($"Restored Text: {text}");
            }

            public void UpdateHistory(TextEditorMementoV2 memento)
            {
                history.Push(memento);
            }

            public TextEditorMementoV2 Undo()
            {
                if (history.Count > 0)
                {
                    return history.Pop();
                }
                else
                {
                    return null;
                }
            }
        }

        // Memento - TextEditorMementoV2
        public class TextEditorMementoV2
        {
            private readonly string text;

            public TextEditorMementoV2(string text)
            {
                this.text = text;
            }

            public string GetSavedText()
            {
                return text;
            }
        }
    }
}
