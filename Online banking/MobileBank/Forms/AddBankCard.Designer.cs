
namespace MobileBank.Forms
{
    partial class AddBankCard
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
            this.CloseButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cardTypeComboBox = new System.Windows.Forms.ComboBox();
            this.PhoneNumberPanel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.currencyComboBox = new System.Windows.Forms.ComboBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.paymentSystemComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.addCardButton = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.numericUpDownPin = new System.Windows.Forms.NumericUpDown();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPin)).BeginInit();
            this.SuspendLayout();
            // 
            // CloseButton
            // 
            this.CloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(198)))), ((int)(((byte)(65)))));
            this.CloseButton.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.CloseButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CloseButton.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.CloseButton.ForeColor = System.Drawing.Color.White;
            this.CloseButton.Location = new System.Drawing.Point(559, 12);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(29, 34);
            this.CloseButton.TabIndex = 66;
            this.CloseButton.Text = "X";
            this.CloseButton.UseVisualStyleBackColor = false;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(9, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 17);
            this.label1.TabIndex = 67;
            this.label1.Text = "Тип карти ";
            // 
            // cardTypeComboBox
            // 
            this.cardTypeComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.cardTypeComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cardTypeComboBox.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.cardTypeComboBox.ForeColor = System.Drawing.Color.White;
            this.cardTypeComboBox.FormattingEnabled = true;
            this.cardTypeComboBox.Items.AddRange(new object[] {
            "Дебетова",
            "Кредитна"});
            this.cardTypeComboBox.Location = new System.Drawing.Point(12, 52);
            this.cardTypeComboBox.Name = "cardTypeComboBox";
            this.cardTypeComboBox.Size = new System.Drawing.Size(251, 33);
            this.cardTypeComboBox.TabIndex = 68;
            this.cardTypeComboBox.Tag = "";
            // 
            // PhoneNumberPanel
            // 
            this.PhoneNumberPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(198)))), ((int)(((byte)(65)))));
            this.PhoneNumberPanel.Location = new System.Drawing.Point(12, 91);
            this.PhoneNumberPanel.Name = "PhoneNumberPanel";
            this.PhoneNumberPanel.Size = new System.Drawing.Size(250, 2);
            this.PhoneNumberPanel.TabIndex = 69;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(9, 105);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 17);
            this.label2.TabIndex = 70;
            this.label2.Text = "Валюта";
            // 
            // currencyComboBox
            // 
            this.currencyComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.currencyComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.currencyComboBox.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.currencyComboBox.ForeColor = System.Drawing.Color.White;
            this.currencyComboBox.FormattingEnabled = true;
            this.currencyComboBox.Items.AddRange(new object[] {
            "UAH",
            "USD",
            "EUR"});
            this.currencyComboBox.Location = new System.Drawing.Point(12, 125);
            this.currencyComboBox.Name = "currencyComboBox";
            this.currencyComboBox.Size = new System.Drawing.Size(251, 33);
            this.currencyComboBox.TabIndex = 71;
            this.currencyComboBox.Tag = "";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(198)))), ((int)(((byte)(65)))));
            this.panel1.Location = new System.Drawing.Point(12, 164);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(250, 2);
            this.panel1.TabIndex = 72;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(198)))), ((int)(((byte)(65)))));
            this.panel2.Location = new System.Drawing.Point(12, 237);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(250, 2);
            this.panel2.TabIndex = 75;
            // 
            // paymentSystemComboBox
            // 
            this.paymentSystemComboBox.AutoCompleteCustomSource.AddRange(new string[] {
            "Visa",
            "Mastercard"});
            this.paymentSystemComboBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.paymentSystemComboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.paymentSystemComboBox.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.paymentSystemComboBox.ForeColor = System.Drawing.Color.White;
            this.paymentSystemComboBox.FormattingEnabled = true;
            this.paymentSystemComboBox.Items.AddRange(new object[] {
            "Visa",
            "Mastercard"});
            this.paymentSystemComboBox.Location = new System.Drawing.Point(12, 198);
            this.paymentSystemComboBox.Name = "paymentSystemComboBox";
            this.paymentSystemComboBox.Size = new System.Drawing.Size(251, 33);
            this.paymentSystemComboBox.TabIndex = 74;
            this.paymentSystemComboBox.Tag = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(9, 178);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 17);
            this.label3.TabIndex = 73;
            this.label3.Text = "Платіжна система";
            // 
            // addCardButton
            // 
            this.addCardButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(198)))), ((int)(((byte)(65)))));
            this.addCardButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.addCardButton.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold);
            this.addCardButton.ForeColor = System.Drawing.Color.White;
            this.addCardButton.Location = new System.Drawing.Point(12, 318);
            this.addCardButton.Name = "addCardButton";
            this.addCardButton.Size = new System.Drawing.Size(251, 50);
            this.addCardButton.TabIndex = 76;
            this.addCardButton.Text = "Створити";
            this.addCardButton.UseVisualStyleBackColor = false;
            this.addCardButton.Click += new System.EventHandler(this.addCardButton_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(198)))), ((int)(((byte)(65)))));
            this.panel3.Location = new System.Drawing.Point(12, 310);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(250, 2);
            this.panel3.TabIndex = 79;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(32)))), ((int)(((byte)(32)))));
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(9, 251);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(54, 17);
            this.label4.TabIndex = 77;
            this.label4.Text = "PIN-код";
            // 
            // numericUpDownPin
            // 
            this.numericUpDownPin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.numericUpDownPin.Font = new System.Drawing.Font("Segoe UI", 14.25F);
            this.numericUpDownPin.ForeColor = System.Drawing.Color.White;
            this.numericUpDownPin.InterceptArrowKeys = false;
            this.numericUpDownPin.Location = new System.Drawing.Point(12, 271);
            this.numericUpDownPin.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numericUpDownPin.Name = "numericUpDownPin";
            this.numericUpDownPin.Size = new System.Drawing.Size(251, 33);
            this.numericUpDownPin.TabIndex = 80;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(198)))), ((int)(((byte)(65)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("Segoe UI Semibold", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(238, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(25, 25);
            this.button2.TabIndex = 81;
            this.button2.Text = "X";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // AddBankCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.ClientSize = new System.Drawing.Size(275, 385);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.numericUpDownPin);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.addCardButton);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.paymentSystemComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.currencyComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PhoneNumberPanel);
            this.Controls.Add(this.cardTypeComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CloseButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddBankCard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddBankCard";
            this.Load += new System.EventHandler(this.AddBankCard_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AddBankCard_MouseDown);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPin)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button CloseButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cardTypeComboBox;
        private System.Windows.Forms.Panel PhoneNumberPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox currencyComboBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ComboBox paymentSystemComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button addCardButton;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericUpDownPin;
        private System.Windows.Forms.Button button2;
    }
}