
namespace MobileBank.Forms
{
    partial class СhangePhoneNumber
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
            this.label1 = new System.Windows.Forms.Label();
            this.NumberTextBox = new System.Windows.Forms.TextBox();
            this.PhoneNumberPanel = new System.Windows.Forms.Panel();
            this.changePhoneBtn = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Dubai", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(59, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(298, 27);
            this.label1.TabIndex = 40;
            this.label1.Text = "Введіть новий номер телефона:";
            // 
            // NumberTextBox
            // 
            this.NumberTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.NumberTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.NumberTextBox.Font = new System.Drawing.Font("Dubai", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NumberTextBox.ForeColor = System.Drawing.Color.White;
            this.NumberTextBox.Location = new System.Drawing.Point(64, 97);
            this.NumberTextBox.Name = "NumberTextBox";
            this.NumberTextBox.Size = new System.Drawing.Size(330, 33);
            this.NumberTextBox.TabIndex = 39;
            // 
            // PhoneNumberPanel
            // 
            this.PhoneNumberPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(79)))), ((int)(((byte)(79)))));
            this.PhoneNumberPanel.Location = new System.Drawing.Point(64, 136);
            this.PhoneNumberPanel.Name = "PhoneNumberPanel";
            this.PhoneNumberPanel.Size = new System.Drawing.Size(330, 2);
            this.PhoneNumberPanel.TabIndex = 38;
            // 
            // changePhoneBtn
            // 
            this.changePhoneBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(198)))), ((int)(((byte)(65)))));
            this.changePhoneBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.changePhoneBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold);
            this.changePhoneBtn.ForeColor = System.Drawing.Color.White;
            this.changePhoneBtn.Location = new System.Drawing.Point(64, 153);
            this.changePhoneBtn.Name = "changePhoneBtn";
            this.changePhoneBtn.Size = new System.Drawing.Size(330, 50);
            this.changePhoneBtn.TabIndex = 37;
            this.changePhoneBtn.Text = "Змінити номер телефона";
            this.changePhoneBtn.UseVisualStyleBackColor = false;
            this.changePhoneBtn.Click += new System.EventHandler(this.changePhoneBtn_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(198)))), ((int)(((byte)(65)))));
            this.CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CloseButton.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold);
            this.CloseButton.ForeColor = System.Drawing.Color.White;
            this.CloseButton.Location = new System.Drawing.Point(416, 12);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(25, 25);
            this.CloseButton.TabIndex = 36;
            this.CloseButton.Text = "X";
            this.CloseButton.UseVisualStyleBackColor = false;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // СhangePhoneNumber
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.ClientSize = new System.Drawing.Size(453, 241);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.NumberTextBox);
            this.Controls.Add(this.PhoneNumberPanel);
            this.Controls.Add(this.changePhoneBtn);
            this.Controls.Add(this.CloseButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "СhangePhoneNumber";
            this.Text = "changePhoneNumber";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.СhangePhoneNumber_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox NumberTextBox;
        private System.Windows.Forms.Panel PhoneNumberPanel;
        private System.Windows.Forms.Button changePhoneBtn;
        private System.Windows.Forms.Button CloseButton;
    }
}