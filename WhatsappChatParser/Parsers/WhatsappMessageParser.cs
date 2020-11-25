using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsappChatParser.Exceptions;

namespace WhatsappChatParser.Parsers
{
    public class WhatsappMessageParser : MessageParser
    {
        public WhatsappMessageParser(string data, ChatType chatType, int messageIndex) : base(data, chatType, messageIndex)
        {

        }

        public override bool IsValidMessage(out Message message)
        {
            try
            {
                message = Parse();
                return message != null;
            }
            catch(MessageParseException)
            {
                message = null;
                return false;
            }
        }

        public override Message Parse()
        {
            try
            {
                switch (chatType)
                {
                    case ChatType.Whatsapp_SingleSpaceWithoutSeconds:
                        {
                            /* EG:
                                21/03/2015, 01:35 - Bob Jones created group â€GroupNameâ€
                                21/03/2015, 01:35 - You were added
                                19/03/2016, 11:51 - James Smith: Hey all! We vaguely spoke about camping during the last week of the Easter holidays
                                19/03/2016, 11:52 - Bob Kingles: This is interesting to me
                             */

                            string[] sections = data.Split(new string[] { " - " }, StringSplitOptions.None); //datetime | name: message
                            DateTime sendTime = Convert.ToDateTime(sections[0]);
                            string[] senderAndMessage = sections[1].Split(new string[] { ": " }, StringSplitOptions.None); // name | message (probably, we'll check next)

                            //detect system messages
                            //eg 21/03/2015, 01:35 - Bob Jones created group â€GroupNameâ€
                            //or 21/03/2015, 01:35 - You were added
                            Person sender;
                            int contentStartIndex;
                            if (senderAndMessage.Length < 2)
                            {
                                sender = new Person("SYSTEM");
                                contentStartIndex = 0;
                            }
                            //normal message
                            //eg 19/03/2016, 11:52 - Bob Kingles: This is interesting to me
                            else
                            {
                                sender = new Person(senderAndMessage[0]);
                                contentStartIndex = 1;
                            }

                            string contents = "";
                            for (int i = contentStartIndex; i < senderAndMessage.Length; i++)
                            {
                                contents += senderAndMessage[i];
                                if (i != (senderAndMessage.Length - 1))
                                {
                                    contents += ": ";
                                }
                            }
                            return new Message(sendTime, sender, contents, messageIndex);
                        }
                    case ChatType.Whatsapp_DoubleSpaceWithSeconds:
                    case ChatType.Whatsapp_ReversedFormat:
                        {
                            /* EG:
                           29/03/2015 22:17:48: Sam Wellington: Congrats on the curtains, welcome to the club 👍

                           29/03/2015 22:46:07: Beth Jones: I was so happy to see them, apparently mum whipped them up yesterday. Apparently she knew I was worried about not having them hahah

                           29/03/2015 22:50:53: Beth Jones: You know what is just as good as curtains?

                           30/03/2015 07:52:54: Sam Wellington: What's that?
                            */
                            string separator = ": ";
                            string[] sections = data.Split(new string[] { separator }, StringSplitOptions.None); //datetime | username | message ( | maybe more message)
                            DateTime sendTime = Convert.ToDateTime(sections[0]);

                            int startPosition;
                            Person sender;
                            if (sections.Length > 2)
                            {
                                sender = new Person(sections[1]);
                                startPosition = 2;
                            }
                            else
                            {
                                sender = new Person("SYSTEM");
                                startPosition = 1;
                            }

                            string contents = "";
                            for (int i = startPosition; i < sections.Length; i++)
                            {
                                contents += sections[i];
                                if (i != (sections.Length - 1))
                                {
                                    contents += separator;
                                }
                            }
                            return new Message(sendTime, sender, contents, messageIndex);
                        }
                    case ChatType.UnknownFormat:
                    default:
                        throw new ArgumentException("Unknown chat format");
                }
            }
            catch (Exception ex)
            {
                MessageParseException outerException = new MessageParseException("Data was not a valid message", ex);
                throw outerException;
            }
        }
    }
}
