using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WhatsappChatParser
{
    public partial class MainForm : Form
    {
        string allText;
        WhatsappChat currentChat;
        
        public MainForm()
        {
            InitializeComponent();
            toolsToolStripMenuItem.Enabled = false;
        }
        
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void OpenFile()
        {
            DialogResult result = openFileMenu.ShowDialog();

            if (result != DialogResult.Cancel && File.Exists(openFileMenu.FileName))
            {
                currentChat = null;
                allText = null;

                infoLabel.Text = "Loading File...";

                string[] allLines = File.ReadAllLines(openFileMenu.FileName);
                allText = String.Join(Environment.NewLine, allLines.ToArray());
                messageListView.Clear();
                try
                {
                    currentChat = new WhatsappChat(allText);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Parsing Failed - " + ex.Message);
                    allText = null;
                    currentChat = null;
                    toolsToolStripMenuItem.Enabled = false;
                    return;
                }

                infoLabel.Text = "Updating display";
                
                Task.Run(() => 
                    {
                        UpdateMessageView();
                    });

                toolsToolStripMenuItem.Enabled = true;
            }
            else
            {
                infoLabel.Text = "File not loaded.";
            }
        }

        private async Task UpdateMessageView()
        {
            int total = currentChat.AllMessages.Count;
            int count = 1;
            int step = total / 20;
            if(step < 1)
            {
                step = 1;
            }

            List<ListViewItem> listViewAdditions = new List<ListViewItem>();
            //Update display - super slow
            foreach (Message msg in currentChat.AllMessages)
            {
                if (count % step == 0)
                {
                    messageListView.Invoke((MethodInvoker)delegate {
                        messageListView.Items.AddRange(listViewAdditions.ToArray());
                    });
                    listViewAdditions.Clear();

                    infoLabel.Invoke((MethodInvoker)delegate {
                        infoLabel.Text = "Updating display - " + ((float)((float)count / (float)total)*100).ToString("#.##") + "%";
                    });
                }
                ListViewItem item = new ListViewItem(msg.SentDateTime + " " + msg.Sender + ": " + msg.Body);
                listViewAdditions.Add(item);

                count++;
            }
            infoLabel.Invoke((MethodInvoker)delegate
            {
                infoLabel.Text = "Display updated";
            });
        }

        private void openAndExtractBasicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFile();
        }

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentChat != null)
            {

                Find findForm = new Find(currentChat);
                findForm.Show();
            }
            else
            {
                infoLabel.Text = "No chat loaded!";
            }
            
        }

        private void clearExtractedInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            extractedInfoTextBox.Text = "";
        }

        private void wordDistributionChartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(currentChat == null)
            {
                infoLabel.Text = "No chat loaded";
                return;
            }
            WordChartOptionsForm wordChartOptionsForm = new WordChartOptionsForm(currentChat);
            wordChartOptionsForm.Show();
        }

        private void messageWordCountDistibutionChartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            infoLabel.Text = "Calculating....";
            Dictionary<int, int> wordCounts = currentChat.GetMessageWordCountDistribution();
            infoLabel.Text = "Done!";
            ChartView chartView = new ChartView();
            chartView.Show();
            chartView.ReplaceData<int, int>(wordCounts, gridLineFrequencyY: GetLineFrequencyFromDictionaryValues(wordCounts));
        }

        private void totalMessagesPerDayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            infoLabel.Text = "Calculating...";
            Dictionary<string, int> messageCountByDay = currentChat.GetMessageCountByDayOfWeek(true, true);
            infoLabel.Text = "Done!";
            ChartView chartView = new ChartView();
            chartView.Show();
            chartView.ReplaceData<string, int>(messageCountByDay, gridLineFrequencyY: GetLineFrequencyFromDictionaryValues(messageCountByDay));
        }

        private void averageMessagesPerDayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            infoLabel.Text = "Calculating...";
            Dictionary<string, double> messageCountByDay = currentChat.GetAverageMessageCountByDayOfWeek(true, true);
            infoLabel.Text = "Done!";
            ChartView chartView = new ChartView();
            chartView.Show();
            chartView.ReplaceData<string, double>(messageCountByDay, gridLineFrequencyY: GetLineFrequencyFromDictionaryValues(messageCountByDay));
        }

        private void totalMessagesPerMonthToolStripMenuItem_Click(object sender, EventArgs e)
        {
            infoLabel.Text = "Calculating...";
            Dictionary<string, int> messageCountByMonth = currentChat.GetMessageCountByMonth(true, true);
            infoLabel.Text = "Done!";
            ChartView chartView = new ChartView();
            chartView.Show();
            chartView.ReplaceData<string, int>(messageCountByMonth, gridLineFrequencyY: GetLineFrequencyFromDictionaryValues(messageCountByMonth));
        }

        private void averageMessagesPerMonthToolStripMenuItem_Click(object sender, EventArgs e)
        {
            infoLabel.Text = "Calculating...";
            Dictionary<string, double> messageCountByMonth = currentChat.GetAverageMessageCountByMonth(true, true);
            infoLabel.Text = "Done!";
            ChartView chartView = new ChartView();
            chartView.Show();
            chartView.ReplaceData<string, double>(messageCountByMonth, gridLineFrequencyY: GetLineFrequencyFromDictionaryValues(messageCountByMonth));
        }

        private void totalMessagesPerUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            infoLabel.Text = "Collating Data...";
            Dictionary<string, int> messagesPerUser = currentChat.GetMessageCountPerUser(true);
            infoLabel.Text = "Done!";
            ChartView chartView = new ChartView();
            chartView.Show();
            chartView.ReplaceData<string, int>(messagesPerUser, gridLineFrequencyY: GetLineFrequencyFromDictionaryValues(messagesPerUser));
        }

        private void averageMessagesPerUserPerDayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            infoLabel.Text = "Calculating...";
            Dictionary<string, double> averageMessages = currentChat.GetMessagesPerSenderPerDay(true);
            infoLabel.Text = "Done";
            ChartView chartView = new ChartView();
            chartView.Show();
            chartView.ReplaceData<string, double>(averageMessages, gridLineFrequencyY: GetLineFrequencyFromDictionaryValues(averageMessages));
        }

        private void longestMessageStreakPerUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            infoLabel.Text = "Collating Data...";
            Dictionary<string, int> longestStreak = currentChat.GetLongestMessageStreakPerUser(true);
            infoLabel.Text = "Done.";
            ChartView chartView = new ChartView();
            chartView.Show();
            chartView.ReplaceData(longestStreak, gridLineFrequencyY: Math.Floor(GetLineFrequencyFromDictionaryValues(longestStreak)));
        }

        /// <summary>
        /// Calculate a frequency for displaying lines on the graph based on the data in the given dictionary
        /// </summary>
        /// <param name="data">The data to parse for calculation, the value must be convertable to a double</param>
        /// <param name="granularity">Higher granularity = increased frequency</param>
        /// <returns>A frequency value</returns>
        private double GetLineFrequencyFromDictionaryValues<T, U>(Dictionary<T, U> data, double granularity = 10.0f)
        {
            int count = 0;
            double minVal = double.NegativeInfinity;
            double maxVal = double.PositiveInfinity;
            bool firstRun = true;

            foreach (KeyValuePair<T, U> keyPair in data)
            {
                double pairValue = double.NaN;
                try
                {
                    pairValue = Convert.ToDouble(keyPair.Value);
                }
                catch (Exception ex)
                {
                    ArgumentException exception = new ArgumentException("Cannot convert value to double type, impossible to find min and max", ex);
                    throw exception;
                }

                if (firstRun)
                {
                    minVal = pairValue;
                    maxVal = pairValue;
                    firstRun = false;
                }
                if (pairValue < minVal)
                {
                    minVal = pairValue;
                }
                if (pairValue > maxVal)
                {
                    maxVal = pairValue;
                }
            }

            double difference = maxVal - minVal;

            return difference / granularity;
        }

        private void messageListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            MessageViewer vwr = new MessageViewer(currentChat.AllMessages[messageListView.Items.IndexOf(messageListView.SelectedItems[0])]);
            vwr.Show();
        }

        private void totalMessagesPerHourToolStripMenuItem_Click(object sender, EventArgs e)
        {
            infoLabel.Text = "Collating data...";
            Dictionary<string, int> messagesPerHour = currentChat.GetMessageCountByHourOfDay();
            infoLabel.Text = "Complete.";

            ChartView chartView = new ChartView();
            chartView.Show();
            chartView.ReplaceData(messagesPerHour, gridLineFrequencyY: Math.Floor(GetLineFrequencyFromDictionaryValues(messagesPerHour)));
        }

        private void averageMessagesPerHourToolStripMenuItem_Click(object sender, EventArgs e)
        {
            infoLabel.Text = "Collating data...";
            Dictionary<string, double> messagesPerHour = currentChat.GetAverageMessageCountByHourOfDay();
            infoLabel.Text = "Complete.";

            ChartView chartView = new ChartView();
            chartView.Show();
            chartView.ReplaceData(messagesPerHour, gridLineFrequencyY: Math.Floor(GetLineFrequencyFromDictionaryValues(messagesPerHour)));
        }

        private void mergeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentChat != null)
            {
                WhatsappChat otherChat;

                DialogResult result = openFileMenu.ShowDialog();

                if (result != DialogResult.Cancel && File.Exists(openFileMenu.FileName))
                {
                    infoLabel.Text = "Loading File To Merge...";

                    string[] allLines = File.ReadAllLines(openFileMenu.FileName);
                    allText = String.Join(Environment.NewLine, allLines.ToArray());
                    messageListView.Clear();
                    try
                    {
                        otherChat = new WhatsappChat(allText);
                        currentChat.Merge(otherChat);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Parsing of Merge Chat Failed - " + ex.Message);
                        infoLabel.Text = "Merge failed - " + ex.Message;
                    }

                    Task.Run(() =>
                    {
                        UpdateMessageView();
                    });
                }
            }
            else
            {
                MessageBox.Show("No loaded chat to merge, please open a chat first");
            }
        }

        private void basicInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(currentChat == null)
            {
                extractedInfoTextBox.Text += "No chat loaded" + Environment.NewLine;
                return;
            }

            string info = Environment.NewLine;
            info += "Chat extract: " + Environment.NewLine;
            info += "Participants: " + currentChat.Participants.Select(x => x.Name + " (" + x.Messages.Count + " Messages)").Aggregate((x, y) => x + Environment.NewLine + y);
            info += Environment.NewLine + Environment.NewLine + "Message Total: " + currentChat.AllMessages.Count + Environment.NewLine;

            extractedInfoTextBox.Text += info;
        }

        private void toPDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (currentChat == null)
            {
                MessageBox.Show("No chat loaded to export!");
                return;
            }

            saveFileDialog.Filter = "PDF Files | *.pdf";
            DialogResult result = saveFileDialog.ShowDialog();

            if (result == System.Windows.Forms.DialogResult.OK)
            {
                currentChat.ToPDF(saveFileDialog.FileName, currentChat.Participants[0]);
            }
        }

        private void searchTotalPerUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Find findBox = new Find(currentChat, (List<Message> messages, string query, Find find) =>
            {
                find.Close();

                Dictionary<string, int> personCounter = new Dictionary<string, int>();
                messages.ForEach((Message message) =>
                {
                    if (personCounter.ContainsKey(message.Sender.Name))
                    {
                        personCounter[message.Sender.Name]++;
                    }
                    else
                    {
                        personCounter.Add(message.Sender.Name, 1);
                    }
                });
                
                IEnumerable<string> resultString = personCounter.AsEnumerable().OrderBy(pair => pair.Value).Select(pair => pair.Key + ": " + pair.Value.ToString());

                string output = query + " count per user:" + Environment.NewLine + String.Join(Environment.NewLine, resultString) + Environment.NewLine;
                extractedInfoTextBox.AppendText(output);
            });
            findBox.Show();
        }
    }
}
