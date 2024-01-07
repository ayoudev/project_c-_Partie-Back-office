using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
//using Microsoft.Office.Interop.Excel;

namespace Projet3.Model
{
    public class ExportExel
    {
        public ExportExel(DataGrid datagrid, DateTime dt)
        {
            Microsoft.Office.Interop.Excel.Application application = new Microsoft.Office.Interop.Excel.Application();
            application.Visible = true;
            Worksheet sheet = application.Workbooks.Add(Missing.Value).Sheets[1];
            //sheet.Range["A1:C1"].Merge();
            //sheet.Range["A2:C2"].Merge();

            string titre = "Sample Liste in ExcelSheet";
            //sheet.Range["A1:C1"].Value = titre;
            //sheet.Range["A1:C1"].Font.Bold = true;
            //sheet.Range["A1:C2"].Value = dt.ToShortDateString();

            // Set column headers
            for (int j = 0; j < datagrid.Columns.Count; j++)
            {
                Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet.Cells[2, j + 1];
                myRange.Font.Bold = true;
                string header = datagrid.Columns[j].Header.ToString();

                sheet.Columns[j + 1].ColumnWidth = header.Length + 5; // Adjust column width
                myRange.Value2 = header;
            }


            // Populate data
            // Populate data
            for (int j = 0; j < datagrid.Items.Count; j++)
            {
                var item = datagrid.Items[j] as Adherents;

                if (item != null)
                {
                    sheet.Cells[j + 3, 1].Value = item.AdherentID;
                    sheet.Cells[j + 3, 2].Value = item.Nom;
                    sheet.Cells[j + 3, 3].Value = item.Prenom;
                    sheet.Cells[j + 3, 4].Value = item.telephone;
                    sheet.Cells[j + 3, 5].Value = item.adresse;
                    sheet.Cells[j + 3, 6].Value = item.Email;
                }
                else
                {
                    // Handle the case where item is null, if needed.
                    // For example, you can skip the row or log a message.
                }
            }

        }

    }
}
