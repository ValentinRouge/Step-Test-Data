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
        public FormTest(CurrentTest Data)
        {
            InitializeComponent();
        }

        private void FormTest_Load(object sender, EventArgs e)
        {
            combo_stephight.Items.AddRange(new object[] { 15, 20, 25, 30 });
            lbl_results.Hide();
            lbl_nxtresult.Hide();
            lbl_indication.Hide();
            txt_result.Hide();
        }

        private void txt_name_TextChanged(object sender, EventArgs e)
        {
            checkIfComplete();
        }

        private void checkIfComplete()
        {
            if (lbl_Name.Text != "" && lbl_age.Text != "" && (rbtn_female.Checked == true || rbtn_male.Checked == true) && (combo_stephight.Text == "15" || combo_stephight.Text == "20" || combo_stephight.Text == "25" || combo_stephight.Text == "30"))
            {
                lbl_results.Show();
                lbl_nxtresult.Show();
                lbl_indication.Show();
                txt_result.Show();
                Console.WriteLine("test");
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
            checkIfComplete();
        }

        private void rbtn_female_CheckedChanged(object sender, EventArgs e)
        {
            checkIfComplete();
        }

        private void rbtn_male_CheckedChanged(object sender, EventArgs e)
        {
            checkIfComplete();
        }

        private void combo_stephight_SelectedIndexChanged(object sender, EventArgs e)
        {
            checkIfComplete();
        }

        private void combo_stephight_TextChanged(object sender, EventArgs e)
        {
            checkIfComplete();
        }
    }
}
