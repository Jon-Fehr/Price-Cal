﻿using ExcelDataReader;
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

        // Creates two data sets and a datatable - these are used to store the information from the spreadsheets. 
        DataSet result;
        DataSet result2;
        DataTable finalDataTable = new DataTable("MyTable1");

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

            foreach (DataGridViewColumn column in dataGridView1.Columns)
            {
                finalDataTable.Columns.Add(column.Name, typeof(string));
            }
            

            calcCWTPrice();
            calcCFTPrice();
            calcCSFPrice();

            addSkus();
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
                        matches++;
                        lblMatches.Text = matches.ToString();
                        dataGridView2.Rows[k].DefaultCellStyle.BackColor = Color.LightGreen;
                        dataGridView1.Rows[j].DefaultCellStyle.BackColor = Color.LightGreen;
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
                // Convert markup function needed. 
                markup = Convert.ToInt32(tbMarkUp.Text);
                markup = (1 + (markup / 100));
            }
            catch
            {
                MessageBox.Show("You can only enter whole numbers as a markup.");
            }
            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                lBEach = Convert.ToDouble(dataGridView1.Rows[i].Cells["Lbs EA"].Value.ToString());
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
            double price;
            double materialCost;
            double markup = 0.0;

            try
            {
                // Convert markup function needed. 
                markup = Convert.ToInt32(tbMarkUp.Text);
                markup = (1 + (markup / 100));
            }
            catch
            {
                MessageBox.Show("You can only enter whole numbers as a markup.");
            }

            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                if (dataGridView1.Rows[i].Cells["UOM"].Value.ToString().ToLower() == "cft")
                {
                    materialCost = Convert.ToDouble(dataGridView1.Rows[i].Cells["Material Cost"].Value.ToString());

                    if (dataGridView1.Rows[i].Cells["Description"].Value.ToString().Contains("24\'")){
                        price = (.24 * materialCost * markup);
                        dataGridView1.Rows[i].Cells["Price"].Value = Math.Round(price, 2);
                    }
                    else if(dataGridView1.Rows[i].Cells["Description"].Value.ToString().Contains("20\'") || dataGridView1.Rows[i].Cells["Description"].Value.ToString().Contains(" 20R"))
                    {
                        price = (.2 * materialCost * markup);
                        dataGridView1.Rows[i].Cells["Price"].Value = Math.Round(price, 2);
                    }
                    else if(dataGridView1.Rows[i].Cells["Description"].Value.ToString().Contains("21\'"))
                    {
                        price = (.21 * materialCost * markup);
                        dataGridView1.Rows[i].Cells["Price"].Value = Math.Round(price, 2);
                    }
                    else if(dataGridView1.Rows[i].Cells["Description"].Value.ToString().Contains("40\'"))
                    {
                        price = (.4 * materialCost * markup);
                        dataGridView1.Rows[i].Cells["Price"].Value = Math.Round(price, 2);
                    }
                    else if (dataGridView1.Rows[i].Cells["Description"].Value.ToString().Contains("12\'"))
                    {
                        price = (.12 * materialCost * markup);
                        dataGridView1.Rows[i].Cells["Price"].Value = Math.Round(price, 2);
                    }
                }
            }
        }

        //Calculates all the priceing for the CSF items.
        
        public void calcCSFPrice() { 
            double price;
            double materialCost;
            double markup = 0.0;

            try
            { 
                // Convert markup function needed. 
                markup = Convert.ToInt32(tbMarkUp.Text);
                markup = (1 + (markup / 100));
            }
            catch
            {
                MessageBox.Show("You can only enter whole numbers as a markup.");
            }
        
            for (int i = 0; i < dataGridView1.RowCount - 1; i++)
            {
                String cellValue = dataGridView1.Rows[i].Cells["Description"].Value.ToString();
                Double newPrice = 0.0;
                try
                {
                    newPrice = Convert.ToDouble(dataGridView1.Rows[i].Cells["Price"].Value.ToString());
                }
                catch
                {
                    MessageBox.Show("Line number: " + i + " " + dataGridView1.Rows[i].Cells["Item #"].Value.ToString());
                }


                if (dataGridView1.Rows[i].Cells["UOM"].Value.ToString().ToLower() == "csf")
                {
                    materialCost = Convert.ToDouble(dataGridView1.Rows[i].Cells["Material Cost"].Value.ToString());

                    //4' Sheets
                    if (cellValue.Contains("4X8") || cellValue.Contains("4 X 8") || cellValue.Contains("4X 8") || cellValue.Contains("4 X8"))
                    {
                        price = .32 * materialCost * markup;
                        dataGridView1.Rows[i].Cells["Price"].Value = Math.Round(price, 2);
                    }
                    else if (cellValue.Contains("4X10") || cellValue.Contains("4 X 10") || cellValue.Contains("4X 10") ||  cellValue.Contains("4 X10"))
                    {
                        price = .40 * materialCost * markup;
                        dataGridView1.Rows[i].Cells["Price"].Value = Math.Round(price, 2);

                    }
                    else if (cellValue.Contains("4X12") || cellValue.Contains("4 X 12") || cellValue.Contains("4X 12") || cellValue.Contains("4 X12"))
                    {
                        price = .48 * materialCost * markup;
                        dataGridView1.Rows[i].Cells["Price"].Value = Math.Round(price, 2);
                    }

                    //5' Sheets
                    else if (cellValue.Contains("5X8") || cellValue.Contains("5 X 8") || cellValue.Contains("5X 8") || cellValue.Contains("5 X8"))
                    {
                        price = .45 * materialCost * markup;
                        dataGridView1.Rows[i].Cells["Price"].Value = Math.Round(price, 2);

                    }
                    else if (cellValue.Contains("5X10") || cellValue.Contains("5 X 10") || cellValue.Contains("5X 10") || cellValue.Contains("5 X10"))
                    {
                        price = .50 * materialCost * markup;
                        dataGridView1.Rows[i].Cells["Price"].Value = Math.Round(price, 2);
                    }
                    else if (cellValue.Contains("5X12") || cellValue.Contains("5 X 12") || cellValue.Contains("5X 12") || cellValue.Contains("5 X12"))
                    {
                        price = .60 * materialCost * markup;
                        dataGridView1.Rows[i].Cells["Price"].Value = Math.Round(price, 2);
                    }

                    //6' Sheets
                    else if (cellValue.Contains("6X8") || cellValue.Contains("6 X 8") || cellValue.Contains("6X 8") || cellValue.Contains("6 X8"))
                    {
                        price = .48 * materialCost * markup;
                        dataGridView1.Rows[i].Cells["Price"].Value = Math.Round(price, 2);
                    }
                    else if (cellValue.Contains("6X10") || cellValue.Contains("6 X 10") || cellValue.Contains("6X 10") || cellValue.Contains("6 X10"))
                    {
                        price = .60 * materialCost * markup;
                        dataGridView1.Rows[i].Cells["Price"].Value = Math.Round(price, 2);
                    }
                    else if (cellValue.Contains("6X12") || cellValue.Contains("6 X 12") || cellValue.Contains("6X 12") || cellValue.Contains("6 X12"))
                    {
                        price = .72 * materialCost * markup;
                        dataGridView1.Rows[i].Cells["Price"].Value = Math.Round(price, 2);
                    }
                }
            }
        }

        public void addSkus()
        {
            //Creates a new datatable and copies the column names over to it. 
            

            for (int i = 0; i < dataGridView1.RowCount -1; i++)
            {
                Console.Write(i + " " + dataGridView1.Rows[i].Cells["Price"].Value.ToString());
                String materialDescp = dataGridView1.Rows[i].Cells["Description"].Value.ToString();
                double newPrice = 0.0;
                try
                {
                   newPrice = Convert.ToDouble(dataGridView1.Rows[i].Cells["Price"].Value.ToString());
                }
                catch
                {
                    MessageBox.Show("Line number: " + i + " " + dataGridView1.Rows[i].Cells["Item #"].Value.ToString());
                }
                if (materialDescp.Contains("24\'"))
                {
                    // Pulls the price from the DGV then calculates the price
                    Double Price = Convert.ToDouble(dataGridView1.Rows[i].Cells["Price"].Value.ToString()) * .83;
                    Double PriceA = Price / 2;
                    Double PriceB = PriceA / 2;
                    // Pulls the description for the DGV then changes it so it can be assigned to the approprate SKU
                    String descriptionOrig = dataGridView1.Rows[i].Cells["Description"].Value.ToString();
                    String description = descriptionOrig.Replace("24\'" , " 20\'");
                    String descriptionA = descriptionOrig.Replace("24\'" , " 10\'");
                    String descriptionB = descriptionOrig.Replace("24\'" , " 5\'");

                    // Creates a new row and adds it to the new DataTable.
                    finalDataTable.Rows.Add("", dataGridView1.Rows[i].Cells["Item #"].Value.ToString(),description, "", "", "", Math.Round(Price, 2));
                    finalDataTable.Rows.Add("",dataGridView1.Rows[i].Cells["Item #"].Value.ToString() + "A", descriptionA,"","","", Math.Round(PriceA,2));
                    finalDataTable.Rows.Add("", dataGridView1.Rows[i].Cells["Item #"].Value.ToString() + "B", descriptionB, "", "", "", Math.Round(PriceB, 2));
                    finalDataTable.Rows.Add("", dataGridView1.Rows[i].Cells["Item #"].Value.ToString() + "C", descriptionOrig, "", "", "", dataGridView1.Rows[i].Cells["Price"].Value.ToString());                 
                }
                else if (materialDescp.Contains("20\'R") && materialDescp.Contains("DOM"))
                {
                    Double Price = Convert.ToDouble(dataGridView1.Rows[i].Cells["Price"].Value.ToString());
                    Double PriceD = Price / 40;
                    
                    String descriptionOrig = dataGridView1.Rows[i].Cells["Description"].Value.ToString();
                    String descriptionA = descriptionOrig.Replace("20\'", " 6\"");
                 
                    finalDataTable.Rows.Add("", dataGridView1.Rows[i].Cells["Item #"].Value.ToString(), descriptionOrig, "", "", "", Math.Round(Price, 2));
                    finalDataTable.Rows.Add("", dataGridView1.Rows[i].Cells["Item #"].Value.ToString() + "D", descriptionA, "", "", "", Math.Round(PriceD, 2));
                }
                else if (materialDescp.Contains("20\'"))
                {
                    Double Price = Convert.ToDouble(dataGridView1.Rows[i].Cells["Price"].Value.ToString());
                    Double PriceA = Price / 2;
                    Double PriceB = PriceA / 2;

                    String descriptionOrig = dataGridView1.Rows[i].Cells["Description"].Value.ToString();
                    String descriptionA = descriptionOrig.Replace("20\'", " 10\'");
                    String descriptionB = descriptionOrig.Replace("20\'", " 5\'");

                    finalDataTable.Rows.Add("", dataGridView1.Rows[i].Cells["Item #"].Value.ToString(), descriptionOrig, "", "", "", Math.Round(Price, 2));
                    finalDataTable.Rows.Add("", dataGridView1.Rows[i].Cells["Item #"].Value.ToString() + "A", descriptionA, "", "", "", Math.Round(PriceA, 2));
                    finalDataTable.Rows.Add("", dataGridView1.Rows[i].Cells["Item #"].Value.ToString() + "B", descriptionB, "", "", "", Math.Round(PriceB, 2));

                }
                else if (materialDescp.Contains("21\'"))
                {
                    Double Price = Convert.ToDouble(dataGridView1.Rows[i].Cells["Price"].Value.ToString());
                    Double PriceA = (.95 *  Price) / 2;
                    Double PriceB = PriceA / 2;

                    String descriptionOrig = dataGridView1.Rows[i].Cells["Description"].Value.ToString();
                    String descriptionA = descriptionOrig.Replace("21\'", " 10\'");
                    String descriptionB = descriptionOrig.Replace("21\'", " 5\'");

                    finalDataTable.Rows.Add("", dataGridView1.Rows[i].Cells["Item #"].Value.ToString(), descriptionOrig, "", "", "", Math.Round(Price, 2));
                    finalDataTable.Rows.Add("", dataGridView1.Rows[i].Cells["Item #"].Value.ToString() + "A", descriptionA, "", "", "", Math.Round(PriceA, 2));
                    finalDataTable.Rows.Add("", dataGridView1.Rows[i].Cells["Item #"].Value.ToString() + "B", descriptionB, "", "", "", Math.Round(PriceB, 2));
                }
                else if (materialDescp.Contains("21\'"))
                {
                    Double Price = Convert.ToDouble(dataGridView1.Rows[i].Cells["Price"].Value.ToString());
                    Double PriceA = (Price) / 2;
                    Double PriceB = PriceA / 2;

                    String descriptionOrig = dataGridView1.Rows[i].Cells["Description"].Value.ToString();
                    String descriptionA = descriptionOrig.Replace("12\'", " 6\'");
                    String descriptionB = descriptionOrig.Replace("12\'", " 3\'");

                    finalDataTable.Rows.Add("", dataGridView1.Rows[i].Cells["Item #"].Value.ToString(), descriptionOrig, "", "", "", Math.Round(Price, 2));
                    finalDataTable.Rows.Add("", dataGridView1.Rows[i].Cells["Item #"].Value.ToString() + "A", descriptionA, "", "", "", Math.Round(PriceA, 2));
                    finalDataTable.Rows.Add("", dataGridView1.Rows[i].Cells["Item #"].Value.ToString() + "B", descriptionB, "", "", "", Math.Round(PriceB, 2));
                }
                else if (materialDescp.Contains("40\'"))
                {
                    Double Price = Convert.ToDouble(dataGridView1.Rows[i].Cells["Price"].Value.ToString());

                    String descriptionOrig = dataGridView1.Rows[i].Cells["Description"].Value.ToString();

                    finalDataTable.Rows.Add("", dataGridView1.Rows[i].Cells["Item #"].Value.ToString(), descriptionOrig, "", "", "", Math.Round(Price, 2));
                }
            }
            //Updates the DGV to show the new datatable we have created with all the skus. 
            dataGridView1.DataSource = finalDataTable;
            dataGridView1.Columns["Class"].Visible = false;
            dataGridView1.Columns["LBs EA"].Visible = false;
            dataGridView1.Columns["Material Cost"].Visible = false;
            dataGridView1.Columns["UOM"].Visible = false;
            lblDG1RowCount.Text = dataGridView1.RowCount.ToString();
        }
    }
}



            