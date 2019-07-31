using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str = "data source=DESKTOP-CSS0A7M;initial catalog=student;integrated Security=sspi";
            SqlConnection scon = new SqlConnection(str);

            SqlCommand scom = new SqlCommand("select * from 管理员 where rtrim(用户名)='" + textBox1.Text + "'", scon);
            scom.CommandType = CommandType.Text;
            SqlDataAdapter sdp = new SqlDataAdapter();
            DataSet ds = new DataSet();
            sdp.SelectCommand = scom;
            if (scon.State != ConnectionState.Open)
            {
                scon.Open();
            }
            scom.ExecuteNonQuery();
            if (scon.State != ConnectionState.Closed)
            {
                scon.Close();
            }
            sdp.Fill(ds);
            if (ds.Tables[0].Rows.Count == 0)
            {
                label4.Text = "输入用户名或密码错误，请重试";
                return;
            }
            if (ds.Tables[0].Rows[0]["密码"].ToString() == textBox2.Text)
                label4.Text = "登陆成功";
            else
            {
                label4.Text = "输入用户名或密码有误，请重试";
                return;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }

}


