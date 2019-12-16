using System;

namespace Project_CSharp
{
    partial class Form2
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.panel1 = new System.Windows.Forms.Panel();
            this.Favo_POS = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Win_Rate = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Play_Cham = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Play_Time = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.User_id = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSelect = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Profile = new System.Windows.Forms.Button();
            this.Basic_info = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textEmpty = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.테이블데이터저장ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveClick = new System.Windows.Forms.ToolStripMenuItem();
            this.ExcelClick = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.Favo_POS);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.Win_Rate);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.Play_Cham);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.Play_Time);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.User_id);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(26, 60);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(541, 158);
            this.panel1.TabIndex = 0;
            // 
            // Favo_POS
            // 
            this.Favo_POS.Location = new System.Drawing.Point(108, 121);
            this.Favo_POS.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Favo_POS.Name = "Favo_POS";
            this.Favo_POS.Size = new System.Drawing.Size(378, 21);
            this.Favo_POS.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(39, 124);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "Favo_POS";
            // 
            // Win_Rate
            // 
            this.Win_Rate.Location = new System.Drawing.Point(108, 96);
            this.Win_Rate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Win_Rate.Name = "Win_Rate";
            this.Win_Rate.Size = new System.Drawing.Size(378, 21);
            this.Win_Rate.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "Play_Cham";
            // 
            // Play_Cham
            // 
            this.Play_Cham.Location = new System.Drawing.Point(108, 71);
            this.Play_Cham.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Play_Cham.Name = "Play_Cham";
            this.Play_Cham.Size = new System.Drawing.Size(378, 21);
            this.Play_Cham.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "Win_Rate";
            // 
            // Play_Time
            // 
            this.Play_Time.Location = new System.Drawing.Point(108, 44);
            this.Play_Time.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Play_Time.Name = "Play_Time";
            this.Play_Time.Size = new System.Drawing.Size(378, 21);
            this.Play_Time.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Play_Time";
            // 
            // User_id
            // 
            this.User_id.Location = new System.Drawing.Point(108, 19);
            this.User_id.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.User_id.Name = "User_id";
            this.User_id.Size = new System.Drawing.Size(378, 21);
            this.User_id.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(55, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "User_id";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label7.Location = new System.Drawing.Point(139, 35);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(358, 24);
            this.label7.TabIndex = 7;
            this.label7.Text = "UNICEF 관리 시스템 - 플레이어 공개정보 목록";
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(8, 19);
            this.btnSelect.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(91, 47);
            this.btnSelect.TabIndex = 1;
            this.btnSelect.Text = "선택";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(117, 19);
            this.btnInsert.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(91, 47);
            this.btnInsert.TabIndex = 2;
            this.btnInsert.Text = "삽입";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(227, 19);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(91, 47);
            this.btnUpdate.TabIndex = 3;
            this.btnUpdate.Text = "수정";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(336, 19);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(91, 47);
            this.btnDelete.TabIndex = 4;
            this.btnDelete.Text = "삭제";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(26, 315);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(814, 374);
            this.dataGridView1.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Profile);
            this.groupBox1.Controls.Add(this.Basic_info);
            this.groupBox1.Location = new System.Drawing.Point(577, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(263, 63);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "다른 목록 확인";
            // 
            // Profile
            // 
            this.Profile.Location = new System.Drawing.Point(139, 19);
            this.Profile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Profile.Name = "Profile";
            this.Profile.Size = new System.Drawing.Size(118, 37);
            this.Profile.TabIndex = 11;
            this.Profile.Text = "프로필 내역";
            this.Profile.UseVisualStyleBackColor = true;
            this.Profile.Click += new System.EventHandler(this.Profile_Click);
            // 
            // Basic_info
            // 
            this.Basic_info.Location = new System.Drawing.Point(6, 19);
            this.Basic_info.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Basic_info.Name = "Basic_info";
            this.Basic_info.Size = new System.Drawing.Size(118, 37);
            this.Basic_info.TabIndex = 10;
            this.Basic_info.Text = "기본 정보 목록";
            this.Basic_info.UseVisualStyleBackColor = true;
            this.Basic_info.Click += new System.EventHandler(this.Basic_info_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.textEmpty);
            this.groupBox2.Controls.Add(this.btnUpdate);
            this.groupBox2.Controls.Add(this.btnSelect);
            this.groupBox2.Controls.Add(this.btnInsert);
            this.groupBox2.Controls.Add(this.btnDelete);
            this.groupBox2.Location = new System.Drawing.Point(26, 223);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(541, 71);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "데이터 조작 메뉴";
            // 
            // textEmpty
            // 
            this.textEmpty.Location = new System.Drawing.Point(444, 19);
            this.textEmpty.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textEmpty.Name = "textEmpty";
            this.textEmpty.Size = new System.Drawing.Size(91, 47);
            this.textEmpty.TabIndex = 5;
            this.textEmpty.Text = "검색 초기화";
            this.textEmpty.UseVisualStyleBackColor = true;
            this.textEmpty.Click += new System.EventHandler(this.textEmpty_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(577, 122);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(263, 172);
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.테이블데이터저장ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(867, 24);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 테이블데이터저장ToolStripMenuItem
            // 
            this.테이블데이터저장ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SaveClick,
            this.ExcelClick});
            this.테이블데이터저장ToolStripMenuItem.Name = "테이블데이터저장ToolStripMenuItem";
            this.테이블데이터저장ToolStripMenuItem.Size = new System.Drawing.Size(123, 20);
            this.테이블데이터저장ToolStripMenuItem.Text = "테이블 데이터 저장";
            // 
            // SaveClick
            // 
            this.SaveClick.Name = "SaveClick";
            this.SaveClick.Size = new System.Drawing.Size(180, 22);
            this.SaveClick.Text = "txt로 저장";
            this.SaveClick.Click += new System.EventHandler(this.SaveClick_Click);
            // 
            // ExcelClick
            // 
            this.ExcelClick.Name = "ExcelClick";
            this.ExcelClick.Size = new System.Drawing.Size(180, 22);
            this.ExcelClick.Text = "Excel로 저장";
            this.ExcelClick.Click += new System.EventHandler(this.ExcelClick_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(867, 709);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UNICEF - 프로필 목록";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox Win_Rate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Play_Cham;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Play_Time;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox User_id;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Profile;
        private System.Windows.Forms.Button Basic_info;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button textEmpty;
        private System.Windows.Forms.TextBox Favo_POS;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 테이블데이터저장ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SaveClick;
        private System.Windows.Forms.ToolStripMenuItem ExcelClick;
    }
}