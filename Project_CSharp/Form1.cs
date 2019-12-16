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
using Excel = Microsoft.Office.Interop.Excel;

namespace Project_CSharp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.pictureBox1.Image = Image.FromFile(@"..\..\image\deepdarkfantasy.gif");
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        MySqlConnection conn;
        MySqlDataAdapter dataAdapter;
        DataSet dataSet;
        private object filePath;

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
            string sql = "INSERT INTO basic_info (User_id, Name, Level, Cash, Grade) " +
                "VALUES(@user_id, @name, @level, @cash, @grade)";
            dataAdapter.InsertCommand = new MySqlCommand(sql, conn);
            dataAdapter.InsertCommand.Parameters.AddWithValue("@user_id", User_id.Text);
            dataAdapter.InsertCommand.Parameters.AddWithValue("@name", User_Name.Text);
            dataAdapter.InsertCommand.Parameters.AddWithValue("@level", Convert.ToInt32(Level.Text));
            dataAdapter.InsertCommand.Parameters.AddWithValue("@cash", Convert.ToInt32(Cash.Text));
            dataAdapter.InsertCommand.Parameters.AddWithValue("@grade", Convert.ToInt32(Grade.Text));

            DataRow newRow = dataSet.Tables["basic_info"].NewRow();
            newRow["User_id"] = User_id.Text;
            newRow["Name"] = User_Name.Text;
            newRow["Level"] = Convert.ToInt32(Level.Text);
            newRow["Cash"] = Convert.ToInt32(Cash.Text);
            newRow["Grade"] = Convert.ToInt32(Grade.Text);
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

        private void Profiles_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form3 profile = new Form3();
            profile.ShowDialog();
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

        private void Player_info_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            Form2 player_info = new Form2();
            player_info.ShowDialog();
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

        private void SaveTextFile(string fileName)
        {
            using (StreamWriter sw = new StreamWriter(saveFileDialog1.FileName))
            {
                foreach (DataColumn col in dataSet.Tables["basic_info"].Columns)
                {
                    sw.Write($"{col.ColumnName}\t");
                }
                sw.WriteLine();

                foreach (DataRow row in dataSet.Tables["basic_info"].Rows)
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

        private void SaveExcelFile(string fileName)
        {
            // 1. 엑셀 사용에 필요한 객체 준비
            Excel.Application eApp;     // 엑셀 프로그램
            Excel.Workbook eWorkbook;   // 엑셀 워크북(시트 여러개 포함)
            Excel.Worksheet eWorkSheet; // 엑셀 워크시트

            eApp = new Excel.Application();
            eWorkbook = eApp.Workbooks.Add();       // 엑셀 프로그램 객체에 포함시킴.
            eWorkSheet = eWorkbook.Sheets[1];       // 엑셀 워크시트는 index가 1부터 시작됨.

            // 2. 엑셀에 저장할 데이터를 2차원 스트링 배열로 준비
            int colCount = dataSet.Tables["basic_info"].Columns.Count;
            int rowCount = dataSet.Tables["basic_info"].Rows.Count + 1;
            string[,] dataArr = new string[rowCount, colCount];     // 검색 결과를 저장할 배열

            // 2-1 Column 이름 저장
            for (int i = 0; i < dataSet.Tables["basic_info"].Columns.Count; i++)
            {
                dataArr[0, i] = dataSet.Tables["basic_info"].Columns[i].ColumnName;   // 찻 헹에 컬럼이름들 저장
            }

            // 2-2 Row 데이터 저장
            for (int i = 0; i < dataSet.Tables["basic_info"].Rows.Count; i++)
            {
                for (int j = 0; j < dataSet.Tables["basic_info"].Columns.Count; j++)
                {
                    dataArr[i + 1, j] = dataSet.Tables["basic_info"].Rows[i].ItemArray[j].ToString();
                }
            }

            // 3. 준비된 스트링 배열을 엑셀파일로 저장
            string endCell = Convert.ToChar(65 + dataSet.Tables["basic_info"].Columns.Count - 1).ToString() + rowCount.ToString();
            eWorkSheet.get_Range($"A1:{endCell}").Value = dataArr;    // 배열의 데이터를 엑셀 시트에 기록

            eWorkbook.SaveAs(filePath, Excel.XlFileFormat.xlWorkbookDefault, Type.Missing, Type.Missing,
                false, false, Excel.XlSaveAsAccessMode.xlShared, false, false, Type.Missing, Type.Missing,
                Type.Missing);
            eWorkbook.Close(false, Type.Missing, Type.Missing);
            eApp.Quit();
        }

        private void ExcelClick_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "엑셀 파일(*.xlsx) | *.xlsx";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                SaveExcelFile(saveFileDialog1.FileName);
            }
        }
    }
}