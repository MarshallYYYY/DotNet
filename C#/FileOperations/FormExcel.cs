using System;
using System.IO;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop.Excel;


namespace FileOperations
{
    public partial class FormExcel : Form
    {
        public FormExcel()
        {
            InitializeComponent();
        }
        private readonly string path = Path.Combine(@"C:\Users\YYYXB\Desktop\", "Test.xlsx");
        private void BtnWriteExcel_Click(object sender, EventArgs e)
        {
            double[,] data = new double[5, 5];
            WriteExcel(data, path);
        }
        private void WriteExcel(double[,] data, string path)
        {
            Excel.Application app = new Excel.Application();
            Workbook workbook = app.Workbooks.Add(true);
            Worksheet worksheet = workbook.Sheets[1];
            //激活worksheet
            worksheet.Activate();

            //将二维数组中的数据写入worksheet这个sheet
            for (int i = 0; i < data.GetLength(0); i++)
                for (int j = 0; j < data.GetLength(1); j++)
                    worksheet.Cells[i + 1, j + 1] = data[i, j].ToString();

            //将workbook另存为path
            workbook.SaveAs(path);
            //关闭workbook
            workbook.Close();
            //退出Excel程序
            app.Quit();
        }

        private void BtnReadExcel_Click(object sender, EventArgs e)
        {
            ReadExcel(path);

        }
        private void ReadExcel(string path)
        {
            Excel.Application app = new Excel.Application();
            Workbook workbook = app.Workbooks.Add(path);
            //app.Visible = true;

            Worksheet sheet = workbook.Sheets[1];
            sheet.Activate();
            MessageBox.Show(
                $"打开了{sheet.Name}\n" +
                $"本sheet共有{sheet.Rows.Count}行，{sheet.Columns.Count}列");

            string result = "";
            Range region = sheet.UsedRange.CurrentRegion;
            for (int i = 0; i < region.Rows.Count; i++)
            {
                for (int j = 0; j < region.Columns.Count; j++)
                    result += $"{sheet.Cells[i + 1, j + 1].Text} ";
                result += "\n";
            }
            MessageBox.Show(result);
            workbook.Close();
            app.Quit();
        }
    }
}
