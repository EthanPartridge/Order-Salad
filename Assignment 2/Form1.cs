using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Assignment_2
{
    public partial class Form1 : Form
    {
        // Form 1 Initialization Method
        public Form1()
        {
            InitializeComponent();
        }

        // Data
        string sauceChargeString = ""; //data member to construct sauce and spoon information
        List<double> priceList = new List<double>(); //list that holds all prices of order

        // Place Order Menu Strip Click Event
        private void placeOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Your order has been placed successfully!");
        }

        // Reset Order Menu Strip Click Event
        private void clearOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ResetOrder();
            MessageBox.Show("Your order has been cleared!");
        }
        
        // Display Order Menu Strip Click Event
        private void displayOrderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StringBuilder str = new StringBuilder();
            foreach (object selectedItem in lbChoice.Items)
            {
                str.AppendLine(selectedItem.ToString());
            }
            MessageBox.Show("You have ordered: \n"+ str + "\n Your total is: " + priceList.Sum().ToString());
        }

        // Exit Menu Strip Click Event
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        // Help Menu Strip Click Event
        private void aboutTheAppToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Version 1.0.0");
        }

        // Reset Order Method
        private void ResetOrder()
        {
            // Clear ListBox
            lbChoice.Items.Clear();
            
            // Clear CheckedListBox
            for (int i = 0; i < checkedListBox1.Items.Count;i++)
                {
                    checkedListBox1.SetItemChecked(i, false);
                }

            // Clear ComboBox
            cbSpoonSauce.SelectedIndex = -1;

            // Clear Radio Buttons
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            radioButton5.Checked = false;
            radioButton6.Checked = false;

            // Clear Price List
            priceList.Clear();
        }

        // ComboBox SelectedIndexChanged Event to Construct Sauce and Spoon Information
        private void cbSpoonSauce_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSpoonSauce.SelectedItem != null)
            {
                string s = cbSpoonSauce.SelectedItem.ToString();
                this.sauceChargeString += s + " spoons: $" + s + " - ";
            }
        }

        // Button Click Event
        private void button1_Click(object sender, EventArgs e)
        {
            // If statement prevents app crashes by making user select value for number of spoons
            if (cbSpoonSauce.SelectedItem == null)
            {
                MessageBox.Show("Please select number of spoons.");
            }
            else
            {
                // Credit Card Payment Check
                if (this.radioButton5.Checked)
                {
                    MessageBox.Show("You chose to pay with credit card.");
                }
                else if (this.radioButton6.Checked)
                {
                    MessageBox.Show("You did not choose to pay with credit card.");
                }

                // Check Sauce Type and Number of Spoons
                checksauce();
                lbChoice.Items.Add(this.sauceChargeString);
                parseSpoons(sauceChargeString); //adds number of spoons to priceList
                this.sauceChargeString = ""; //resets string

                // Add CheckedListBox Items to ListBox
                foreach (Object item in checkedListBox1.CheckedItems)
                {
                    lbChoice.Items.Add(item);
                    parsePrice(item.ToString());
                }

                // Determine and Display Total Price
                double sum1 = priceList.Sum();
                string sumString = sum1.ToString();
                label5.Text += " $" + sumString;

                cbSpoonSauce.SelectedIndex = -1; // resets ComboBox item value to null
            }

        }

        // Check Sauce Method
        private void checksauce()
        {
            string sauceString = "";
            if (this.radioButton1.Checked)
                sauceString = radioButton1.Text;
            if (this.radioButton2.Checked)
                sauceString = radioButton2.Text;
            if (this.radioButton3.Checked)
                sauceString = radioButton3.Text;
            if (this.radioButton4.Checked)
                sauceString = radioButton4.Text;

            this.sauceChargeString += sauceString;
        }

        // Parse Ingredient Price Method
        private void parsePrice(string v)
        {
            string price = v.Substring(v.IndexOf("$") + 1);

            //convert string to double
            double p = double.Parse(price);

            //add double price to list
            priceList.Add(p);
        }

        // Parse Sauce Price Method
        private void parseSpoons(string v)
        {
            string price = v.Substring(0,1);

            double p = double.Parse(price);

            priceList.Add(p);
        }
    }
}
