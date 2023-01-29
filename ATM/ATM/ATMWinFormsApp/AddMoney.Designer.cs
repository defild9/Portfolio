namespace ATMWinFormsApp
{
    partial class AddMoney
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
            this.AddLabel = new System.Windows.Forms.Label();
            this.AddTextLabel = new System.Windows.Forms.Label();
            this.InputAddNum = new System.Windows.Forms.TextBox();
            this.WithdrawButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AddLabel
            // 
            this.AddLabel.AutoSize = true;
            this.AddLabel.Font = new System.Drawing.Font("Segoe UI", 27.84906F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.AddLabel.Location = new System.Drawing.Point(129, 9);
            this.AddLabel.Name = "AddLabel";
            this.AddLabel.Size = new System.Drawing.Size(254, 57);
            this.AddLabel.TabIndex = 2;
            this.AddLabel.Text = "Add money";
            // 
            // AddTextLabel
            // 
            this.AddTextLabel.AutoSize = true;
            this.AddTextLabel.Font = new System.Drawing.Font("Segoe UI", 16.30189F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.AddTextLabel.Location = new System.Drawing.Point(12, 90);
            this.AddTextLabel.Name = "AddTextLabel";
            this.AddTextLabel.Size = new System.Drawing.Size(459, 35);
            this.AddTextLabel.TabIndex = 27;
            this.AddTextLabel.Text = "Enter the sum which you want to add:";
            // 
            // InputAddNum
            // 
            this.InputAddNum.Font = new System.Drawing.Font("Segoe UI", 12.22642F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.InputAddNum.Location = new System.Drawing.Point(24, 155);
            this.InputAddNum.MaxLength = 16;
            this.InputAddNum.Name = "InputAddNum";
            this.InputAddNum.Size = new System.Drawing.Size(483, 31);
            this.InputAddNum.TabIndex = 28;
            // 
            // WithdrawButton
            // 
            this.WithdrawButton.Font = new System.Drawing.Font("Segoe UI", 14.26415F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.WithdrawButton.Location = new System.Drawing.Point(116, 221);
            this.WithdrawButton.Name = "WithdrawButton";
            this.WithdrawButton.Size = new System.Drawing.Size(304, 90);
            this.WithdrawButton.TabIndex = 30;
            this.WithdrawButton.Text = "Add";
            this.WithdrawButton.UseVisualStyleBackColor = true;
            this.WithdrawButton.Click += new System.EventHandler(this.AddButton_Click);
            // 
            // AddMoney
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 336);
            this.Controls.Add(this.WithdrawButton);
            this.Controls.Add(this.InputAddNum);
            this.Controls.Add(this.AddTextLabel);
            this.Controls.Add(this.AddLabel);
            this.Name = "AddMoney";
            this.Text = "AddMoney";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label AddLabel;
        private Label AddTextLabel;
        private TextBox InputAddNum;
        private Button WithdrawButton;
    }
}