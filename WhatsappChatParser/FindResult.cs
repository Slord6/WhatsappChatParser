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
    public partial class FindResult : Form
    {
        List<Message> foundMessages;
        public FindResult(List <Message> messages)
        {
            InitializeComponent();
            foundMessages = messages;

            foreach (Message msg in foundMessages)
            {
                ListViewItem item = new ListViewItem(msg.SentDateTime + " " + msg.Sender + ": " + msg.Body);
                messageListView.Items.Add(item);
            }

            if (messageListView.Columns.Count > 0)
            {
                //resize
            }
        }

        private void messageListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            MessageViewer vwr = new MessageViewer(foundMessages[messageListView.Items.IndexOf(messageListView.SelectedItems[0])]);
            vwr.Show();
        }
    }
}
