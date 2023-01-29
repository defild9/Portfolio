using ATMLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATMWinFormsApp
{
    public partial class SendTo : Form
    {
        public SendTo()
        {
            InitializeComponent();
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(InputSendDistCard.Text) && string.IsNullOrEmpty(InputSendSum.Text)) 
            {
                MessageBox.Show("Error, check your what you input");
            }
            else
            {
                if (!double.TryParse(InputSendSum.Text, out double sum))
                {
                    MessageBox.Show("Error, try enter sum againe");
                    InputSendSum.Clear();
                }
                else
                {
                    string distCard = InputSendDistCard.Text;
                    DataStorage.atm.SendMoneyTo(sum, distCard);
                    Close();
                }
            }
        }
    }
}
