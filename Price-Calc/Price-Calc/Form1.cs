using ExcelDataReader;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Price_Calc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        DataSet result;
        DataSet result2;


        private void btnOpen1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Excel Workbook 97-2003|*.xls|Excel Workbook|*.xlsx", ValidateNames = true })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    FileStream fs = File.Open(ofd.FileName, FileMode.Open, FileAccess.Read);
                    IExcelDataReader reader = ExcelReaderFactory.CreateBinaryReader(fs);
                    result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true
                        }
                    });
                    cboOpen.Items.Clear();
                    foreach (System.Data.DataTable dt in result.Tables)
                        cboOpen.Items.Add(dt.TableName);
                    reader.Close();

                }
            }
        }

        private void cboOpen_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = result.Tables[cboOpen.SelectedIndex];
        }

        private void btnOpen2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Excel Workbook 97-2003|*.xls|Excel Workbook|*.xlsx", ValidateNames = true })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    FileStream fs = File.Open(ofd.FileName, FileMode.Open, FileAccess.Read);
                    IExcelDataReader reader = ExcelReaderFactory.CreateBinaryReader(fs);
                    result2 = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true
                        }
                    });
                    cboOpen2.Items.Clear();
                    foreach (System.Data.DataTable dt in result2.Tables)
                        cboOpen2.Items.Add(dt.TableName);
                    reader.Close();

                }
               
            }
        }

        private void cboOpen2_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView2.DataSource = result2.Tables[cboOpen2.SelectedIndex];
        }

        private void btnCalcPrice_Click(object sender, EventArgs e)
        {
            // - Displays the value in the data grid view at the particular cell. 
            //MessageBox.Show(this.btnCalcPrice.Text = dataGridView2[1, 2].Value.ToString()); 

            // Use a for loop go through and delete all SKUS that have an A,B,C, or D
            removeABSize();

            // Makes all Skus that are 4 in length 5 in length. Adds a 0 in from of any sku that only has 4 numbers. 
            skuSize();
            

            // compare the new Dataset to the supplier set. 
                // If there are any matches put that info(Entire Row) into a new data set. 



        }
        public void skuSize()
        {
            

            for (int i = 0; i < this.dataGridView2.RowCount-1; i++){
                // MessageBox.Show(this.btnCalcPrice.Text = dataGridView2[1, i].Value.ToString()+ this.dataGridView2.RowCount);
                int skuLength = dataGridView2.Rows[i].Cells["Custom SKU"].Value.ToString().Length;
               if (skuLength == 4)
                {
                    String newSku = "";

                    newSku = "0" + dataGridView2.Rows[i].Cells["Custom SKU"].Value.ToString();
                    dataGridView2.Rows[i].Cells["Custom SKU"].Value = newSku;
                    MessageBox.Show(newSku);
                   
                }
               

            }
            lblItemCount.Text = dataGridView2.RowCount.ToString();
        }

        public void removeABSize()
        {
            for (int i = 0; i < this.dataGridView2.RowCount - 1; i++)
            {
                String skuString = dataGridView2.Rows[i].Cells["Custom SKU"].Value.ToString();
                if(skuString.Length >= 6 && skuString[5] == 'A'|| skuString.Length >= 6 && skuString[5] == 'B'|| skuString.Length >= 6 && skuString[5] == 'C')
                {
                    //MessageBox.Show(dataGridView2.Rows[i].Cells["Custom SKU"].Value.ToString());
                    lblItemCount.Text = dataGridView2.RowCount.ToString();
                    dataGridView2.Rows.RemoveAt(i);
                    lblItemCount.Text = dataGridView2.RowCount.ToString();
                }
                else if(skuString.Length == 0)
                {
                    dataGridView2.Rows.RemoveAt(i);
                }
            }

            for(int j = 0; j < this.dataGridView2.RowCount - 1; j++)
            {
                String skuString = dataGridView2.Rows[j].Cells["Custom SKU"].Value.ToString();
              if (skuString.Length >= 6 && skuString[5] == 'A' || skuString.Length >= 6 && skuString[5] == 'B' || skuString.Length >= 6 && skuString[5] == 'C')
                {
                    j = 0;
                    removeABSize();
                }
            }
            
        }
    }
    
    
}

