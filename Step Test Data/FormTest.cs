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
    public partial class FormTest : Form
    {
        CurrentTest Data;
        bool ageOK = false;
        bool nameOK = false;
        bool sexOK = false;
        bool stepOK = false;

        public FormTest(CurrentTest data)
        {
            InitializeComponent();
            Data = data;
            string Data_name = Data.Name;
            if (Data_name != "")
            {
                txt_name.Text = Data_name;
                nameOK = true;
            }
            int Data_age = Data.Age;
            if (Data_age != 0)
            {
                txt_Age.Text = Data.Age.ToString();
                ageOK = true;
            }
            if (Data.isFemale && !Data.isMale)
            {
                rbtn_female.Checked = true;
                sexOK = true;
            } 
            if (Data.isMale && !Data.isFemale)
            {
                rbtn_male.Checked = true;
                sexOK = true;
            }
            string Data_Step = Data.TestStepHigh.ToString();
            if (Data.TestStepHigh != 0)
            {
                combo_stephight.Text = Data_Step.Remove(0, 1);
                stepOK = true;
            }
        }

        private void FormTest_Load(object sender, EventArgs e)
        {
            combo_stephight.Items.AddRange(new object[] { 15, 20, 25, 30 });
            lbl_results.Hide();
            lbl_nxtresult.Hide();
            lbl_indication.Hide();
            txt_result.Hide();
            lbl_age_error.Hide();
            lbl_step_error.Hide();
            checkIfComplete();
        }

        private void txt_name_TextChanged(object sender, EventArgs e)
        {
            string name = txt_name.Text;
            Data.Name = name;
            if (name != "")
            {
                nameOK = true;
            }
            checkIfComplete();
        }

        private void checkIfComplete()
        {
            if (ageOK && nameOK && sexOK && stepOK)
            {
                lbl_results.Show();
                lbl_nxtresult.Show();
                lbl_indication.Show();
                txt_result.Show();
            } else
            {
                lbl_results.Hide();
                lbl_nxtresult.Hide();
                lbl_indication.Hide();
                txt_result.Hide();
            }
        }

        private void txt_Age_TextChanged(object sender, EventArgs e)
        {
            
            int age;
            bool result;
            result = Int32.TryParse(txt_Age.Text, out age);
            if (result)
            {
                Data.Age = age;
                ageOK = true;
                lbl_age_error.Hide();
                checkIfComplete();
            } else
            {
                lbl_age_error.Show();
            }
            
        }

        private void rbtn_female_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtn_female.Checked)
            {
                Data.isFemale = true;
                Data.isMale = false;
            }
            sexOK = true;
            checkIfComplete();

        }

        private void rbtn_male_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtn_male.Checked)
            {
                Data.isFemale = false;
                Data.isMale = true;
            }
            sexOK = true;
            checkIfComplete();
        }

        private void combo_stephight_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Data.TestStepHigh = (StepHigh)Int32.Parse(combo_stephight.Text);
                if (!Data.TestStepHigh.ToString().StartsWith("_"))
                    throw new Exception("Not authorized number");
                stepOK = true;
                lbl_step_error.Hide();

            }
            catch
            {
                lbl_step_error.Show();
                stepOK = false;
            }
            checkIfComplete();
        }
    }
}
