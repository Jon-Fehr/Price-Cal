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
    }
    
}
