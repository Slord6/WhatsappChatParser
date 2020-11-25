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
    public partial class MessageViewer : Form
    {
        private Message displayedMessage;

        public MessageViewer(Message message)
        {
            InitializeComponent();
            AssignData(message);
        }

        private void AssignData(Message message)
        {
            displayedMessage = message;
            messageSenderNameTextBox.Text = message.Sender.ToString();
            dateTimeSentTextBox.Text = message.SentDateTime.ToString();
            messageBodyTextbox.Text = message.Body;

            previousMessageButton.Enabled = (message.Previous != null);
            nextMessageButton.Enabled = (message.Next != null);
        }

        private void previousMessageButton_Click(object sender, EventArgs e)
        {
            AssignData(displayedMessage.Previous);
        }

        private void nextMessageButton_Click(object sender, EventArgs e)
        {
            AssignData(displayedMessage.Next);
        }
    }
}
