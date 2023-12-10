using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;


namespace Inventory_system
{
    public partial class Form1 : Form
    {

        private SqlConnection sqlConnection;
        private SqlDataAdapter dataAdapter;
        private DataTable dataTable;


        public static class GlobalConnection
        {
            public static string TableName { get; set; }

            public static string DataSource { get; set; }
            public static string DatabaseName { get; set; }
            public static string DatabaseCatalog { get; set; }
            public static string DatabaseTable { get; set; }

            public static string ConnectionString
            {
                get
                {
                    return $"Data Source=(" + DataSource + ")\\" + DatabaseName +
                                                ";Integrated Security=SSPI;Initial Catalog=" + DatabaseCatalog + ";";
                }
            }

        }

        public void updateDB(string sortOrder = "ITEM ASC")
        {
           
            try
            {
                string connectionString = GlobalConnection.ConnectionString;

                using (SqlConnection sqlcon = new SqlConnection(connectionString))
                {
                    
                    SqlDataAdapter adapter = new SqlDataAdapter($"SELECT * FROM {GlobalConnection.DatabaseTable} ORDER BY {sortOrder}", sqlcon);
                    DataTable data = new DataTable();
                    dataTable = data;
                    sqlcon.Open();
                    adapter.Fill(dataTable);
                    dataGridView1.Columns["Column3"].DefaultCellStyle.Format = "c2";
                    dataGridView1.DataSource = dataTable;
                    sqlcon.Close();
                }
            }
            catch(Exception ex) { MessageBox.Show($"Cannot find Database {ex.Message}"); }
        }

        private void DataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
{
    // Check if the current cell is in the "PRICE" column
        if (dataGridView1.Columns[e.ColumnIndex].Name == "PRICE")
        {
            // Apply currency formatting
            if (e.Value != null && double.TryParse(e.Value.ToString(), out double price))
            {
                e.Value = price.ToString("C"); // "C" is the format for currency
                e.FormattingApplied = true;
            }
        }
}


        public Form1()
        {
            InitializeComponent();
            //Initialize the SQL server
            GlobalConnection.DataSource = "LocalDB";
            GlobalConnection.DatabaseName = "LoaclDBTest";
            GlobalConnection.DatabaseCatalog = "Inventory_DB";
            GlobalConnection.DatabaseTable = "TABLE_INVENTORY1";
 
            btnAddItem.Click -= btnAddItem_Click;
            btnAddItem.Click += btnAddItem_Click;
            //Initializes the data to dataGridView
            updateDB();
            // Enable editing in the DataGridView
            dataGridView1.ReadOnly = false;

            // Subscribe to the CellEndEdit event to capture changes
            dataGridView1.CellEndEdit += DataGridView1_CellEndEdit;

            // Subscribe to the CellClick event to open the edit form
            dataGridView1.CellClick += DataGridView1_CellClick;

        }



        private void Form1_Load(object sender, EventArgs e)
        {
          
        }


    

    private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void DataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the clicked cell is in the row header
            if (e.RowIndex >= 0 && e.ColumnIndex == -1)
            {

                // Get data for the clicked row
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];
                string itemName = selectedRow.Cells["ITEM"].Value.ToString();
                int quantity = Convert.ToInt32(selectedRow.Cells["Column2"].Value);
                double price = Convert.ToDouble(selectedRow.Cells["Column3"].Value);

                // Open the edit form with the selected data
                EditForm editForm = new EditForm(itemName, quantity, price);
                editForm.ShowDialog();

                // If the edit form is closed with OK result, update the DataGridView and database
                if (editForm.DialogResult == DialogResult.OK)
                {
                    
                }
                    updateDB();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            updateDB();
        }



        private void btnAddItem_Click(object sender, EventArgs e)
        {
            Form2 secondForm = new Form2();
            if (secondForm.ShowDialog() == DialogResult.OK)
            {
                
            }
            updateDB();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedOption = comboBox1.SelectedItem.ToString();

            switch (selectedOption)
            {
                case "Alphanumeric":
                    updateDB(); 
                    break;
                case "Price High to Low":
                    updateDB("PRICE DESC");
                    break;
                case "Price Low to High":
                    updateDB("PRICE ASC");
                    break;
                default:
                    break;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DataSource dataSource = new DataSource();
            if (dataSource.ShowDialog() == DialogResult.OK)
            {
               
            }
            updateDB();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            if (form3.ShowDialog() == DialogResult.OK) { updateDB(); }
        }
    }
}

