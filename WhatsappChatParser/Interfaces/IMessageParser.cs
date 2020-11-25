using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsappChatParser.Interfaces
{
    public interface IMessageParser
    {
        Message Parse();
        bool IsValidMessage(out Message message);
    }
}
