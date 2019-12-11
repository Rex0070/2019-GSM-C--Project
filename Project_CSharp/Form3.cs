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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        MySqlConnection conn;
        MySqlDataAdapter dataAdapter;
        DataSet dataSet;

        private void Form3_Load(object sender, EventArgs e)
        {
            conn = new MySqlConnection("server=localhost;port=3306;database=mydb;uid=root;pwd=1234;charset=UTF8");
            dataAdapter = new MySqlDataAdapter("SELECT * FROM orders", conn);
            dataSet = new DataSet();

            dataAdapter.Fill(dataSet, "orders");
            dataGridView1.DataSource = dataSet.Tables["orders"];
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM orders WHERE custid=@custid";
            dataAdapter.SelectCommand = new MySqlCommand(sql, conn);
            dataAdapter.SelectCommand.Parameters.AddWithValue("@custid", textBoxCustId.Text);

            try
            {
                conn.Open();
                dataSet.Clear();
                if (dataAdapter.Fill(dataSet, "orders") > 0)
                    dataGridView1.DataSource = dataSet.Tables["orders"];
                else
                {
                    MessageBox.Show("검색된 데이터가 없습니다.");
                    dataAdapter = new MySqlDataAdapter("SELECT * FROM orders", conn);
                    dataSet = new DataSet();

                    dataAdapter.Fill(dataSet, "orders");
                    dataGridView1.DataSource = dataSet.Tables["orders"];
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string sql = "UPDATE orders SET bookid=@bookid WHERE orderid=@orderid";
            dataAdapter.UpdateCommand = new MySqlCommand(sql, conn);
            dataAdapter.UpdateCommand.Parameters.AddWithValue("@orderid", textBoxOrderId.Text);
            dataAdapter.UpdateCommand.Parameters.AddWithValue("@custid", textBoxCustId.Text);
            dataAdapter.UpdateCommand.Parameters.AddWithValue("@bookid", textBoxBookId.Text);
            dataAdapter.UpdateCommand.Parameters.AddWithValue("@saleprice", textBoxSalePrice.Text);
            dataAdapter.UpdateCommand.Parameters.AddWithValue("@orderdate", textBoxOrderdate.Text);

            try
            {
                conn.Open();

                if (dataAdapter.UpdateCommand.ExecuteNonQuery() > 0)
                {
                    dataSet.Clear();
                    dataAdapter.Fill(dataSet, "orders");
                    dataGridView1.DataSource = dataSet.Tables["orders"];
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
            string sql = "DELETE FROM orders WHERE orderid=@orderid";
            dataAdapter.DeleteCommand = new MySqlCommand(sql, conn);
            int id = (int)dataGridView1.SelectedRows[0].Cells["orderid"].Value;
            dataAdapter.DeleteCommand.Parameters.AddWithValue("@orderid", id);

            try
            {
                conn.Open();
                if (dataAdapter.DeleteCommand.ExecuteNonQuery() > 0)
                {
                    dataSet.Clear();
                    dataAdapter.Fill(dataSet, "orders");
                    dataGridView1.DataSource = dataSet.Tables["orders"];
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

        private void Customer_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form2 customer = new Form2();
            customer.ShowDialog();
        }

        private void Book_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form1 book = new Form1();
            book.ShowDialog();
        }

        private void btnInsert_Click_1(object sender, EventArgs e)
        {
            string sql = "INSERT INTO orders (custid, bookid, saleprice, orderdate) " +
                "VALUES(@custid, @bookid, @saleprice, @orderdate)";
            dataAdapter.InsertCommand = new MySqlCommand(sql, conn);
            dataAdapter.InsertCommand.Parameters.AddWithValue("@custid", textBoxCustId.Text);
            dataAdapter.InsertCommand.Parameters.AddWithValue("@bookid", textBoxBookId.Text);
            dataAdapter.InsertCommand.Parameters.AddWithValue("@saleprice", textBoxSalePrice.Text);
            dataAdapter.InsertCommand.Parameters.AddWithValue("@orderdate", textBoxOrderdate.Text);

            DataRow newRow = dataSet.Tables["orders"].NewRow();
            newRow["custid"] = textBoxCustId.Text;
            newRow["bookid"] = textBoxBookId.Text;
            newRow["saleprice"] = textBoxSalePrice.Text;
            newRow["orderdate"] = textBoxOrderdate.Text;
            dataSet.Tables["orders"].Rows.Add(newRow);

            try
            {
                if (dataAdapter.Update(dataSet, "orders") > 0)
                {
                    dataSet.Clear();
                    dataAdapter.Fill(dataSet, "orders");
                    dataGridView1.DataSource = dataSet.Tables["orders"];
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

        private void textEmpty_Click(object sender, EventArgs e)
        {
            textBoxOrderId.Text = "";
            textBoxBookId.Text = "";
            textBoxCustId.Text = "";
            textBoxSalePrice.Text = "";
            textBoxOrderdate.Text = "";

            dataAdapter = new MySqlDataAdapter("SELECT * FROM orders", conn);
            dataSet = new DataSet();

            dataAdapter.Fill(dataSet, "orders");
            dataGridView1.DataSource = dataSet.Tables["orders"];
        }
    }
}
