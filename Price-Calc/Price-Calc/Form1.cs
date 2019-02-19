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
                    try
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
                    catch
                    {
                        MessageBox.Show("You are currently trying to use a file you have open. Please close this file and try again.");
                    }
                }
            }
        }

        private void cboOpen_SelectedIndexChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = result.Tables[cboOpen.SelectedIndex];
            lblDG1RowCount.Text = dataGridView1.RowCount.ToString();
        }

        private void btnOpen2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Excel Workbook 97-2003|*.xls|Excel Workbook|*.xlsx", ValidateNames = true })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
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
                    catch
                    {
                        MessageBox.Show("You are currently trying to use a file you have open. Please close this file and try again.");
                    }
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

        private void btnRmvSkus_Click(object sender, EventArgs e)
        {
            removeUnusedSku();
        }

        private void btnCalcPrices_Click(object sender, EventArgs e)
        {
            calcCWTPrice();
        }

        public void skuSize()
        {
            for (int a = 0; a < dataGridView2.RowCount - 1; a++)
            {
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
            // This forloop runs from the end to the start. This avoids the issues of trying to delete a cell that just had data put into it.
            for (int b = dataGridView2.RowCount - 2; b >= 0; b--)
            {
                //Runs through the dataset once and removes any sku that ends with an A,B,or C or has an empty cell for the SKU number.
                String skuString = dataGridView2.Rows[b].Cells["Custom SKU"].Value.ToString();
                if (skuString.Length >= 6 && skuString[5] == 'A' || skuString.Length >= 6 && skuString[5] == 'B' || skuString.Length >= 6 && skuString[5] == 'C' || skuString.Length >= 6 && skuString[5] == 'D')
                {
                    dataGridView2.Rows.RemoveAt(b);
                }
                else if (skuString.Length == 0)
                {
                    dataGridView2.Rows.RemoveAt(b);
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
                for (int j = dataGridView1.RowCount - 2; j >= 0; j--)
                {
                    // MessageBox.Show("enter for "+ dataGridView1.RowCount + " DG1 " + dataGridView1.Rows[j].Cells["Item #"].Value.ToString()+ " DG2 " + dataGridView2.Rows[k].Cells["Custom SKU"].Value.ToString());
                    if (dataGridView2.Rows[k].Cells["Custom SKU"].Value.ToString() == dataGridView1.Rows[j].Cells["Item #"].Value.ToString())
                    {
                        // MessageBox.Show("enter if");
                        matches++;
                        lblMatches.Text = matches.ToString();
                        //Make sure that all the cells are being checked. 
                        dataGridView2.Rows[k].DefaultCellStyle.BackColor = Color.Green;
                        dataGridView1.Rows[j].DefaultCellStyle.BackColor = Color.Green;
                    }
                }

            }
        }

        public void removeUnusedSku()
        {
            for (int j = dataGridView1.RowCount - 2; j >= 0; j--)
            {
                if (dataGridView1.Rows[j].DefaultCellStyle.BackColor != dataGridView1.Rows[0].DefaultCellStyle.BackColor)
                {
                    dataGridView1.Rows.RemoveAt(j);
                }
            }
            dataGridView1.Refresh();
            lblDG1RowCount.Text = dataGridView1.RowCount.ToString();
        }

        //Calculates all the priceing for the CWT items.
        //Needs to create new skus based on the old ones for half and quater sizes. (10' and 5' pieces)
        public void calcCWTPrice()
        {

            double lBEach;
            double price;
            double materialCost;
            double markup = 0.0;
            
            try{
                markup = Convert.ToInt32(tbMarkUp.Text);
                MessageBox.Show(markup.ToString());
                markup = (1 + (markup / 100));
                MessageBox.Show(markup.ToString());
            }
            catch
            {
                MessageBox.Show("You can only enter whole numbers as a markup.");
            }
            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                lBEach = Convert.ToDouble(dataGridView1.Rows[i].Cells["Lbs EA"].Value.ToString());
                // price = Convert.ToDouble(dataGridView1.Rows[i].Cells["Price"].Value.ToString());
                materialCost = Convert.ToDouble(dataGridView1.Rows[i].Cells["Material Cost"].Value.ToString());

                if (dataGridView1.Rows[i].Cells["UOM"].Value.ToString().ToLower() == "cwt")
                {
                    price = lBEach / 100 * materialCost * markup;
                    dataGridView1.Rows[i].Cells["Price"].Value = Math.Round(price,2);


                }
            }
        }

        //Calculates all the priceing for the CFT items.
        //Needs to create new skus based on the old ones for half and quater sizes. (24' 20' 10' and 5' pieces)
        public void calcCFTPrice()
        {
            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                if (dataGridView1.Rows[i].Cells["UOM"].Value.ToString().ToLower() == "cft")
                {
                    MessageBox.Show("calculate price here.");
                }
            }
        }

        //Calculates all the priceing for the CSF items.
        
        public void calcCSFPrice()
        {
            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                if (dataGridView1.Rows[i].Cells["UOM"].Value.ToString().ToLower() == "csf")
                {
                    MessageBox.Show("calculate price here.");
                }
            }
        }


    }
}



            