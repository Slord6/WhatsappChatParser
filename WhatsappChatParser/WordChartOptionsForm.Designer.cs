namespace WhatsappChatParser
{
    partial class WordChartOptionsForm
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
            this.ignoreCaseCheckBox = new System.Windows.Forms.CheckBox();
            this.removePunctuationCheckBox = new System.Windows.Forms.CheckBox();
            this.ignoreSystemMessagesCheckBox = new System.Windows.Forms.CheckBox();
            this.ignoreMediaOmmittedCheckBox = new System.Windows.Forms.CheckBox();
            this.ignoreFromWordListCheckBox = new System.Windows.Forms.CheckBox();
            this.selectWordListButton = new System.Windows.Forms.Button();
            this.createChartButton = new System.Windows.Forms.Button();
            this.openFileMenu = new System.Windows.Forms.OpenFileDialog();
            this.numberOfWordsLabel = new System.Windows.Forms.Label();
            this.numberOfWordsNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.stripPostApostropheCheckBox = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.limitToRegexMatchWordsCheckBox = new System.Windows.Forms.CheckBox();
            this.regexComboBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfWordsNumericUpDown)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ignoreCaseCheckBox
            // 
            this.ignoreCaseCheckBox.AutoSize = true;
            this.ignoreCaseCheckBox.Checked = true;
            this.ignoreCaseCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ignoreCaseCheckBox.Location = new System.Drawing.Point(11, 11);
            this.ignoreCaseCheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.ignoreCaseCheckBox.Name = "ignoreCaseCheckBox";
            this.ignoreCaseCheckBox.Size = new System.Drawing.Size(83, 17);
            this.ignoreCaseCheckBox.TabIndex = 0;
            this.ignoreCaseCheckBox.Text = "Ignore Case";
            this.ignoreCaseCheckBox.UseVisualStyleBackColor = true;
            // 
            // removePunctuationCheckBox
            // 
            this.removePunctuationCheckBox.AutoSize = true;
            this.removePunctuationCheckBox.Checked = true;
            this.removePunctuationCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.removePunctuationCheckBox.Location = new System.Drawing.Point(11, 33);
            this.removePunctuationCheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.removePunctuationCheckBox.Name = "removePunctuationCheckBox";
            this.removePunctuationCheckBox.Size = new System.Drawing.Size(126, 17);
            this.removePunctuationCheckBox.TabIndex = 1;
            this.removePunctuationCheckBox.Text = "Remove Punctuation";
            this.removePunctuationCheckBox.UseVisualStyleBackColor = true;
            // 
            // ignoreSystemMessagesCheckBox
            // 
            this.ignoreSystemMessagesCheckBox.AutoSize = true;
            this.ignoreSystemMessagesCheckBox.Checked = true;
            this.ignoreSystemMessagesCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ignoreSystemMessagesCheckBox.Location = new System.Drawing.Point(10, 55);
            this.ignoreSystemMessagesCheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.ignoreSystemMessagesCheckBox.Name = "ignoreSystemMessagesCheckBox";
            this.ignoreSystemMessagesCheckBox.Size = new System.Drawing.Size(144, 17);
            this.ignoreSystemMessagesCheckBox.TabIndex = 2;
            this.ignoreSystemMessagesCheckBox.Text = "Ignore System Messages";
            this.ignoreSystemMessagesCheckBox.UseVisualStyleBackColor = true;
            // 
            // ignoreMediaOmmittedCheckBox
            // 
            this.ignoreMediaOmmittedCheckBox.AutoSize = true;
            this.ignoreMediaOmmittedCheckBox.Checked = true;
            this.ignoreMediaOmmittedCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ignoreMediaOmmittedCheckBox.Location = new System.Drawing.Point(10, 76);
            this.ignoreMediaOmmittedCheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.ignoreMediaOmmittedCheckBox.Name = "ignoreMediaOmmittedCheckBox";
            this.ignoreMediaOmmittedCheckBox.Size = new System.Drawing.Size(196, 17);
            this.ignoreMediaOmmittedCheckBox.TabIndex = 3;
            this.ignoreMediaOmmittedCheckBox.Text = "Ignore \"Media Ommitted\" Messages";
            this.ignoreMediaOmmittedCheckBox.UseVisualStyleBackColor = true;
            // 
            // ignoreFromWordListCheckBox
            // 
            this.ignoreFromWordListCheckBox.AutoSize = true;
            this.ignoreFromWordListCheckBox.Location = new System.Drawing.Point(13, 18);
            this.ignoreFromWordListCheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.ignoreFromWordListCheckBox.Name = "ignoreFromWordListCheckBox";
            this.ignoreFromWordListCheckBox.Size = new System.Drawing.Size(130, 17);
            this.ignoreFromWordListCheckBox.TabIndex = 4;
            this.ignoreFromWordListCheckBox.Text = "Ignore From Word List";
            this.ignoreFromWordListCheckBox.UseVisualStyleBackColor = true;
            this.ignoreFromWordListCheckBox.CheckStateChanged += new System.EventHandler(this.ignoreFromWordListCheckBox_CheckStateChanged);
            // 
            // selectWordListButton
            // 
            this.selectWordListButton.Enabled = false;
            this.selectWordListButton.Location = new System.Drawing.Point(13, 40);
            this.selectWordListButton.Margin = new System.Windows.Forms.Padding(2);
            this.selectWordListButton.Name = "selectWordListButton";
            this.selectWordListButton.Size = new System.Drawing.Size(105, 19);
            this.selectWordListButton.TabIndex = 5;
            this.selectWordListButton.Text = "Select Word List";
            this.selectWordListButton.UseVisualStyleBackColor = true;
            this.selectWordListButton.Click += new System.EventHandler(this.selectWordListButton_Click);
            // 
            // createChartButton
            // 
            this.createChartButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.createChartButton.Location = new System.Drawing.Point(259, 324);
            this.createChartButton.Margin = new System.Windows.Forms.Padding(2);
            this.createChartButton.Name = "createChartButton";
            this.createChartButton.Size = new System.Drawing.Size(78, 19);
            this.createChartButton.TabIndex = 6;
            this.createChartButton.Text = "Create Chart";
            this.createChartButton.UseVisualStyleBackColor = true;
            this.createChartButton.Click += new System.EventHandler(this.createChartButton_Click);
            // 
            // openFileMenu
            // 
            this.openFileMenu.FileName = "openFileDialog1";
            // 
            // numberOfWordsLabel
            // 
            this.numberOfWordsLabel.AutoSize = true;
            this.numberOfWordsLabel.Location = new System.Drawing.Point(12, 288);
            this.numberOfWordsLabel.Name = "numberOfWordsLabel";
            this.numberOfWordsLabel.Size = new System.Drawing.Size(90, 13);
            this.numberOfWordsLabel.TabIndex = 8;
            this.numberOfWordsLabel.Text = "Number of Words";
            // 
            // numberOfWordsNumericUpDown
            // 
            this.numberOfWordsNumericUpDown.Location = new System.Drawing.Point(106, 286);
            this.numberOfWordsNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numberOfWordsNumericUpDown.Name = "numberOfWordsNumericUpDown";
            this.numberOfWordsNumericUpDown.Size = new System.Drawing.Size(68, 20);
            this.numberOfWordsNumericUpDown.TabIndex = 9;
            this.numberOfWordsNumericUpDown.Value = new decimal(new int[] {
            20,
            0,
            0,
            0});
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ignoreFromWordListCheckBox);
            this.groupBox1.Controls.Add(this.selectWordListButton);
            this.groupBox1.Location = new System.Drawing.Point(10, 119);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(327, 67);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ignore Words";
            // 
            // stripPostApostropheCheckBox
            // 
            this.stripPostApostropheCheckBox.AutoSize = true;
            this.stripPostApostropheCheckBox.Checked = true;
            this.stripPostApostropheCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.stripPostApostropheCheckBox.Location = new System.Drawing.Point(10, 97);
            this.stripPostApostropheCheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.stripPostApostropheCheckBox.Name = "stripPostApostropheCheckBox";
            this.stripPostApostropheCheckBox.Size = new System.Drawing.Size(176, 17);
            this.stripPostApostropheCheckBox.TabIndex = 11;
            this.stripPostApostropheCheckBox.Text = "Strip post-apostophe characters";
            this.stripPostApostropheCheckBox.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.regexComboBox);
            this.groupBox2.Controls.Add(this.limitToRegexMatchWordsCheckBox);
            this.groupBox2.Location = new System.Drawing.Point(11, 192);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(327, 71);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Word Matching";
            // 
            // limitToRegexMatchWordsCheckBox
            // 
            this.limitToRegexMatchWordsCheckBox.AutoSize = true;
            this.limitToRegexMatchWordsCheckBox.Location = new System.Drawing.Point(13, 18);
            this.limitToRegexMatchWordsCheckBox.Margin = new System.Windows.Forms.Padding(2);
            this.limitToRegexMatchWordsCheckBox.Name = "limitToRegexMatchWordsCheckBox";
            this.limitToRegexMatchWordsCheckBox.Size = new System.Drawing.Size(164, 17);
            this.limitToRegexMatchWordsCheckBox.TabIndex = 4;
            this.limitToRegexMatchWordsCheckBox.Text = "Limit To Regex Match Words";
            this.limitToRegexMatchWordsCheckBox.UseVisualStyleBackColor = true;
            this.limitToRegexMatchWordsCheckBox.CheckedChanged += new System.EventHandler(this.limitToRegexMatchWordsCheckBox_CheckedChanged);
            // 
            // regexComboBox
            // 
            this.regexComboBox.Enabled = false;
            this.regexComboBox.FormattingEnabled = true;
            this.regexComboBox.Location = new System.Drawing.Point(13, 41);
            this.regexComboBox.Name = "regexComboBox";
            this.regexComboBox.Size = new System.Drawing.Size(310, 21);
            this.regexComboBox.TabIndex = 5;
            // 
            // WordChartOptionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(346, 352);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.stripPostApostropheCheckBox);
            this.Controls.Add(this.numberOfWordsNumericUpDown);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.createChartButton);
            this.Controls.Add(this.numberOfWordsLabel);
            this.Controls.Add(this.ignoreMediaOmmittedCheckBox);
            this.Controls.Add(this.ignoreSystemMessagesCheckBox);
            this.Controls.Add(this.removePunctuationCheckBox);
            this.Controls.Add(this.ignoreCaseCheckBox);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "WordChartOptionsForm";
            this.Text = "WordChartOptionsForm";
            ((System.ComponentModel.ISupportInitialize)(this.numberOfWordsNumericUpDown)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox ignoreCaseCheckBox;
        private System.Windows.Forms.CheckBox removePunctuationCheckBox;
        private System.Windows.Forms.CheckBox ignoreSystemMessagesCheckBox;
        private System.Windows.Forms.CheckBox ignoreMediaOmmittedCheckBox;
        private System.Windows.Forms.CheckBox ignoreFromWordListCheckBox;
        private System.Windows.Forms.Button selectWordListButton;
        private System.Windows.Forms.Button createChartButton;
        private System.Windows.Forms.OpenFileDialog openFileMenu;
        private System.Windows.Forms.Label numberOfWordsLabel;
        private System.Windows.Forms.NumericUpDown numberOfWordsNumericUpDown;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox stripPostApostropheCheckBox;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox regexComboBox;
        private System.Windows.Forms.CheckBox limitToRegexMatchWordsCheckBox;
    }
}