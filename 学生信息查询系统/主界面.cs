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
    public partial class 主界面 : Form
    {
        public 主界面()
        {
            InitializeComponent();
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
        }
        private void 主界面_Load(object sender, EventArgs e)
        {
            this.dataGridView1.Visible = false;
            label6.Text = 登录界面.txt;
            string connString = @"Data Source=DESKTOP-SFFEEKC\SQLEXPRESS;Initial Catalog=学生信息表;Integrated Security=SSPI";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            string strQuery = "SELECT 姓名,学院,专业,班级  FROM Table_1 where 学号='" + 登录界面.txt + "'";
            SqlCommand command = new SqlCommand(strQuery, conn);
            SqlDataAdapter da = new SqlDataAdapter(strQuery, conn);
            DataTable ds = new DataTable();
            da.Fill(ds);
            label7.Text = ds.Rows[0][0].ToString();
            label8.Text = ds.Rows[0][1].ToString();
            label9.Text = ds.Rows[0][2].ToString();
            label10.Text = ds.Rows[0][3].ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form5 a = new Form5();
            a.Show();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void 考试安排ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string connString = @"Data Source=DESKTOP-SFFEEKC\SQLEXPRESS;Initial Catalog=学生信息表;Integrated Security=SSPI";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            string strQuery = "SELECT *  FROM Table_3 where 考试对象='" + label10.Text + "'";
            SqlCommand command = new SqlCommand(strQuery, conn);
            if (command.ExecuteScalar() == null)
            { MessageBox.Show("目前没有考试安排"); }
            else
            {
                this.dataGridView1.Visible = true;
                SqlDataAdapter da = new SqlDataAdapter(strQuery, conn);
                DataSet ds = new DataSet();
                da.Fill(ds, "table");
                dataGridView1.DataSource = ds.Tables["table"].DefaultView;
                this.dataGridView1.Columns[0].Visible = false;
                conn.Close();
            }
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

        private void 课表信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void 考试成绩ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            string connString = @"Data Source=DESKTOP-SFFEEKC\SQLEXPRESS;Initial Catalog=学生信息表;Integrated Security=SSPI";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            string strQuery = "SELECT *  FROM Table_4 where 学号='" + label6.Text + "'";
            SqlCommand command = new SqlCommand(strQuery, conn);
            if (command.ExecuteScalar() == null)
            { MessageBox.Show("成绩还没有出来，请耐心等待！"); }
            else
            {
                this.dataGridView1.Visible = true;
                SqlDataAdapter da = new SqlDataAdapter(strQuery, conn);
                DataSet ds = new DataSet();
                da.Fill(ds, "table");
                dataGridView1.DataSource = ds.Tables["table"].DefaultView;
                this.dataGridView1.Columns[0].Visible = false;
                conn.Close();
            }
        }

        private void 注销ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           登录界面 a = new 登录界面();
            a.Show();
            this.Close();
        }
    }
}
    


