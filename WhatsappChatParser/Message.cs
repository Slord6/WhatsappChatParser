using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsappChatParser.Exceptions;
using WhatsappChatParser.Interfaces;

namespace WhatsappChatParser
{
    public class Message : IComparable, IMessage
    {
        protected DateTime sendTime;
        protected Person sender;
        protected string contents;
        protected int index; //Which message this was in the chat
        
        protected Message previous;
        protected Message next;

        public static Message ParseToMessage(IMessageParser parser)
        {
            return parser.Parse();
        }

        public Message(DateTime sendTime, Person sender, string body, int index)
        {
            this.sendTime = sendTime;
            this.sender = sender;
            this.contents = body;
            this.index = index;

            sender.AddNewMessage(this);
        }

        /// <summary>
        /// Append content to the body of the message
        /// </summary>
        /// <param name="content">The content to add</param>
        public void AddMessageContent(string content)
        {
            if (contents == null)
            {
                contents = "";
            }

            contents += content;
        }

        public int CompareTo(object obj)
        {
            if (obj.GetType() != typeof(Message))
            {
                throw new ArgumentException("Can only compare Message objects");
            }

            Message other = (Message)obj;

            int sort = DateTime.Compare(sendTime, other.sendTime);

            //Messages exactly matching each other can sometimes get mixed up (especially in imports where seconds are not included,
            //therefore when comparing, if we're the same we actaully say this message goes before the other
            if(sort == 0)
            {
                sort = -1;
            }

            return sort;
        }

        public DateTime SentDateTime
        {
            get
            {
                return sendTime;
            }
        }

        public Person Sender
        {
            get
            {
                return sender;
            }
        }

        public string Body
        {
            get
            {
                return contents;
            }
        }

        public int Index
        {
            get
            {
                return index;
            }
            set
            {
                index = value;
            }
        }

        public Message Previous
        {
            get
            {
                return previous;
            }
            set
            {
                previous = value;
            }
        }

        public Message Next
        {
            get
            {
                return next;
            }
            set
            {
                next = value;
            }
        }
    }
}
