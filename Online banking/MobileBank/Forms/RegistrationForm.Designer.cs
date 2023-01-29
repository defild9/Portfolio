
namespace MobileBank.Forms
{
    partial class RegistrationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RegistrationForm));
            this.GenderComboBox = new System.Windows.Forms.ComboBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.PhoneNumberPanel = new System.Windows.Forms.Panel();
            this.RegistrationLable = new System.Windows.Forms.Label();
            this.FirstNameTextBox = new System.Windows.Forms.TextBox();
            this.FirstNameLabel = new System.Windows.Forms.Label();
            this.ShowPasswordCheckBox = new System.Windows.Forms.CheckBox();
            this.LastNameTextBox = new System.Windows.Forms.TextBox();
            this.LastNameLabel = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.MiddleNameTextBox = new System.Windows.Forms.TextBox();
            this.MiddleNameLabel = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.GenderLabel = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.PasswordTextBox = new System.Windows.Forms.TextBox();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.ConfirmPasswordTextBox = new System.Windows.Forms.TextBox();
            this.ConfirmPasswordLabel = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.EmailTextBox = new System.Windows.Forms.TextBox();
            this.EmailLable = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.PhoneNumberTextBox = new System.Windows.Forms.TextBox();
            this.PhoneNumberLabel = new System.Windows.Forms.Label();
            this.CloseButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // GenderComboBox
            // 
            this.GenderComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.GenderComboBox.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.GenderComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.GenderComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.GenderComboBox.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.GenderComboBox.ForeColor = System.Drawing.Color.White;
            this.GenderComboBox.FormattingEnabled = true;
            this.GenderComboBox.Items.AddRange(new object[] {
            "Чол",
            "Жін"});
            this.GenderComboBox.Location = new System.Drawing.Point(12, 286);
            this.GenderComboBox.Name = "GenderComboBox";
            this.GenderComboBox.Size = new System.Drawing.Size(376, 33);
            this.GenderComboBox.TabIndex = 29;
            // 
            // SaveButton
            // 
            this.SaveButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(198)))), ((int)(((byte)(65)))));
            this.SaveButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.SaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.SaveButton.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SaveButton.ForeColor = System.Drawing.Color.White;
            this.SaveButton.Location = new System.Drawing.Point(12, 638);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(185, 50);
            this.SaveButton.TabIndex = 32;
            this.SaveButton.Text = "Зберегти";
            this.SaveButton.UseVisualStyleBackColor = false;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(198)))), ((int)(((byte)(65)))));
            this.ClearButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.ClearButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.ClearButton.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ClearButton.ForeColor = System.Drawing.Color.White;
            this.ClearButton.Location = new System.Drawing.Point(203, 638);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(185, 50);
            this.ClearButton.TabIndex = 33;
            this.ClearButton.Text = "Очистити";
            this.ClearButton.UseVisualStyleBackColor = false;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(198)))), ((int)(((byte)(65)))));
            this.panel1.Location = new System.Drawing.Point(12, 175);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(376, 2);
            this.panel1.TabIndex = 41;
            // 
            // PhoneNumberPanel
            // 
            this.PhoneNumberPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(198)))), ((int)(((byte)(65)))));
            this.PhoneNumberPanel.Location = new System.Drawing.Point(12, 106);
            this.PhoneNumberPanel.Name = "PhoneNumberPanel";
            this.PhoneNumberPanel.Size = new System.Drawing.Size(376, 2);
            this.PhoneNumberPanel.TabIndex = 40;
            // 
            // RegistrationLable
            // 
            this.RegistrationLable.AutoSize = true;
            this.RegistrationLable.Cursor = System.Windows.Forms.Cursors.Default;
            this.RegistrationLable.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RegistrationLable.ForeColor = System.Drawing.Color.White;
            this.RegistrationLable.Location = new System.Drawing.Point(150, 9);
            this.RegistrationLable.Name = "RegistrationLable";
            this.RegistrationLable.Size = new System.Drawing.Size(106, 25);
            this.RegistrationLable.TabIndex = 39;
            this.RegistrationLable.Text = "Реєстрація";
            // 
            // FirstNameTextBox
            // 
            this.FirstNameTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.FirstNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.FirstNameTextBox.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FirstNameTextBox.ForeColor = System.Drawing.Color.White;
            this.FirstNameTextBox.Location = new System.Drawing.Point(12, 140);
            this.FirstNameTextBox.Name = "FirstNameTextBox";
            this.FirstNameTextBox.Size = new System.Drawing.Size(376, 26);
            this.FirstNameTextBox.TabIndex = 38;
            // 
            // FirstNameLabel
            // 
            this.FirstNameLabel.AutoSize = true;
            this.FirstNameLabel.Cursor = System.Windows.Forms.Cursors.Default;
            this.FirstNameLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FirstNameLabel.ForeColor = System.Drawing.Color.White;
            this.FirstNameLabel.Location = new System.Drawing.Point(10, 118);
            this.FirstNameLabel.Name = "FirstNameLabel";
            this.FirstNameLabel.Size = new System.Drawing.Size(77, 17);
            this.FirstNameLabel.TabIndex = 37;
            this.FirstNameLabel.Text = "Введіть ім\'я";
            // 
            // ShowPasswordCheckBox
            // 
            this.ShowPasswordCheckBox.AutoSize = true;
            this.ShowPasswordCheckBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.ShowPasswordCheckBox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ShowPasswordCheckBox.ForeColor = System.Drawing.Color.White;
            this.ShowPasswordCheckBox.Location = new System.Drawing.Point(274, 476);
            this.ShowPasswordCheckBox.Name = "ShowPasswordCheckBox";
            this.ShowPasswordCheckBox.Size = new System.Drawing.Size(118, 17);
            this.ShowPasswordCheckBox.TabIndex = 36;
            this.ShowPasswordCheckBox.Text = "Показати пароль";
            this.ShowPasswordCheckBox.UseVisualStyleBackColor = true;
            this.ShowPasswordCheckBox.CheckedChanged += new System.EventHandler(this.ShowPasswordCheckBox_CheckedChanged);
            // 
            // LastNameTextBox
            // 
            this.LastNameTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.LastNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LastNameTextBox.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LastNameTextBox.ForeColor = System.Drawing.Color.White;
            this.LastNameTextBox.Location = new System.Drawing.Point(12, 71);
            this.LastNameTextBox.Name = "LastNameTextBox";
            this.LastNameTextBox.Size = new System.Drawing.Size(376, 26);
            this.LastNameTextBox.TabIndex = 35;
            // 
            // LastNameLabel
            // 
            this.LastNameLabel.AutoSize = true;
            this.LastNameLabel.Cursor = System.Windows.Forms.Cursors.Default;
            this.LastNameLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LastNameLabel.ForeColor = System.Drawing.Color.White;
            this.LastNameLabel.Location = new System.Drawing.Point(10, 48);
            this.LastNameLabel.Name = "LastNameLabel";
            this.LastNameLabel.Size = new System.Drawing.Size(111, 17);
            this.LastNameLabel.TabIndex = 34;
            this.LastNameLabel.Text = "Введіть прізвище";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(198)))), ((int)(((byte)(65)))));
            this.panel2.Location = new System.Drawing.Point(12, 249);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(376, 2);
            this.panel2.TabIndex = 44;
            // 
            // MiddleNameTextBox
            // 
            this.MiddleNameTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.MiddleNameTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.MiddleNameTextBox.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MiddleNameTextBox.ForeColor = System.Drawing.Color.White;
            this.MiddleNameTextBox.Location = new System.Drawing.Point(12, 214);
            this.MiddleNameTextBox.Name = "MiddleNameTextBox";
            this.MiddleNameTextBox.Size = new System.Drawing.Size(376, 26);
            this.MiddleNameTextBox.TabIndex = 43;
            // 
            // MiddleNameLabel
            // 
            this.MiddleNameLabel.AutoSize = true;
            this.MiddleNameLabel.Cursor = System.Windows.Forms.Cursors.Default;
            this.MiddleNameLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MiddleNameLabel.ForeColor = System.Drawing.Color.White;
            this.MiddleNameLabel.Location = new System.Drawing.Point(10, 192);
            this.MiddleNameLabel.Name = "MiddleNameLabel";
            this.MiddleNameLabel.Size = new System.Drawing.Size(125, 17);
            this.MiddleNameLabel.TabIndex = 42;
            this.MiddleNameLabel.Text = "Введіть по батькові";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(198)))), ((int)(((byte)(65)))));
            this.panel3.Location = new System.Drawing.Point(12, 325);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(376, 2);
            this.panel3.TabIndex = 47;
            // 
            // GenderLabel
            // 
            this.GenderLabel.AutoSize = true;
            this.GenderLabel.Cursor = System.Windows.Forms.Cursors.Default;
            this.GenderLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GenderLabel.ForeColor = System.Drawing.Color.White;
            this.GenderLabel.Location = new System.Drawing.Point(10, 263);
            this.GenderLabel.Name = "GenderLabel";
            this.GenderLabel.Size = new System.Drawing.Size(90, 17);
            this.GenderLabel.TabIndex = 45;
            this.GenderLabel.Text = "Оберіть стать";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(198)))), ((int)(((byte)(65)))));
            this.panel5.Location = new System.Drawing.Point(12, 397);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(376, 2);
            this.panel5.TabIndex = 53;
            // 
            // PasswordTextBox
            // 
            this.PasswordTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.PasswordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PasswordTextBox.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PasswordTextBox.ForeColor = System.Drawing.Color.White;
            this.PasswordTextBox.Location = new System.Drawing.Point(12, 362);
            this.PasswordTextBox.Name = "PasswordTextBox";
            this.PasswordTextBox.Size = new System.Drawing.Size(376, 26);
            this.PasswordTextBox.TabIndex = 52;
            this.PasswordTextBox.UseSystemPasswordChar = true;
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Cursor = System.Windows.Forms.Cursors.Default;
            this.PasswordLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PasswordLabel.ForeColor = System.Drawing.Color.White;
            this.PasswordLabel.Location = new System.Drawing.Point(10, 340);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(99, 17);
            this.PasswordLabel.TabIndex = 51;
            this.PasswordLabel.Text = "Введіть пароль";
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(198)))), ((int)(((byte)(65)))));
            this.panel4.Location = new System.Drawing.Point(12, 468);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(376, 2);
            this.panel4.TabIndex = 56;
            // 
            // ConfirmPasswordTextBox
            // 
            this.ConfirmPasswordTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.ConfirmPasswordTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ConfirmPasswordTextBox.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ConfirmPasswordTextBox.ForeColor = System.Drawing.Color.White;
            this.ConfirmPasswordTextBox.Location = new System.Drawing.Point(12, 433);
            this.ConfirmPasswordTextBox.Name = "ConfirmPasswordTextBox";
            this.ConfirmPasswordTextBox.Size = new System.Drawing.Size(376, 26);
            this.ConfirmPasswordTextBox.TabIndex = 55;
            this.ConfirmPasswordTextBox.UseSystemPasswordChar = true;
            // 
            // ConfirmPasswordLabel
            // 
            this.ConfirmPasswordLabel.AutoSize = true;
            this.ConfirmPasswordLabel.Cursor = System.Windows.Forms.Cursors.Default;
            this.ConfirmPasswordLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ConfirmPasswordLabel.ForeColor = System.Drawing.Color.White;
            this.ConfirmPasswordLabel.Location = new System.Drawing.Point(10, 411);
            this.ConfirmPasswordLabel.Name = "ConfirmPasswordLabel";
            this.ConfirmPasswordLabel.Size = new System.Drawing.Size(161, 17);
            this.ConfirmPasswordLabel.TabIndex = 54;
            this.ConfirmPasswordLabel.Text = "Введіть пароль повторно";
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(198)))), ((int)(((byte)(65)))));
            this.panel6.Location = new System.Drawing.Point(12, 550);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(376, 2);
            this.panel6.TabIndex = 59;
            // 
            // EmailTextBox
            // 
            this.EmailTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.EmailTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.EmailTextBox.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EmailTextBox.ForeColor = System.Drawing.Color.White;
            this.EmailTextBox.Location = new System.Drawing.Point(12, 518);
            this.EmailTextBox.Name = "EmailTextBox";
            this.EmailTextBox.Size = new System.Drawing.Size(376, 26);
            this.EmailTextBox.TabIndex = 58;
            // 
            // EmailLable
            // 
            this.EmailLable.AutoSize = true;
            this.EmailLable.Cursor = System.Windows.Forms.Cursors.Default;
            this.EmailLable.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EmailLable.ForeColor = System.Drawing.Color.White;
            this.EmailLable.Location = new System.Drawing.Point(10, 496);
            this.EmailLable.Name = "EmailLable";
            this.EmailLable.Size = new System.Drawing.Size(157, 17);
            this.EmailLable.TabIndex = 57;
            this.EmailLable.Text = "Введіть електрону пошту";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(198)))), ((int)(((byte)(65)))));
            this.panel7.Location = new System.Drawing.Point(12, 623);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(376, 2);
            this.panel7.TabIndex = 62;
            // 
            // PhoneNumberTextBox
            // 
            this.PhoneNumberTextBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.PhoneNumberTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PhoneNumberTextBox.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PhoneNumberTextBox.ForeColor = System.Drawing.Color.White;
            this.PhoneNumberTextBox.Location = new System.Drawing.Point(15, 591);
            this.PhoneNumberTextBox.Name = "PhoneNumberTextBox";
            this.PhoneNumberTextBox.Size = new System.Drawing.Size(373, 26);
            this.PhoneNumberTextBox.TabIndex = 61;
            // 
            // PhoneNumberLabel
            // 
            this.PhoneNumberLabel.AutoSize = true;
            this.PhoneNumberLabel.Cursor = System.Windows.Forms.Cursors.Default;
            this.PhoneNumberLabel.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.PhoneNumberLabel.ForeColor = System.Drawing.Color.White;
            this.PhoneNumberLabel.Location = new System.Drawing.Point(10, 569);
            this.PhoneNumberLabel.Name = "PhoneNumberLabel";
            this.PhoneNumberLabel.Size = new System.Drawing.Size(154, 17);
            this.PhoneNumberLabel.TabIndex = 60;
            this.PhoneNumberLabel.Text = "Введіть номер телефону";
            // 
            // CloseButton
            // 
            this.CloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(198)))), ((int)(((byte)(65)))));
            this.CloseButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CloseButton.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CloseButton.ForeColor = System.Drawing.Color.White;
            this.CloseButton.Location = new System.Drawing.Point(363, 9);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(25, 25);
            this.CloseButton.TabIndex = 83;
            this.CloseButton.Text = "X";
            this.CloseButton.UseVisualStyleBackColor = false;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // RegistrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.ClientSize = new System.Drawing.Size(400, 700);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.PhoneNumberTextBox);
            this.Controls.Add(this.PhoneNumberLabel);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.EmailTextBox);
            this.Controls.Add(this.EmailLable);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.ConfirmPasswordTextBox);
            this.Controls.Add(this.ConfirmPasswordLabel);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.PasswordTextBox);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.GenderLabel);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.MiddleNameTextBox);
            this.Controls.Add(this.MiddleNameLabel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.PhoneNumberPanel);
            this.Controls.Add(this.RegistrationLable);
            this.Controls.Add(this.FirstNameTextBox);
            this.Controls.Add(this.FirstNameLabel);
            this.Controls.Add(this.ShowPasswordCheckBox);
            this.Controls.Add(this.LastNameTextBox);
            this.Controls.Add(this.LastNameLabel);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.GenderComboBox);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "RegistrationForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RegistrationForm";
            this.Load += new System.EventHandler(this.RegistrationForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox GenderComboBox;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel PhoneNumberPanel;
        private System.Windows.Forms.Label RegistrationLable;
        private System.Windows.Forms.TextBox FirstNameTextBox;
        private System.Windows.Forms.Label FirstNameLabel;
        private System.Windows.Forms.CheckBox ShowPasswordCheckBox;
        private System.Windows.Forms.TextBox LastNameTextBox;
        private System.Windows.Forms.Label LastNameLabel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox MiddleNameTextBox;
        private System.Windows.Forms.Label MiddleNameLabel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label GenderLabel;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox PasswordTextBox;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TextBox ConfirmPasswordTextBox;
        private System.Windows.Forms.Label ConfirmPasswordLabel;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.TextBox EmailTextBox;
        private System.Windows.Forms.Label EmailLable;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.TextBox PhoneNumberTextBox;
        private System.Windows.Forms.Label PhoneNumberLabel;
        private System.Windows.Forms.Button CloseButton;
    }
}