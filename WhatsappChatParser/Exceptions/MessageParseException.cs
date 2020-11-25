using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsappChatParser.Exceptions
{
    public class MessageParseException : Exception
    {
        public MessageParseException()
            : base()
        {

        }

        public MessageParseException(string message)
            : base(message)
        {

        }

        public MessageParseException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}
