using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace MainNamespace
{
    public class Node
    {
        private String Text { get; set; }
        public Node Next { get; set; }
        public Node(String text) { this.Text = text; }

        public String getText() => Text;
        public String setText(String text) => this.Text = text;
    }

    public class LinkedList : IEnumerable<String>
    {
        public Node Head { get; set; }
        public Node Tail { get; set; }

        // добавление
        public void Add(String text)
        {
            Node node = new Node(text);

            if (Head == null)
                Head = node;
            else
                Tail.Next = node;
            Tail = node;
        }

        // удаление
        public bool Remove(String text)
        {
            Node current = Head;
            Node previous = null;

            while (current != null)
            {
                if (current.getText().Equals(text))
                {
                    if (previous != null)
                    {
                        previous.Next = current.Next;

                        if (current.Next == null)
                            Tail = previous;
                    }
                    else
                    {
                        Head = Head.Next;

                        if (Head == null)
                            Tail = null;
                    }
                    return true;
                }

                previous = current;
                current = current.Next;
            }
            return false;
        }

        // очистка
        public void Clear()
        {
            Head = null;
            Tail = null;
        }

        // Реверс
        public void Revers()
        {
            String head_text = Tail.getText();
            Node next0 = Head.Next;
            Head.Next = null;
            Node next1 = next0.Next;
            next0.Next = Head;
            do
            {
                Head = next0;
                next0 = next1;
                next1 = next0.Next;
                next0.Next = Head;
            } while (next1 != null);

            AppendFirst(head_text);
        }

        // добвление в начало
        public void AppendFirst(String text)
        {
            Node node = new Node(text);
            node.Next = Head;
            Head = node;
        }

        public IEnumerator<string> GetEnumerator()
        {
            Node current = Head;
            while (current != null)
            {
                yield return current.getText();
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }
    }
}
