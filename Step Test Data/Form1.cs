using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Step_Test_Data
{
    public partial class Form1 : Form
    {

        List<CurrentTest> TestInAction = new List<CurrentTest>(); //List that will stock all the tests that are beeing done
        public Form1()
        {
            InitializeComponent();
        }

        public void updateList()
        ///Function that updates the list of participants in the test
        {
            int a;
            List<String> nameList = new List<String>();
            for (a = 0; a < TestInAction.Count; a+=1) 
            //For each test that is beeing done
            {
                if (TestInAction[a].stepOfTheTest != StepOfTheTest.finish)
                {
                    nameList.Add(TestInAction[a].Name);
                    //Add the names of the participants to a list to display it
                }
            }
            lst_current_Test.DataSource = nameList;
            if (nameList.Count == 0)
            {
                btn_open_current.Enabled = false;       
            }
            //display the list of names
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var showTestForms = new showForm();
            showTestForms.Show();
            //Display the form to show the precedent tests
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_newEmptyTest_Click(object sender, EventArgs e)
        /// Create an empty new test and open a form to edit it
        {
            var testData = new CurrentTest();
            // create a new empty test
            TestInAction.Add(testData);
            //add this new test to the list of test currently happening
            var TestForm = new FormTest(testData);
            //create the form to edit the new test
            updateList();
            //update the list of peope doing a test
            TestForm.Show();
            //Show the form
        }

        private void btn_open_current_Click(object sender, EventArgs e)
        {
            var testData = TestInAction[lst_current_Test.SelectedIndex];
            //Get the test that the user wants to edit
            var TestForm = new FormTest(testData);
            TestForm.Show();
            //Open it in a new form
        }

        protected override void OnActivated(EventArgs e)
        {
            updateList();
            //update the list when you come back to the form so it is be updated
        }

        private void btn_import_Click(object sender, EventArgs e)
        {
            string fileContent = string.Empty;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            ///Open the dialog to select the file
            {
                openFileDialog.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
                //only accept txt files
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    //Read the contents of the file into a stream
                    var fileStream = openFileDialog.OpenFile();

                    using (StreamReader reader = new StreamReader(fileStream))
                    {
                        fileContent = reader.ReadToEnd();
                        //put the content to a string
                    }
                }
            }
            string[] Separators = new string[] { "\n" };
            string[] participants = fileContent.Split(Separators, StringSplitOptions.None);
            //split all tge lines
            foreach (string line in participants)
            {
                string[] word = line.Split(char.Parse(";"));
                //split all the data
                CurrentTest Test = new CurrentTest();
                //create a new test
                //Save data from file to data
                Test.Name = word[0];
                int num;
                bool result;
                result = int.TryParse(word[1], out num);
                if (result)
                {
                    Test.Age = num;
                }
                if (word[2] == "Male" || word[2] == "male" || word[2] == "M")
                {
                    Test.isFemale = false;
                    Test.isMale = true;
                }
                else if (word[2] == "Female" || word[2] == "female" || word[2] == "F")
                {
                    Test.isFemale = true;
                    Test.isMale = false;
                }
                result = int.TryParse(word[3], out num);
                if (result)
                {
                    if (num == 15 || num == 20 || num == 25 || num == 30)
                    {
                        Test.TestStepHigh = (StepHigh)num;
                    }
                }
                TestInAction.Add(Test);
            }
            updateList();
        }

        private void btn_Info_Click(object sender, EventArgs e)
        {
            MessageBox.Show("To import participant via a file you have to enter a text file containing one line per participant type :\nName;Age;Male/Female;Step High\n");
        }
    }
}
