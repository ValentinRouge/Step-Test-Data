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
        Utils utils = new Utils();
        MathUtils math = new MathUtils();
        private enum numberInLetter { first,second,third,fourth,fifth }


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
            if (Data_Step != "0")
            {
                int index = ((Int32.Parse(Data_Step.Remove(0, 1)) - 15) / 5);
                combo_stephight.Text = 15.ToString();
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
            lbl_result_error.Hide();
            btn_validate.Hide();
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
                btn_validate.Show();
                lbl_indication.Text = "The participant do the first test";
                lbl_nxtresult.Text = "Result of the first test (bpm) : ";
            }
            else
            {
                lbl_results.Hide();
                lbl_nxtresult.Hide();
                lbl_indication.Hide();
                txt_result.Hide();
                btn_validate.Hide();
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
                Data.maxHR = 220 - age;
                Data._85maxHR = (double)Data.maxHR * (double)0.85;
                Data._50maxHR = (double)Data.maxHR * (double)0.5;
                var text = "Max HR  : " + Data.maxHR.ToString() + " b/min \n\n85% MaxHR : " + Data._85maxHR.ToString() + " b/min \n\n";
                RelnitResultText(text);
                checkIfComplete();
            }
            else
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

        private void updateResults()
        {
            switch ((StepOfTheTest)Data.stepOfTheTest)
            {
                case StepOfTheTest.init:
                    break;
                case StepOfTheTest.HR1:
                    PopulateTextBox(Data.HR1,0);
                    break;
                case StepOfTheTest.HR2:
                    PopulateTextBox(Data.HR2, 1);
                    break;
                case StepOfTheTest.HR3:
                    PopulateTextBox(Data.HR3, 2);
                    break;
                case StepOfTheTest.HR4:
                    PopulateTextBox(Data.HR4, 3);
                    break;
                case StepOfTheTest.finish:
                    updateResultText("Fourth HR mesured : " + Data.HR5.ToString());
                    if (Data.HR5 < Data._50maxHR)
                    {
                         updateResultText("(This HR will not be taken into acount because it is to low) \n\n");
                    }
                    else if (Data.HR5 > Data._85maxHR)
                    {
                        updateResultText("(This HR will not be taken into acount because it is to high) \n\n");
                    }
                    else
                    {
                        updateResultText("\n\n");
                        Data.takenHr.Add(Data.HR5);
                        Data.takenX.Add(Data.Xvalues[4]);
                    }
                    testIsFinished();
                    break;
            }
        }

        private void PopulateTextBox(int hr,int number)
        {
            updateResultText($"{(numberInLetter)number} HR mesured : {hr.ToString()}");
            if (hr < Data._50maxHR)
            {

                updateResultText("(This HR will not be taken into acount because it is to low) \n\n");
                lbl_indication.Text = $"The participant do the {(numberInLetter)(number+1)} test";
                lbl_nxtresult.Text = $"Result of the {(numberInLetter)(number + 1)} test (bpm) : ";
            }
            else if (hr > Data._85maxHR)
            {
                updateResultText("(This HR will not be taken into acount because it is to high) \n\n");
                testIsFinished();
            }
            else
            {
                updateResultText("\n\n");
                lbl_indication.Text = $"The participant do the {(numberInLetter)(number + 1)} test";
                lbl_nxtresult.Text = $"Result of the {(numberInLetter)(number + 1)} test (bpm) : ";
                Data.takenHr.Add(hr);
                Data.takenX.Add(Data.Xvalues[number]);
            }
        }

        private void testIsFinished()
        {
            lbl_indication.Text = "The test is finished";
            txt_result.Hide();
            lbl_nxtresult.Hide();
            btn_validate.Hide();
            int number_of_points = Data.takenHr.Count();
            if (number_of_points > 1)
            {
                double aerobic_capacity = utils.getAerobicCapacity(Data);
                lbl_indication.Text += "\n\nYour aerobic capacity is " + aerobic_capacity;


            } else if (number_of_points == 1)
            {
                List<int> invalidTest = new List<int> { Data.HR1, Data.HR2, Data.HR3, Data.HR4, Data.HR5 }.ToList();
                invalidTest.Remove(Data.takenHr[0]);
                int clothest = math.getClosestFrom(invalidTest[0], invalidTest[1], invalidTest[2], invalidTest[3], Data._50maxHR, Data._85maxHR);
                double aerobic_capacity = utils.getAerobicCapacity(Data, Data.takenHr[0], clothest, Data.takenX[0]);
                lbl_indication.Text += "\n\nYour aerobic capacity is " + aerobic_capacity;
                lbl_nxtresult.Show();
                lbl_nxtresult.Text = $"You only had a valid value. Your score was calculated from the closest value in the valid value field: {clothest} bpm";

            } else 
            {
                lbl_indication.Text += "\n\nThere are no valid points, so your test is invalid. \n\nTry again, perhaps with a different step height. ";
            }

        }

        private void btn_validate_Click(object sender, EventArgs e)
        {
            int HR;
            bool result;
            result = Int32.TryParse(txt_result.Text, out HR);
            if (result)
            {
                lbl_result_error.Hide();
                switch ((StepOfTheTest)Data.stepOfTheTest)
                {
                    case StepOfTheTest.init:
                        utils.updateXList(Data);
                        Data.stepOfTheTest = (StepOfTheTest)1;
                        Data.HR1 = HR;
                        combo_stephight.Hide();
                        lbl_stephigh.Text += Data.TestStepHigh.ToString().Remove(0, 1);
                        txt_Age.Enabled = false;
                        break;
                    case StepOfTheTest.HR1:
                        Data.stepOfTheTest = (StepOfTheTest)2;
                        Data.HR2 = HR;
                        break;
                    case StepOfTheTest.HR2:
                        Data.stepOfTheTest = (StepOfTheTest)3;
                        Data.HR3 = HR;
                        break;
                    case StepOfTheTest.HR3:
                        Data.stepOfTheTest = (StepOfTheTest)4;
                        Data.HR4 = HR;
                        break;
                    case StepOfTheTest.HR4:
                        Data.stepOfTheTest = (StepOfTheTest)5;
                        Data.HR5 = HR;
                        break;
                    case StepOfTheTest.finish:
                        break;
                }
                updateResults();
            }
            else
            {
                lbl_result_error.Show();
            }
        }
        
        private void updateResultText(string Text)
        {
            Data.result_text = Data.result_text + Text;
            lbl_results.Text = Data.result_text;
        }
        private void RelnitResultText(string Text)
        {
            Data.result_text = Text;
            lbl_results.Text = Data.result_text;
        }
    }
}
