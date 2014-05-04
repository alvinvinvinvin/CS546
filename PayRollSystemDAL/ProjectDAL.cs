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
            prj.costinwage = (decimal?)SqlHelper.FromDBValue(row["costinwage"]);
            prj.costinother = (decimal?)SqlHelper.FromDBValue(row["costinother"]);
            prj.cost = (decimal?)SqlHelper.FromDBValue(row["cost"]);
            prj.description = (string)SqlHelper.FromDBValue(row["description"]);
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

            Employee[] employees = listAllParticipators(prj);
            decimal? totalWage = 0;
            for (int i = 0; i < employees.Length; i++)
            {
                totalWage += employees[i].AfterTaxWage;
            }
            return totalWage;

            //DataTable dtEmpID = SqlHelper.ExecuteDataTable(
            //      "@select employeeID from T_PrjParticipation where projectID=@prjID",
            //      new SqlParameter("@prjID",SqlHelper.ToDBValue(prj.projectID)));
            //Employee[] employees = new Employee[dtEmpID.Rows.Count];
            //decimal? totalWage = 0;
            //for (int i = 0; i < dtEmpID.Rows.Count; i++)
            //{
            //    employees[i] = new EmployeeDAL().getByID((Guid)dtEmpID.Rows[0][i]);
            //    if (employees[i].AfterTaxWage == null)
            //        employees[i].AfterTaxWage = 0;
            //    totalWage += employees[i].AfterTaxWage;
            //}
            //return totalWage;
        }

        public void insertPrj(Project prj)
        {
            SqlHelper.ExecuteNonQuery(@"insert into T_Project
                  (projectID, projectName, startDate, dueDate, costinwage, costinother, cost, description)
                    values(@prjID, @prjName, @startDate, @dueDate, @costinwage, @costinother, @cost, @description)",
                     new SqlParameter("@prjID",prj.projectID),
                     new SqlParameter("@prjName",prj.projectName),
                     new SqlParameter("@startDate",SqlHelper.ToDBValue(prj.startDate)),
                     new SqlParameter("@dueDate",SqlHelper.ToDBValue(prj.dueDate)),
                     new SqlParameter("@costinwage", SqlHelper.ToDBValue(prj.costinwage)),
                     new SqlParameter("@costinother", SqlHelper.ToDBValue(prj.costinother)),
                     new SqlParameter("@cost",SqlHelper.ToDBValue(prj.cost)),
                     new SqlParameter("@description",SqlHelper.ToDBValue(prj.description)));
        }

        public void updatePrj(Project prj)
        {
            SqlHelper.ExecuteNonQuery(@"update T_Project set
                            projectName=@prjName,
                            startDate=@startDate,
                            dueDate=@dueDate,
                            costinwage=@costinwage,
                            costinother=@costinother,
                            cost=@cost,
                            description=@description",
                   new SqlParameter("@prjName",prj.projectName),
                   new SqlParameter("@startDate",SqlHelper.ToDBValue(prj.startDate)),
                   new SqlParameter("@dueDate",SqlHelper.ToDBValue(prj.dueDate)),
                   new SqlParameter("@costinwage", SqlHelper.ToDBValue(prj.costinwage)),
                   new SqlParameter("@costinother", SqlHelper.ToDBValue(prj.costinother)),
                   new SqlParameter("@cost",SqlHelper.ToDBValue(prj.cost)),
                   new SqlParameter("@description",SqlHelper.ToDBValue(prj.description)));
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

        public bool IsParticipatorExisted(Project project, Employee employee)
        {
            object obj = SqlHelper.ExecuteScalar(@"select * from T_PrjParticipation 
                            where projectID=@prjID and employeeID=@empID",
                            new SqlParameter("@projectID", project.projectID),
                            new SqlParameter("@employeeID", employee.ID));
            return Convert.ToInt32(obj) > 0;
        }

        public Employee[] listAllParticipators(Project prj)
        {
            DataTable dtEmpID = SqlHelper.ExecuteDataTable(
                  @"select employeeID from T_PrjParticipation where projectID=@prjID",
                  new SqlParameter("@prjID",SqlHelper.ToDBValue(prj.projectID)));
            Employee[] employees = new Employee[dtEmpID.Rows.Count];
            for (int i = 0; i < dtEmpID.Rows.Count; i++)
            {
                employees[i] = new EmployeeDAL().getByID((Guid)dtEmpID.Rows[i][0]);
            }
            return employees;
        }

        public Employee[] listDepartmentParticipators(Project prj, Department dpt)
        {
            DataTable dtEmpID = SqlHelper.ExecuteDataTable(@"select employeeID 
            from T_PrjParticipation where projectID=@prjID and departmentID=@dptID",
            new SqlParameter("@prjID",prj.projectID),
            new SqlParameter("@dptID",dpt.DepartmentID));
            Employee[] employees = new Employee[dtEmpID.Rows.Count];
            for (int i = 0; i < dtEmpID.Rows.Count; i++)
            {
                employees[i] = new EmployeeDAL().getByID((Guid)dtEmpID.Rows[i][0]);
            }
            return employees;
        }

        public Department[] listAssignedDepartment(Project prj)
        {
            DataTable dtDptID = SqlHelper.ExecuteDataTable(@"select departmentID 
            from T_PrjDptParticipation where projectID=@prjID",
            new SqlParameter("@prjID", prj.projectID));
            Department[] dpts = new Department[dtDptID.Rows.Count];
            for (int i = 0; i < dtDptID.Rows.Count; i++)
            {
                dpts[i] = new DepartmentDAL().getByID((Guid)dtDptID.Rows[i][0]);
            }
            return dpts;
        }

        public bool isDepartmentExisted(Project prj, Department dpt)
        {
            object obj = SqlHelper.ExecuteScalar(@"select * from T_PrjDptParticipation 
                            where projectID=@prjID and departmentID=@dptID",
                            new SqlParameter("@projectID", prj.projectID),
                            new SqlParameter("@departmentID", dpt.DepartmentID));
            return Convert.ToInt32(obj) > 0;
        }
    }
}
