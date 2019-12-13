using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        MySqlDataAdapter dataAdapter2;
        DataSet dataSet;

        public Form4()
        {
            InitializeComponent();
            this.pictureBox1.Image = Image.FromFile(@"..\..\image\tenor.gif");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            this.pictureBox2.Image = Image.FromFile(@"..\..\image\billy.gif");
            pictureBox2.SizeMode = PictureBoxSizeMode.StretchImage;
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
                MessageBox.Show("DB를 연결해주세요!", "UNICEF", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void 끝내기ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void 정보ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("이 시스템은 보안관리자와 시스템관리가 깨어있습니다.\n\n- 안★전★보★장 -", "★System Warning★", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void DBStart_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Closed)
            {
                string connectionString = "server=localhost;port=3306;username=root;database=mydb;password=1234;charset=UTF8"; ;
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

                dataAdapter = new MySqlDataAdapter("SELECT * FROM profile", conn);
                dataAdapter2 = new MySqlDataAdapter("SELECT * FROM cheat_has_player_info", conn);
                dataSet = new DataSet();

                dataAdapter.Fill(dataSet, "profile");
                dataAdapter2.Fill(dataSet, "cheat_has_player_info");
                dataGridView1.DataSource = dataSet.Tables["profile"];
                dataGridView2.DataSource = dataSet.Tables["cheat_has_player_info"];
            }
            catch (Exception ex)
            {
                MessageBox.Show($"{ex.Message}", "DB Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void 회원목록새로고침ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Open) {
                dataAdapter = new MySqlDataAdapter("SELECT * FROM profile", conn);
                dataSet = new DataSet();

                dataAdapter.Fill(dataSet, "profile");
                dataGridView1.DataSource = dataSet.Tables["profile"];
            }
            else
            {
                MessageBox.Show("DB 연결을 해주세요!", "UNICEF", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void 부정행위자새로고침ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (conn.State == ConnectionState.Open)
            {
                dataAdapter2 = new MySqlDataAdapter("SELECT * FROM cheat_has_player_info", conn);
                dataSet = new DataSet();

                dataAdapter2.Fill(dataSet, "cheat_has_player_info");
                dataGridView2.DataSource = dataSet.Tables["cheat_has_player_info"];
            }
            else
            {
                MessageBox.Show("DB 연결을 해주세요!", "UNICEF", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
