using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsappChatParser
{
    public enum ChatType
    {
        Whatsapp_SingleSpaceWithoutSeconds,
        Whatsapp_DoubleSpaceWithSeconds,
        Whatsapp_ReversedFormat,
        Generic,
        UnknownFormat
    }
}
