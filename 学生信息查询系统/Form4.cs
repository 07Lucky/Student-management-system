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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string connString = @"Data Source=DESKTOP-SFFEEKC\SQLEXPRESS;Initial Catalog=学生信息表;Integrated Security=SSPI";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            string strQuery = "UPDATE Table_1 SET 密码='" + textBox1.Text + "' where 学号='" + Form5.txt + "'";
            SqlCommand command = new SqlCommand(strQuery, conn);
            if (textBox1.Text == textBox2.Text)
                if (command.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("修改成功");
                    this.Hide();
                }
                else
                    MessageBox.Show("信息有误，请重新输入");
            else
                MessageBox.Show("密码输入不一致，请重新输入！");
            conn.Close(); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
          
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
