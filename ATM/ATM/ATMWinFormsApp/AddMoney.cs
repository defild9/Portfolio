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
    public partial class AddMoney : Form
    {
       
        public AddMoney()
        {
            InitializeComponent();
        }

 
        private void AddButton_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(InputAddNum.Text))
            {
                MessageBox.Show("Error, enter sum");
            }
            else
            {
                if(!int.TryParse(InputAddNum.Text, out int sum))
                {
                    MessageBox.Show("Error, try enter sum againe");
                    InputAddNum.Clear();
                }
                else
                {
                    DataStorage.atm.AddMoney(sum);
                    Close();
                }
            }
        }
    }
}
