using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;

namespace Laba_for_Anton_num4_Cheban_Bogdan
{
    public partial class Form1 : Form
    {

        List<StudentInfo> lst = new List<StudentInfo>();

        Helper helper = new Helper();

        string path = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\") + "Data.json");

        public Form1()
        {
            InitializeComponent();
            lst.AddRange(helper.deserializeJSON(path));
            dataGridView1.DataSource = new BindingList<StudentInfo>(lst);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            AddStudent form = new AddStudent();
            form.ShowDialog();
            if (!form.check)
                return;

            helper.AddStudent(form, lst);
            helper.serializeAndWriteToJSON(lst, path);
            dataGridView1.DataSource = new BindingList<StudentInfo>(lst);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Чебан Богдан К-27\n" +
                "Номер варіанту-28\n" +
                "\"Студентський парламент\"");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(comboChoice.Text))
            {
                MessageBox.Show("Please chhose sort option from combo box");
                return;
            }

            dataGridView1.DataSource = helper.orderBy(lst, comboChoice.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var valueInCell = dataGridView1.SelectedCells[0].Value.ToString();
            int columnIndex = dataGridView1.CurrentCell.ColumnIndex;
            string columnName = dataGridView1.Columns[columnIndex].Name;

            if (columnName != "Name")
            {
                MessageBox.Show("Please choose the \"Name\" column");
                return;
            }
            if (string.IsNullOrEmpty(valueInCell))
            {
                MessageBox.Show("Current cell is empty");
                return;
            }

            lst.RemoveAll(x => x.Name == dataGridView1.SelectedCells[0].Value.ToString());

            helper.serializeAndWriteToJSON(lst, path);
            dataGridView1.DataSource = new BindingList<StudentInfo>(lst);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = new BindingList<StudentInfo>(helper.wipeAllData(helper, path));
        }

        private void button6_Click(object sender, EventArgs e)
        {
            helper.serializeAndWriteToJSON(lst, path);
            dataGridView1.DataSource = new BindingList<StudentInfo>(lst);
        }
    }
}
