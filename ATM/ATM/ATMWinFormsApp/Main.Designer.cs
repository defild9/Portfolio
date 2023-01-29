namespace ATMWinFormsApp
{
    partial class Main
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
            this.CheckBalanceButton = new System.Windows.Forms.Button();
            this.AddMoneyButton = new System.Windows.Forms.Button();
            this.SendToButton = new System.Windows.Forms.Button();
            this.WithdrawMoneyButton = new System.Windows.Forms.Button();
            this.SettingsButton = new System.Windows.Forms.Button();
            this.ExitButton = new System.Windows.Forms.Button();
            this.ManuLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CheckBalanceButton
            // 
            this.CheckBalanceButton.Font = new System.Drawing.Font("Segoe UI", 14.26415F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.CheckBalanceButton.Location = new System.Drawing.Point(23, 71);
            this.CheckBalanceButton.Name = "CheckBalanceButton";
            this.CheckBalanceButton.Size = new System.Drawing.Size(226, 60);
            this.CheckBalanceButton.TabIndex = 0;
            this.CheckBalanceButton.Text = "Check the balance";
            this.CheckBalanceButton.UseVisualStyleBackColor = true;
            this.CheckBalanceButton.Click += new System.EventHandler(this.Operations);
            // 
            // AddMoneyButton
            // 
            this.AddMoneyButton.Font = new System.Drawing.Font("Segoe UI", 14.26415F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.AddMoneyButton.Location = new System.Drawing.Point(23, 161);
            this.AddMoneyButton.Name = "AddMoneyButton";
            this.AddMoneyButton.Size = new System.Drawing.Size(226, 60);
            this.AddMoneyButton.TabIndex = 1;
            this.AddMoneyButton.Text = "Add money";
            this.AddMoneyButton.UseVisualStyleBackColor = true;
            this.AddMoneyButton.Click += new System.EventHandler(this.Operations);
            // 
            // SendToButton
            // 
            this.SendToButton.Font = new System.Drawing.Font("Segoe UI", 12.22642F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.SendToButton.Location = new System.Drawing.Point(23, 259);
            this.SendToButton.Name = "SendToButton";
            this.SendToButton.Size = new System.Drawing.Size(226, 60);
            this.SendToButton.TabIndex = 2;
            this.SendToButton.Text = "Send money to another card";
            this.SendToButton.UseVisualStyleBackColor = true;
            this.SendToButton.Click += new System.EventHandler(this.Operations);
            // 
            // WithdrawMoneyButton
            // 
            this.WithdrawMoneyButton.Font = new System.Drawing.Font("Segoe UI", 14.26415F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.WithdrawMoneyButton.Location = new System.Drawing.Point(302, 71);
            this.WithdrawMoneyButton.Name = "WithdrawMoneyButton";
            this.WithdrawMoneyButton.Size = new System.Drawing.Size(226, 60);
            this.WithdrawMoneyButton.TabIndex = 3;
            this.WithdrawMoneyButton.Text = "Withdraw money";
            this.WithdrawMoneyButton.UseVisualStyleBackColor = true;
            this.WithdrawMoneyButton.Click += new System.EventHandler(this.Operations);
            // 
            // SettingsButton
            // 
            this.SettingsButton.Font = new System.Drawing.Font("Segoe UI", 14.26415F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.SettingsButton.Location = new System.Drawing.Point(302, 161);
            this.SettingsButton.Name = "SettingsButton";
            this.SettingsButton.Size = new System.Drawing.Size(226, 60);
            this.SettingsButton.TabIndex = 4;
            this.SettingsButton.Text = "Settings";
            this.SettingsButton.UseVisualStyleBackColor = true;
            this.SettingsButton.Click += new System.EventHandler(this.Operations);
            // 
            // ExitButton
            // 
            this.ExitButton.Font = new System.Drawing.Font("Segoe UI", 14.26415F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ExitButton.Location = new System.Drawing.Point(302, 259);
            this.ExitButton.Name = "ExitButton";
            this.ExitButton.Size = new System.Drawing.Size(226, 60);
            this.ExitButton.TabIndex = 5;
            this.ExitButton.Text = "Exit";
            this.ExitButton.UseVisualStyleBackColor = true;
            this.ExitButton.Click += new System.EventHandler(this.Operations);
            // 
            // ManuLabel
            // 
            this.ManuLabel.AutoSize = true;
            this.ManuLabel.Font = new System.Drawing.Font("Segoe UI", 27.84906F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ManuLabel.Location = new System.Drawing.Point(212, 9);
            this.ManuLabel.Name = "ManuLabel";
            this.ManuLabel.Size = new System.Drawing.Size(138, 57);
            this.ManuLabel.TabIndex = 6;
            this.ManuLabel.Text = "Menu";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 364);
            this.Controls.Add(this.ManuLabel);
            this.Controls.Add(this.ExitButton);
            this.Controls.Add(this.SettingsButton);
            this.Controls.Add(this.WithdrawMoneyButton);
            this.Controls.Add(this.SendToButton);
            this.Controls.Add(this.AddMoneyButton);
            this.Controls.Add(this.CheckBalanceButton);
            this.Name = "Main";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button CheckBalanceButton;
        private Button AddMoneyButton;
        private Button SendToButton;
        private Button WithdrawMoneyButton;
        private Button SettingsButton;
        private Button ExitButton;
        private Label ManuLabel;
    }
}