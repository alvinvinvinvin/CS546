using PayRollSystemModel;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayRollSystemDAL
{
    public class SalarySheetDAL
    {
        public bool IsExisted(int year, int month, Guid dptId)
        {
            object obj =
                    SqlHelper.ExecuteScalar(@"select count(*) from T_SalarySheet 
                    where Year = @Year and Month = @Month and DepartmentID = @dptId",
                                     new SqlParameter("@Year", year),
                                     new SqlParameter("@Month", month),
                                     new SqlParameter("@dptId", dptId));
            return Convert.ToInt32(obj) > 0;
        }
        // clear exsited salarysheet
        public void Clear(int year, int month, Guid dptId)
        {
            object obj =
                    SqlHelper.ExecuteScalar(@"select SalarySheetID from T_SalarySheet 
                    where Year = @Year and Month = @Month and DepartmentID = @dptId",
                             new SqlParameter("@Year", year),
                             new SqlParameter("@Month", month),
                             new SqlParameter("@dptId", dptId));
            Guid sheetID = (Guid)obj;
            //delete item first then sheet
            SqlHelper.ExecuteNonQuery(@"delete from T_SalarySheetItem 
                                        where SalarySheetID = @SalarySheetID",
                            new SqlParameter("@SalarySheetID", sheetID));
            SqlHelper.ExecuteNonQuery(@"delete from T_SalarySheet where SalarySheetID = @SalarySheetID",
                            new SqlParameter("@SalarySheetID", sheetID));

        }
        public void Generate(int year, int month, Guid dptId)
        {

            Guid sheetID = Guid.NewGuid();
            SqlHelper.ExecuteNonQuery(@"insert into 
                                    T_SalarySheet(SalarySheetID,Year,Month,DepartmentID) 
                                    values(@SalarySheetID,@Year,@Month,@DepartmentID)",
                                    new SqlParameter("@SalarySheetID", sheetID),
                                    new SqlParameter("@Year", year),
                                    new SqlParameter("@Month", month),
                                    new SqlParameter("@DepartmentID", dptId));
            Employee[] employees = new EmployeeDAL().SearchByDpt(dptId);
            foreach (Employee employee in employees)
            {
                SqlHelper.ExecuteNonQuery(@"insert into 
                T_SalarySheetItem(SalarySheetItemID,SalarySheetID,EmployeeID,BaseSalary,Bonus,Deduction,AfterTaxWage) 
                values(newid(),@SalarySheetID,@EmployeeID,0,0,0,0)",
                 new SqlParameter("@SalarySheetID", sheetID),
                 new SqlParameter("@EmployeeID", employee.ID));
            }

        }
        public void Update(SalarySheetItem item)
        {
            SqlHelper.ExecuteNonQuery(@"Update T_SalarySheetItem set 
                                        BaseSalary = @BaseSalary, 
                                        Bonus = @Bonus, 
                                        Deduction = @Deduction,
                                        AfterTaxWage = @AfterTaxWage
                                        where SalarySheetItemID = @SalarySheetItemID",
                                 new SqlParameter("@BaseSalary",SqlHelper.ToDBValue( item.BaseSalary)),
                                 new SqlParameter("@Bonus",SqlHelper.ToDBValue( item.Bonus)),
                                 new SqlParameter("@Deduction",SqlHelper.ToDBValue( item.Deduction)),
                                 new SqlParameter("@AfterTaxWage",SqlHelper.ToDBValue( item.AfterTaxWage)),
                                 new SqlParameter("@SalarySheetItemID",item.SalarySheetItemID));
            EmployeeDAL employDAL = new EmployeeDAL();
            employDAL.UpdateEmployeeSalarys(item);
            
        }

    }
}
