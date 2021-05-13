﻿using System;
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

        public void updateList()
        {
            int a;
            List<String> nameList = new List<String>();
            for (a = 0; a < TestInAction.Count; a+=1)
            {
                nameList.Add(TestInAction[a].Name);
            }
            lst_current_Test.DataSource = nameList;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var showTestForms = new showForm();
            showTestForms.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var DBM = new DBManager();
            DBM.Add("Valentin", 2, 5);
            DBM.Add("Leo", 2, 5);
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
            updateList();
            TestForm.Show();
        }

        private void btn_open_current_Click(object sender, EventArgs e)
        {
            var testData = TestInAction[lst_current_Test.SelectedIndex];
            var TestForm = new FormTest(testData);
            TestForm.Show();
        }

        protected override void OnActivated(EventArgs e)
        {
            updateList();
        }
    }
}
