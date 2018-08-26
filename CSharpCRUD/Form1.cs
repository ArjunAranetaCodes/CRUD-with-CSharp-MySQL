using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CSharpCRUD
{
    public partial class Form1 : Form
    {
        MySqlConnection conn = new MySqlConnection("Server=localhost; User Id=root1;Password='';Database=db_csharpcrud");
        MySqlDataAdapter adapter = new MySqlDataAdapter();
        MySqlCommand command = new MySqlCommand();
        public DataSet ds = new DataSet();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetRecords();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ds = new DataSet();
            adapter = new MySqlDataAdapter("insert into tbl_names (firstname, lastname) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "')", conn);
            adapter.Fill(ds, "tbl_names");
            MessageBox.Show("Added!");
            textBox1.Clear();
            textBox2.Clear();
            GetRecords();
        }

        private void GetRecords() {
            ds = new DataSet();
            adapter = new MySqlDataAdapter("select * from tbl_names", conn);
            adapter.Fill(ds, "tbl_names");

            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "tbl_names";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int i = dataGridView1.CurrentRow.Index;

            label3.Text = dataGridView1[0, i].Value.ToString();
            textBox1.Text = dataGridView1[1, i].Value.ToString();
            textBox2.Text = dataGridView1[2, i].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ds = new DataSet();
            adapter = new MySqlDataAdapter("update tbl_names set firstname = '" + textBox1.Text + "', lastname = '" + textBox2.Text + "' where id = " + label3.Text, conn);
            adapter.Fill(ds, "tbl_names");
            textBox1.Clear();
            textBox2.Clear();
            label3.Text = "";
            GetRecords();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int i = dataGridView1.CurrentRow.Index;
            ds = new DataSet();
            adapter = new MySqlDataAdapter("delete from tbl_names where id = " + dataGridView1[0, i].Value.ToString(), conn);
            adapter.Fill(ds, "tbl_names");
            textBox1.Clear();
            textBox2.Clear();
            label3.Text = "";
            GetRecords();
        }

    }
}
