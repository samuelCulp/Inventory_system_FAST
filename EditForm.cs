using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory_system
{
    public partial class EditForm : Form
    {
        public string EditedItemName { get; set; }
        public int EditedQuantity { get; set; }
        public double EditedPrice { get; set; }

        public EditForm(string itemName, int quantity, double price)
        {
            InitializeComponent();

            // Initialize the form controls with the provided data


            ItemName.Text = "ITEM:";
            QTYLabel.Text = "QTY:";
            NameBox.Text = itemName;
            QTYBox.Text = quantity.ToString();
            PriceBox.Text = price.ToString();
            
            EditedItemName = itemName;
            EditedQuantity = quantity;  
            EditedPrice = price;

        }

        private void ItemName_Click(object sender, EventArgs e)
        {

        }

        private void PriceLabel_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string editedItemName = NameBox.Text;
            string editedQuantity = QTYBox.Text;
            string editedPrice = PriceBox.Text;

            UpdateDatabase(EditedItemName, editedItemName, editedQuantity, editedPrice);

            Close();
        }

       

        private void UpdateDatabase(string originalItemName, string editedItemName, string editedQuantity, string editedPrice)
        {
            try
            {
                string connectionString = "Data Source=(LocalDB)\\LoaclDBTest;Integrated Security=SSPI;Initial Catalog=Inventory_DB;";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Update only the columns that have changed
                    string updateQuery = "UPDATE TABLE_INVENTORY1 SET ";

                    if (editedItemName != originalItemName)
                    {
                        updateQuery += "ITEM = @EditedItemName, ";
                    }

                    if (editedQuantity != originalItemName)
                    {
                        updateQuery += "QUANTITY = @EditedQuantity, ";
                    }

                    if (editedPrice != originalItemName)
                    {
                        updateQuery += "PRICE = @EditedPrice, ";
                    }

                    // Remove the trailing comma and space if any
                    if (updateQuery.EndsWith(", "))
                    {
                        updateQuery = updateQuery.Remove(updateQuery.Length - 2);
                    }

                    // Add the WHERE clause
                    updateQuery += " WHERE ITEM = @OriginalItemName";

                    using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                    {
                        updateCommand.Parameters.AddWithValue("@EditedItemName", editedItemName);
                        updateCommand.Parameters.AddWithValue("@EditedQuantity", editedQuantity);
                        updateCommand.Parameters.AddWithValue("@EditedPrice", editedPrice);
                        updateCommand.Parameters.AddWithValue("@OriginalItemName", originalItemName);

                        int rowsAffected = updateCommand.ExecuteNonQuery();
                        //MessageBox.Show($"Rows affected by update: {rowsAffected}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating database: {ex.Message}");
            }
        }

        private void DeleteBtn_Click(object sender, EventArgs e)
        {
            DeleteFromDatabase(EditedItemName);
            Close();
        } 
        
        private void DeleteFromDatabase(string itemName)
        {
            try
            {
                string connectionString = "Data Source=(LocalDB)\\LoaclDBTest;Integrated Security=SSPI;Initial Catalog=Inventory_DB;";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Delete the record based on the item name
                    string deleteQuery = "DELETE FROM TABLE_INVENTORY1 WHERE ITEM = @ItemName";

                    using (SqlCommand deleteCommand = new SqlCommand(deleteQuery, connection))
                    {
                        deleteCommand.Parameters.AddWithValue("@ItemName", itemName);

                        int rowsAffected = deleteCommand.ExecuteNonQuery();
                        Console.WriteLine($"Rows affected by delete: {rowsAffected}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error deleting from database: {ex.Message}");
            }
        }
    }
}

