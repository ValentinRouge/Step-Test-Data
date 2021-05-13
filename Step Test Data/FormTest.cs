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
        string text_results = "";
        List<int> Xvalues = new List<int>();


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
                updateXList();
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
                updateResults();
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
                    text_results = "";
                    text_results += "Max HR  : " + Data.maxHR.ToString() + " b/min \n\n";
                    text_results += "85% MaxHR : " + Data._85maxHR.ToString() + " b/min \n\n";
                    lbl_indication.Text = "The participant do the first test";
                    lbl_nxtresult.Text = "Result of the first test (bpm) : ";
                    break;
                case StepOfTheTest.HR1:
                    text_results += "First HR mesured : " + Data.HR1.ToString();
                    if (Data.HR1 < Data._50maxHR)
                    {

                        text_results += "(This HR will not be taken into acount because it is to low) \n\n";
                        lbl_indication.Text = "The participant do the second test";
                        lbl_nxtresult.Text = "Result of the second test (bpm) : ";
                    }
                    else if (Data.HR1 > Data._85maxHR)
                    {
                        text_results += "(This HR will not be taken into acount because it is to high) \n\n";
                        testIsFinished();
                    }
                    else
                    {
                        text_results += "\n\n";
                        lbl_indication.Text = "The participant do the second test";
                        lbl_nxtresult.Text = "Result of the second test (bpm) : ";
                        Data.takenHr.Add(Data.HR1);
                        Data.takenX.Add(Xvalues[0]);
                    }
                    break;
                case StepOfTheTest.HR2:
                    text_results += "Second HR mesured : " + Data.HR2.ToString();
                    if (Data.HR2 < Data._50maxHR)
                    {
                        text_results += "(This HR will not be taken into acount because it is to low) \n\n";
                        lbl_indication.Text = "The participant do the third test";
                        lbl_nxtresult.Text = "Result of the third test (bpm) : ";
                    }
                    else if (Data.HR2 > Data._85maxHR)
                    {
                        text_results += "(This HR will not be taken into acount because it is to high) \n\n";
                        testIsFinished();
                    }
                    else
                    {
                        text_results += "\n\n";
                        lbl_indication.Text = "The participant do the third test";
                        lbl_nxtresult.Text = "Result of the third test (bpm) : ";
                        Data.takenHr.Add(Data.HR2);
                        Data.takenX.Add(Xvalues[1]);
                    }
                    break;
                case StepOfTheTest.HR3:
                    text_results += "Third HR mesured : " + Data.HR3.ToString();
                    if (Data.HR3 < Data._50maxHR)
                    {
                        text_results += "(This HR will not be taken into acount because it is to low) \n\n";
                        lbl_indication.Text = "The participant do the fourth test";
                        lbl_nxtresult.Text = "Result of the fourth test (bpm) : ";
                    }
                    else if (Data.HR3 > Data._85maxHR)
                    {
                        text_results += "(This HR will not be taken into acount because it is to high) \n\n";
                        testIsFinished();
                    }
                    else
                    {
                        text_results += "\n\n";
                        lbl_indication.Text = "The participant do the fourth test";
                        lbl_nxtresult.Text = "Result of the fourth test (bpm) : ";
                        Data.takenHr.Add(Data.HR3);
                        Data.takenX.Add(Xvalues[2]);
                    }
                    break;
                case StepOfTheTest.HR4:
                    text_results += "Fourth HR mesured : " + Data.HR4.ToString();
                    if (Data.HR4 < Data._50maxHR)
                    {
                        text_results += "(This HR will not be taken into acount because it is to low) \n\n";
                        lbl_indication.Text = "The participant do the fifth test";
                        lbl_nxtresult.Text = "Result of the fifth test (bpm) : ";
                    }
                    else if (Data.HR4 > Data._85maxHR)
                    {
                        text_results += "(This HR will not be taken into acount because it is to high) \n\n";
                        testIsFinished();
                    }
                    else
                    {
                        text_results += "\n\n";
                        lbl_indication.Text = "The participant do the fifth test";
                        lbl_nxtresult.Text = "Result of the fifth test (bpm) : ";
                        Data.takenHr.Add(Data.HR4);
                        Data.takenX.Add(Xvalues[3]);
                    }
                    break;
                case StepOfTheTest.finish:
                    text_results += "Fourth HR mesured : " + Data.HR5.ToString();
                    if (Data.HR5 < Data._50maxHR)
                    {
                        text_results += "(This HR will not be taken into acount because it is to low) \n\n";
                    }
                    else if (Data.HR5 > Data._85maxHR)
                    {
                        text_results += "(This HR will not be taken into acount because it is to high) \n\n";
                    }
                    else
                    {
                        text_results += "\n\n";
                        Data.takenHr.Add(Data.HR5);
                        Data.takenX.Add(Xvalues[4]);
                    }
                    testIsFinished();
                    break;

            }

            lbl_results.Text = text_results;
        }

        private void testIsFinished()
        {
            lbl_indication.Text = "The test is finished";
            txt_result.Hide();
            lbl_nxtresult.Hide();
            btn_validate.Hide();
            int number_of_points = Data.takenHr.Count();
            List<double> coeficient = new List<double>();
            if (number_of_points > 1)
            {
                for (int i = 0; i < number_of_points; i++)
                {
                    for (int a = i + 1; a < number_of_points; a++)
                    {
                        coeficient.Add((Data.takenHr[a] - Data.takenHr[i]) / (Data.takenX[a] - Data.takenX[i]));
                    }
                }
                double average_coefficient = calcAverage(coeficient);
                double averageX = calcAverage(Data.takenX);
                double averageY = calcAverage(Data.takenHr);
                double origin = averageY - averageX * average_coefficient;
                double aerobic_capacity = (Data.maxHR - origin) / average_coefficient;
                lbl_indication.Text += "\n\nYour aerobic capacity is " + aerobic_capacity;


            } else if (number_of_points == 1)
            {
                //CODER POUR PAS POSSIBLE
            } else 
            {
                //COMMENT FAIRE AVEC QUE 1 PT ??
            }

        }

        private double calcAverage(List<double> list)
        {
            int sum = 0;
            foreach (int val in list)
            {
                sum += val;
            }
            return sum / list.Count;
        }

        private double calcAverage(List<int> list)
        {
            int sum = 0;
            foreach (int val in list)
            {
                sum += val;
            }
            return sum / list.Count;
        }

        private void btn_validate_Click(object sender, EventArgs e)
        {
            int HR;
            bool result;
            result = Int32.TryParse(txt_result.Text, out HR);
            if (result)
            {
                
                switch ((StepOfTheTest)Data.stepOfTheTest)
                {
                    case StepOfTheTest.init:
                        lbl_result_error.Hide();
                        updateXList();
                        Data.stepOfTheTest = (StepOfTheTest)1;
                        Data.HR1 = HR;
                        combo_stephight.Hide();
                        lbl_stephigh.Text += Data.TestStepHigh.ToString().Remove(0, 1);
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

        private void updateXList()
        {
            switch (Data.TestStepHigh)
            {
                case StepHigh._15:
                    Xvalues.AddRange(new[] { 11, 14, 18, 21, 25 }.ToList());
                    break;
                case StepHigh._20:
                    Xvalues.AddRange(new[] { 12, 17, 21, 25, 29 }.ToList());
                    break;
                case StepHigh._25:
                    Xvalues.AddRange(new[] { 14, 19, 24, 28, 33 }.ToList());
                    break;
                case StepHigh._30:
                    Xvalues.AddRange(new[] { 16, 21, 27, 32, 37 }.ToList());
                    break;
            }
        }
    }
}
