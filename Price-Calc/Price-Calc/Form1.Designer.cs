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
            this.btnFindMatches = new System.Windows.Forms.Button();
            this.btnRmvSkus = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lblDG1RowCount = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(468, 11);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(84, 13);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Price Calculator ";
            // 
            // btnOpen1
            // 
            this.btnOpen1.Location = new System.Drawing.Point(29, 42);
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
            this.cboOpen.Location = new System.Drawing.Point(163, 53);
            this.cboOpen.Name = "cboOpen";
            this.cboOpen.Size = new System.Drawing.Size(188, 21);
            this.cboOpen.TabIndex = 2;
            this.cboOpen.SelectedIndexChanged += new System.EventHandler(this.cboOpen_SelectedIndexChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(29, 104);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(484, 410);
            this.dataGridView1.TabIndex = 3;
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(546, 104);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(500, 409);
            this.dataGridView2.TabIndex = 4;
            // 
            // cboOpen2
            // 
            this.cboOpen2.FormattingEnabled = true;
            this.cboOpen2.Location = new System.Drawing.Point(680, 53);
            this.cboOpen2.Name = "cboOpen2";
            this.cboOpen2.Size = new System.Drawing.Size(188, 21);
            this.cboOpen2.TabIndex = 6;
            this.cboOpen2.SelectedIndexChanged += new System.EventHandler(this.cboOpen2_SelectedIndexChanged);
            // 
            // btnOpen2
            // 
            this.btnOpen2.Location = new System.Drawing.Point(546, 42);
            this.btnOpen2.Name = "btnOpen2";
            this.btnOpen2.Size = new System.Drawing.Size(128, 32);
            this.btnOpen2.TabIndex = 7;
            this.btnOpen2.Text = "Yakesh Inv Sheet";
            this.btnOpen2.UseVisualStyleBackColor = true;
            this.btnOpen2.Click += new System.EventHandler(this.btnOpen2_Click);
            // 
            // btnFormatList
            // 
            this.btnFormatList.Location = new System.Drawing.Point(1063, 104);
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
            this.label1.Location = new System.Drawing.Point(1060, 140);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Item Count:";
            // 
            // lblItemCount
            // 
            this.lblItemCount.AutoSize = true;
            this.lblItemCount.Location = new System.Drawing.Point(1184, 140);
            this.lblItemCount.Name = "lblItemCount";
            this.lblItemCount.Size = new System.Drawing.Size(13, 13);
            this.lblItemCount.TabIndex = 10;
            this.lblItemCount.Text = "0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1060, 233);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "matches found:";
            // 
            // lblMatches
            // 
            this.lblMatches.AutoSize = true;
            this.lblMatches.Location = new System.Drawing.Point(1184, 233);
            this.lblMatches.Name = "lblMatches";
            this.lblMatches.Size = new System.Drawing.Size(13, 13);
            this.lblMatches.TabIndex = 12;
            this.lblMatches.Text = "0";
            // 
            // btnFindMatches
            // 
            this.btnFindMatches.Location = new System.Drawing.Point(1063, 181);
            this.btnFindMatches.Name = "btnFindMatches";
            this.btnFindMatches.Size = new System.Drawing.Size(134, 23);
            this.btnFindMatches.TabIndex = 13;
            this.btnFindMatches.Text = "Find matches";
            this.btnFindMatches.UseVisualStyleBackColor = true;
            this.btnFindMatches.Click += new System.EventHandler(this.btnFindMatches_Click);
            // 
            // btnRmvSkus
            // 
            this.btnRmvSkus.Location = new System.Drawing.Point(1063, 272);
            this.btnRmvSkus.Name = "btnRmvSkus";
            this.btnRmvSkus.Size = new System.Drawing.Size(134, 23);
            this.btnRmvSkus.TabIndex = 14;
            this.btnRmvSkus.Text = "Remove Unneeded ";
            this.btnRmvSkus.UseVisualStyleBackColor = true;
            this.btnRmvSkus.Click += new System.EventHandler(this.btnRmvSkus_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1063, 315);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "DG1 row Count:";
            // 
            // lblDG1RowCount
            // 
            this.lblDG1RowCount.AutoSize = true;
            this.lblDG1RowCount.Location = new System.Drawing.Point(1162, 315);
            this.lblDG1RowCount.Name = "lblDG1RowCount";
            this.lblDG1RowCount.Size = new System.Drawing.Size(13, 13);
            this.lblDG1RowCount.TabIndex = 16;
            this.lblDG1RowCount.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1784, 629);
            this.Controls.Add(this.lblDG1RowCount);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnRmvSkus);
            this.Controls.Add(this.btnFindMatches);
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
            this.Text = "Form1";
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
        private System.Windows.Forms.Button btnFindMatches;
        private System.Windows.Forms.Button btnRmvSkus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblDG1RowCount;
    }
}

