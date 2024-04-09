using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using System.Data;
using System.Data.Common;
using System.Data.SqlTypes;
using System.Net.Http.Headers;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace studentInfo_DB
{
    public partial class Form1 : Form
    {
        SqlConnection conn;

        bool flag = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void nameTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_load(object sender, EventArgs e)
        {


        }

        private void loadtableButton_Click(object sender, EventArgs e)
        {
            string ConnectionString = "Data Source=(localdb)\\ProjectModels;Initial Catalog=Students;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            conn = new SqlConnection(ConnectionString);
            conn.Open();

            string getQuery = "SELECT Regestraion , Name , Age FROM StudentsInfo";


            SqlCommand cmd = new SqlCommand(getQuery, conn);


            DataTable dt = new DataTable();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            try
            {
                sda.Fill(dt);
            }
            catch (Exception h)
            {
                MessageBox.Show(h.Message);
            }

            dataGridView1.DataSource = dt;

        }

        private void SaveButton_Click(object sender, EventArgs e)
        {

            if (exists() && !flag )
            {
                MessageBox.Show("Record All Ready exists, Please Enter carefully");
                return;
            }

            if ((nameTextBox.Text.IsNullOrEmpty()) && (regestraionTextBox.Text.IsNullOrEmpty()))
            {
                MessageBox.Show("Above Field cannot be empty");
                return;
            }

            if (flag)
            {
                querryExecuter($"update StudentsInfo set Name = @Sname , Regestraion = @Sregestration , Age = @Sage where Regestraion = '{dataGridView1.CurrentRow.Cells[0].Value.ToString()}'");
                flag = false;

                MessageBox.Show("Record Edit sucessfully");
                loadtableButton.PerformClick();
                return;
            }
            querryExecuter("INSERT into StudentsInfo( Name , Regestraion , Age) Values(@Sname , @Sregestration , @Sage)");

            nameTextBox.Clear();
            regestraionTextBox.Clear();
            ageNumericUpDown.Value = ageNumericUpDown.Minimum;

            MessageBox.Show("Record Enterd Sucessfully");

            loadtableButton.PerformClick();


            conn.Close();

        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            string ConnectionString = "Data Source=(localdb)\\ProjectModels;Initial Catalog=Students;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            conn = new SqlConnection(ConnectionString);
            conn.Open();

            string deleteQuery = "Delete StudentsInfo";

            DialogResult dialogResult = MessageBox.Show("Are You sure, This action will clear all data", "Confirmation", MessageBoxButtons.OKCancel);

            SqlCommand cmd = new SqlCommand(deleteQuery, conn);
            if (dialogResult == DialogResult.OK)
            {

                cmd.ExecuteNonQuery();
                loadtableButton.PerformClick();
                MessageBox.Show("All Entries have been Deleted");
            }
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Click Show All Button to Edit exsisting Record");
                return;
            }
            flag = true;
            nameTextBox.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            ageNumericUpDown.Value = Convert.ToInt32(dataGridView1.CurrentRow.Cells[2].Value.ToString());
            regestraionTextBox.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }
        private void querryExecuter(string querry)
        {
            string ConnectionString = "Data Source=(localdb)\\ProjectModels;Initial Catalog=Students;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            conn = new SqlConnection(ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand(querry, conn);
            //cmd.Parameters.Add(new SqlParameter("Sname", System.Data.SqlDbType.VarChar).Value = nameTextBox.Text); one method 
            SqlParameter sqlParameter = new SqlParameter("Sname", System.Data.SqlDbType.VarChar); sqlParameter.Value = nameTextBox.Text;
            SqlParameter sqlParameter1 = new SqlParameter("Sregestration", System.Data.SqlDbType.VarChar); sqlParameter1.Value = regestraionTextBox.Text;
            SqlParameter sqlParameter2 = new SqlParameter("Sage", System.Data.SqlDbType.Int); sqlParameter2.Value = ageNumericUpDown.Value;
            cmd.Parameters.Add(sqlParameter);
            //cmd.Parameters.AddWithValue("Sregestration", regestraionTextBox.Text);
            cmd.Parameters.Add(sqlParameter1);
            cmd.Parameters.Add(sqlParameter2);
            cmd.ExecuteNonQuery();
            conn.Close();
        }


        private bool exists()
        {
            string ConnectionString = "Data Source=(localdb)\\ProjectModels;Initial Catalog=Students;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            conn = new SqlConnection(ConnectionString);
            conn.Open();

            SqlCommand check_User_Name = new SqlCommand("SELECT COUNT(*) FROM StudentsInfo WHERE (Regestraion = @Sregestration)", conn);
            check_User_Name.Parameters.AddWithValue("@Sregestration", regestraionTextBox.Text);
            int UserExist = (int)check_User_Name.ExecuteScalar();

            if (UserExist > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            string ConnectionString = "Data Source=(localdb)\\ProjectModels;Initial Catalog=Students;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            conn = new SqlConnection(ConnectionString);
            conn.Open();


            string searchQuery = $"SELECT Regestraion , Name , Age From StudentsInfo WHERE Name = '{searchTextBox.Text}'";
            SqlCommand cmd = new SqlCommand(searchQuery, conn);
            DataSet ds = new DataSet();
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            try
            {
                sda.Fill(ds);
            }
            catch (Exception h)
            {
                MessageBox.Show(h.Message);
            }

            dataGridView1.DataSource = ds.Tables[0];
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("Click Show All Button to Delete exsisting Record");
                return;
            }

            string ConnectionString = "Data Source=(localdb)\\ProjectModels;Initial Catalog=Students;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            conn = new SqlConnection(ConnectionString);
            conn.Open();

            string deleteQuery = $"Delete From StudentsInfo where Regestraion = '{dataGridView1.CurrentRow.Cells[0].Value.ToString()}'";
            SqlCommand cmd = new SqlCommand(deleteQuery, conn);




            cmd.ExecuteNonQuery();
            loadtableButton.PerformClick();




        }
    }

}