namespace Price_Calc
{
    partial class Form1
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnOpen1 = new System.Windows.Forms.Button();
            this.cboOpen = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.cboOpen2 = new System.Windows.Forms.ComboBox();
            this.btnOpen2 = new System.Windows.Forms.Button();
            this.btnFormatList = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblItemCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblMatches = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblDG1RowCount = new System.Windows.Forms.Label();
            this.btnCalcPrices = new System.Windows.Forms.Button();
            this.tbMarkUp = new System.Windows.Forms.TextBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(798, 6);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(84, 13);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Price Calculator ";
            // 
            // btnOpen1
            // 
            this.btnOpen1.Location = new System.Drawing.Point(12, 66);
            this.btnOpen1.Name = "btnOpen1";
            this.btnOpen1.Size = new System.Drawing.Size(128, 32);
            this.btnOpen1.TabIndex = 1;
            this.btnOpen1.Text = "Supplier Inv Sheet";
            this.btnOpen1.UseVisualStyleBackColor = true;
            this.btnOpen1.Click += new System.EventHandler(this.btnOpen1_Click);
            // 
            // cboOpen
            // 
            this.cboOpen.FormattingEnabled = true;
            this.cboOpen.Location = new System.Drawing.Point(146, 77);
            this.cboOpen.Name = "cboOpen";
            this.cboOpen.Size = new System.Drawing.Size(188, 21);
            this.cboOpen.TabIndex = 2;
            this.cboOpen.SelectedIndexChanged += new System.EventHandler(this.cboOpen_SelectedIndexChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 104);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(820, 410);
            this.dataGridView1.TabIndex = 3;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(856, 104);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(916, 409);
            this.dataGridView2.TabIndex = 4;
            // 
            // cboOpen2
            // 
            this.cboOpen2.FormattingEnabled = true;
            this.cboOpen2.Location = new System.Drawing.Point(990, 77);
            this.cboOpen2.Name = "cboOpen2";
            this.cboOpen2.Size = new System.Drawing.Size(188, 21);
            this.cboOpen2.TabIndex = 6;
            this.cboOpen2.SelectedIndexChanged += new System.EventHandler(this.cboOpen2_SelectedIndexChanged);
            // 
            // btnOpen2
            // 
            this.btnOpen2.Location = new System.Drawing.Point(856, 66);
            this.btnOpen2.Name = "btnOpen2";
            this.btnOpen2.Size = new System.Drawing.Size(128, 32);
            this.btnOpen2.TabIndex = 7;
            this.btnOpen2.Text = "Yakesh Inv Sheet";
            this.btnOpen2.UseVisualStyleBackColor = true;
            this.btnOpen2.Click += new System.EventHandler(this.btnOpen2_Click);
            // 
            // btnFormatList
            // 
            this.btnFormatList.Location = new System.Drawing.Point(12, 520);
            this.btnFormatList.Name = "btnFormatList";
            this.btnFormatList.Size = new System.Drawing.Size(134, 23);
            this.btnFormatList.TabIndex = 8;
            this.btnFormatList.Text = "Format List";
            this.btnFormatList.UseVisualStyleBackColor = true;
            this.btnFormatList.Click += new System.EventHandler(this.btnCalcPrice_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(236, 530);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Item Count:";
            // 
            // lblItemCount
            // 
            this.lblItemCount.AutoSize = true;
            this.lblItemCount.Location = new System.Drawing.Point(355, 530);
            this.lblItemCount.Name = "lblItemCount";
            this.lblItemCount.Size = new System.Drawing.Size(13, 13);
            this.lblItemCount.TabIndex = 10;
            this.lblItemCount.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(236, 565);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Matches Found:";
            // 
            // lblMatches
            // 
            this.lblMatches.AutoSize = true;
            this.lblMatches.Location = new System.Drawing.Point(355, 565);
            this.lblMatches.Name = "lblMatches";
            this.lblMatches.Size = new System.Drawing.Size(13, 13);
            this.lblMatches.TabIndex = 12;
            this.lblMatches.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(236, 607);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "DG1 row Count:";
            // 
            // lblDG1RowCount
            // 
            this.lblDG1RowCount.AutoSize = true;
            this.lblDG1RowCount.Location = new System.Drawing.Point(355, 607);
            this.lblDG1RowCount.Name = "lblDG1RowCount";
            this.lblDG1RowCount.Size = new System.Drawing.Size(13, 13);
            this.lblDG1RowCount.TabIndex = 16;
            this.lblDG1RowCount.Text = "0";
            // 
            // btnCalcPrices
            // 
            this.btnCalcPrices.Location = new System.Drawing.Point(12, 597);
            this.btnCalcPrices.Name = "btnCalcPrices";
            this.btnCalcPrices.Size = new System.Drawing.Size(131, 23);
            this.btnCalcPrices.TabIndex = 17;
            this.btnCalcPrices.Text = "Calculate Prices";
            this.btnCalcPrices.UseVisualStyleBackColor = true;
            this.btnCalcPrices.Click += new System.EventHandler(this.btnCalcPrices_Click);
            // 
            // tbMarkUp
            // 
            this.tbMarkUp.Location = new System.Drawing.Point(12, 558);
            this.tbMarkUp.Name = "tbMarkUp";
            this.tbMarkUp.Size = new System.Drawing.Size(134, 20);
            this.tbMarkUp.TabIndex = 18;
            this.tbMarkUp.Text = "Percent Markup Here";
            this.tbMarkUp.Enter += new System.EventHandler(this.tbMarkUp_Enter);
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(117, 654);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(143, 21);
            this.btnExport.TabIndex = 20;
            this.btnExport.Text = "Export to Excel";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(467, 558);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(657, 13);
            this.label4.TabIndex = 21;
            this.label4.Text = "1.  Click on Supplier Inv Sheet button. From there locate the spreadsheet from yo" +
    "ur supplier. You will need to add a column called \"Price\". ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(467, 525);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(252, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "To use this calculator please follow the steps below.";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(467, 571);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(300, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "2. Click the Yakesh Inv List button and do the same as step 1.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(467, 624);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 13);
            this.label7.TabIndex = 24;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(467, 584);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(439, 13);
            this.label8.TabIndex = 25;
            this.label8.Text = "3. Click on both files from the drop down list by the buttons(One file is in each" +
    " drop down list)";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(467, 597);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(150, 13);
            this.label9.TabIndex = 26;
            this.label9.Text = "4. Click the Format List button.";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(467, 610);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(331, 13);
            this.label10.TabIndex = 27;
            this.label10.Text = "5. Enter a whole number in the percent markup text box(example: 40)";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(467, 624);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(416, 13);
            this.label11.TabIndex = 28;
            this.label11.Text = "6. Click the calculate button to generate skus based on the Yakesh Steel invantor" +
    "y list.";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(467, 637);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(263, 13);
            this.label12.TabIndex = 29;
            this.label12.Text = "7. If you want to export this list click the export button. ";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(467, 662);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(271, 13);
            this.label13.TabIndex = 30;
            this.label13.Text = "All button will turn green when the task at hand is done. ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(1784, 708);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.tbMarkUp);
            this.Controls.Add(this.btnCalcPrices);
            this.Controls.Add(this.lblDG1RowCount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lblMatches);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblItemCount);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnFormatList);
            this.Controls.Add(this.btnOpen2);
            this.Controls.Add(this.cboOpen2);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cboOpen);
            this.Controls.Add(this.btnOpen1);
            this.Controls.Add(this.lblTitle);
            this.Name = "Form1";
            this.Text = "Yakesh Steel Price Calculator";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button btnOpen1;
        private System.Windows.Forms.ComboBox cboOpen;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.ComboBox cboOpen2;
        private System.Windows.Forms.Button btnOpen2;
        private System.Windows.Forms.Button btnFormatList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblItemCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblMatches;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblDG1RowCount;
        private System.Windows.Forms.Button btnCalcPrices;
        private System.Windows.Forms.TextBox tbMarkUp;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
    }
}

