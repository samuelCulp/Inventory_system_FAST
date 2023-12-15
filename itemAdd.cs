using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// this file adds new item to the database

namespace Inventory_system
{
    public partial class itemAdd : Form
    {

        public string Item_name {  get; private set; }
        public int Item_qty { get; private set; }
        public double Item_price { get; private set; }


        public itemAdd()
        {
            InitializeComponent();
           
            Item_qty = 0;
            Item_price = 0;
            Item_name = string.Empty;
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string item_name = textBox1.Text;
            string str_item_qty = textBox2.Text;
            string str_item_price = textBox3.Text;
            int item_qty;
            double item_price;

            if (int.TryParse(str_item_qty, out item_qty) && double.TryParse(str_item_price, out item_price))
            {
                Item_price = Math.Round(item_price, 2);
                Item_qty = item_qty;
                Item_name = item_name;

                // Perform the database operation
                data_storing.WriteDb(Item_name, item_qty, item_price);
                if (checkBox1.Checked)
                {
                    // Clear the textboxes for the next entry
                    textBox1.Text = string.Empty;
                    textBox2.Text = string.Empty;
                    textBox3.Text = string.Empty;

                    // Optionally, set focus to the first textbox for convenience
                    textBox1.Focus();
                }
                else { Close(); }
            }
            else
            {
                MessageBox.Show("Invalid Input");
            }
        }


        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
