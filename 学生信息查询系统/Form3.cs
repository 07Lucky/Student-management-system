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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connString = @"Data Source=DESKTOP-SFFEEKC\SQLEXPRESS;Initial Catalog=学生信息表;Integrated Security=SSPI";
            SqlConnection conn = new SqlConnection(connString);
            conn.Open();
            string strQuery = "DELETE FROM Table_1  where 学号='" + textBox1.Text + "'";
            SqlCommand command = new SqlCommand(strQuery, conn);
            if (command.ExecuteNonQuery() == 1)
            { MessageBox.Show("删除成功！"); }
            else
                MessageBox.Show("学号不存在，请重新输入！");
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            主界面 b = new 主界面();
            this.Hide();
            b.Show();
        }
    }
}
