using System;

namespace DMessager.Example
{
    public class MessageBuilder
    {
        private string text;
        private string author;
        private DateTime createdAt;

        public MessageBuilder(string author, string text)
        {
            this.text = text;
            this.author = author;
            this.createdAt = DateTime.Now;
        }

        public string Text => text;

        public string Author => author;

        public DateTime CreatedAt => createdAt;
    }
}