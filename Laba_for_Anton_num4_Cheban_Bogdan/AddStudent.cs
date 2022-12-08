using System;
using System.Windows.Forms;

namespace Laba_for_Anton_num4_Cheban_Bogdan
{
    public partial class AddStudent : Form
    {
        public StudentInfo info { get; set; } = new StudentInfo();
        public Facultet facultet { get; set; } = new Facultet();

        public bool check = true;
        public AddStudent()
        {
            InitializeComponent();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            check = false;
            Close();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
