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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        MySqlConnection conn;
        MySqlDataAdapter dataAdapter;
        DataSet dataSet;

        private void Form1_Load(object sender, EventArgs e)
        {
            conn = new MySqlConnection("server=localhost;port=3306;database=mydb;uid=root;pwd=1234;charset=UTF8");
            dataAdapter = new MySqlDataAdapter("SELECT * FROM book", conn);
            dataSet = new DataSet();

            dataAdapter.Fill(dataSet, "book");
            dataGridView1.DataSource = dataSet.Tables["book"];
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM book WHERE publisher=@publisher";
            dataAdapter.SelectCommand = new MySqlCommand(sql, conn);
            dataAdapter.SelectCommand.Parameters.AddWithValue("@publisher", textBoxPublisher.Text);

            try
            {
                conn.Open();
                dataSet.Clear();
                if (dataAdapter.Fill(dataSet, "book") > 0)
                    dataGridView1.DataSource = dataSet.Tables["book"];
                else
                {
                    MessageBox.Show("검색된 데이터가 없습니다.");
                    dataAdapter = new MySqlDataAdapter("SELECT * FROM book", conn);
                    dataSet = new DataSet();

                    dataAdapter.Fill(dataSet, "book");
                    dataGridView1.DataSource = dataSet.Tables["book"];
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
            string sql = "INSERT INTO book (bookname, publisher, price) " +
                "VALUES(@bookname, @publisher, @price)";
            dataAdapter.InsertCommand = new MySqlCommand(sql, conn);
            dataAdapter.InsertCommand.Parameters.AddWithValue("@bookname", textBoxBookName.Text);
            dataAdapter.InsertCommand.Parameters.AddWithValue("@publisher", textBoxPublisher.Text);
            dataAdapter.InsertCommand.Parameters.AddWithValue("@price", textBoxPrice.Text);

            DataRow newRow = dataSet.Tables["book"].NewRow();
            newRow["bookname"] = textBoxBookName.Text;
            newRow["publisher"] = textBoxPublisher.Text;
            newRow["price"] = textBoxPrice.Text;
            dataSet.Tables["book"].Rows.Add(newRow);

            try
            {
                if (dataAdapter.Update(dataSet, "book") > 0)
                {
                    dataSet.Clear();
                    dataAdapter.Fill(dataSet, "book");
                    dataGridView1.DataSource = dataSet.Tables["book"];
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
            string sql = "UPDATE book SET bookname=@bookname WHERE publisher=@publisher";
            dataAdapter.UpdateCommand = new MySqlCommand(sql, conn);
            dataAdapter.UpdateCommand.Parameters.AddWithValue("@bookid", textBoxBookId.Text);
            dataAdapter.UpdateCommand.Parameters.AddWithValue("@bookname", textBoxBookName.Text);
            dataAdapter.UpdateCommand.Parameters.AddWithValue("@publisher", textBoxPublisher.Text);
            dataAdapter.UpdateCommand.Parameters.AddWithValue("@price", textBoxPublisher.Text);

            try
            {
                conn.Open();

                if (dataAdapter.UpdateCommand.ExecuteNonQuery() > 0)
                {
                    dataSet.Clear();
                    dataAdapter.Fill(dataSet, "book");
                    dataGridView1.DataSource = dataSet.Tables["book"];
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
            string sql = "DELETE FROM book WHERE bookid=@bookid";
            dataAdapter.DeleteCommand = new MySqlCommand(sql, conn);
            int id = (int)dataGridView1.SelectedRows[0].Cells["bookid"].Value;
            dataAdapter.DeleteCommand.Parameters.AddWithValue("@bookid", id);

            try
            {
                conn.Open();
                if (dataAdapter.DeleteCommand.ExecuteNonQuery() > 0)
                {
                    dataSet.Clear();
                    dataAdapter.Fill(dataSet, "book");
                    dataGridView1.DataSource = dataSet.Tables["book"];
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

        private void Order_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form3 order = new Form3();
            order.ShowDialog();
        }

        private void TextEmpty_Click(object sender, EventArgs e)
        {
            textBoxBookId.Text = "";
            textBoxBookName.Text = "";
            textBoxPublisher.Text = "";
            textBoxPrice.Text = "";

            dataAdapter = new MySqlDataAdapter("SELECT * FROM book", conn);
            dataSet = new DataSet();

            dataAdapter.Fill(dataSet, "book");
            dataGridView1.DataSource = dataSet.Tables["book"];
        }
    }
}