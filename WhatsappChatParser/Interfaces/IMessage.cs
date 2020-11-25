using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsappChatParser.Interfaces
{
    public interface IMessage
    {
        /// <summary>
        /// The time the message was sent
        /// </summary>
        DateTime SentDateTime { get; }
        /// <summary>
        /// The person who send the message
        /// </summary>
        Person Sender { get; }
        /// <summary>
        /// The message body
        /// </summary>
        string Body { get; }
        /// <summary>
        /// Which message this was in the chat
        /// </summary>
        int Index { get; }
        /// <summary>
        /// The message sent prior to this one
        /// </summary>
        Message Previous { get; set; }
        /// <summary>
        /// The message sent after this one
        /// </summary>
        Message Next { get; set; }

        /// <summary>
        /// Append content to the body of the message
        /// </summary>
        /// <param name="content">The content to add</param>
        void AddMessageContent(string content);

    }
}
