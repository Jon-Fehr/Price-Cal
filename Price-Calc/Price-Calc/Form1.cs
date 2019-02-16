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
            // Use a for loop go through and delete all SKUS that have an A,B,C, or D
            removeABSize();

            // Makes all Skus that are 4 in length 5 in length. Adds a 0 in from of any sku that only has 4 numbers. 
            skuSize();
            //Shows the number of rows we have in invantory. 
            lblItemCount.Text = dataGridView2.RowCount.ToString();
        }

        private void btnFindMatches_Click(object sender, EventArgs e)
        {

            // compare the new Dataset to the supplier set. 
            // If there are any matches put that info(Entire Row) into a new data set.
            compareDataSets();
        }

        public void skuSize()
        {


            for (int a = 0; a < dataGridView2.RowCount - 1; a++) {
                // Zeros are dropped infront of a sku from the store invantory list. This readds them, so the sku can be propperly matched to the suppliers
                // invantory list. 
                int skuLength = dataGridView2.Rows[a].Cells["Custom SKU"].Value.ToString().Length;
                if (skuLength == 4)
                {
                    String newSku = "";

                    newSku = "0" + dataGridView2.Rows[a].Cells["Custom SKU"].Value.ToString();
                    dataGridView2.Rows[a].Cells["Custom SKU"].Value = newSku;
                }


            }
            lblItemCount.Text = dataGridView2.RowCount.ToString();
        }

        public void removeABSize()
        {
            for (int b = 0; b < dataGridView2.RowCount - 1; b++)
            {
                //Runs through the dataset once and removes any sku that ends with an A,B,or C
                String skuString = dataGridView2.Rows[b].Cells["Custom SKU"].Value.ToString();
                if (skuString.Length >= 6 && skuString[5] == 'A' || skuString.Length >= 6 && skuString[5] == 'B' || skuString.Length >= 6 && skuString[5] == 'C'|| skuString.Length >= 6 && skuString[5] == 'D')
                {
                    dataGridView2.Rows.RemoveAt(b);

                }
                else if (skuString.Length == 0)
                {
                    dataGridView2.Rows.RemoveAt(b);
                }
            }

            for (int c = 0; c < dataGridView2.RowCount - 1; c++)
            {
                //Since you can't remove a row if it has been repositioned(row moved up because the one above it was deleted.) This runs through
                // the dataset to check if there are any skus that ends with an A,B,or C. If there are any it calls the remove funcution again. 
                // (Makes it so the rows aren't considered moved anymore so the sku can be deleted if needed.)
                String skuString = dataGridView2.Rows[c].Cells["Custom SKU"].Value.ToString();
                if (skuString.Length >= 6 && skuString[5] == 'A' || skuString.Length >= 6 && skuString[5] == 'B' || skuString.Length >= 6 && skuString[5] == 'C')
                {
                    c = 0;
                    removeABSize();
                }
            }
        }

        public void compareDataSets()
        {
            //Loops through the invantory dataset and looks to see if there is a match for the sku in the supplier data set. 

            int matches = 0;
            //This is the loop for the invantory data set.
            for (int k = 0; k < dataGridView2.RowCount - 1; k++)
            {
                //Loop that goes through the suppliers invantory
                for (int j = 0; j < dataGridView1.RowCount - 1; j++)
                {  
                    if (dataGridView2.Rows[k].Cells["Custom SKU"].Value.ToString() == dataGridView1.Rows[j].Cells["Item #"].Value.ToString())
                    {
                        matches++;
                        lblMatches.Text = matches.ToString();
                        //Make sure that all the cells are being checked. 
                        dataGridView2.Rows[k].DefaultCellStyle.BackColor = Color.Green;
                        j = 0;
                        k++;
                    }
                }
            }
        }
    

       
    }
    
    
}

