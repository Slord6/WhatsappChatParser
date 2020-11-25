namespace WhatsappChatParser
{
    partial class FindResult
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
            this.messageListView = new System.Windows.Forms.ListView();
            this.infoLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // messageListView
            // 
            this.messageListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.messageListView.Location = new System.Drawing.Point(12, 12);
            this.messageListView.Name = "messageListView";
            this.messageListView.Size = new System.Drawing.Size(463, 146);
            this.messageListView.TabIndex = 0;
            this.messageListView.UseCompatibleStateImageBehavior = false;
            this.messageListView.View = System.Windows.Forms.View.List;
            this.messageListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.messageListView_MouseDoubleClick);
            // 
            // infoLabel
            // 
            this.infoLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.infoLabel.AutoSize = true;
            this.infoLabel.Location = new System.Drawing.Point(12, 161);
            this.infoLabel.Name = "infoLabel";
            this.infoLabel.Size = new System.Drawing.Size(164, 13);
            this.infoLabel.TabIndex = 1;
            this.infoLabel.Text = "Double click to view full message";
            // 
            // FindResult
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(487, 189);
            this.Controls.Add(this.infoLabel);
            this.Controls.Add(this.messageListView);
            this.Name = "FindResult";
            this.Text = "FindResult";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView messageListView;
        private System.Windows.Forms.Label infoLabel;

    }
}