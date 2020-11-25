using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WhatsappChatParser
{
    public partial class Find : Form
    {
        WhatsappChat chat;
        private Action<List<Message>, string, Find> foundCallback = (List<Message> messages, string query, Find find) => new FindResult(messages).Show();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="chat"></param>
        /// <param name="findClickCallback">Callback, if the callback returns</param>
        public Find(WhatsappChat chat, Action<List<Message>, string, Find> foundCallback = null)
        {
            InitializeComponent();
            this.chat = chat;
            if (foundCallback != null) this.foundCallback = foundCallback;
        }

        private void findButton_Click(object sender, EventArgs e)
        {
            string query = findTextBox.Text;
            if (query != "")
            {
                List<Message> matches = FindMatchingMessages(query, chat.AllMessages);
                foundCallback(matches, query, this);
            }
        }

        public List<Message> FindMatchingMessages(string query, List<Message> messages)
        {
            List<Message> matches = new List<Message>();
            foreach (Message msg in messages)
            {
                bool nameFound = msg.Sender.ToString().Contains(query);
                bool dateTimeFound = msg.SentDateTime.ToString().Contains(query);
                bool bodyFound = msg.Body.Contains(query);

                if (nameFound || bodyFound || dateTimeFound)
                {
                    matches.Add(msg);
                }
            }
            return matches;
        }
    }
}
