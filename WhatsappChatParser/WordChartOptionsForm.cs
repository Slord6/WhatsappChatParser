using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WhatsappChatParser
{
    public partial class WordChartOptionsForm : Form
    {
        WhatsappChat currentChat;
        string[] ignoredWords = null;
        private Dictionary<string, Regex> builtinRegex;

        public WordChartOptionsForm(WhatsappChat currentChat)
        {
            InitializeComponent();
            this.currentChat = currentChat;
            SetupRegexComboBox();
        }

        private void SetupRegexComboBox()
        {
            builtinRegex = new Dictionary<string, Regex>();

            Regex regex = new Regex(@"(\u00a9|\u00ae|[\u2000-\u3300]|\ud83c[\ud000-\udfff]|\ud83d[\ud000-\udfff]|\ud83e[\ud000-\udfff])");
            builtinRegex.Add("Contains Emoji - " + regex.ToString(), regex);

            regex = new Regex(@"^(\u00a9|\u00ae|[\u2000-\u3300]|\ud83c[\ud000-\udfff]|\ud83d[\ud000-\udfff]|\ud83e[\ud000-\udfff])$");
            builtinRegex.Add("Single Emoji - " + regex.ToString(), regex);

            regexComboBox.Items.AddRange(builtinRegex.Keys.ToArray());
        }

        private void ignoreFromWordListCheckBox_CheckStateChanged(object sender, EventArgs e)
        {
            selectWordListButton.Enabled = ignoreFromWordListCheckBox.Checked;
        }

        private void createChartButton_Click(object sender, EventArgs e)
        {
            ChartView chartView = new ChartView();
            chartView.Show();
            Dictionary<string, int> wordCount = currentChat.GetWordDistribution(GetWordLimitingRegex(), ignoreCaseCheckBox.Checked, removePunctuationCheckBox.Checked, ignoreSystemMessagesCheckBox.Checked, ignoreMediaOmmittedCheckBox.Checked, ignoredWords, stripPostApostropheCheckBox.Checked);
                
            //sort and limit to top 10
            wordCount = wordCount.OrderByDescending(pair => pair.Value).Take((int)numberOfWordsNumericUpDown.Value).ToDictionary(pair => pair.Key, pair => pair.Value);

            chartView.ReplaceData<string, int>(wordCount);
        }

        private Regex GetWordLimitingRegex()
        {
            if(limitToRegexMatchWordsCheckBox.Checked)
            {
                string selected = regexComboBox.Text;
                if (builtinRegex.ContainsKey(selected))
                {
                    return builtinRegex[selected];
                } else
                {
                    return new Regex(selected);
                }
            }

            return new Regex(@"[\s\S]+"); // match everything
        }

        private void selectWordListButton_Click(object sender, EventArgs e)
        {
            openFileMenu.ShowDialog();

            if (File.Exists(openFileMenu.FileName))
            {
                ignoredWords = File.ReadAllLines(openFileMenu.FileName);
                MessageBox.Show("Loaded " + ignoredWords.Length + " words to ignore");
            }
            else
            {
                MessageBox.Show("File doesn't exist");
                selectWordListButton.Enabled = false;
                ignoreFromWordListCheckBox.Checked = false;
            }
        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {

        }

        private void limitToRegexMatchWordsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            regexComboBox.Enabled = limitToRegexMatchWordsCheckBox.Checked;
        }
    }
}
