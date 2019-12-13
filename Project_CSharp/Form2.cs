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
            dataAdapter = new MySqlDataAdapter("SELECT * FROM player_info", conn);
            dataSet = new DataSet();

            dataAdapter.Fill(dataSet, "player_info");
            dataGridView1.DataSource = dataSet.Tables["player_info"];
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM player_info WHERE User_id=@user_id";
            dataAdapter.SelectCommand = new MySqlCommand(sql, conn);
            dataAdapter.SelectCommand.Parameters.AddWithValue("@user_id", User_id.Text);

            try
            {
                conn.Open();
                dataSet.Clear();
                if (dataAdapter.Fill(dataSet, "player_info") > 0)
                    dataGridView1.DataSource = dataSet.Tables["player_info"];
                else
                {
                    MessageBox.Show("검색된 데이터가 없습니다.");
                    dataAdapter = new MySqlDataAdapter("SELECT * FROM player_info", conn);
                    dataSet = new DataSet();

                    dataAdapter.Fill(dataSet, "player_info");
                    dataGridView1.DataSource = dataSet.Tables["player_info"];
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
            string sql = "INSERT INTO player_info (User_id, Play_Time, Play_Cham, Win_Rate, Favo_POS) " +
                "VALUES(@user_id, @play_time, @play_cham, @win_rate, @favo_pos)";
            dataAdapter.InsertCommand = new MySqlCommand(sql, conn);
            dataAdapter.InsertCommand.Parameters.AddWithValue("@user_id", User_id.Text);
            dataAdapter.InsertCommand.Parameters.AddWithValue("@play_time", Convert.ToInt32(Play_Time.Text));
            dataAdapter.InsertCommand.Parameters.AddWithValue("@play_cham", Play_Cham.Text);
            dataAdapter.InsertCommand.Parameters.AddWithValue("@win_rate", Convert.ToDouble(Win_Rate.Text));
            dataAdapter.InsertCommand.Parameters.AddWithValue("@favo_pos", Favo_POS.Text);

            DataRow newRow = dataSet.Tables["player_info"].NewRow();
            newRow["User_id"] = User_id.Text;
            newRow["Play_Time"] = Convert.ToInt32(Play_Time.Text);
            newRow["Play_Cham"] = Play_Cham.Text;
            newRow["Win_Rate"] = Convert.ToDouble(Win_Rate.Text);
            newRow["Favo_POS"] = Favo_POS.Text;
            dataSet.Tables["player_info"].Rows.Add(newRow);

            try
            {
                if (dataAdapter.Update(dataSet, "player_info") > 0)
                {
                    dataSet.Clear();
                    dataAdapter.Fill(dataSet, "player_info");
                    dataGridView1.DataSource = dataSet.Tables["player_info"];
                }
                else
                    MessageBox.Show("삽입할 데이터가 없습니다.");
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
            string sql = "UPDATE player_info SET Play_Time=@play_time WHERE User_id=@user_id";
            dataAdapter.UpdateCommand = new MySqlCommand(sql, conn);
            dataAdapter.UpdateCommand.Parameters.AddWithValue("@user_id", User_id.Text);
            dataAdapter.UpdateCommand.Parameters.AddWithValue("@play_time", Convert.ToInt32(Play_Time.Text));
            dataAdapter.UpdateCommand.Parameters.AddWithValue("@play_cham", Play_Cham.Text);
            dataAdapter.UpdateCommand.Parameters.AddWithValue("@win_rate", Convert.ToDouble(Win_Rate.Text));
            dataAdapter.UpdateCommand.Parameters.AddWithValue("@favo_pos", Favo_POS.Text);

            try
            {
                conn.Open();

                if (dataAdapter.UpdateCommand.ExecuteNonQuery() > 0)
                {
                    dataSet.Clear();
                    dataAdapter.Fill(dataSet, "player_info");
                    dataGridView1.DataSource = dataSet.Tables["player_info"];
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
            string sql = "DELETE FROM player_info WHERE User_id=@user_id";
            dataAdapter.DeleteCommand = new MySqlCommand(sql, conn);
            int id = (int)dataGridView1.SelectedRows[0].Cells["User_id"].Value;
            dataAdapter.DeleteCommand.Parameters.AddWithValue("@user_id", id);

            try
            {
                conn.Open();
                if (dataAdapter.DeleteCommand.ExecuteNonQuery() > 0)
                {
                    dataSet.Clear();
                    dataAdapter.Fill(dataSet, "player_info");
                    dataGridView1.DataSource = dataSet.Tables["player_info"];
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
            Form1 basic_info = new Form1();
            basic_info.ShowDialog();
        }

        private void Order_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form3 order = new Form3();
            order.ShowDialog();
        }

        private void textEmpty_Click(object sender, EventArgs e)
        {
            User_id.Text = "";
            Play_Time.Text = "";
            Play_Cham.Text = "";
            Win_Rate.Text = "";

            dataAdapter = new MySqlDataAdapter("SELECT * FROM player_info", conn);
            dataSet = new DataSet();

            dataAdapter.Fill(dataSet, "player_info");
            dataGridView1.DataSource = dataSet.Tables["player_info"];
        }
    }
}