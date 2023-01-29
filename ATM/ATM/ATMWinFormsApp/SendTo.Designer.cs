namespace ATMWinFormsApp
{
    partial class SendTo
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
            this.SendLabel = new System.Windows.Forms.Label();
            this.InputSendDistCard = new System.Windows.Forms.TextBox();
            this.SendTextLabel = new System.Windows.Forms.Label();
            this.InputSendSum = new System.Windows.Forms.TextBox();
            this.SendText1Label = new System.Windows.Forms.Label();
            this.SendButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SendLabel
            // 
            this.SendLabel.AutoSize = true;
            this.SendLabel.Font = new System.Drawing.Font("Segoe UI", 27.84906F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.SendLabel.Location = new System.Drawing.Point(188, 9);
            this.SendLabel.Name = "SendLabel";
            this.SendLabel.Size = new System.Drawing.Size(282, 57);
            this.SendLabel.TabIndex = 4;
            this.SendLabel.Text = "Send money ";
            // 
            // InputSendDistCard
            // 
            this.InputSendDistCard.Font = new System.Drawing.Font("Segoe UI", 12.22642F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.InputSendDistCard.Location = new System.Drawing.Point(34, 166);
            this.InputSendDistCard.MaxLength = 16;
            this.InputSendDistCard.Name = "InputSendDistCard";
            this.InputSendDistCard.Size = new System.Drawing.Size(613, 31);
            this.InputSendDistCard.TabIndex = 31;
            // 
            // SendTextLabel
            // 
            this.SendTextLabel.AutoSize = true;
            this.SendTextLabel.Font = new System.Drawing.Font("Segoe UI", 16.30189F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.SendTextLabel.Location = new System.Drawing.Point(34, 104);
            this.SendTextLabel.Name = "SendTextLabel";
            this.SendTextLabel.Size = new System.Drawing.Size(613, 35);
            this.SendTextLabel.TabIndex = 30;
            this.SendTextLabel.Text = "Enter number card which you want to send money:";
            // 
            // InputSendSum
            // 
            this.InputSendSum.Font = new System.Drawing.Font("Segoe UI", 12.22642F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.InputSendSum.Location = new System.Drawing.Point(34, 284);
            this.InputSendSum.MaxLength = 16;
            this.InputSendSum.Name = "InputSendSum";
            this.InputSendSum.Size = new System.Drawing.Size(613, 31);
            this.InputSendSum.TabIndex = 33;
            // 
            // SendText1Label
            // 
            this.SendText1Label.AutoSize = true;
            this.SendText1Label.Font = new System.Drawing.Font("Segoe UI", 16.30189F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.SendText1Label.Location = new System.Drawing.Point(34, 224);
            this.SendText1Label.Name = "SendText1Label";
            this.SendText1Label.Size = new System.Drawing.Size(471, 35);
            this.SendText1Label.TabIndex = 32;
            this.SendText1Label.Text = "Enter the sum which you want to send:";
            // 
            // SendButton
            // 
            this.SendButton.Font = new System.Drawing.Font("Segoe UI", 14.26415F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.SendButton.Location = new System.Drawing.Point(166, 332);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(304, 90);
            this.SendButton.TabIndex = 34;
            this.SendButton.Text = "Send";
            this.SendButton.UseVisualStyleBackColor = true;
            this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // SendTo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 450);
            this.Controls.Add(this.SendButton);
            this.Controls.Add(this.InputSendSum);
            this.Controls.Add(this.SendText1Label);
            this.Controls.Add(this.InputSendDistCard);
            this.Controls.Add(this.SendTextLabel);
            this.Controls.Add(this.SendLabel);
            this.Name = "SendTo";
            this.Text = "SendTo";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label SendLabel;
        private TextBox InputSendDistCard;
        private Label SendTextLabel;
        private TextBox InputSendSum;
        private Label SendText1Label;
        private Button SendButton;
    }
}