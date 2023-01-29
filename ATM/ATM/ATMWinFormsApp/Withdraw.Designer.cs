namespace ATMWinFormsApp
{
    partial class Withdraw
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
            this.WithdrawLabel = new System.Windows.Forms.Label();
            this.AddTextLabel = new System.Windows.Forms.Label();
            this.InputWithdrawSum = new System.Windows.Forms.TextBox();
            this.WithdrawButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // WithdrawLabel
            // 
            this.WithdrawLabel.AutoSize = true;
            this.WithdrawLabel.Font = new System.Drawing.Font("Segoe UI", 27.84906F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.WithdrawLabel.Location = new System.Drawing.Point(84, 38);
            this.WithdrawLabel.Name = "WithdrawLabel";
            this.WithdrawLabel.Size = new System.Drawing.Size(366, 57);
            this.WithdrawLabel.TabIndex = 3;
            this.WithdrawLabel.Text = "Withdraw money";
            // 
            // AddTextLabel
            // 
            this.AddTextLabel.AutoSize = true;
            this.AddTextLabel.Font = new System.Drawing.Font("Segoe UI", 16.30189F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.AddTextLabel.Location = new System.Drawing.Point(12, 95);
            this.AddTextLabel.Name = "AddTextLabel";
            this.AddTextLabel.Size = new System.Drawing.Size(526, 35);
            this.AddTextLabel.TabIndex = 28;
            this.AddTextLabel.Text = "Enter the sum which you want to withdraw:";
            // 
            // InputWithdrawSum
            // 
            this.InputWithdrawSum.Font = new System.Drawing.Font("Segoe UI", 12.22642F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.InputWithdrawSum.Location = new System.Drawing.Point(23, 156);
            this.InputWithdrawSum.MaxLength = 16;
            this.InputWithdrawSum.Name = "InputWithdrawSum";
            this.InputWithdrawSum.Size = new System.Drawing.Size(483, 31);
            this.InputWithdrawSum.TabIndex = 29;
            // 
            // WithdrawButton
            // 
            this.WithdrawButton.Font = new System.Drawing.Font("Segoe UI", 14.26415F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.WithdrawButton.Location = new System.Drawing.Point(118, 221);
            this.WithdrawButton.Name = "WithdrawButton";
            this.WithdrawButton.Size = new System.Drawing.Size(304, 90);
            this.WithdrawButton.TabIndex = 31;
            this.WithdrawButton.Text = "Withdraw ";
            this.WithdrawButton.UseVisualStyleBackColor = true;
            this.WithdrawButton.Click += new System.EventHandler(this.WithdrawButton_Click);
            // 
            // Withdraw
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(559, 353);
            this.Controls.Add(this.WithdrawButton);
            this.Controls.Add(this.InputWithdrawSum);
            this.Controls.Add(this.AddTextLabel);
            this.Controls.Add(this.WithdrawLabel);
            this.Name = "Withdraw";
            this.Text = "Withdraw";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label WithdrawLabel;
        private Label AddTextLabel;
        private TextBox InputWithdrawSum;
        private Button WithdrawButton;
    }
}