namespace WhatsappChatParser
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileMenu = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mergeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toPDFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchTotalPerUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chartsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.messagesPerUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.totalMessagesPerUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.averageMessagesPerUserPerDayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.longestMessageStreakPerUserToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.messagesByTimeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.totalMessagesPerDayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.averageMessagesPerDayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hourToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.totalMessagesPerHourToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.averageMessagesPerHourToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.messageContentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wordsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.wordDistributionChartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.messageWordCountDistibutionChartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.basicInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearExtractedInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoLabel = new System.Windows.Forms.Label();
            this.extractedInfoTextBox = new System.Windows.Forms.RichTextBox();
            this.extractedInfoTitleLabel = new System.Windows.Forms.Label();
            this.messageListView = new System.Windows.Forms.ListView();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.monthToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.totalMessagesPerMonthToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.averageMessagesPerMonthToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileMenu
            // 
            this.openFileMenu.Filter = "Text files|*.txt|All files|*.*";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.viewToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(720, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.mergeToolStripMenuItem,
            this.exportToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.ToolTipText = "Open a chat";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // mergeToolStripMenuItem
            // 
            this.mergeToolStripMenuItem.Name = "mergeToolStripMenuItem";
            this.mergeToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.mergeToolStripMenuItem.Text = "Merge...";
            this.mergeToolStripMenuItem.Click += new System.EventHandler(this.mergeToolStripMenuItem_Click);
            // 
            // exportToolStripMenuItem
            // 
            this.exportToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toPDFToolStripMenuItem});
            this.exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            this.exportToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.exportToolStripMenuItem.Text = "Export";
            // 
            // toPDFToolStripMenuItem
            // 
            this.toPDFToolStripMenuItem.Name = "toPDFToolStripMenuItem";
            this.toPDFToolStripMenuItem.Size = new System.Drawing.Size(110, 22);
            this.toPDFToolStripMenuItem.Text = "To PDF";
            this.toPDFToolStripMenuItem.Click += new System.EventHandler(this.toPDFToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.searchToolStripMenuItem,
            this.searchTotalPerUserToolStripMenuItem,
            this.chartsToolStripMenuItem,
            this.basicInfoToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.searchToolStripMenuItem.Text = "Search...";
            this.searchToolStripMenuItem.Click += new System.EventHandler(this.searchToolStripMenuItem_Click);
            // 
            // searchTotalPerUserToolStripMenuItem
            // 
            this.searchTotalPerUserToolStripMenuItem.Name = "searchTotalPerUserToolStripMenuItem";
            this.searchTotalPerUserToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.searchTotalPerUserToolStripMenuItem.Text = "Search total per User";
            this.searchTotalPerUserToolStripMenuItem.Click += new System.EventHandler(this.searchTotalPerUserToolStripMenuItem_Click);
            // 
            // chartsToolStripMenuItem
            // 
            this.chartsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.messagesPerUserToolStripMenuItem,
            this.messagesByTimeToolStripMenuItem,
            this.messageContentToolStripMenuItem});
            this.chartsToolStripMenuItem.Name = "chartsToolStripMenuItem";
            this.chartsToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.chartsToolStripMenuItem.Text = "Charts";
            // 
            // messagesPerUserToolStripMenuItem
            // 
            this.messagesPerUserToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.totalMessagesPerUserToolStripMenuItem,
            this.averageMessagesPerUserPerDayToolStripMenuItem,
            this.longestMessageStreakPerUserToolStripMenuItem});
            this.messagesPerUserToolStripMenuItem.Name = "messagesPerUserToolStripMenuItem";
            this.messagesPerUserToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.messagesPerUserToolStripMenuItem.Text = "Messages Per User";
            // 
            // totalMessagesPerUserToolStripMenuItem
            // 
            this.totalMessagesPerUserToolStripMenuItem.Name = "totalMessagesPerUserToolStripMenuItem";
            this.totalMessagesPerUserToolStripMenuItem.Size = new System.Drawing.Size(260, 22);
            this.totalMessagesPerUserToolStripMenuItem.Text = "Total Messages Per User";
            this.totalMessagesPerUserToolStripMenuItem.Click += new System.EventHandler(this.totalMessagesPerUserToolStripMenuItem_Click);
            // 
            // averageMessagesPerUserPerDayToolStripMenuItem
            // 
            this.averageMessagesPerUserPerDayToolStripMenuItem.Name = "averageMessagesPerUserPerDayToolStripMenuItem";
            this.averageMessagesPerUserPerDayToolStripMenuItem.Size = new System.Drawing.Size(260, 22);
            this.averageMessagesPerUserPerDayToolStripMenuItem.Text = "Average Messages Per User Per Day";
            this.averageMessagesPerUserPerDayToolStripMenuItem.Click += new System.EventHandler(this.averageMessagesPerUserPerDayToolStripMenuItem_Click);
            // 
            // longestMessageStreakPerUserToolStripMenuItem
            // 
            this.longestMessageStreakPerUserToolStripMenuItem.Name = "longestMessageStreakPerUserToolStripMenuItem";
            this.longestMessageStreakPerUserToolStripMenuItem.Size = new System.Drawing.Size(260, 22);
            this.longestMessageStreakPerUserToolStripMenuItem.Text = "Longest Message Streak Per User";
            this.longestMessageStreakPerUserToolStripMenuItem.Click += new System.EventHandler(this.longestMessageStreakPerUserToolStripMenuItem_Click);
            // 
            // messagesByTimeToolStripMenuItem
            // 
            this.messagesByTimeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dayToolStripMenuItem,
            this.hourToolStripMenuItem,
            this.monthToolStripMenuItem});
            this.messagesByTimeToolStripMenuItem.Name = "messagesByTimeToolStripMenuItem";
            this.messagesByTimeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.messagesByTimeToolStripMenuItem.Text = "Messages by Time";
            // 
            // dayToolStripMenuItem
            // 
            this.dayToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.totalMessagesPerDayToolStripMenuItem,
            this.averageMessagesPerDayToolStripMenuItem});
            this.dayToolStripMenuItem.Name = "dayToolStripMenuItem";
            this.dayToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.dayToolStripMenuItem.Text = "Day";
            // 
            // totalMessagesPerDayToolStripMenuItem
            // 
            this.totalMessagesPerDayToolStripMenuItem.Name = "totalMessagesPerDayToolStripMenuItem";
            this.totalMessagesPerDayToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.totalMessagesPerDayToolStripMenuItem.Text = "Total Messages Per Day";
            this.totalMessagesPerDayToolStripMenuItem.Click += new System.EventHandler(this.totalMessagesPerDayToolStripMenuItem_Click);
            // 
            // averageMessagesPerDayToolStripMenuItem
            // 
            this.averageMessagesPerDayToolStripMenuItem.Name = "averageMessagesPerDayToolStripMenuItem";
            this.averageMessagesPerDayToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.averageMessagesPerDayToolStripMenuItem.Text = "Average Messages Per Day";
            this.averageMessagesPerDayToolStripMenuItem.Click += new System.EventHandler(this.averageMessagesPerDayToolStripMenuItem_Click);
            // 
            // hourToolStripMenuItem
            // 
            this.hourToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.totalMessagesPerHourToolStripMenuItem,
            this.averageMessagesPerHourToolStripMenuItem});
            this.hourToolStripMenuItem.Name = "hourToolStripMenuItem";
            this.hourToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.hourToolStripMenuItem.Text = "Hour";
            // 
            // totalMessagesPerHourToolStripMenuItem
            // 
            this.totalMessagesPerHourToolStripMenuItem.Name = "totalMessagesPerHourToolStripMenuItem";
            this.totalMessagesPerHourToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.totalMessagesPerHourToolStripMenuItem.Text = "Total Messages Per Hour";
            this.totalMessagesPerHourToolStripMenuItem.Click += new System.EventHandler(this.totalMessagesPerHourToolStripMenuItem_Click);
            // 
            // averageMessagesPerHourToolStripMenuItem
            // 
            this.averageMessagesPerHourToolStripMenuItem.Name = "averageMessagesPerHourToolStripMenuItem";
            this.averageMessagesPerHourToolStripMenuItem.Size = new System.Drawing.Size(221, 22);
            this.averageMessagesPerHourToolStripMenuItem.Text = "Average Messages Per Hour";
            this.averageMessagesPerHourToolStripMenuItem.Click += new System.EventHandler(this.averageMessagesPerHourToolStripMenuItem_Click);
            // 
            // messageContentToolStripMenuItem
            // 
            this.messageContentToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wordsToolStripMenuItem});
            this.messageContentToolStripMenuItem.Name = "messageContentToolStripMenuItem";
            this.messageContentToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.messageContentToolStripMenuItem.Text = "Message Content";
            // 
            // wordsToolStripMenuItem
            // 
            this.wordsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wordDistributionChartToolStripMenuItem,
            this.messageWordCountDistibutionChartToolStripMenuItem});
            this.wordsToolStripMenuItem.Name = "wordsToolStripMenuItem";
            this.wordsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.wordsToolStripMenuItem.Text = "Words";
            // 
            // wordDistributionChartToolStripMenuItem
            // 
            this.wordDistributionChartToolStripMenuItem.Name = "wordDistributionChartToolStripMenuItem";
            this.wordDistributionChartToolStripMenuItem.Size = new System.Drawing.Size(281, 22);
            this.wordDistributionChartToolStripMenuItem.Text = "Word Distribution Chart";
            this.wordDistributionChartToolStripMenuItem.Click += new System.EventHandler(this.wordDistributionChartToolStripMenuItem_Click);
            // 
            // messageWordCountDistibutionChartToolStripMenuItem
            // 
            this.messageWordCountDistibutionChartToolStripMenuItem.Name = "messageWordCountDistibutionChartToolStripMenuItem";
            this.messageWordCountDistibutionChartToolStripMenuItem.Size = new System.Drawing.Size(281, 22);
            this.messageWordCountDistibutionChartToolStripMenuItem.Text = "Message Word Count Distibution Chart";
            this.messageWordCountDistibutionChartToolStripMenuItem.Click += new System.EventHandler(this.messageWordCountDistibutionChartToolStripMenuItem_Click);
            // 
            // basicInfoToolStripMenuItem
            // 
            this.basicInfoToolStripMenuItem.Name = "basicInfoToolStripMenuItem";
            this.basicInfoToolStripMenuItem.Size = new System.Drawing.Size(182, 22);
            this.basicInfoToolStripMenuItem.Text = "Basic Info";
            this.basicInfoToolStripMenuItem.Click += new System.EventHandler(this.basicInfoToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearExtractedInfoToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // clearExtractedInfoToolStripMenuItem
            // 
            this.clearExtractedInfoToolStripMenuItem.Name = "clearExtractedInfoToolStripMenuItem";
            this.clearExtractedInfoToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.clearExtractedInfoToolStripMenuItem.Text = "Clear Extracted Info";
            this.clearExtractedInfoToolStripMenuItem.Click += new System.EventHandler(this.clearExtractedInfoToolStripMenuItem_Click);
            // 
            // infoLabel
            // 
            this.infoLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.infoLabel.Location = new System.Drawing.Point(12, 499);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(434, 13);
            this.infoLabel.TabIndex = 2;
            this.infoLabel.Text = "No File Loaded.";
            // 
            // extractedInfoTextBox
            // 
            this.extractedInfoTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.extractedInfoTextBox.Font = new System.Drawing.Font("Segoe UI Emoji", 10.15F);
            this.extractedInfoTextBox.Location = new System.Drawing.Point(473, 51);
            this.extractedInfoTextBox.Name = "extractedInfoTextBox";
            this.extractedInfoTextBox.ReadOnly = true;
            this.extractedInfoTextBox.Size = new System.Drawing.Size(238, 445);
            this.extractedInfoTextBox.TabIndex = 4;
            this.extractedInfoTextBox.Text = "";
            // 
            // extractedInfoTitleLabel
            // 
            this.extractedInfoTitleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.extractedInfoTitleLabel.AutoSize = true;
            this.extractedInfoTitleLabel.Location = new System.Drawing.Point(470, 28);
            this.extractedInfoTitleLabel.Name = "extractedInfoTitleLabel";
            this.extractedInfoTitleLabel.Size = new System.Drawing.Size(76, 13);
            this.extractedInfoTitleLabel.TabIndex = 5;
            this.extractedInfoTitleLabel.Text = "Extracted Info:";
            // 
            // messageListView
            // 
            this.messageListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.messageListView.HideSelection = false;
            this.messageListView.Location = new System.Drawing.Point(12, 51);
            this.messageListView.Name = "messageListView";
            this.messageListView.Size = new System.Drawing.Size(452, 445);
            this.messageListView.TabIndex = 6;
            this.messageListView.UseCompatibleStateImageBehavior = false;
            this.messageListView.View = System.Windows.Forms.View.List;
            this.messageListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.messageListView_MouseDoubleClick);
            // 
            // monthToolStripMenuItem
            // 
            this.monthToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.totalMessagesPerMonthToolStripMenuItem,
            this.averageMessagesPerMonthToolStripMenuItem});
            this.monthToolStripMenuItem.Name = "monthToolStripMenuItem";
            this.monthToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.monthToolStripMenuItem.Text = "Month";
            // 
            // totalMessagesPerMonthToolStripMenuItem
            // 
            this.totalMessagesPerMonthToolStripMenuItem.Name = "totalMessagesPerMonthToolStripMenuItem";
            this.totalMessagesPerMonthToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.totalMessagesPerMonthToolStripMenuItem.Text = "Total Messages Per Month";
            this.totalMessagesPerMonthToolStripMenuItem.Click += new System.EventHandler(this.totalMessagesPerMonthToolStripMenuItem_Click);
            // 
            // averageMessagesPerMonthToolStripMenuItem
            // 
            this.averageMessagesPerMonthToolStripMenuItem.Name = "averageMessagesPerMonthToolStripMenuItem";
            this.averageMessagesPerMonthToolStripMenuItem.Size = new System.Drawing.Size(230, 22);
            this.averageMessagesPerMonthToolStripMenuItem.Text = "Average Messages Per Month";
            this.averageMessagesPerMonthToolStripMenuItem.Click += new System.EventHandler(this.averageMessagesPerMonthToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 521);
            this.Controls.Add(this.messageListView);
            this.Controls.Add(this.extractedInfoTitleLabel);
            this.Controls.Add(this.extractedInfoTextBox);
            this.Controls.Add(this.infoLabel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Whatsapp Chat Parser";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileMenu;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Label infoLabel;
        private System.Windows.Forms.RichTextBox extractedInfoTextBox;
        private System.Windows.Forms.Label extractedInfoTitleLabel;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearExtractedInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chartsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem messagesPerUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem totalMessagesPerUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem averageMessagesPerUserPerDayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem messagesByTimeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem totalMessagesPerDayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem averageMessagesPerDayToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem messageContentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wordsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem wordDistributionChartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem messageWordCountDistibutionChartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem longestMessageStreakPerUserToolStripMenuItem;
        private System.Windows.Forms.ListView messageListView;
        private System.Windows.Forms.ToolStripMenuItem hourToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem totalMessagesPerHourToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem averageMessagesPerHourToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mergeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem basicInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toPDFToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolStripMenuItem searchTotalPerUserToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem monthToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem totalMessagesPerMonthToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem averageMessagesPerMonthToolStripMenuItem;
    }
}

