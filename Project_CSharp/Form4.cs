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
    public partial class Form4 : Form
    {
        MySqlConnection conn;
        MySqlDataAdapter dataAdapter;
        DataSet dataSet;

        public Form4()
        {
            InitializeComponent();
        }

        private void ShowDBConnectionState()
        {
            if (conn.State == ConnectionState.Open)
            {
                DatabaseConnection_State.Text = "Connected";
                DatabaseConnection_State.ForeColor = Color.Green;
            }
            else
            {
                DatabaseConnection_State.Text = "Not Connected";
                DatabaseConnection_State.ForeColor = Color.Red;
            }
        }

        private void 데이터베이스관리ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                Form1 book = new Form1();
                book.Show();
            }
            else
            {
                MessageBox.Show("DB를 연결해주세요!", "GSM BOOK", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void 끝내기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 정보ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("이 시스템은 도서 구매 데이터베이스의 관리를 위한 시스템입니다.\n\n- Made by Chrina -", "System Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void DBStart_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Closed)
            {
                string connectionString = "server=localhost;port=3306;username=root;password=1234";
                conn = new MySqlConnection(connectionString);

                try
                {
                    conn.Open();
                    ShowDBConnectionState();

                }
                catch (Exception ex)
                {
                    DatabaseConnection_State.Text = $"{ex.Message}";
                }
            }
        }

        private void DBShutdown_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
                ShowDBConnectionState();
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            string connectionString = "server=localhost;port=3306;username=root;database=mydb;password=1234;charset=UTF8";
            conn = new MySqlConnection(connectionString);

            try
            {
                conn.Open();
                ShowDBConnectionState();

                dataAdapter = new MySqlDataAdapter("SELECT * FROM customer", conn);
                dataSet = new DataSet();

                dataAdapter.Fill(dataSet, "customer");
                dataGridView1.DataSource = dataSet.Tables["customer"];
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void 가입자목록새로고침ToolStripMenuItem_Click(object sender, EventArgs e)
        {
                dataAdapter = new MySqlDataAdapter("SELECT * FROM customer", conn);
                dataSet = new DataSet();

                dataAdapter.Fill(dataSet, "customer");
                dataGridView1.DataSource = dataSet.Tables["customer"];
        }
    }
}
