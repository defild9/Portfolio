
namespace MobileBank.Forms
{
    partial class СhangeEmail
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
            this.EmailTextBox = new System.Windows.Forms.TextBox();
            this.PhoneNumberPanel = new System.Windows.Forms.Panel();
            this.changeEmailBtn = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Dubai", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(59, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 27);
            this.label1.TabIndex = 45;
            this.label1.Text = "Введіть нову ел. пошту";
            // 
            // EmailTextBox
            // 
            this.EmailTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.EmailTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.EmailTextBox.Font = new System.Drawing.Font("Dubai", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EmailTextBox.ForeColor = System.Drawing.Color.White;
            this.EmailTextBox.Location = new System.Drawing.Point(64, 96);
            this.EmailTextBox.Name = "EmailTextBox";
            this.EmailTextBox.Size = new System.Drawing.Size(330, 33);
            this.EmailTextBox.TabIndex = 44;
            // 
            // PhoneNumberPanel
            // 
            this.PhoneNumberPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(79)))), ((int)(((byte)(79)))));
            this.PhoneNumberPanel.Location = new System.Drawing.Point(64, 135);
            this.PhoneNumberPanel.Name = "PhoneNumberPanel";
            this.PhoneNumberPanel.Size = new System.Drawing.Size(330, 2);
            this.PhoneNumberPanel.TabIndex = 43;
            // 
            // changeEmailBtn
            // 
            this.changeEmailBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(198)))), ((int)(((byte)(65)))));
            this.changeEmailBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.changeEmailBtn.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold);
            this.changeEmailBtn.ForeColor = System.Drawing.Color.White;
            this.changeEmailBtn.Location = new System.Drawing.Point(64, 152);
            this.changeEmailBtn.Name = "changeEmailBtn";
            this.changeEmailBtn.Size = new System.Drawing.Size(330, 50);
            this.changeEmailBtn.TabIndex = 42;
            this.changeEmailBtn.Text = "Змінити ел. пошту";
            this.changeEmailBtn.UseVisualStyleBackColor = false;
            this.changeEmailBtn.Click += new System.EventHandler(this.changeEmailBtn_Click);
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
            this.CloseButton.TabIndex = 41;
            this.CloseButton.Text = "X";
            this.CloseButton.UseVisualStyleBackColor = false;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // СhangeEmail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.ClientSize = new System.Drawing.Size(450, 240);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.EmailTextBox);
            this.Controls.Add(this.PhoneNumberPanel);
            this.Controls.Add(this.changeEmailBtn);
            this.Controls.Add(this.CloseButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "СhangeEmail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "changeEmail";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.СhangeEmail_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox EmailTextBox;
        private System.Windows.Forms.Panel PhoneNumberPanel;
        private System.Windows.Forms.Button changeEmailBtn;
        private System.Windows.Forms.Button CloseButton;
    }
}