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
    public partial class 登录界面 : Form
    {
        public static string txt = "";
        public 登录界面()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txt = textBox1.Text;
            string connString = @"Data Source=DESKTOP-SFFEEKC\SQLEXPRESS;Initial Catalog=学生信息表;Integrated Security=SSPI";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            string strQuery = "SELECT * FROM Table_1 where 密码='" + textBox2.Text + "' and 学号='" + textBox1.Text + "'and 身份='"+comboBox1.Text+"'";
            SqlCommand command = new SqlCommand(strQuery, conn);
            command.CommandType = CommandType.Text;
            SqlDataReader read = command.ExecuteReader();

            if (read.Read())
            {
                if (comboBox1.Text == "管理员")
                {
                    MessageBox.Show("登录成功");
                    this.Hide();
                    Form6 x = new Form6();
                    x.Show();
                }
                else if (comboBox1.Text == "老师")
                {
                    MessageBox.Show("登录成功");
                    this.Hide();
                    Form2 x = new Form2();
                    x.Show();
                }
                else if (comboBox1.Text == "学生")
                {
                    MessageBox.Show("登录成功");
                    this.Hide();
                    主界面 main = new 主界面();
                    main.Show();
                }
                else
                {
                    MessageBox.Show("请选择身份");
                }
            }
                else
                {
                    MessageBox.Show("登录失败，密码错误或身份选择错误！");
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {
           
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form5 a2 = new Form5();
            a2.Show();

        }

        private void label5_Click(object sender, EventArgs e)
        {
        
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void 登录界面_Load(object sender, EventArgs e)
        {

        }
    }
}
