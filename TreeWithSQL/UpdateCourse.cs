﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TreeWithSQL
{
    public partial class UpdateCourse : Form
    {
        string id;
        string facultyId;

        public UpdateCourse(string id, string facultyId)
        {
            InitializeComponent();
            this.id = id;
            this.facultyId = facultyId;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=TreeWithSQLLab;Integrated Security=True;");
            conn.Open();
            var sqlq = $"UPDATE [dbo].[Course] SET [CourseNumber] = {textBox1.Text} WHERE [Id] = {id} AND [FacultyId] = {facultyId}";
            var cmd = new SqlCommand(sqlq, conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void textBox1_KeyUp(object sender, KeyEventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int w) || textBox1.Text == "")
            {

            }
            else
            {
                MessageBox.Show("Вы ввели символ, вводите цифры!");
                textBox1.Clear();
            }
        }
    }
}
