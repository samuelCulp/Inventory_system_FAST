using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory_system
{
    public partial class DataSource : Form
    {
        public DataSource()
        {
            InitializeComponent();

            textBox1.Text = mainForm.GlobalConnection.DataSource;
            textBox2.Text = mainForm.GlobalConnection.DatabaseName;
            textBox3.Text = mainForm.GlobalConnection.DatabaseCatalog;
            textBox4.Text = mainForm.GlobalConnection.DatabaseTable;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string connectionStringTest = $"Data Source=({textBox1.Text})\\{textBox2.Text};Integrated Security=SSPI;Initial Catalog={textBox3.Text};";

            try
            {
                
                using (SqlConnection sqlConnection = new SqlConnection(connectionStringTest))
                {
                    // Set the timeout before opening the connection
                    sqlConnection.Open();

                    MessageBox.Show("Connection successful. SQL Server exists.");

                    mainForm.GlobalConnection.DataSource = textBox1.Text;
                    mainForm.GlobalConnection.DatabaseName = textBox2.Text;
                    mainForm.GlobalConnection.DatabaseCatalog = textBox3.Text;
                    mainForm.GlobalConnection.DatabaseTable = textBox4.Text;
                    Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
           
        }
    }
}
