using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CoffeeShopWithList
{
    public partial class CoffeeShopByList : Form
    {
        List<string> customerNames = new List<string> { };
        List<string> contactNumber = new List<string> { };
        List<string> address = new List<string> { };
        List<string> orders = new List<string> { };
        List<int> quantitys = new List<int> { };

        public CoffeeShopByList()
        {
            InitializeComponent();
        }

        public void AddCustomer(string name, string number, string Address, string order, int quantity)
        {
            customerNames.Add(name);
            contactNumber.Add(number);
            address.Add(Address);
            orders.Add(order);
            quantitys.Add(quantity);

            
        }

        private void addCustomerButton_Click(object sender, EventArgs e)
        {


            if (String.IsNullOrEmpty(quantityBox.Text))
                {
                    MessageBox.Show("Please enter the quanity!");
                    return;
                }
                else if(String.IsNullOrEmpty(orderComboBox.Text))
                {
                    MessageBox.Show("Please select the order!");
                    return;
                }
           else if (contactNumber.Contains(contactBox.Text))
            {
                MessageBox.Show("Contact number is already exist.\n" + "Please enter a valid unique contact number");
                return;
            }
                else
                {
                    AddCustomer(customerNameBox.Text,contactBox.Text, addressBox.Text, orderComboBox.Text, Convert.ToInt32(quantityBox.Text));
                }
            MessageBox.Show("Data Added");
            customerNameBox.Text = "";
            contactBox.Text = "";
            addressBox.Text = "";
            orderComboBox.Text = "";
            quantityBox.Text = "";

        }

        private void showBtn_Click(object sender, EventArgs e)
        {
            ShowInfo();
        }

        //Method to customer information
        private void ShowInfo()
        {
            string output = "";
            int totalAmount=0;
            for (int i = 0; i < customerNames.Count(); i++)
            {
                if (!String.IsNullOrEmpty(orderComboBox.Text) && orderComboBox.Text == "Black")
                {
                    totalAmount = (quantitys[i] * 120);
                }

                else if (!String.IsNullOrEmpty(orderComboBox.Text) && orderComboBox.Text == "Cold")
                {
                    totalAmount = (quantitys[i] * 100);
                }
                else if (!String.IsNullOrEmpty(orderComboBox.Text) && orderComboBox.Text == "Hot")
                {
                    totalAmount = (quantitys[i] * 90);
                }
                else if(!String.IsNullOrEmpty(orderComboBox.Text) && orderComboBox.Text == "Regular")
                {
                    totalAmount = (quantitys[i] * 80);
                }
                output += "Customer Name: " + customerNames[i] + "\n" + "Customer No: " + contactNumber[i] + "\n" + "Address: " + address[i] + "\n" + "Order: " + orders[i] + "\n" + "Price: " + totalAmount + "\n" + "\n";
            }
            outputRichTextBox.Text = output;
           
        }

        
    }       
    }

