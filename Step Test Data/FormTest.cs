using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Step_Test_Data
{
    public partial class FormTest : Form
    {
        CurrentTest Data;
        bool ageOK = false;
        bool nameOK = false;
        bool sexOK = false;
        bool stepOK = false;
        /// <summary>
        /// Data used to know if all the conditions are required to show the rest of the test interface
        /// </summary>
        Utils utils = new Utils();
        MathUtils math = new MathUtils();
        private enum numberInLetter { first,second,third,fourth,fifth }
        /// <summary>
        /// use to display data
        /// </summary>
        ChartArea area;
        //area for the chart

        public FormTest(CurrentTest data)
        {
            InitializeComponent();
            /// import the data from main form to the interface
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
            ///both are needed to avoid issues dues to default false data
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
                combo_stephight.Text = Data_Step.Remove(0, 1);
                ///remove the underscore in the StepHigh enum
                stepOK = true;
            }
            if (Data.stepOfTheTest != StepOfTheTest.init)
            {
                combo_stephight.Hide();
                lbl_stephigh.Text += Data.TestStepHigh.ToString().Remove(0, 1);
                txt_Age.Enabled = false;
                /// if test has begun make components uneditable because it could cause issue to the test
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
            lbl_result_explains.Hide();
            result_chart.Hide();
            checkIfComplete();
            ///Hide all the things that are not usefull (errors labels and the components linked to test)
        }

        private void txt_name_TextChanged(object sender, EventArgs e)
        {
            string name = txt_name.Text;
            Data.Name = name;
            if (name != "")
            {
                nameOK = true;
                ///if the name is not null it is consider as valid
            }
            checkIfComplete();
        }

        private void checkIfComplete()
            ///If all the conditions are required the followings items are enabled
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
            ///check if it is convertible to an int
            if (result)
            {
                if (age >= 15 && age <= 65)
                    ///Check if it is in the bounds of the test 
                {
                    Console.WriteLine("prb");
                    Data.Age = age;
                    ageOK = true;
                    lbl_age_error.Hide();
                    Data.maxHR = 220 - age;
                    Data._85maxHR = (double)Data.maxHR * (double)0.85;
                    Data._50maxHR = (double)Data.maxHR * (double)0.5;
                    //calculate Data
                    var text = "Max HR  : " + Data.maxHR.ToString() + " b/min \n\n85% MaxHR : " + Data._85maxHR.ToString() + " b/min \n\n";
                    ///text to display
                    if (Data.stepOfTheTest == StepOfTheTest.init)
                    {
                        RelnitResultText(text);
                        ///if the test has alreade begin just display what was before displaid before or write to the label if the test has not begun 
                    } else
                    {
                        updateResultText("");
                    }
                    checkIfComplete();
                } else
                {
                    lbl_age_error.Show();
                    lbl_age_error.Text = "The participant must be 15 and 65 years old.";
                    ageOK = false;
                }

            }
            else
            {
                lbl_age_error.Show();
                lbl_age_error.Text = "Type a correct age.";
                ageOK = false;

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
            //if one sex box is selected sex data is consider as OK
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
            //if one sex box is selected sex data is consider as OK
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
                // check if the text that is writen is one of the possible step high

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
                        //is the HR is valid
                        updateResultText("\n\n");
                        Data.takenHr.Add(Data.HR5);
                        Data.takenX.Add(Data.Xvalues[4]);
                    }
                    testIsFinished();
                    ///in all the case : there is at maxiumum 5 test
                    break;
            }
        }

        private void PopulateTextBox(int hr,int number)
            //treat the data that has just be writen
        {
            updateResultText($"{(numberInLetter)number} HR mesured : {hr.ToString()}");
            if (hr < Data._50maxHR)
            {

                updateResultText(" (This HR will not be taken into acount because it is to low) \n\n");
                lbl_indication.Text = $"The participant do the {(numberInLetter)(number+1)} test";
                lbl_nxtresult.Text = $"Result of the {(numberInLetter)(number + 1)} test (bpm) : ";
                ///display the phrases to the labels
            }
            else if (hr > Data._85maxHR)
            {
                updateResultText(" (This HR will not be taken into acount because it is to high) \n\n");
                testIsFinished();
            }
            else
            {
                updateResultText("\n\n");
                lbl_indication.Text = $"The participant do the {(numberInLetter)(number + 1)} test";
                lbl_nxtresult.Text = $"Result of the {(numberInLetter)(number + 1)} test (bpm) : ";
                ///display the phrases to the labels
                Data.takenHr.Add(hr);
                Data.takenX.Add(Data.Xvalues[number]);
                //add to the lists of valid values
            }
        }

        private void testIsFinished()
            ///function that run when the test is finished
        {
            Data.stepOfTheTest = StepOfTheTest.finish;
            lbl_indication.Text = "The test is finished";
            txt_result.Hide();
            lbl_nxtresult.Hide();
            btn_validate.Hide();
            int number_of_points = Data.takenHr.Count();
            if (number_of_points > 1)
            {
                //if more than 1 point
                Data.aerobic_capacity = (int)utils.getAerobicCapacity(Data);
                lbl_indication.Text += "\n\nYour aerobic capacity is " + Data.aerobic_capacity;
                DisplayFitnessResult();

            } else if (number_of_points == 1)
            {
                //if one point
                List<int> invalidTest = new List<int> { Data.HR1, Data.HR2, Data.HR3, Data.HR4, Data.HR5 }.ToList();
                invalidTest.Remove(Data.takenHr[0]);
                int clothest = math.getClosestFrom(invalidTest[0], invalidTest[1], invalidTest[2], invalidTest[3], Data._50maxHR, Data._85maxHR);
                //get less false value
                Data.aerobic_capacity = (int)utils.getAerobicCapacity(Data, Data.takenHr[0], clothest, Data.takenX[0]);
                lbl_indication.Text += "\n\nYour aerobic capacity is " + Data.aerobic_capacity;
                lbl_result_explains.Show();
                lbl_result_explains.Text = $"You only had a valid value. Your score was calculated from the closest value in the valid value field: {clothest} bpm";
                DisplayFitnessResult();

            } else 
            {
                // if 0 points
                lbl_indication.Text += "\n\nThere are no valid points, so your test is invalid. \n\nTry again, perhaps with a different step height. ";
            }
        }

        private void DisplayFitnessResult()
        {
            result_chart.Show();
            CreateChar();
            Data.FitnessResult = FitnessScoreDict.ComputeRatingFromScore(Data.aerobic_capacity, Data.Age, Data.isFemale);
            lbl_indication.Text += $"\n\nYou fitness rating is {Data.FitnessResult}";
            DBManager DBM = new DBManager();
            DBM.Add(Data.Name, Data.aerobic_capacity, Data.FitnessResult);
            //save to the database
            
        }

        private void btn_validate_Click(object sender, EventArgs e)
        {
            int HR;
            bool result;
            result = Int32.TryParse(txt_result.Text, out HR);
            ///check if the value is a correct number
            if (result)
            {
                lbl_result_error.Hide();
                switch ((StepOfTheTest)Data.stepOfTheTest)
                {
                    case StepOfTheTest.init:
                        utils.updateXList(Data);
                        //get the list associated with step high
                        Data.stepOfTheTest = (StepOfTheTest)1;
                        //go to next step of the test
                        Data.HR1 = HR;
                        combo_stephight.Hide();
                        lbl_stephigh.Text += Data.TestStepHigh.ToString().Remove(0, 1);
                        txt_Age.Enabled = false;
                        //make age and step high uneditable 
                        break;
                    case StepOfTheTest.HR1:
                        Data.stepOfTheTest = (StepOfTheTest)2;
                        //go to next step of the test
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
                txt_result.Text = "";
                txt_result.Focus();
            }
            else
            {
                lbl_result_error.Show();
            }
        }
        
        private void updateResultText(string Text)
            ///add new text to the label
        {
            Data.result_text = Data.result_text + Text;
            lbl_results.Text = Data.result_text;
        }
        private void RelnitResultText(string Text)
            ///set new text to the label
        {
            Data.result_text = Text;
            lbl_results.Text = Data.result_text;
        }

        Series points;
        Series right;
        Series _50HR;
        Series _85HR;
        Series MaxHR;

        private void CreateChar()
        {
            area = result_chart.ChartAreas[0];

            area.AxisX.Minimum = 0;
            area.AxisX.Maximum = 80;

            area.AxisY.Minimum = 0;
            area.AxisY.Maximum = 220;

            area.AxisX.Interval = 5;
            area.AxisY.Interval = 10;

             points = result_chart.Series.Add("Results");
             right = result_chart.Series.Add("Right created with the points");
             _50HR = result_chart.Series.Add("HRMax 50%");
             _85HR = result_chart.Series.Add("HRMax 85%");
            MaxHR = result_chart.Series.Add("Max HR");

            _50HR.Color = _85HR.Color = Color.Green;
            _50HR.ChartType = _85HR.ChartType = SeriesChartType.FastLine;
            MaxHR.Color = Color.Red;
            MaxHR.ChartType = SeriesChartType.FastLine;

            
            points.Points.Add(new DataPoint(Data.Xvalues[0], Data.HR1));
            points.Points.Add(new DataPoint(Data.Xvalues[1], Data.HR2));
            points.Points.Add(new DataPoint(Data.Xvalues[2], Data.HR3));
            points.Points.Add(new DataPoint(Data.Xvalues[3], Data.HR4));
            points.Points.Add(new DataPoint(Data.Xvalues[4], Data.HR5));


            _50HR.Points.Add(new DataPoint(0, Data._50maxHR));
            _50HR.Points.Add(new DataPoint(80, Data._50maxHR));

            _85HR.Points.Add(new DataPoint(0, Data._85maxHR));
            _85HR.Points.Add(new DataPoint(80, Data._85maxHR));

            MaxHR.Points.Add(new DataPoint(0, Data.maxHR));
            MaxHR.Points.Add(new DataPoint(80, Data.maxHR));

            points.ChartType = SeriesChartType.Point;
        }
    }
}
