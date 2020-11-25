using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using WhatsappChatParser.Exceptions;
using WhatsappChatParser.Interfaces;
using WhatsappChatParser.Parsers;
using System.Text.RegularExpressions;
using System.Globalization;

namespace WhatsappChatParser
{
    public class WhatsappChat : Chat
    {
        private string fileContents;
        private string[] splitByLine;

        public override ChatType TypeOfChat
        {
            get
            {
                return DetermineChatType();
            }
        }

        public int TotalMessages
        {
            get
            {
                return allMessages.Count;
            }
        }

        public string AllText
        {
            get
            {
                return fileContents;
            }
        }

        public WhatsappChat(string theChat)
        {
            fileContents = theChat;

            allMessages = new List<Message>();
            chatters = new List<Person>();

            splitByLine = fileContents.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
            ChatType chatType = DetermineChatType();

            Message previousMessage = null;
            Message currentMessage = null;
            int messageIndex = 0;

            for (int i = 0; i < splitByLine.Length; i++)
            {
                if (!string.IsNullOrWhiteSpace(splitByLine[i]) && !string.IsNullOrEmpty(splitByLine[i]))
                {
                    try
                    {
                        currentMessage = Message.ParseToMessage(new GenericRegexParser(splitByLine[i], chatType, messageIndex));
                        allMessages.Add(currentMessage);
                        if (!chatters.Contains(currentMessage.Sender))
                        {
                            chatters.Add(currentMessage.Sender);
                        }
                        Person chatter = chatters.Find(eachChatter => eachChatter.Name == currentMessage.Sender.Name);
                        if (!chatter.Messages.Contains(currentMessage))
                        {
                            chatter.Messages.Add(currentMessage);
                        }
                        messageIndex++;
                    }
                    catch (MessageParseException ex)
                    {
                        previousMessage.AddMessageContent(Environment.NewLine + splitByLine[i]);
                        currentMessage = previousMessage; //still building the last message
                    }

                    //Assign the previous and next messages as appropriate to build a kind of linked list
                    if (previousMessage != null)
                    {
                        previousMessage.Next = currentMessage;
                    }
                    currentMessage.Previous = previousMessage;

                    previousMessage = currentMessage;
                    currentMessage = null;
                }
            }


            allMessages.Sort();
            startDate = allMessages[0].SentDateTime;
            endDate = allMessages[allMessages.Count - 1].SentDateTime;
        }

        public ChatType DetermineChatType()
        {
            try
            {
                if ((splitByLine[1] == "\r" && splitByLine[3] == "\r" && splitByLine[5] == "\r") ||
                    (splitByLine[1] == "" && splitByLine[3] == "" && splitByLine[5] == ""))
                {
                    return ChatType.Whatsapp_DoubleSpaceWithSeconds;
                }
                else
                {

                    string timeData = splitByLine[0].Split(new string[] { " - " }, StringSplitOptions.None)[0];
                    try
                    {
                        DateTime convertedDateTime = Convert.ToDateTime(timeData);

                        if (convertedDateTime.Second == 0) //only has 2 elements (hour and min) in time
                        {
                            return ChatType.Whatsapp_SingleSpaceWithoutSeconds;
                        }
                    }
                    catch (Exception ex)
                    {
                        //test for "25/06/2011 22:42:05: John Doe: Some message"
                        string firstTimeStamp = splitByLine[0].Split(new string[] { ": " }, StringSplitOptions.None)[0];
                        string secondTimeStamp = splitByLine[2].Split(new string[] { ": " }, StringSplitOptions.None)[0];

                        DateTime firstDateTimeStamp = Convert.ToDateTime(firstTimeStamp);
                        DateTime secondDateTimeStamp = Convert.ToDateTime(secondTimeStamp);

                        if (firstDateTimeStamp > secondDateTimeStamp) //first timestamp comes after second ergo is in reverse order
                        {
                            return ChatType.Whatsapp_ReversedFormat;
                        }
                        return ChatType.Generic;
                    }
                }
            }
            catch (Exception ex)
            {
                return ChatType.Generic;
                throw new ArgumentException("Unknown chat type", ex);
            }
            return ChatType.Generic;
            throw new ArgumentException("Unknown chat type");
        }

        /// <summary>
        /// Get the word count for all words sent in messages
        /// </summary>
        /// <param name="ignoreCase">Makes all words lower case if true</param>
        /// <param name="removePunctuation">Strips punctuation if true</param>
        /// <param name="ignoreSystemMessages">Doesn't include messages sent by the system if true</param>
        /// <param name="ignoreMediaOmmitted">For exports where media is not included, ignores Media Ommited Messages if true</param>
        /// <param name="ignoredWords">If set, words in the array matching found words (after all modifiers are applied) will be ignored</param>
        /// <returns>Dictionary of all words and the corresponding count</returns>
        public Dictionary<string, int> GetWordDistribution(Regex matchRegex, bool ignoreCase = true, bool removePunctuation = true, bool ignoreSystemMessages = true, bool ignoreMediaOmmitted = true, string[] ignoredWords = null, bool stripPostApostrophe = false)
        {
            Dictionary<string, int> wordCounts = new Dictionary<string, int>();
            int counter = 0;

            foreach (Message message in AllMessages)
            {
                if((ignoreSystemMessages && IsSystemMessage(message)) || (ignoreMediaOmmitted && IsMediaOmmitedMessage(message)))
                {
                    continue;
                }

                counter++;
                foreach (string word in message.Body.Split(' '))
                {
                    string wordModified = word;

                    if (ignoreCase)
                    {
                        wordModified = wordModified.ToLower();
                    }
                    if (removePunctuation)
                    {
                        StringBuilder stringBuilder = new StringBuilder();
                        string apostrophes = "'’";
                        string punctuation = "!\"£$%^&*()_+-={}:@~<>?[];#,./|\\`¬/*" + apostrophes;

                        foreach (char character in wordModified)
                        {
                            if(stripPostApostrophe && apostrophes.Contains(character))
                            {
                                break;
                            }
                            if (!punctuation.Contains(character))
                            {
                                stringBuilder.Append(character);
                            }
                        }

                        wordModified = stringBuilder.ToString();
                    }

                    if (!string.IsNullOrWhiteSpace(wordModified) && matchRegex.IsMatch(wordModified))
                    {
                        if (ignoredWords != null && ignoredWords.Contains(wordModified))
                        {
                            continue;
                        }
                        else
                        {
                            if (wordCounts.ContainsKey(wordModified))
                            {
                                wordCounts[wordModified]++;
                            }
                            else
                            {
                                wordCounts.Add(wordModified, 1);
                            }
                        }
                    }
                }
            }
            return wordCounts;
        }

        /// <summary>
        /// Get the count of the number of words per message
        /// </summary>
        /// <returns>Dictionary of (numberOfWords,countOfMessagesWithThatNumberOfWords)</returns>
        public Dictionary<int, int> GetMessageWordCountDistribution()
        {
            Dictionary<int, int> messageWordCounts = new Dictionary<int, int>();

            foreach (Message message in allMessages)
            {
                int wordCount = message.Body.Split(' ').Length;
                if (messageWordCounts.ContainsKey(wordCount))
                {
                    messageWordCounts[wordCount]++;
                }
                else
                {
                    messageWordCounts.Add(wordCount, 1);
                }
            }
            return messageWordCounts;
        }

        public Dictionary<string, int> GetMessageCountByDayOfWeek(bool ignoreSystemMessages = true, bool ignoreMediaOmmitted = true)
        {
            Dictionary<string, int> dailyWordCount = new Dictionary<string, int>();

            //Ensure all days are shown and in the correct order
            dailyWordCount.Add(DayOfWeek.Monday.ToString(), 0);
            dailyWordCount.Add(DayOfWeek.Tuesday.ToString(), 0);
            dailyWordCount.Add(DayOfWeek.Wednesday.ToString(), 0);
            dailyWordCount.Add(DayOfWeek.Thursday.ToString(), 0);
            dailyWordCount.Add(DayOfWeek.Friday.ToString(), 0);
            dailyWordCount.Add(DayOfWeek.Saturday.ToString(), 0);
            dailyWordCount.Add(DayOfWeek.Sunday.ToString(), 0);

            foreach (Message message in allMessages)
            {
                if (ignoreSystemMessages && IsSystemMessage(message) || ignoreMediaOmmitted && IsMediaOmmitedMessage(message))
                {
                    continue;
                }

                string day = message.SentDateTime.DayOfWeek.ToString();
                dailyWordCount[day]++;
            }
            return dailyWordCount;
        }

        /// <summary>
        /// Gets the average number of messages sent on each day of the week
        /// </summary>
        /// <param name="ignoreSystemMessages">Should system messages be ignored?</param>
        /// <param name="ignoreMediaOmmitted">Should 'Media Ommited' messages be ignored?</param>
        /// <returns>Dictionary of (dayOfWeek,averageMessageCount)</returns>
        public Dictionary<string, double> GetAverageMessageCountByDayOfWeek(bool ignoreSystemMessages = true, bool ignoreMediaOmmitted = true)
        {
            Dictionary<string, int> dailyWords = GetMessageCountByDayOfWeek(ignoreSystemMessages, ignoreMediaOmmitted);
            TimeSpan chatLength = EndDate - StartDate;
            double numberOfWeeks = chatLength.TotalDays / 7.0f;

            Dictionary<string, double> averageDailyWords = new Dictionary<string, double>();
            foreach (KeyValuePair<string, int> dayValue in dailyWords)
            {
                averageDailyWords.Add(dayValue.Key, (dayValue.Value / numberOfWeeks));
            }

            return averageDailyWords;
        }


        public Dictionary<string,int> GetMessageCountByHourOfDay(bool ignoreSystemMessages = true, bool ignoreMediaOmmitted = true)
        {
            Dictionary<string, int> countByHours = new Dictionary<string, int>();

            for(int i = 0; i < 24; i++)
            {
                countByHours.Add(i.ToString() + ":00", 0);
            }

            foreach(Message message in allMessages)
            {
                if((ignoreSystemMessages && IsSystemMessage(message)) || (ignoreMediaOmmitted && IsMediaOmmitedMessage(message)))
                {
                    continue;
                }
                int hour = message.SentDateTime.Hour;
                countByHours[hour.ToString() + ":00"] += 1;
            }

            return countByHours;
        }

        public Dictionary<string, double> GetAverageMessageCountByHourOfDay(bool ignoreSystemMessages = true, bool ignoreMediaOmmitted = true)
        {
            Dictionary<string, int> messagesByHourTotal = GetMessageCountByHourOfDay(ignoreSystemMessages, ignoreMediaOmmitted);
            TimeSpan chatLength = EndDate - StartDate;

            Dictionary<string, double> averageMessagesByHour = new Dictionary<string, double>();
            foreach(KeyValuePair<string, int> hourValue in messagesByHourTotal)
            {
                averageMessagesByHour.Add(hourValue.Key, (hourValue.Value / chatLength.TotalDays));
            }

            return averageMessagesByHour;
        }

        public Dictionary<string, int> GetMessageCountByMonth(bool ignoreSystemMessages = true, bool ignoreMediaOmmitted = true)
        {
            Dictionary<string, int> countByMonth = new Dictionary<string, int>();

            for (int i = 1; i <= 12; i++)
            {
                countByMonth.Add(CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(i), 0);
            }

            foreach (Message message in allMessages)
            {
                if ((ignoreSystemMessages && IsSystemMessage(message)) || (ignoreMediaOmmitted && IsMediaOmmitedMessage(message)))
                {
                    continue;
                }
                string month = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(message.SentDateTime.Month);
                countByMonth[month] += 1;
            }

            return countByMonth;
        }

        public Dictionary<string, double> GetAverageMessageCountByMonth(bool ignoreSystemMessages = true, bool ignoreMediaOmmitted = true)
        {
            Dictionary<string, int> messagesByMonthTotal = GetMessageCountByMonth(ignoreSystemMessages, ignoreMediaOmmitted);
            TimeSpan chatLength = EndDate - StartDate;
            // Number of years as we want average for each month, and each month occurs... once per year
            double numberOfYears = (chatLength.TotalDays / (double)365);

            Dictionary<string, double> averageMessagesByMonth = new Dictionary<string, double>();
            foreach (KeyValuePair<string, int> monthValue in messagesByMonthTotal)
            {
                averageMessagesByMonth.Add(monthValue.Key, (monthValue.Value / numberOfYears));
            }

            return averageMessagesByMonth;
        }

        public Dictionary<string, int> GetMessageCountPerUser(bool ignoreSystemMessages = true)
        {
            Dictionary<string, int> messagesByUser = new Dictionary<string, int>();

            foreach (Person sender in Participants)
            {
                if (ignoreSystemMessages && IsSystemMessage(sender.Messages[0]))
                {
                    continue;
                }
                messagesByUser.Add(sender.Name, sender.Messages.Count);
            }

            return messagesByUser;
        }

        public Dictionary<string, double> GetMessagesPerSenderPerDay(bool ignoreSystemMessages = true)
        {
            Dictionary<string, int> messagesPerUser = GetMessageCountPerUser(ignoreSystemMessages);
            double chatLengthDays = (EndDate - StartDate).TotalDays;

            Dictionary<string, double> averageMessagesPerUserPerDay = new Dictionary<string, double>();

            foreach (KeyValuePair<string, int> userMessages in messagesPerUser)
            {
                averageMessagesPerUserPerDay.Add(userMessages.Key, (userMessages.Value / chatLengthDays));
            }
            return averageMessagesPerUserPerDay;
        }
        
        /// <summary>
        /// Get the longest streak of messages a user sent without any replies
        /// </summary>
        /// <param name="ignoreSystemMessages">Should system messages be ignored?</param>
        /// <returns>A string,int ditctionary of (username,longest streak)</returns>
        public Dictionary<string, int> GetLongestMessageStreakPerUser(bool ignoreSystemMessages = true)
        {
            Dictionary<string, int> messageStreakValues = new Dictionary<string, int>();

            foreach (Person user in Participants)
            {
                if (user.Name == "SYSTEM")
                {
                    continue;
                }
                
                int longestCount = 0;
                int count = 1;
                for (int i = 1; i < user.Messages.Count; i++)
                {
                    Message prevMessage = user.Messages[i-1];
                    Message currMessage = user.Messages[i];
                    if (prevMessage.Index == currMessage.Index - 1)
                    {
                        count++;
                    }
                    else
                    {
                        if (longestCount < count)
                        {
                            longestCount = count;
                        }
                        count = 0;
                    }
                }

                if (longestCount < count)
                {
                    longestCount = count;
                }

                messageStreakValues.Add(user.Name, longestCount);
            }

            return messageStreakValues;
        }

        //public Dictionary<string, double> GetAverageMessageStreakPerUser(bool ignoreSystemMessages = true)
        //{
        //    Dictionary<string, List<int>> messageStreakValuesPerUser = new Dictionary<string, List<int>>();

        //    int currentStreak = 0;
        //    Person currentStreaker = AllMessages[0].Sender;
        //    Person previousStreaker = null;
        //    for (int i = 0; i < AllMessages.Count; i++)
        //    {
        //        currentStreaker = AllMessages[i].Sender;
        //        if (currentStreaker != previousStreaker)
        //        {
        //            AllMessages[0].
        //        }
        //    }
        //}

        public override void Merge(Chat chat)
        {
            chatters = new List<Person>();
            allMessages.AddRange(chat.AllMessages);
            allMessages.Sort();

            for (int i = 0; i < allMessages.Count; i++)
            {
                Message currentMessage = allMessages[i];
                if (i > 0)
                {
                    currentMessage.Previous = allMessages[i - 1];
                }
                else
                {
                    currentMessage.Previous = null;
                }
                //Assign 'next' value of previous message to the current message
                if (currentMessage.Previous != null)
                {
                    currentMessage.Previous.Next = currentMessage;
                }

                if (!chatters.Contains(currentMessage.Sender))
                {
                    chatters.Add(currentMessage.Sender);
                }
                //Assign messages to chatter
                chatters.Find(chatter => chatter.Name == currentMessage.Sender.Name).Messages.Add(currentMessage);
                currentMessage.Index = i;
            }

            startDate = allMessages[0].SentDateTime;
            endDate = allMessages[allMessages.Count - 1].SentDateTime;
        }

        private bool IsSystemMessage(Message message)
        {
            return (message.Sender.Name == "SYSTEM");
        }

        private bool IsMediaOmmitedMessage(Message message)
        {
            return (message.Body == "<Media omitted>") || (message.Body == "<Médias omis>");
        }
    }
    
}
