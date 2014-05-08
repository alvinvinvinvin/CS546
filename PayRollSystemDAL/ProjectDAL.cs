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

        public Project[] listPrjsByDpt(Guid dptID)
        {
            DataTable dtPrj = SqlHelper.ExecuteDataTable(@"select * from T_PrjDptParticipation where departmentID=@dptID",
                new SqlParameter("@dptID",dptID));
            Project[] prjs = new Project[dtPrj.Rows.Count];
            for (int i = 0; i < dtPrj.Rows.Count; i++)
            {
                Project prj = getPrjbyID((Guid)dtPrj.Rows[i][1]);
                prjs[i] = prj;
            }
            return prjs;
        }

        public Project getPrjbyID(Guid prjID)
        {
            DataTable dtPrj = SqlHelper.ExecuteDataTable(
                    @"select * from T_Project where projectID=@prjID",
                                new SqlParameter("@prjID", prjID));
            Project prj = ToModel(dtPrj.Rows[0]);
            return prj;
        }

        public Project getPrjbyName(string prjName)
        {
            DataTable dtPrj = SqlHelper.ExecuteDataTable(
                @"select * from T_Project where projectName=@prjName",
                new SqlParameter("@prjName", prjName));
            if (dtPrj.Rows.Count == 1)
            {
                Project prj = ToModel(dtPrj.Rows[0]);
                return prj;
            }
            else throw new Exception("duplication of prjName."); ;
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

        public int? countEmpPeriod(Participation part)
        {
            DataTable dtDiff = SqlHelper.ExecuteDataTable(
                @"select datadiff(day, @startDate, @quitDate)",
                new SqlParameter("@startDate", SqlHelper.ToDBValue(part.startDate)),
                new SqlParameter("@quitDate", SqlHelper.ToDBValue(part.quitDate)));
            int? period = (int?)SqlHelper.FromDBValue(dtDiff.Rows[0][0]);
            return period / 7;
        }

        public decimal? costInwageNew(Participation parti)
        {
            EmployeeDAL empDAL = new EmployeeDAL();
            decimal? cost=0;
            DataTable dtParti = SqlHelper.ExecuteDataTable(@"select * from
            T_PrjParticipation where projectID = @prjID and employeeID=@empID",
            new SqlParameter("@prjID", parti.projectID),
            new SqlParameter("@empID", parti.employeeID));
            if (dtParti.Rows.Count > 0)
            {
                  Employee emp = empDAL.getByID(parti.employeeID); 
                  cost = countEmpPeriod(parti)*emp.AfterTaxWage;
            }
            
            return cost;
        }
        

        public decimal? costInWage(Project prj)
        {

            Employee[] employees = listAllParticipators(prj);
            decimal? totalWage = 0;
            if (employees != null)
            {
                for (int i = 0; i < employees.Length; i++)
                {
                    totalWage += employees[i].AfterTaxWage;
                }
                return totalWage;
            }
            else return null;

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
                     new SqlParameter("@prjName",SqlHelper.ToDBValue(prj.projectName)),
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
                            description=@description where projectID=@prjID",
                   new SqlParameter("@prjID",prj.projectID),
                   new SqlParameter("@prjName",SqlHelper.ToDBValue(prj.projectName)),
                   new SqlParameter("@startDate",SqlHelper.ToDBValue(prj.startDate)),
                   new SqlParameter("@dueDate",SqlHelper.ToDBValue(prj.dueDate)),
                   new SqlParameter("@costinwage", SqlHelper.ToDBValue(prj.costinwage)),
                   new SqlParameter("@costinother", SqlHelper.ToDBValue(prj.costinother)),
                   new SqlParameter("@cost",SqlHelper.ToDBValue(prj.cost)),
                   new SqlParameter("@description",SqlHelper.ToDBValue(prj.description)));
        }

        public void insertEmployeeToPrj(Project project, Employee employee)
        {
            SqlHelper.ExecuteNonQuery(@"insert into T_PrjParticipation
                                (participatingID, projectID, employeeID) 
                                values (newid(), @projectID, @employeeID)",
                                new SqlParameter("@projectID",project.projectID),
                                new SqlParameter("@employeeID",employee.ID)
                                );
        }
        

        public bool IsParticipatorExisted(Project project, Employee employee)
        {
            object obj = SqlHelper.ExecuteScalar(@"select count(*) from T_PrjParticipation 
                            where projectID=@prjID and employeeID=@empID",
                            new SqlParameter("@prjID",project.projectID),
                            new SqlParameter("@empID",employee.ID));
            return Convert.ToInt32(obj) > 0;
        }

        public bool IsAssignedDptExisted(Project prj, Department dpt)
        {
            object obj = SqlHelper.ExecuteScalar(@"select count(*) from T_PrjDptParticipation
                             where projectID=@prjID and departmentID=@dptID",
                             new SqlParameter("@prjID",prj.projectID),
                             new SqlParameter("@dptID",dpt.DepartmentID));
            return Convert.ToInt32(obj) > 0;
        }

        public bool IsPrjNameExisted(string name)
        {
            object obj = SqlHelper.ExecuteScalar(@"select count(*) from T_Project
                            where projectName=@prjName",
                           new SqlParameter("@prjName",name));
            return Convert.ToInt32(obj) > 0;
        }

        public Employee[] listAllParticipators(Project prj)
        {
            DataTable dtEmpID = SqlHelper.ExecuteDataTable(
                  @"select employeeID from T_PrjParticipation where projectID=@prjID",
                  new SqlParameter("@prjID",SqlHelper.ToDBValue(prj.projectID)));
            if (dtEmpID.Rows.Count > 0)
            {
                Employee[] employees = new Employee[dtEmpID.Rows.Count];
                for (int i = 0; i < dtEmpID.Rows.Count; i++)
                {
                    employees[i] = new EmployeeDAL().getByID((Guid)dtEmpID.Rows[i][0]);
                }
                return employees;
            }
            else return null;
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

        public void insertAssignedDepartment(Project prj, Department[] dpt)
        {
            for (int i = 0; i < dpt.Length; i++)
            {
                SqlHelper.ExecuteNonQuery(@"insert into 
                T_PrjDptParticipation(participatingID, projectID, departmentID)
                values(newid(), @prjID, @dptID)",
                    new SqlParameter("@prjID",SqlHelper.ToDBValue(prj.projectID)),
                    new SqlParameter("@dptID",SqlHelper.ToDBValue(dpt[i].DepartmentID)));
            }
        }

        //public void updateAssignedDepartment(Project prj, Department[] dpt)
        //{
        //    for (int i = 0; i < dpt.Length; i++)
        //    {
        //        SqlHelper.ExecuteNonQuery(@"update TT_PrjDptParticipation set")
        //    }
        //}
        public void deletePrj(Project prj)
        {
            SqlHelper.ExecuteNonQuery(@"delete from T_Project where projectID=@prjID",
                new SqlParameter("@prjID", prj.projectID));
            SqlHelper.ExecuteNonQuery(@"delete from T_PrjParticipation where projectID=@prjID",
                new SqlParameter("@prjID", prj.projectID));
            SqlHelper.ExecuteNonQuery(@"delete from T_PrjDptParticipation where projectID=@prjID",
                new SqlParameter("@prjID", prj.projectID));
        }
    }
}
