using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using static Inventory_system.Form1;


/* This file writing to the database also create new tables 
 */

namespace Inventory_system
{
    public class data_storing
    {
        public string ConnectionString { get { return Form1.GlobalConnection.ConnectionString; } }
        public string TableName { get { return Form1.GlobalConnection.TableName; } }
        public SqlDataAdapter adpt { get; private set; }

        public static SqlDataAdapter updateQ()
        {
            var mc = new data_storing();
            mc.adpt = new SqlDataAdapter("SELECT * FORM {mc.TableName}", mc.ConnectionString);
           
            return mc.adpt;
        }
        public static DataTable ReadDB()
        {
            var mc = new data_storing();
            DataTable dataTable = new DataTable();
     
            using (SqlConnection connection = new SqlConnection(mc.ConnectionString))
            {
                connection.Open();
                mc.adpt = new SqlDataAdapter("SELECT * FORM {mc.TableName}", mc.ConnectionString);
                string query = $"SELECT * FROM {mc.TableName}";
                
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Create columns in the DataTable based on the SqlDataReader schema
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            DataColumn column = new DataColumn(reader.GetName(i), reader.GetFieldType(i));
                            dataTable.Columns.Add(column);
                        }

                        // Read data from SqlDataReader and populate the DataTable
                        while (reader.Read())
                        {
                            DataRow row = dataTable.NewRow();
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                row[i] = reader[i];
                            }
                            dataTable.Rows.Add(row);
                        }
                    }
                }
            }

            MessageBox.Show(mc.adpt.ToString());
            return dataTable;
        }

        private static bool DoesItemExist(string itemName)
        {
            try
            {
                string connectionString = Form1.GlobalConnection.ConnectionString;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Check if the item name already exists
                    string checkQuery = "SELECT COUNT(*) FROM TABLE_INVENTORY1 WHERE ITEM = @ItemName";

                    using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@ItemName", itemName);

                        int count = (int)checkCommand.ExecuteScalar();
                        // If count is greater than 0, the item already exists
                        return count > 0;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error checking item existence: {ex.Message}");
                return false; // Return false in case of an exception
            }
        }


        public static void WriteDb(string item_name, int item_qty, double item_price)
        {   // Connection to the localDB and the database
           
            if (!DoesItemExist(item_name))
            {
                string connectionString = Form1.GlobalConnection.ConnectionString;

                string itemName = item_name;
                int quantity = item_qty;
                double price = item_price;

                // SQL command to insert data into the table
                string insertQuery = $"INSERT INTO {Form1.GlobalConnection.DatabaseTable} (ITEM, QUANTITY, PRICE) VALUES (@Item, @Quantity, @Price)";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Insert data into the table
                    using (SqlCommand insertCommand = new SqlCommand(insertQuery, connection))
                    {

                        insertCommand.Parameters.AddWithValue("@Item", itemName);
                        insertCommand.Parameters.AddWithValue("@Quantity", quantity);
                        insertCommand.Parameters.AddWithValue("@Price", price);

                        int rowsAffected = insertCommand.ExecuteNonQuery();
                        connection.Close();
                    }
                }
            }
            else
            {
                MessageBox.Show("Item Already Exist");
            }
        }


        public static void CreateDB(string newTableName)
        {
            string connectionString = GlobalConnection.ConnectionString;
            string databaseName = GlobalConnection.DatabaseCatalog;

            // Define the columns and their data types for the new table
            string columnsDefinition = "ITEM VARCHAR(255), QUANTITY INT, PRICE FLOAT";

            // Check if the database exists
            string checkDatabaseQuery = $"SELECT COUNT(*) FROM sys.databases WHERE name = '{databaseName}'";

            // Create the new table with defined columns
            string createTableQuery = $"USE {databaseName}; " +
                                      $"CREATE TABLE {newTableName} ({columnsDefinition})";

            SqlConnection sqlConnection = new SqlConnection(connectionString);

            try
            {
                sqlConnection.Open();

                // Check if the database exists
                SqlCommand checkDatabaseCommand = new SqlCommand(checkDatabaseQuery, sqlConnection);
                int databaseCount = (int)checkDatabaseCommand.ExecuteScalar();

                if (databaseCount == 0)
                {
                    // Create the database if it doesn't exist
                    string createDatabaseQuery = $"CREATE DATABASE {databaseName}";
                    SqlCommand createDatabaseCommand = new SqlCommand(createDatabaseQuery, sqlConnection);
                    createDatabaseCommand.ExecuteNonQuery();
                }

                // Create the new table with defined columns
                SqlCommand createTableCommand = new SqlCommand(createTableQuery, sqlConnection);
                createTableCommand.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                sqlConnection.Close();
            }
        }





    }
}


