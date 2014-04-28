using PayRollSystemModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayRollSystemDAL
{
    public class SalarySheetItemDAL
    {
        public SalarySheetItem ToModel(DataRow row)
        {
            SalarySheetItem item = new SalarySheetItem();
            item.SalarySheetItemID = (Guid)row["SalarySheetItemID"];
            item.SalarySheetID = (Guid)row["SalarySheetID"];
            item.EmployeeID = (Guid)row["EmployeeID"];
            item.BaseSalary = (decimal)row["BaseSalary"];
            item.Bonus = (decimal)row["Bonus"];
            item.Deduction = (decimal)row["Deduction"];
            item.AfterTaxWage = (decimal)row["AfterTaxWage"];
            return item;
        }
        public SalarySheetItem[] GetItemsByDate(int year, int month, Guid dptid)
        {
            DataTable tableSheet = SqlHelper.ExecuteDataTable(@"select * from T_SalarySheet
            where Year = @year and Month = @month and DepartmentID = @dptid",
                              new SqlParameter("@Year",year),
                              new SqlParameter("@month", month),
                              new SqlParameter("@dptid", dptid));
            if (tableSheet.Rows.Count == 1)
            {
                Guid SheetID = (Guid)tableSheet.Rows[0]["SalarySheetID"];
                DataTable tableItem = SqlHelper.ExecuteDataTable(@"select * from T_SalarySheetItem
                                    where SalarySheetID = @SalarySheetItem",
                                    new SqlParameter("@SalarySheetItem", SheetID));
                SalarySheetItem[] Items = new SalarySheetItem[tableItem.Rows.Count];
                for (int i = 0; i < tableItem.Rows.Count; i++)
                {
                    Items[i] = ToModel(tableItem.Rows[i]);
                }
                return Items;
            }
            else if (tableSheet.Rows.Count <= 0)
            {
                return new SalarySheetItem[0];
            }
            else
            {
                throw new Exception("");
            }
        }
    }
}
