using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_CSharp
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        MySqlConnection conn;
        MySqlDataAdapter dataAdapter;
        DataSet dataSet;

        private void Form2_Load(object sender, EventArgs e)
        {
            conn = new MySqlConnection("server=localhost;port=3306;database=mydb;uid=root;pwd=1234;charset=UTF8");
            dataAdapter = new MySqlDataAdapter("SELECT * FROM customer", conn);
            dataSet = new DataSet();

            dataAdapter.Fill(dataSet, "customer");
            dataGridView1.DataSource = dataSet.Tables["customer"];
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM customer WHERE name=@name";
            dataAdapter.SelectCommand = new MySqlCommand(sql, conn);
            dataAdapter.SelectCommand.Parameters.AddWithValue("@name", textBoxUserName.Text);

            try
            {
                conn.Open();
                dataSet.Clear();
                if (dataAdapter.Fill(dataSet, "customer") > 0)
                    dataGridView1.DataSource = dataSet.Tables["customer"];
                else
                {
                    MessageBox.Show("검색된 데이터가 없습니다.");
                    dataAdapter = new MySqlDataAdapter("SELECT * FROM customer", conn);
                    dataSet = new DataSet();

                    dataAdapter.Fill(dataSet, "customer");
                    dataGridView1.DataSource = dataSet.Tables["customer"];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            string sql = "INSERT INTO customer (name, address, phone) " +
                "VALUES(@name, @address, @phone)";
            dataAdapter.InsertCommand = new MySqlCommand(sql, conn);
            dataAdapter.InsertCommand.Parameters.AddWithValue("@name", textBoxUserName.Text);
            dataAdapter.InsertCommand.Parameters.AddWithValue("@address", textBoxAddress.Text);
            dataAdapter.InsertCommand.Parameters.AddWithValue("@phone", textBoxPhone.Text);

            DataRow newRow = dataSet.Tables["customer"].NewRow();
            newRow["name"] = textBoxUserName.Text;
            newRow["address"] = textBoxAddress.Text;
            newRow["phone"] = textBoxPhone.Text;
            dataSet.Tables["customer"].Rows.Add(newRow);

            try
            {
                if (dataAdapter.Update(dataSet, "customer") > 0)
                {
                    dataSet.Clear();
                    dataAdapter.Fill(dataSet, "customer");
                    dataGridView1.DataSource = dataSet.Tables["customer"];
                }
                else
                    MessageBox.Show("검색된 데이터가 없습니다.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string sql = "UPDATE customer SET name=@name WHERE address=@address";
            dataAdapter.UpdateCommand = new MySqlCommand(sql, conn);
            dataAdapter.UpdateCommand.Parameters.AddWithValue("@custid", textBoxCustID.Text);
            dataAdapter.UpdateCommand.Parameters.AddWithValue("@name", textBoxUserName.Text);
            dataAdapter.UpdateCommand.Parameters.AddWithValue("@address", textBoxAddress.Text);
            dataAdapter.UpdateCommand.Parameters.AddWithValue("@phone", textBoxPhone.Text);

            try
            {
                conn.Open();

                if (dataAdapter.UpdateCommand.ExecuteNonQuery() > 0)
                {
                    dataSet.Clear();
                    dataAdapter.Fill(dataSet, "customer");
                    dataGridView1.DataSource = dataSet.Tables["customer"];
                }
                else
                    MessageBox.Show("수정된 데이터가 없습니다.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            string sql = "DELETE FROM customer WHERE custid=@custid";
            dataAdapter.DeleteCommand = new MySqlCommand(sql, conn);
            int id = (int)dataGridView1.SelectedRows[0].Cells["custid"].Value;
            dataAdapter.DeleteCommand.Parameters.AddWithValue("@custid", id);

            try
            {
                conn.Open();
                if (dataAdapter.DeleteCommand.ExecuteNonQuery() > 0)
                {
                    dataSet.Clear();
                    dataAdapter.Fill(dataSet, "customer");
                    dataGridView1.DataSource = dataSet.Tables["customer"];
                }
                else
                {
                    MessageBox.Show("삭제된 데이터가 없습니다.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void Book_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form1 book = new Form1();
            book.ShowDialog();
        }

        private void Order_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form3 order = new Form3();
            order.ShowDialog();
        }

        private void textEmpty_Click(object sender, EventArgs e)
        {
            textBoxCustID.Text = "";
            textBoxUserName.Text = "";
            textBoxAddress.Text = "";
            textBoxPhone.Text = "";

            dataAdapter = new MySqlDataAdapter("SELECT * FROM customer", conn);
            dataSet = new DataSet();

            dataAdapter.Fill(dataSet, "customer");
            dataGridView1.DataSource = dataSet.Tables["customer"];
        }
    }
}