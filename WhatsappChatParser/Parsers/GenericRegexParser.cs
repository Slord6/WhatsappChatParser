using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using WhatsappChatParser.Exceptions;

namespace WhatsappChatParser.Parsers
{
    public class GenericRegexParser : MessageParser
    {
        public GenericRegexParser(string data, ChatType chatType, int messageIndex) : base(data, chatType, messageIndex)
        {
            this.data = data;
            this.chatType = chatType;
            this.messageIndex = messageIndex;
        }

        public override bool IsValidMessage(out Message message)
        {
            try
            {
                message = Parse();
                return true;
            }
            catch (Exception)
            {
                message = null;
                return false;
            }
        }

        public override Message Parse()
        {
            Regex groupChangeNameMessageRegex = new Regex("(?:\\d\\d:\\d\\d(:\\d\\d)?).*?(\\:|-) (.*\".*\" (?:(?:en)|(?:to)) \".*\".)");
            Regex dateRegex = new Regex(@"\d\d\/\d\d\/\d\d(?:\d\d)?");
            Regex timeRegex = new Regex(@"\d\d\:\d\d(?:\:\d\d)?");
            Regex userAndMessageRegex = new Regex(@"(?:\d\d:\d\d).*?- (?:(?:(.*?): )?(.*?))$");

            Match dateMatch = dateRegex.Match(data);
            Match timeMatch = timeRegex.Match(data);
            Match userAndMessageMatch = userAndMessageRegex.Match(data);
            Match groupNameChangeMatch = groupChangeNameMessageRegex.Match(data);


            DateTime sendTime = DateTime.MinValue;
            try
            {
                sendTime = DateTime.Parse(dateMatch.Value + " " + timeMatch.Value);
            }
            catch (Exception ex)
            {
                // No send time - invalid message
                throw new MessageParseException("No valid send time", ex);
            }

            // Handle system messages for group name change
            if (!String.IsNullOrEmpty(groupNameChangeMatch.Value))
            {
                return new Message(sendTime, new Person("SYSTEM"), groupNameChangeMatch.Groups[3].Value, messageIndex);
            }
            else
            {
                string sender = userAndMessageMatch.Groups[1].Value;
                if (String.IsNullOrEmpty(sender)) sender = "SYSTEM"; // any other system messages
                string message = userAndMessageMatch.Groups[2].Value;

                Person person = new Person(sender);

                return new Message(sendTime, person, message, messageIndex);
            }
        }
    }
}
