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
    public partial class Withdraw : Form
    {
        public Withdraw()
        {
            InitializeComponent();
        }

        private void WithdrawButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(InputWithdrawSum.Text))
            {
                MessageBox.Show("Error, enter sum");
            }
            else
            {
                if (!int.TryParse(InputWithdrawSum.Text, out int sum))
                {
                    MessageBox.Show("Error, try enter sum againe");
                    InputWithdrawSum.Clear();
                }
                else
                {
                    DataStorage.atm.WithdrawMoney(sum);
                    Close();
                }
            }
        }
    }
}
