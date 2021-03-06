
namespace Step_Test_Data
{
    partial class FormTest
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTest));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.lbl_Name = new System.Windows.Forms.Label();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.txt_Age = new System.Windows.Forms.TextBox();
            this.lbl_age = new System.Windows.Forms.Label();
            this.rbtn_female = new System.Windows.Forms.RadioButton();
            this.rbtn_male = new System.Windows.Forms.RadioButton();
            this.lbl_sex = new System.Windows.Forms.Label();
            this.combo_stephight = new System.Windows.Forms.ComboBox();
            this.lbl_stephigh = new System.Windows.Forms.Label();
            this.lbl_results = new System.Windows.Forms.Label();
            this.lbl_indication = new System.Windows.Forms.Label();
            this.lbl_nxtresult = new System.Windows.Forms.Label();
            this.txt_result = new System.Windows.Forms.TextBox();
            this.lbl_age_error = new System.Windows.Forms.Label();
            this.lbl_step_error = new System.Windows.Forms.Label();
            this.btn_validate = new System.Windows.Forms.Button();
            this.lbl_result_error = new System.Windows.Forms.Label();
            this.lbl_result_explains = new System.Windows.Forms.Label();
            this.result_chart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.result_chart)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl_Name
            // 
            this.lbl_Name.AutoSize = true;
            this.lbl_Name.Location = new System.Drawing.Point(25, 27);
            this.lbl_Name.Name = "lbl_Name";
            this.lbl_Name.Size = new System.Drawing.Size(57, 17);
            this.lbl_Name.TabIndex = 0;
            this.lbl_Name.Text = "Name : ";
            // 
            // txt_name
            // 
            this.txt_name.Location = new System.Drawing.Point(79, 27);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(143, 22);
            this.txt_name.TabIndex = 1;
            this.txt_name.TextChanged += new System.EventHandler(this.txt_name_TextChanged);
            // 
            // txt_Age
            // 
            this.txt_Age.Location = new System.Drawing.Point(299, 27);
            this.txt_Age.Name = "txt_Age";
            this.txt_Age.Size = new System.Drawing.Size(143, 22);
            this.txt_Age.TabIndex = 3;
            this.txt_Age.TextChanged += new System.EventHandler(this.txt_Age_TextChanged);
            // 
            // lbl_age
            // 
            this.lbl_age.AutoSize = true;
            this.lbl_age.Location = new System.Drawing.Point(248, 30);
            this.lbl_age.Name = "lbl_age";
            this.lbl_age.Size = new System.Drawing.Size(45, 17);
            this.lbl_age.TabIndex = 2;
            this.lbl_age.Text = "Age : ";
            // 
            // rbtn_female
            // 
            this.rbtn_female.AutoSize = true;
            this.rbtn_female.Location = new System.Drawing.Point(537, 32);
            this.rbtn_female.Name = "rbtn_female";
            this.rbtn_female.Size = new System.Drawing.Size(75, 21);
            this.rbtn_female.TabIndex = 4;
            this.rbtn_female.TabStop = true;
            this.rbtn_female.Text = "Female";
            this.rbtn_female.UseVisualStyleBackColor = true;
            this.rbtn_female.CheckedChanged += new System.EventHandler(this.rbtn_female_CheckedChanged);
            // 
            // rbtn_male
            // 
            this.rbtn_male.AutoSize = true;
            this.rbtn_male.Location = new System.Drawing.Point(618, 32);
            this.rbtn_male.Name = "rbtn_male";
            this.rbtn_male.Size = new System.Drawing.Size(59, 21);
            this.rbtn_male.TabIndex = 5;
            this.rbtn_male.TabStop = true;
            this.rbtn_male.Text = "Male";
            this.rbtn_male.UseVisualStyleBackColor = true;
            this.rbtn_male.CheckedChanged += new System.EventHandler(this.rbtn_male_CheckedChanged);
            // 
            // lbl_sex
            // 
            this.lbl_sex.AutoSize = true;
            this.lbl_sex.Location = new System.Drawing.Point(488, 32);
            this.lbl_sex.Name = "lbl_sex";
            this.lbl_sex.Size = new System.Drawing.Size(43, 17);
            this.lbl_sex.TabIndex = 6;
            this.lbl_sex.Text = "Sex : ";
            // 
            // combo_stephight
            // 
            this.combo_stephight.FormattingEnabled = true;
            this.combo_stephight.Location = new System.Drawing.Point(139, 79);
            this.combo_stephight.Name = "combo_stephight";
            this.combo_stephight.Size = new System.Drawing.Size(143, 24);
            this.combo_stephight.TabIndex = 7;
            this.combo_stephight.TextChanged += new System.EventHandler(this.combo_stephight_TextChanged);
            // 
            // lbl_stephigh
            // 
            this.lbl_stephigh.AutoSize = true;
            this.lbl_stephigh.Location = new System.Drawing.Point(25, 82);
            this.lbl_stephigh.Name = "lbl_stephigh";
            this.lbl_stephigh.Size = new System.Drawing.Size(108, 17);
            this.lbl_stephigh.TabIndex = 8;
            this.lbl_stephigh.Text = "Step high (cm) :";
            // 
            // lbl_results
            // 
            this.lbl_results.AutoSize = true;
            this.lbl_results.Location = new System.Drawing.Point(25, 153);
            this.lbl_results.MaximumSize = new System.Drawing.Size(300, 0);
            this.lbl_results.Name = "lbl_results";
            this.lbl_results.Size = new System.Drawing.Size(299, 102);
            this.lbl_results.TabIndex = 10;
            this.lbl_results.Text = resources.GetString("lbl_results.Text");
            // 
            // lbl_indication
            // 
            this.lbl_indication.AutoSize = true;
            this.lbl_indication.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.lbl_indication.Location = new System.Drawing.Point(378, 153);
            this.lbl_indication.MaximumSize = new System.Drawing.Size(400, 0);
            this.lbl_indication.Name = "lbl_indication";
            this.lbl_indication.Size = new System.Drawing.Size(394, 58);
            this.lbl_indication.TabIndex = 11;
            this.lbl_indication.Text = "Lorem ipsum sit amet Lorem ispum sir amet";
            // 
            // lbl_nxtresult
            // 
            this.lbl_nxtresult.AutoSize = true;
            this.lbl_nxtresult.Location = new System.Drawing.Point(380, 224);
            this.lbl_nxtresult.MaximumSize = new System.Drawing.Size(400, 0);
            this.lbl_nxtresult.Name = "lbl_nxtresult";
            this.lbl_nxtresult.Size = new System.Drawing.Size(156, 17);
            this.lbl_nxtresult.TabIndex = 12;
            this.lbl_nxtresult.Text = "Enter next HR after test";
            // 
            // txt_result
            // 
            this.txt_result.Location = new System.Drawing.Point(383, 244);
            this.txt_result.Name = "txt_result";
            this.txt_result.Size = new System.Drawing.Size(100, 22);
            this.txt_result.TabIndex = 13;
            // 
            // lbl_age_error
            // 
            this.lbl_age_error.AutoSize = true;
            this.lbl_age_error.ForeColor = System.Drawing.Color.Red;
            this.lbl_age_error.Location = new System.Drawing.Point(296, 52);
            this.lbl_age_error.Name = "lbl_age_error";
            this.lbl_age_error.Size = new System.Drawing.Size(128, 17);
            this.lbl_age_error.TabIndex = 14;
            this.lbl_age_error.Text = "Type a correct age";
            // 
            // lbl_step_error
            // 
            this.lbl_step_error.AutoSize = true;
            this.lbl_step_error.ForeColor = System.Drawing.Color.Red;
            this.lbl_step_error.Location = new System.Drawing.Point(136, 106);
            this.lbl_step_error.Name = "lbl_step_error";
            this.lbl_step_error.Size = new System.Drawing.Size(153, 17);
            this.lbl_step_error.TabIndex = 15;
            this.lbl_step_error.Text = "Enter a value of the list";
            // 
            // btn_validate
            // 
            this.btn_validate.Location = new System.Drawing.Point(490, 242);
            this.btn_validate.Name = "btn_validate";
            this.btn_validate.Size = new System.Drawing.Size(75, 23);
            this.btn_validate.TabIndex = 16;
            this.btn_validate.Text = "Validate";
            this.btn_validate.UseVisualStyleBackColor = true;
            this.btn_validate.Click += new System.EventHandler(this.btn_validate_Click);
            // 
            // lbl_result_error
            // 
            this.lbl_result_error.AutoSize = true;
            this.lbl_result_error.ForeColor = System.Drawing.Color.Red;
            this.lbl_result_error.Location = new System.Drawing.Point(380, 269);
            this.lbl_result_error.Name = "lbl_result_error";
            this.lbl_result_error.Size = new System.Drawing.Size(152, 17);
            this.lbl_result_error.TabIndex = 17;
            this.lbl_result_error.Text = "Type a correct number";
            // 
            // lbl_result_explains
            // 
            this.lbl_result_explains.AutoSize = true;
            this.lbl_result_explains.Location = new System.Drawing.Point(383, 344);
            this.lbl_result_explains.MaximumSize = new System.Drawing.Size(400, 0);
            this.lbl_result_explains.Name = "lbl_result_explains";
            this.lbl_result_explains.Size = new System.Drawing.Size(46, 17);
            this.lbl_result_explains.TabIndex = 18;
            this.lbl_result_explains.Text = "label1";
            // 
            // result_chart
            // 
            chartArea1.Name = "ChartArea1";
            this.result_chart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.result_chart.Legends.Add(legend1);
            this.result_chart.Location = new System.Drawing.Point(800, 27);
            this.result_chart.Name = "result_chart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.result_chart.Series.Add(series1);
            this.result_chart.Size = new System.Drawing.Size(612, 422);
            this.result_chart.TabIndex = 19;
            this.result_chart.Text = "chart1";
            // 
            // FormTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1455, 461);
            this.Controls.Add(this.result_chart);
            this.Controls.Add(this.lbl_result_explains);
            this.Controls.Add(this.lbl_result_error);
            this.Controls.Add(this.btn_validate);
            this.Controls.Add(this.lbl_step_error);
            this.Controls.Add(this.lbl_age_error);
            this.Controls.Add(this.txt_result);
            this.Controls.Add(this.lbl_nxtresult);
            this.Controls.Add(this.lbl_indication);
            this.Controls.Add(this.lbl_results);
            this.Controls.Add(this.lbl_stephigh);
            this.Controls.Add(this.combo_stephight);
            this.Controls.Add(this.lbl_sex);
            this.Controls.Add(this.rbtn_male);
            this.Controls.Add(this.rbtn_female);
            this.Controls.Add(this.txt_Age);
            this.Controls.Add(this.lbl_age);
            this.Controls.Add(this.txt_name);
            this.Controls.Add(this.lbl_Name);
            this.Name = "FormTest";
            this.Text = "Test";
            this.Load += new System.EventHandler(this.FormTest_Load);
            ((System.ComponentModel.ISupportInitialize)(this.result_chart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_Name;
        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.TextBox txt_Age;
        private System.Windows.Forms.Label lbl_age;
        private System.Windows.Forms.RadioButton rbtn_female;
        private System.Windows.Forms.RadioButton rbtn_male;
        private System.Windows.Forms.Label lbl_sex;
        private System.Windows.Forms.ComboBox combo_stephight;
        private System.Windows.Forms.Label lbl_stephigh;
        private System.Windows.Forms.Label lbl_results;
        private System.Windows.Forms.Label lbl_indication;
        private System.Windows.Forms.Label lbl_nxtresult;
        private System.Windows.Forms.TextBox txt_result;
        private System.Windows.Forms.Label lbl_age_error;
        private System.Windows.Forms.Label lbl_step_error;
        private System.Windows.Forms.Button btn_validate;
        private System.Windows.Forms.Label lbl_result_error;
        private System.Windows.Forms.Label lbl_result_explains;
        private System.Windows.Forms.DataVisualization.Charting.Chart result_chart;
    }
}