﻿
namespace Step_Test_Data
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_newEmptyTest = new System.Windows.Forms.Button();
            this.lst_current_Test = new System.Windows.Forms.ListBox();
            this.btn_open_current = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(118, 206);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(172, 100);
            this.button1.TabIndex = 0;
            this.button1.Text = "See previous tests";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(329, 397);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(304, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 39);
            this.label1.TabIndex = 2;
            this.label1.Text = "Step Test";
            // 
            // btn_newEmptyTest
            // 
            this.btn_newEmptyTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_newEmptyTest.Location = new System.Drawing.Point(523, 246);
            this.btn_newEmptyTest.Name = "btn_newEmptyTest";
            this.btn_newEmptyTest.Size = new System.Drawing.Size(176, 100);
            this.btn_newEmptyTest.TabIndex = 3;
            this.btn_newEmptyTest.Text = "New empty test";
            this.btn_newEmptyTest.UseVisualStyleBackColor = true;
            this.btn_newEmptyTest.Click += new System.EventHandler(this.btn_newEmptyTest_Click);
            // 
            // lst_current_Test
            // 
            this.lst_current_Test.FormattingEnabled = true;
            this.lst_current_Test.ItemHeight = 16;
            this.lst_current_Test.Location = new System.Drawing.Point(523, 103);
            this.lst_current_Test.Name = "lst_current_Test";
            this.lst_current_Test.Size = new System.Drawing.Size(176, 84);
            this.lst_current_Test.TabIndex = 5;
            // 
            // btn_open_current
            // 
            this.btn_open_current.Location = new System.Drawing.Point(523, 206);
            this.btn_open_current.Name = "btn_open_current";
            this.btn_open_current.Size = new System.Drawing.Size(176, 23);
            this.btn_open_current.TabIndex = 6;
            this.btn_open_current.Text = "Open selected test";
            this.btn_open_current.UseVisualStyleBackColor = true;
            this.btn_open_current.Click += new System.EventHandler(this.btn_open_current_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_open_current);
            this.Controls.Add(this.lst_current_Test);
            this.Controls.Add(this.btn_newEmptyTest);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_newEmptyTest;
        private System.Windows.Forms.ListBox lst_current_Test;
        private System.Windows.Forms.Button btn_open_current;
    }
}

