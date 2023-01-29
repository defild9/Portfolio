namespace ATMWinFormsApp
{
    partial class Settings
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
            this.SettingsLabel = new System.Windows.Forms.Label();
            this.OffBalance = new System.Windows.Forms.CheckBox();
            this.OffAdd = new System.Windows.Forms.CheckBox();
            this.OffSend = new System.Windows.Forms.CheckBox();
            this.OffWithdraw = new System.Windows.Forms.CheckBox();
            this.OffAuth = new System.Windows.Forms.CheckBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SettingsLabel
            // 
            this.SettingsLabel.AutoSize = true;
            this.SettingsLabel.Font = new System.Drawing.Font("Segoe UI", 27.84906F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.SettingsLabel.Location = new System.Drawing.Point(109, 9);
            this.SettingsLabel.Name = "SettingsLabel";
            this.SettingsLabel.Size = new System.Drawing.Size(185, 57);
            this.SettingsLabel.TabIndex = 5;
            this.SettingsLabel.Text = "Settings";
            // 
            // OffBalance
            // 
            this.OffBalance.AutoSize = true;
            this.OffBalance.Font = new System.Drawing.Font("Segoe UI", 12.22642F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.OffBalance.Location = new System.Drawing.Point(39, 106);
            this.OffBalance.Name = "OffBalance";
            this.OffBalance.Size = new System.Drawing.Size(264, 29);
            this.OffBalance.TabIndex = 34;
            this.OffBalance.Text = "Off/ON balance notification";
            this.OffBalance.UseVisualStyleBackColor = true;
            // 
            // OffAdd
            // 
            this.OffAdd.AutoSize = true;
            this.OffAdd.Font = new System.Drawing.Font("Segoe UI", 12.22642F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.OffAdd.Location = new System.Drawing.Point(39, 141);
            this.OffAdd.Name = "OffAdd";
            this.OffAdd.Size = new System.Drawing.Size(292, 29);
            this.OffAdd.TabIndex = 35;
            this.OffAdd.Text = "Off/ON add money notification";
            this.OffAdd.UseVisualStyleBackColor = true;
            // 
            // OffSend
            // 
            this.OffSend.AutoSize = true;
            this.OffSend.Font = new System.Drawing.Font("Segoe UI", 12.22642F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.OffSend.Location = new System.Drawing.Point(39, 176);
            this.OffSend.Name = "OffSend";
            this.OffSend.Size = new System.Drawing.Size(297, 29);
            this.OffSend.TabIndex = 36;
            this.OffSend.Text = "Off/On send money notification";
            this.OffSend.UseVisualStyleBackColor = true;
            // 
            // OffWithdraw
            // 
            this.OffWithdraw.AutoSize = true;
            this.OffWithdraw.Font = new System.Drawing.Font("Segoe UI", 12.22642F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.OffWithdraw.Location = new System.Drawing.Point(39, 211);
            this.OffWithdraw.Name = "OffWithdraw";
            this.OffWithdraw.Size = new System.Drawing.Size(280, 29);
            this.OffWithdraw.TabIndex = 37;
            this.OffWithdraw.Text = "Off/ON Withdraw notification";
            this.OffWithdraw.UseVisualStyleBackColor = true;
            // 
            // OffAuth
            // 
            this.OffAuth.AutoSize = true;
            this.OffAuth.Font = new System.Drawing.Font("Segoe UI", 12.22642F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.OffAuth.Location = new System.Drawing.Point(39, 246);
            this.OffAuth.Name = "OffAuth";
            this.OffAuth.Size = new System.Drawing.Size(232, 29);
            this.OffAuth.TabIndex = 38;
            this.OffAuth.Text = "Off/ON Authentification";
            this.OffAuth.UseVisualStyleBackColor = true;
            // 
            // SaveButton
            // 
            this.SaveButton.Font = new System.Drawing.Font("Segoe UI", 14.26415F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.SaveButton.Location = new System.Drawing.Point(39, 281);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(304, 90);
            this.SaveButton.TabIndex = 39;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(407, 405);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.OffAuth);
            this.Controls.Add(this.OffWithdraw);
            this.Controls.Add(this.OffSend);
            this.Controls.Add(this.OffAdd);
            this.Controls.Add(this.OffBalance);
            this.Controls.Add(this.SettingsLabel);
            this.Name = "Settings";
            this.Text = "Settings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label SettingsLabel;
        private CheckBox OffBalance;
        private CheckBox OffAdd;
        private CheckBox OffSend;
        private CheckBox OffWithdraw;
        private CheckBox OffAuth;
        private Button SaveButton;
    }
}