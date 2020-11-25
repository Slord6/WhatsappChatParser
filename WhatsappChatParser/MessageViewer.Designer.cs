namespace WhatsappChatParser
{
    partial class MessageViewer
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
            this.senderLabel = new System.Windows.Forms.Label();
            this.dateTimeLabel = new System.Windows.Forms.Label();
            this.bodyLabel = new System.Windows.Forms.Label();
            this.messageBodyTextbox = new System.Windows.Forms.RichTextBox();
            this.messageSenderNameTextBox = new System.Windows.Forms.TextBox();
            this.dateTimeSentTextBox = new System.Windows.Forms.TextBox();
            this.previousMessageButton = new System.Windows.Forms.Button();
            this.nextMessageButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // senderLabel
            // 
            this.senderLabel.AutoSize = true;
            this.senderLabel.Location = new System.Drawing.Point(13, 13);
            this.senderLabel.Name = "senderLabel";
            this.senderLabel.Size = new System.Drawing.Size(44, 13);
            this.senderLabel.TabIndex = 0;
            this.senderLabel.Text = "Sender:";
            // 
            // dateTimeLabel
            // 
            this.dateTimeLabel.AutoSize = true;
            this.dateTimeLabel.Location = new System.Drawing.Point(13, 37);
            this.dateTimeLabel.Name = "dateTimeLabel";
            this.dateTimeLabel.Size = new System.Drawing.Size(86, 13);
            this.dateTimeLabel.TabIndex = 1;
            this.dateTimeLabel.Text = "Date/Time Sent:";
            // 
            // bodyLabel
            // 
            this.bodyLabel.AutoSize = true;
            this.bodyLabel.Location = new System.Drawing.Point(13, 63);
            this.bodyLabel.Name = "bodyLabel";
            this.bodyLabel.Size = new System.Drawing.Size(53, 13);
            this.bodyLabel.TabIndex = 2;
            this.bodyLabel.Text = "Message:";
            // 
            // messageBodyTextbox
            // 
            this.messageBodyTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.messageBodyTextbox.Font = new System.Drawing.Font("Segoe UI Emoji", 10.15F);
            this.messageBodyTextbox.Location = new System.Drawing.Point(12, 79);
            this.messageBodyTextbox.Name = "messageBodyTextbox";
            this.messageBodyTextbox.ReadOnly = true;
            this.messageBodyTextbox.Size = new System.Drawing.Size(303, 194);
            this.messageBodyTextbox.TabIndex = 4;
            this.messageBodyTextbox.Text = "";
            // 
            // messageSenderNameTextBox
            // 
            this.messageSenderNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.messageSenderNameTextBox.Location = new System.Drawing.Point(154, 10);
            this.messageSenderNameTextBox.Name = "messageSenderNameTextBox";
            this.messageSenderNameTextBox.ReadOnly = true;
            this.messageSenderNameTextBox.Size = new System.Drawing.Size(161, 20);
            this.messageSenderNameTextBox.TabIndex = 5;
            // 
            // dateTimeSentTextBox
            // 
            this.dateTimeSentTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTimeSentTextBox.Location = new System.Drawing.Point(154, 34);
            this.dateTimeSentTextBox.Name = "dateTimeSentTextBox";
            this.dateTimeSentTextBox.ReadOnly = true;
            this.dateTimeSentTextBox.Size = new System.Drawing.Size(161, 20);
            this.dateTimeSentTextBox.TabIndex = 6;
            // 
            // previousMessageButton
            // 
            this.previousMessageButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.previousMessageButton.Location = new System.Drawing.Point(12, 279);
            this.previousMessageButton.Name = "previousMessageButton";
            this.previousMessageButton.Size = new System.Drawing.Size(75, 23);
            this.previousMessageButton.TabIndex = 7;
            this.previousMessageButton.Text = "Previous";
            this.previousMessageButton.UseVisualStyleBackColor = true;
            this.previousMessageButton.Click += new System.EventHandler(this.previousMessageButton_Click);
            // 
            // nextMessageButton
            // 
            this.nextMessageButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.nextMessageButton.Location = new System.Drawing.Point(240, 279);
            this.nextMessageButton.Name = "nextMessageButton";
            this.nextMessageButton.Size = new System.Drawing.Size(75, 23);
            this.nextMessageButton.TabIndex = 8;
            this.nextMessageButton.Text = "Next";
            this.nextMessageButton.UseVisualStyleBackColor = true;
            this.nextMessageButton.Click += new System.EventHandler(this.nextMessageButton_Click);
            // 
            // MessageViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(327, 304);
            this.Controls.Add(this.nextMessageButton);
            this.Controls.Add(this.previousMessageButton);
            this.Controls.Add(this.dateTimeSentTextBox);
            this.Controls.Add(this.messageSenderNameTextBox);
            this.Controls.Add(this.messageBodyTextbox);
            this.Controls.Add(this.bodyLabel);
            this.Controls.Add(this.dateTimeLabel);
            this.Controls.Add(this.senderLabel);
            this.Name = "MessageViewer";
            this.Text = "MessageViewer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label senderLabel;
        private System.Windows.Forms.Label dateTimeLabel;
        private System.Windows.Forms.Label bodyLabel;
        private System.Windows.Forms.RichTextBox messageBodyTextbox;
        private System.Windows.Forms.TextBox messageSenderNameTextBox;
        private System.Windows.Forms.TextBox dateTimeSentTextBox;
        private System.Windows.Forms.Button previousMessageButton;
        private System.Windows.Forms.Button nextMessageButton;
    }
}