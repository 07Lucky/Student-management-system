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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            
        }
        private SqlDataAdapter da = null;
        private DataSet ds = new DataSet();
        private SqlConnection conn = null;
        private const string DRIVER = @"Data Source=DESKTOP-SFFEEKC\SQLEXPRESS;Initial Catalog=学生信息表;Integrated Security=SSPI";
        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.dataGridView1.Visible = false; 
            this.groupBox3.Visible = false;
            string connString = @"Data Source=DESKTOP-SFFEEKC\SQLEXPRESS;Initial Catalog=学生信息表;Integrated Security=SSPI";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            string strQuery = "SELECT 姓名  FROM Table_1 where 学号='" + 登录界面.txt + "'";
            SqlCommand command = new SqlCommand(strQuery, conn);
            SqlDataAdapter da = new SqlDataAdapter(strQuery, conn);
            DataTable ds = new DataTable();
            da.Fill(ds);
            label4.Text = ds.Rows[0][0].ToString();
           
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Visible = true;
            string connString = @"Data Source=DESKTOP-SFFEEKC\SQLEXPRESS;Initial Catalog=学生信息表;Integrated Security=SSPI";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            string strQuery = "SELECT * FROM Table_4 where 学号='" + textBox1.Text + "'";
            SqlCommand command = new SqlCommand(strQuery, conn);
            if (command.ExecuteScalar() == null)
            { MessageBox.Show("该用户不存在"); }
            else
            {
                SqlDataAdapter da = new SqlDataAdapter(strQuery, conn);
                DataSet ds = new DataSet();
                da.Fill(ds, "table1");
                dataGridView1.DataSource = ds.Tables["table1"].DefaultView;
                this.dataGridView1.Columns[0].Visible = false;
                conn.Close();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
                conn = new SqlConnection(DRIVER);

                da = new SqlDataAdapter("SELECT * FROM Table_4 where 班级='" + comboBox1.Text + "'", conn);
           
                da.Fill(ds, "table");
                this.dataGridView1.DataSource = ds.Tables["table"].DefaultView;
                this.dataGridView1.Columns[0].Visible = false;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
           
        }

        private void label4_Click(object sender, EventArgs e)
        { 
           
        }

        private void button6_Click(object sender, EventArgs e)
        {
          
        }

        private void button12_Click(object sender, EventArgs e)
        {   
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
    
        }

        private void button11_Click(object sender, EventArgs e)
        {
            SqlCommandBuilder scb = new SqlCommandBuilder(da);

            //更新数据
            try
            {
                //这里是关键
                da.Update(ds); 
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                
            }    
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void 考试安排ToolStripMenuItem_Click(object sender, EventArgs e)
        {
         string connString = @"Data Source=DESKTOP-SFFEEKC\SQLEXPRESS;Initial Catalog=学生信息表;Integrated Security=SSPI";
                    SqlConnection conn = new SqlConnection(connString);
                    conn.Open();
                    string strQuery = "SELECT *  FROM Table_3 where 监考老师='" + label4.Text + "'";
                    SqlCommand command = new SqlCommand(strQuery, conn);
                    if (command.ExecuteScalar() == null)
                    { MessageBox.Show("目前没有考试安排"); }
                    else
                    {
                        SqlDataAdapter da = new SqlDataAdapter(strQuery, conn);
                        DataSet ds = new DataSet();
                        da.Fill(ds, "table");
                        dataGridView1.DataSource = ds.Tables["table"].DefaultView;
                        this.dataGridView1.Columns[0].Visible = false;

                    }
        }

        private void 账户安全ToolStripMenuItem_Click(object sender, EventArgs e)
        {
         Form1 a = new Form1();
                    a.Show();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
             Close();
        }

        private void 成绩ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.dataGridView1.Visible = true;
            this.groupBox3.Visible = true;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(DRIVER);
            conn.Open();
            if (dataGridView1.SelectedRows.Count !=1) return;
            if (dataGridView1.CurrentRow == null) return;
            //string bd = dataGridView1.CurrentRow.Cells[2].Value.ToString();  

            DataRowView row = dataGridView1.CurrentRow.DataBoundItem as DataRowView;
            if (row["id"] == null) return;//可以进行快速监视  
            string bd = Convert.ToString(row["id"]);
            string selectsql = "delete from Table_4 where id = " + bd + "";
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

        private void 修改密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 a =new Form4();
            a.Show();
        }

        private void 查看ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void 查询ToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void 注销ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            登录界面 a = new 登录界面();
            a.Show();
            this.Close();
        }
    }
}
