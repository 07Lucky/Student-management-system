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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connString = @"Data Source=DESKTOP-SFFEEKC\SQLEXPRESS;Initial Catalog=学生信息表;Integrated Security=SSPI";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            string strQuery = "UPDATE Table_1 SET 密保问题='"+comboBox1.Text+"',密保答案='" + textBox1.Text + "' where 学号='" + 登录界面.txt + "'";
            SqlCommand command = new SqlCommand(strQuery,conn);
            if (command.ExecuteNonQuery() == 1)
                MessageBox.Show("设置成功");
            else
                MessageBox.Show("设置失败，请重新设置");
            conn.Close();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
