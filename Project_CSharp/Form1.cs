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

            this.pictureBox1.Image = Image.FromFile(@"..\..\image\tenor.gif");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        MySqlConnection conn;
        MySqlDataAdapter dataAdapter;
        DataSet dataSet;
        string apppath = System.IO.Path.GetDirectoryName(System.Windows.Forms.Application.ExecutablePath);

        private void Form1_Load(object sender, EventArgs e)
        {
            conn = new MySqlConnection("server=localhost;port=3306;database=mydb;uid=root;pwd=1234;charset=UTF8");
            dataAdapter = new MySqlDataAdapter("SELECT * FROM basic_info", conn);
            dataSet = new DataSet();

            dataAdapter.Fill(dataSet, "basic_info");
            dataGridView1.DataSource = dataSet.Tables["basic_info"];
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM basic_info WHERE User_id=@user_id";
            dataAdapter.SelectCommand = new MySqlCommand(sql, conn);
            dataAdapter.SelectCommand.Parameters.AddWithValue("@user_id", User_id.Text);

            try
            {
                conn.Open();
                dataSet.Clear();
                if (dataAdapter.Fill(dataSet, "basic_info") > 0)
                    dataGridView1.DataSource = dataSet.Tables["basic_info"];
                else
                {
                    MessageBox.Show("검색된 데이터가 없습니다.");
                    dataAdapter = new MySqlDataAdapter("SELECT * FROM basic_info", conn);
                    dataSet = new DataSet();

                    dataAdapter.Fill(dataSet, "basic_info");
                    dataGridView1.DataSource = dataSet.Tables["basic_info"];
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
            string sql = "INSERT INTO basic_info (User_id, Name, Level, Cash, Grade, Rank) " +
                "VALUES(@user_id, @name, @level, @cash, @grade, @rank)";
            dataAdapter.InsertCommand = new MySqlCommand(sql, conn);
            dataAdapter.InsertCommand.Parameters.AddWithValue("@user_id", User_id.Text);
            dataAdapter.InsertCommand.Parameters.AddWithValue("@name", User_Name.Text);
            dataAdapter.InsertCommand.Parameters.AddWithValue("@level", Convert.ToInt32(Level.Text));
            dataAdapter.InsertCommand.Parameters.AddWithValue("@cash", Convert.ToInt32(Cash.Text));
            dataAdapter.InsertCommand.Parameters.AddWithValue("@grade", Convert.ToInt32(Grade.Text));
            dataAdapter.InsertCommand.Parameters.AddWithValue("@rank", Convert.ToInt32(Rank.Text));

            DataRow newRow = dataSet.Tables["basic_info"].NewRow();
            newRow["User_id"] = User_id.Text;
            newRow["Name"] = User_Name.Text;
            newRow["Level"] = Convert.ToInt32(Level.Text);
            newRow["Cash"] = Convert.ToInt32(Cash.Text);
            newRow["Grade"] = Convert.ToInt32(Grade.Text);
            newRow["Rank"] = Convert.ToInt32(Rank.Text);
            dataSet.Tables["basic_info"].Rows.Add(newRow);

            try
            {
                if (dataAdapter.Update(dataSet, "basic_info") > 0)
                {
                    dataSet.Clear();
                    dataAdapter.Fill(dataSet, "basic_info");
                    dataGridView1.DataSource = dataSet.Tables["basic_info"];
                }
                else
                    MessageBox.Show("삽입할 수 없습니다.");
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
            string sql = "UPDATE basic_info SET Name=@Name WHERE User_id=@user_id";
            dataAdapter.UpdateCommand = new MySqlCommand(sql, conn);
            dataAdapter.UpdateCommand.Parameters.AddWithValue("@user_id", User_id.Text);
            dataAdapter.UpdateCommand.Parameters.AddWithValue("@name", User_Name.Text);
            dataAdapter.UpdateCommand.Parameters.AddWithValue("@level", Convert.ToInt32(Level.Text));
            dataAdapter.UpdateCommand.Parameters.AddWithValue("@cash", Convert.ToInt32(Cash.Text));
            dataAdapter.UpdateCommand.Parameters.AddWithValue("@grade", Convert.ToInt32(Grade.Text));

            try
            {
                conn.Open();

                if (dataAdapter.UpdateCommand.ExecuteNonQuery() > 0)
                {
                    dataSet.Clear();
                    dataAdapter.Fill(dataSet, "basic_info");
                    dataGridView1.DataSource = dataSet.Tables["basic_info"];
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
            string sql = "DELETE FROM basic_info WHERE User_id=@user_id";
            dataAdapter.DeleteCommand = new MySqlCommand(sql, conn);
            string id = (string)dataGridView1.SelectedRows[0].Cells["User_id"].Value;
            dataAdapter.DeleteCommand.Parameters.AddWithValue("@user_id", id);

            try
            {
                conn.Open();
                if (dataAdapter.DeleteCommand.ExecuteNonQuery() > 0)
                {
                    dataSet.Clear();
                    dataAdapter.Fill(dataSet, "basic_info");
                    dataGridView1.DataSource = dataSet.Tables["basic_info"];
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
            User_id.Text = "";
            User_Name.Text = "";
            Level.Text = "";
            Cash.Text = "";

            dataAdapter = new MySqlDataAdapter("SELECT * FROM basic_info", conn);
            dataSet = new DataSet();

            dataAdapter.Fill(dataSet, "basic_info");
            dataGridView1.DataSource = dataSet.Tables["basic_info"];
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}