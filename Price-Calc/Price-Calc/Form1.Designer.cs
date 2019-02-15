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
            this.btnCalcPrice = new System.Windows.Forms.Button();
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
            // btnCalcPrice
            // 
            this.btnCalcPrice.Location = new System.Drawing.Point(915, 53);
            this.btnCalcPrice.Name = "btnCalcPrice";
            this.btnCalcPrice.Size = new System.Drawing.Size(134, 23);
            this.btnCalcPrice.TabIndex = 8;
            this.btnCalcPrice.Text = "Calculate Price";
            this.btnCalcPrice.UseVisualStyleBackColor = true;
            this.btnCalcPrice.Click += new System.EventHandler(this.btnCalcPrice_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1079, 533);
            this.Controls.Add(this.btnCalcPrice);
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
        private System.Windows.Forms.Button btnCalcPrice;
    }
}

