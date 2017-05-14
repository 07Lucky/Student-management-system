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
    public partial class Form5 : Form
    {
        public static string txt = "";
        public Form5()
        {
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            txt = textBox2.Text;
            string connString = @"Data Source=DESKTOP-SFFEEKC\SQLEXPRESS;Initial Catalog=学生信息表;Integrated Security=SSPI";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            string strQuery = "SELECT * FROM Table_1 where 学号='" + textBox2.Text + "'and 密保问题='" + comboBox1.Text + "' and 密保答案='" + textBox1.Text + "'";

            SqlCommand command = new SqlCommand(strQuery, conn);
            command.CommandType = CommandType.Text;
            SqlDataReader read = command.ExecuteReader();

            if (read.Read())
            {
                MessageBox.Show("回答正确");
                this.Hide();
                Form4 a = new Form4();
                a.Show();
            }
            else
            {
                MessageBox.Show("答案错误，请重新输入！");
            }
        }
    }
}
