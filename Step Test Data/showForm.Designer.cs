
namespace Step_Test_Data
{
    partial class showForm
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
            this.GRIDVIEW_DisplayTest = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_search = new System.Windows.Forms.Label();
            this.txt_search = new System.Windows.Forms.TextBox();
            this.btn_delete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.GRIDVIEW_DisplayTest)).BeginInit();
            this.SuspendLayout();
            // 
            // GRIDVIEW_DisplayTest
            // 
            this.GRIDVIEW_DisplayTest.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.GRIDVIEW_DisplayTest.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.GRIDVIEW_DisplayTest.Location = new System.Drawing.Point(55, 71);
            this.GRIDVIEW_DisplayTest.Name = "GRIDVIEW_DisplayTest";
            this.GRIDVIEW_DisplayTest.RowHeadersWidth = 51;
            this.GRIDVIEW_DisplayTest.RowTemplate.Height = 24;
            this.GRIDVIEW_DisplayTest.Size = new System.Drawing.Size(761, 433);
            this.GRIDVIEW_DisplayTest.TabIndex = 0;
            this.GRIDVIEW_DisplayTest.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GRIDVIEW_CellClick);
            this.GRIDVIEW_DisplayTest.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.GRIDVIEW_DisplayTest_CellContentClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(252, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(332, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "Previous test carried out";
            // 
            // lbl_search
            // 
            this.lbl_search.AutoSize = true;
            this.lbl_search.Location = new System.Drawing.Point(55, 521);
            this.lbl_search.Name = "lbl_search";
            this.lbl_search.Size = new System.Drawing.Size(196, 17);
            this.lbl_search.TabIndex = 2;
            this.lbl_search.Text = "Search a test by participants :";
            // 
            // txt_search
            // 
            this.txt_search.Location = new System.Drawing.Point(258, 521);
            this.txt_search.Name = "txt_search";
            this.txt_search.Size = new System.Drawing.Size(226, 22);
            this.txt_search.TabIndex = 3;
            this.txt_search.TextChanged += new System.EventHandler(this.txt_search_TextChanged);
            // 
            // btn_delete
            // 
            this.btn_delete.Location = new System.Drawing.Point(710, 518);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(106, 23);
            this.btn_delete.TabIndex = 4;
            this.btn_delete.Text = "Delete test";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // showForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(868, 593);
            this.Controls.Add(this.btn_delete);
            this.Controls.Add(this.txt_search);
            this.Controls.Add(this.lbl_search);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.GRIDVIEW_DisplayTest);
            this.Name = "showForm";
            this.Text = "Display previous test";
            this.Load += new System.EventHandler(this.showForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.GRIDVIEW_DisplayTest)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView GRIDVIEW_DisplayTest;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lbl_search;
        private System.Windows.Forms.TextBox txt_search;
        private System.Windows.Forms.Button btn_delete;
    }
}