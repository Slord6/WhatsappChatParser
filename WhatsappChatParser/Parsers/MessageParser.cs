using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsappChatParser.Interfaces;

namespace WhatsappChatParser.Parsers
{
    public abstract class MessageParser : IMessageParser
    {
        protected string data;
        protected ChatType chatType;
        protected int messageIndex;

        public MessageParser(string data, ChatType chatType, int messageIndex)
        {
            this.data = data;
            this.chatType = chatType;
            this.messageIndex = messageIndex;
        }

        public virtual bool IsValidMessage(out Message message)
        {
            message = Parse();
            return message != null;
        }

        public virtual Message Parse()
        {
            return null;
        }
    }
}
