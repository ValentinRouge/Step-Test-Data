using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Step_Test_Data
{
    public partial class Form1 : Form
    {

        List<CurrentTest> TestInAction = new List<CurrentTest>();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var showTestForms = new showForm();
            showTestForms.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var DBM = new DBManager();
            DBM.Add("Grosda", 2, 5);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_newEmptyTest_Click(object sender, EventArgs e)
        {
            var testData = new CurrentTest();
            TestInAction.Add(testData);
            var TestForm = new FormTest(testData);
            TestForm.Show();
        }
    }
}
