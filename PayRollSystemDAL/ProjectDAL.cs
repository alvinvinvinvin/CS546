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
    public class ProjectDAL
    {
        public Project ToModel(DataRow row)
        {
            Project prj = new Project();
            prj.projectID = (Guid)row["projectID"];
            prj.projectName = (string)row["projectName"];
            prj.startDate = (DateTime?)SqlHelper.FromDBValue(row["startDate"]);
            prj.dueDate = (DateTime?)SqlHelper.FromDBValue(row["dueDate"]);
            prj.cost = (decimal?)SqlHelper.FromDBValue(row["cost"]);
            return prj;
        }

        public Project[] listAll()
        {
            DataTable dtPrj = SqlHelper.ExecuteDataTable(@"select * from T_Project");
            Project[] prjs = new Project[dtPrj.Rows.Count];
            for (int i = 0; i < dtPrj.Rows.Count; i++ )
            {
                Project prj = ToModel(dtPrj.Rows[i]);
                prjs[i] = prj;
            }
            return prjs;
        }

        public Project getPrjbyName(string projectName)
        {
            DataTable dtPrj = SqlHelper.ExecuteDataTable(
                    @"select * from T_Project where projectName=@prjName",
                                new SqlParameter("@prjName",projectName));
            Project prj = ToModel(dtPrj.Rows[0]);
            return prj;
        }

        public int? countPeriod(Project prj)
        {
            DateTime? startDate = prj.startDate;
            DateTime? dueDate = prj.dueDate;
            DataTable dtDiff = SqlHelper.ExecuteDataTable(
                        @"select datediff(day, @startDate, @dueDate)",
                        new SqlParameter("@startDate",SqlHelper.ToDBValue(startDate)),
                        new SqlParameter("@dueDate",SqlHelper.ToDBValue(dueDate)));
            int? period = (int?)SqlHelper.FromDBValue(dtDiff.Rows[0][0]);
            return period/7;
        }

        public decimal? costInWage(Project prj)
        {
            DataTable dtEmpID = SqlHelper.ExecuteDataTable(
                  "@select employeeID from T_PrjParticipation where projectID=@prjID",
                  new SqlParameter("@prjID",SqlHelper.ToDBValue(prj.projectID)));
            Employee[] employees = new Employee[dtEmpID.Rows.Count];
            decimal? totalWage = 0;
            for (int i = 0; i < dtEmpID.Rows.Count; i++)
            {
                employees[i] = new EmployeeDAL().getByID((Guid)dtEmpID.Rows[0][i]);
                if (employees[i].AfterTaxWage == null)
                    employees[i].AfterTaxWage = 0;
                totalWage += employees[i].AfterTaxWage;
            }
            return totalWage;
        }

        public void insertPrj(Project prj)
        {
            SqlHelper.ExecuteNonQuery(@"insert into T_Project
                  (projectID, projectName, startDate, dueDate, cost)
                    values(@prjID, @prjName, @startDate, @dueDate, @cost)",
                     new SqlParameter("@prjID",prj.projectID),
                     new SqlParameter("@prjName",prj.projectName),
                     new SqlParameter("@startDate",SqlHelper.ToDBValue(prj.startDate)),
                     new SqlParameter("@dueDate",SqlHelper.ToDBValue(prj.dueDate)),
                     new SqlParameter("@cost",SqlHelper.ToDBValue(prj.cost)));
        }

        public void updatePrj(Project prj)
        {
            SqlHelper.ExecuteNonQuery(@"update T_Project set
                            projectName=@prjName,
                            startDate=@startDate,
                            dueDate=@dueDate,
                            cost=@cost",
                   new SqlParameter("@prjName",prj.projectName),
                   new SqlParameter("@startDate",SqlHelper.ToDBValue(prj.startDate)),
                   new SqlParameter("@dueDate",SqlHelper.ToDBValue(prj.dueDate)),
                   new SqlParameter("@cost",SqlHelper.ToDBValue(prj.cost)));
        }

        public void deletePrj(Project prj)
        {
            SqlHelper.ExecuteNonQuery(@"delete from T_Project where projectID=@prjID",
                    new SqlParameter("@prjID",prj.projectID));
        }

        public void addEmployeeToPrj(Project project, Employee employee)
        {
            SqlHelper.ExecuteNonQuery(@"insert into T_PrjParticipation
                                (participatingID, projectID, employeeID) 
                                values (newid(), @projectID, @employeeID)",
                                new SqlParameter("@projectID",project.projectID),
                                new SqlParameter("@employeeID",employee.ID));
        }
    }
}
