using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace proje2
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'lab3DataSet.Students' table. You can move, or remove it, as needed.
            this.studentsTableAdapter.Fill(this.lab3DataSet.Students);
            using (SqlConnection connection = new SqlConnection("Data Source=localhost;Initial Catalog=Lab3;Integrated Security=True"))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("SELECT CityId, CityName FROM Cities", connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        DataTable table = new DataTable();

                        table.Load(reader);

                        comboBox1.DataSource = table;

                        comboBox1.ValueMember = "CityName";

                        comboBox1.DisplayMember = "CityName";
                    }
                }

            }
            this.studentsTableAdapter.Fill(this.lab3DataSet.Students);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;

            int age;
            if (!int.TryParse(textBox2.Text, out age))
            {
                MessageBox.Show("Invalid input for age");
                return;
            }

            string address = textBox3.Text;

            string city = null;

            if (comboBox1.SelectedValue == null)
            {
                MessageBox.Show("Please select a city");
                return;
            }

            else
            {
                city = comboBox1.SelectedValue.ToString();
            }

            string stuclass = "";

            if (radioButton1.Checked)
            {
                stuclass = "9-A";
            }
            else if (radioButton2.Checked)
            {
                stuclass = "9-B";
            }
            else if (radioButton3.Checked)
            {
                stuclass = "9-C";
            }
            else if (radioButton4.Checked)
            {
                stuclass = "10-C";
            }
            else if (radioButton5.Checked)
            {
                stuclass = "10-B";
            }
            else if (radioButton6.Checked)
            {
                stuclass = "10-A";
            }
            else if (radioButton7.Checked)
            {
                stuclass = "12-C";
            }
            else if (radioButton8.Checked)
            {
                stuclass = "12-B";
            }
            else if (radioButton9.Checked)
            {
                stuclass = "12-A";
            }
            else if (radioButton10.Checked)
            {
                stuclass = "11-C";
            }
            else if (radioButton11.Checked)
            {
                stuclass = "11-B";
            }
            else if (radioButton12.Checked)
            {
                stuclass = "11-A";
            }
            else
            {
                MessageBox.Show("Please select a status");
                return;
            }


            string scholarship = "";

            if (checkBox1.Checked)
            {
                scholarship = "Scholarship";
            }

            else

            {
                scholarship = "Without Scholarship";
            }

          


            using (SqlConnection connection = new SqlConnection("Data Source=localhost;Initial Catalog=Lab3;Integrated Security=True"))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("INSERT INTO Students (StudentName, StudentAge, StudentAddress, StudentCity, StudentClass, StudentScholarship) VALUES (@name, @age, @address, @city, @stuclass, @scholarship)", connection))
                {
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@age", age);
                    command.Parameters.AddWithValue("@address", address);
                    command.Parameters.AddWithValue("@city", city);
                    command.Parameters.AddWithValue("@stuclass", stuclass);
                    command.Parameters.AddWithValue("@scholarship", scholarship);
                   
                    command.ExecuteNonQuery();
                    this.studentsTableAdapter.Fill(this.lab3DataSet.Students);


                }
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            int StudentID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);

            using (SqlConnection connection = new SqlConnection("Data Source=localhost;Initial Catalog=Lab3;Integrated Security=True"))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("DELETE FROM Students WHERE StudentID = @id", connection))
                {
                    command.Parameters.AddWithValue("@id", StudentID);
                    command.ExecuteNonQuery();
                    this.studentsTableAdapter.Fill(this.lab3DataSet.Students);

                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.studentsTableAdapter.Fill(this.lab3DataSet.Students);

        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            comboBox1.SelectedIndex = -1;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            radioButton5.Checked = false;
            radioButton6.Checked = false;
            radioButton7.Checked = false;
            radioButton8.Checked = false;
            radioButton9.Checked = false;
            radioButton10.Checked = false;
            radioButton11.Checked = false;
            radioButton12.Checked = false;
            checkBox1.Checked = false;
            textBox1.Focus();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a row to edit");
                return;
            }

            string name = textBox1.Text;

            int age;
            if (!int.TryParse(textBox2.Text, out age))
            {
                MessageBox.Show("Invalid input for age");
                return;
            }

            string address = textBox3.Text;

            string city = null;

            if (comboBox1.SelectedValue == null)
            {
                MessageBox.Show("Please select a city");
                return;
            }

            else
            {
                city = comboBox1.SelectedValue.ToString();
            }

            string stuclass = "";

            if (radioButton1.Checked)
            {
                stuclass = "9-A";
            }
            else if (radioButton2.Checked)
            {
                stuclass = "9-B";
            }
            else if (radioButton3.Checked)
            {
                stuclass = "9-C";
            }
            else if (radioButton4.Checked)
            {
                stuclass = "10-C";
            }
            else if (radioButton5.Checked)
            {
                stuclass = "10-B";
            }
            else if (radioButton6.Checked)
            {
                stuclass = "10-A";
            }
            else if (radioButton7.Checked)
            {
                stuclass = "12-C";
            }
            else if (radioButton8.Checked)
            {
                stuclass = "12-B";
            }
            else if (radioButton9.Checked)
            {
                stuclass = "12-A";
            }
            else if (radioButton10.Checked)
            {
                stuclass = "11-C";
            }
            else if (radioButton11.Checked)
            {
                stuclass = "11-B";
            }
            else if (radioButton12.Checked)
            {
                stuclass = "11-A";
            }
            else
            {
                MessageBox.Show("Please select a status");
                return;
            }


            string scholarship = "";

            if (checkBox1.Checked)
            {
                scholarship = "Scholarship";
            }

            else

            {
                scholarship = "Without Scholarship";
            }

            // Get the ID of the selected studebt from the data grid
            int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);

            using (SqlConnection connection = new SqlConnection("Data Source=localhost;Initial Catalog=Lab3;Integrated Security=True"))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand("UPDATE Students SET StudentName = @name, StudentAge = @age, StudentAddress = @address, StudentCity = @city, StudentClass = @stuclass, StudentScholarship = @scholarship WHERE StudentID = @id", connection))
                {
                    command.Parameters.AddWithValue("@name", name);
                    command.Parameters.AddWithValue("@age", age);
                    command.Parameters.AddWithValue("@address", address);
                    command.Parameters.AddWithValue("@city", city);
                    command.Parameters.AddWithValue("@stuclass", stuclass);
                    command.Parameters.AddWithValue("@scholarship", scholarship);
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                }
            }
            this.studentsTableAdapter.Fill(this.lab3DataSet.Students);

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            comboBox1.SelectedIndex = -1;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            radioButton5.Checked = false;
            radioButton6.Checked = false;
            radioButton7.Checked = false;
            radioButton8.Checked = false;
            radioButton9.Checked = false;
            radioButton10.Checked = false;
            radioButton11.Checked = false;
            radioButton12.Checked = false;
            checkBox1.Checked = false;


        }
    }
}
