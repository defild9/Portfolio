using ATMLib;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
using System.Security.Principal;

namespace ATMWinFormsApp
{
    public partial class Login : Form
    {
        AutomatedTellerMachine atm = new AutomatedTellerMachine();
        Account account = new Account();
        Bank bank = new Bank(1);
        public Login()
        {
            InitializeComponent();
            InputCardPin.UseSystemPasswordChar = true;
            atm.AuthentificatinEvent += ShowMessage;
        }

        private void ShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if(ShowPassword.Checked == true)
            {
                InputCardPin.UseSystemPasswordChar = false;
            }
            else
            {
                InputCardPin.UseSystemPasswordChar = true;
            }
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            string numCard = InputCardNum.Text;
            string pinCard = InputCardPin.Text;
            bool isLogin = false;
            isLogin = atm.Login(numCard, pinCard);
            
            if(isLogin == true)
            {
                string login = $"You are login at {DateTime.Now}";
                atm.atmId = bank.Id;
                atm.UserCardNum = numCard;
                DataStorage.CardNum = numCard;
                DataStorage.atm = atm;
                DataStorage.Id = bank.Id;
                atm.BalaceEvent += ShowMessage;
                atm.SendMoneyEvent += ShowMessage;
                atm.AddMoneyEvent += ShowMessage;
                atm.WithdrawMoneyEvent += ShowMessage;
                atm.EmailNotice(login);

                Hide();
                Main mainForm = new Main();
                mainForm.ShowDialog();
                mainForm = null;
                Show();
            }
        }
        public static void ShowMessage(object sender, Event e) => MessageBox.Show(e.Message);
    }
}