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
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
            OffAdd.Checked = false;
            OffAuth.Checked = false;
            OffBalance.Checked = false;
            OffSend.Checked = false;
            OffWithdraw.Checked = false;
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (OffAdd.Checked)
            {
                DataStorage.atm.AddMoneyEvent -= Login.ShowMessage;
            }
            else
            {
                DataStorage.atm.AddMoneyEvent += Login.ShowMessage;
            }
            if (OffAuth.Checked)
            {
                DataStorage.atm.AuthentificatinEvent -= Login.ShowMessage;
            }
            else
            {
                DataStorage.atm.AuthentificatinEvent -= Login.ShowMessage;
            }
            if (OffBalance.Checked)
            {
                DataStorage.atm.BalaceEvent -= Login.ShowMessage;
            }
            else
            {
                DataStorage.atm.BalaceEvent += Login.ShowMessage;
            }
            if (OffSend.Checked)
            {
                DataStorage.atm.SendMoneyEvent -= Login.ShowMessage;
            }
            else
            {
                DataStorage.atm.SendMoneyEvent += Login.ShowMessage;
            }
            if (OffWithdraw.Checked)
            {
                DataStorage.atm.WithdrawMoneyEvent -= Login.ShowMessage;
            }
            else
            {
                DataStorage.atm.WithdrawMoneyEvent += Login.ShowMessage;
            }
        }
    }
}
