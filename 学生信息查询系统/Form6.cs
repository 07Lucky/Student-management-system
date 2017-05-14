using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace 学生信息查询系统
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }
        private SqlDataAdapter da = null;
        private DataSet ds = new DataSet();
        private SqlConnection conn = null;
        private const string DRIVER = @"Data Source=DESKTOP-SFFEEKC\SQLEXPRESS;Initial Catalog=学生信息表;Integrated Security=SSPI";
        private void button5_Click(object sender, EventArgs e)
        {
          
        }

        private void button6_Click(object sender, EventArgs e)
        {
           
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            this.dataGridView1.Visible = false;
            this.groupBox1.Visible = false;
            this.groupBox2.Visible = false;
;
        }

        private void 修改密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
             Form5 a = new Form5();
                a.Show();
        }

        private void 账号安全ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 a = new Form1();
            a.Show();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
             Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void 更新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void 删除选定行ToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void 用户管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.groupBox2.Visible = true; 
 this.dataGridView1.Visible = true;
            conn = new SqlConnection(DRIVER);
            da = new SqlDataAdapter("SELECT * FROM Table_1 ", conn);

            da.Fill(ds, "table");
            this.dataGridView1.DataSource = ds.Tables["table"].DefaultView;
            this.dataGridView1.Columns[0].Visible = false;
        }

        private void 更新ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
        }

        private void 考试安排ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.groupBox1.Visible = true;
              this.dataGridView1.Visible = true;
            conn = new SqlConnection(DRIVER);
            da = new SqlDataAdapter("SELECT * FROM Table_4 ", conn);

            da.Fill(ds, "table1");
            this.dataGridView1.DataSource = ds.Tables["table1"].DefaultView;
            this.dataGridView1.Columns[0].Visible = false;
        }

        private void 删除选定行ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void 查看ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }

        private void 查看ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
          
        }

        private void 注销ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            登录界面 a = new 登录界面();
            a.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
SqlCommandBuilder scb = new SqlCommandBuilder(da);

            //更新数据
            try
            {
                //这里是关键
                da.Update(ds, "table1");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);

            }    
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
 conn = new SqlConnection(DRIVER);
            conn.Open();
            if (dataGridView1.SelectedRows.Count != 1) return;
            if (dataGridView1.CurrentRow == null) return;
            //string bd = dataGridView1.CurrentRow.Cells[2].Value.ToString();  

            DataRowView row = dataGridView1.CurrentRow.DataBoundItem as DataRowView;
            if (row["id"] == null) return;//可以进行快速监视  
            string bd = Convert.ToString(row["id"]);
            string selectsql = "delete from Table_1 where id = " + bd + "";
            SqlCommand cmd = new SqlCommand(selectsql, conn);
            cmd.CommandType = CommandType.Text;
            //SqlDataReader sdr;  
            //sdr = cmd.ExecuteReader();  
            int ret = cmd.ExecuteNonQuery();//受影响的行数（总数）  
            if (ret == -1)
            {
                MessageBox.Show("删除失败！");
                return;
            }
            else
            {
                MessageBox.Show("删除成功！");
            }
            conn.Close();  

        }

        private void button3_Click(object sender, EventArgs e)
        {
 SqlCommandBuilder scb = new SqlCommandBuilder(da);

            //更新数据
            try
            {
                //这里是关键
                da.Update(ds,"table");
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);

            }    
        }

        private void button4_Click(object sender, EventArgs e)
        {
  conn = new SqlConnection(DRIVER);
            conn.Open();
            if (dataGridView1.SelectedRows.Count != 1) return;
            if (dataGridView1.CurrentRow == null) return;
            //string bd = dataGridView1.CurrentRow.Cells[2].Value.ToString();  

            DataRowView row = dataGridView1.CurrentRow.DataBoundItem as DataRowView;
            if (row["id"] == null) return;//可以进行快速监视  
            string bd = Convert.ToString(row["id"]);
            string selectsql = "delete from Table_1 where id = " + bd + "";
            SqlCommand cmd = new SqlCommand(selectsql, conn);
            cmd.CommandType = CommandType.Text;
            //SqlDataReader sdr;  
            //sdr = cmd.ExecuteReader();  
            int ret = cmd.ExecuteNonQuery();//受影响的行数（总数）  
            if (ret == -1)
            {
                MessageBox.Show("删除失败！");
                return;
            }
            else
            {
                MessageBox.Show("删除成功！");
            }
            conn.Close();  
        }
    }
}
