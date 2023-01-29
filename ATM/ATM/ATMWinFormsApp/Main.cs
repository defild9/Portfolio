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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            
        }

        private void Operations(object sender, EventArgs e)
        {
            if (sender is Button)
            {
                Button button = (Button)sender;
                switch (button.Name)
                {
                    case "CheckBalanceButton":
                        {
                            DataStorage.atm.CheckBalance();
                            break;
                        }
                    case "AddMoneyButton":
                        {
                            Hide();
                            AddMoney addMoney = new AddMoney();
                            addMoney.ShowDialog();
                            addMoney = null;
                            Show();
                            break;
                        }
                    case "SendToButton":
                        {
                            Hide();
                            SendTo sendTo = new SendTo();
                            sendTo.ShowDialog();
                            sendTo = null;
                            Show();
                            break;
                        }
                    case "WithdrawMoneyButton":
                        {
                            Hide();
                            Withdraw withdraw = new Withdraw();
                            withdraw.ShowDialog();
                            withdraw = null;
                            Show();
                            break;
                        }
                    case "SettingsButton":
                        {
                            Hide();
                            Settings settings = new Settings();
                            settings.ShowDialog();
                            settings = null;
                            Show();
                            break;
                        }
                    case "ExitButton":
                        {
                            Close();
                            break;
                        }
                }
            }
        }

       
        public static void ShowMessage(object sender, Event e) => MessageBox.Show(e.Message);

        private void Main_Load(object sender, EventArgs e)
        {

        }
    }
}
