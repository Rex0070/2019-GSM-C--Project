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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            this.pictureBox1.Image = Image.FromFile(@"..\..\image\Yee.gif");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        MySqlConnection conn;
        MySqlDataAdapter dataAdapter;
        DataSet dataSet;
        private object filePath;

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
            string sql = "UPDATE profile SET Real_Name=@real_name, Phone_num=@phone_num, Email=@email, Age=@age WHERE User_id=@user_id";
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
            string sql = "DELETE FROM profile WHERE User_id=@user_id";
            dataAdapter.DeleteCommand = new MySqlCommand(sql, conn);
            string id = (string)dataGridView1.SelectedRows[0].Cells["User_id"].Value;
            dataAdapter.DeleteCommand.Parameters.AddWithValue("@user_id", id);

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

        private void textEmpty_Click(object sender, EventArgs e)
        {
            User_id.Text = "";
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

        private void SaveClick_Click(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount == 0)
            {
                MessageBox.Show("저장할 데이터가 없습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            saveFileDialog1.Filter = "텍스트 파일(*.txt) | *.txt";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                SaveTextFile(saveFileDialog1.FileName);
        }

        private void ExcelClick_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "엑셀 파일(*.xlsx) | *.xlsx";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                SaveExcelFile(saveFileDialog1.FileName);
            }
        }

        private void SaveTextFile(string filePath)
        {
            using (StreamWriter sw = new StreamWriter(saveFileDialog1.FileName))
            {
                foreach (DataColumn col in dataSet.Tables["profile"].Columns)
                {
                    sw.Write($"{col.ColumnName}\t");
                }
                sw.WriteLine();

                foreach (DataRow row in dataSet.Tables["profile"].Rows)
                {
                    string rowString = "";
                    foreach (var item in row.ItemArray)
                    {
                        rowString += $"{item.ToString()}\t";
                    }
                    sw.WriteLine(rowString);
                }
            }
        }

        private void SaveExcelFile(string filePath)
        {
            Microsoft.Office.Interop.Excel.Application eApp;
            Microsoft.Office.Interop.Excel.Workbook eWorkbook;
            Microsoft.Office.Interop.Excel.Worksheet eWorkSheet;
            eApp = new Microsoft.Office.Interop.Excel.Application();
            eWorkbook = eApp.Workbooks.Add();
            eWorkSheet = eWorkbook.Sheets[1];

            string[,] dataArr;
            int colCount = dataSet.Tables["profile"].Columns.Count + 1;
            int rowCount = dataSet.Tables["profile"].Rows.Count + 1;
            dataArr = new string[rowCount, colCount];

            for (int i = 0; i < dataSet.Tables["profile"].Columns.Count; i++)
            {
                dataArr[0, 1] = dataSet.Tables["profile"].Columns[i].ColumnName;
            }

            for (int i = 0; i < dataSet.Tables["profile"].Rows.Count; i++)
            {
                for (int j = 0; j < dataSet.Tables["profile"].Columns.Count; j++)
                {
                    dataArr[i + 1, j] = dataSet.Tables["profile"].Rows[0].ItemArray[j].ToString();
                }
            }

            string endCell = $"E{rowCount}";
            eWorkSheet.get_Range("A1:" + endCell).Value = dataArr;

            eWorkbook.SaveAs(filePath, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing,
                false, false, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlShared, false, false, Type.Missing, Type.Missing);
            eWorkbook.Close(false, Type.Missing, Type.Missing);
            eApp.Quit();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            string sql = "INSERT INTO profile (User_id, Real_Name, Phone_num, Email, Age) " +
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
            newRow["Email"] = Email.Text;
            newRow["Age"] = Convert.ToInt32(Age.Text);
            dataSet.Tables["profile"].Rows.Add(newRow);

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
    }
}
