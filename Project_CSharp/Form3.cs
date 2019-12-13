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
            dataAdapter = new MySqlDataAdapter("SELECT * FROM profile", conn);
            dataSet = new DataSet();

            dataAdapter.Fill(dataSet, "profile");
            dataGridView1.DataSource = dataSet.Tables["profile"];
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM profile WHERE User_id=@user_id";
            dataAdapter.SelectCommand = new MySqlCommand(sql, conn);
            dataAdapter.SelectCommand.Parameters.AddWithValue("@user_id", User_id.Text);

            try
            {
                conn.Open();
                dataSet.Clear();
                if (dataAdapter.Fill(dataSet, "profile") > 0)
                    dataGridView1.DataSource = dataSet.Tables["profile"];
                else
                {
                    MessageBox.Show("검색된 데이터가 없습니다.");
                    dataAdapter = new MySqlDataAdapter("SELECT * FROM profile", conn);
                    dataSet = new DataSet();

                    dataAdapter.Fill(dataSet, "profile");
                    dataGridView1.DataSource = dataSet.Tables["profile"];
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
            string sql = "UPDATE profile SET Real_Name=@real_name WHERE User_id=@user_id";
            dataAdapter.UpdateCommand = new MySqlCommand(sql, conn);
            dataAdapter.UpdateCommand.Parameters.AddWithValue("@user_id", User_id.Text);
            dataAdapter.UpdateCommand.Parameters.AddWithValue("@real_name", Real_Name.Text);
            dataAdapter.UpdateCommand.Parameters.AddWithValue("@phone_num", Phone_num.Text);
            dataAdapter.UpdateCommand.Parameters.AddWithValue("@email", Email.Text);
            dataAdapter.UpdateCommand.Parameters.AddWithValue("@age", Convert.ToInt32(Age.Text));

            try
            {
                conn.Open();

                if (dataAdapter.UpdateCommand.ExecuteNonQuery() > 0)
                {
                    dataSet.Clear();
                    dataAdapter.Fill(dataSet, "profile");
                    dataGridView1.DataSource = dataSet.Tables["profile"];
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
            string sql = "DELETE FROM profile WHERE User_id=@userid";
            dataAdapter.DeleteCommand = new MySqlCommand(sql, conn);
            int id = (int)dataGridView1.SelectedRows[0].Cells["User_id"].Value;
            dataAdapter.DeleteCommand.Parameters.AddWithValue("@userid", id);

            try
            {
                conn.Open();
                if (dataAdapter.DeleteCommand.ExecuteNonQuery() > 0)
                {
                    dataSet.Clear();
                    dataAdapter.Fill(dataSet, "profile");
                    dataGridView1.DataSource = dataSet.Tables["profile"];
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

        private void player_info_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form2 player_info = new Form2();
            player_info.ShowDialog();
        }

        private void basic_info_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form1 basic_info = new Form1();
            basic_info.ShowDialog();
        }

        private void btnInsert_Click_1(object sender, EventArgs e)
        {
            string sql = "INSERT INTO profile (User_id, Real_Name, Phone_num, E-mail, Age) " +
                "VALUES(@user_id, @real_name, @phone_num, @email, @age)";
            dataAdapter.InsertCommand = new MySqlCommand(sql, conn);
            dataAdapter.InsertCommand.Parameters.AddWithValue("@user_id", User_id.Text);
            dataAdapter.InsertCommand.Parameters.AddWithValue("@real_name", Real_Name.Text);
            dataAdapter.InsertCommand.Parameters.AddWithValue("@phone_num", Phone_num.Text);
            dataAdapter.InsertCommand.Parameters.AddWithValue("@email", Email.Text);
            dataAdapter.InsertCommand.Parameters.AddWithValue("@age", Convert.ToInt32(Age.Text));

            DataRow newRow = dataSet.Tables["profile"].NewRow();
            newRow["User_id"] = User_id.Text;
            newRow["Real_Name"] = Real_Name.Text;
            newRow["Phone_num"] = Phone_num.Text;
            newRow["E-mail"] = Email.Text;
            newRow["Age"] = Convert.ToInt32(Age.Text);
            dataSet.Tables["orders"].Rows.Add(newRow);

            try
            {
                if (dataAdapter.Update(dataSet, "profile") > 0)
                {
                    dataSet.Clear();
                    dataAdapter.Fill(dataSet, "profile");
                    dataGridView1.DataSource = dataSet.Tables["profile"];
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
            Phone_num.Text = "";
            Real_Name.Text = "";
            Email.Text = "";
            Age.Text = "";

            dataAdapter = new MySqlDataAdapter("SELECT * FROM profile", conn);
            dataSet = new DataSet();

            dataAdapter.Fill(dataSet, "profile");
            dataGridView1.DataSource = dataSet.Tables["profile"];
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
