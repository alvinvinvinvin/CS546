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
    public class EmployeeDAL
    {
        public Employee ToModel(DataRow row)
        {
            Employee employee = new Employee();
            employee.ID = (Guid)row["ID"];
            employee.UserName = (string)row["UserName"];
            employee.Password = (string)row["Password"];
            employee.RealName = (string)row["RealName"];
            employee.RankID = (Guid)row["RankID"];
            employee.DepartmentID = (Guid)row["DepartmentID"];
            employee.Birthday = (DateTime)row["Birthday"];
            employee.ContractStartDate = (DateTime)row["ContractStartDate"];
            employee.ContractEndDate = (DateTime)row["ContractEndDate"];
            employee.GenderID = (Guid)row["GenderID"];
            employee.IsDeleted = (bool)row["IsDeleted"];
            employee.ManagerName = (string)SqlHelper.FromDBValue(row["ManagerName"]);
            employee.PaidFreq = (string)SqlHelper.FromDBValue( row["PaidFreq"]);
            employee.LastPaidDate = (DateTime?)SqlHelper.FromDBValue(row["LastPaidDate"]);
            employee.BaseSalary = (decimal?)SqlHelper.FromDBValue(row["BaseSalary"]);
            employee.Bonus = (decimal?)SqlHelper.FromDBValue(row["Bonus"]);
            employee.Deduction = (decimal?)SqlHelper.FromDBValue(row["Deduction"]);
            employee.AfterTaxWage = (decimal?)SqlHelper.FromDBValue(row["AfterTaxWage"]);
            //employee.BaseSalaryRangeID = (Guid)row["BaseSalaryRangeID"];
            return employee;
        }
        public Employee GetByUerName(string username)
        {
            DataTable table = SqlHelper.ExecuteDataTable("Select * from T_Employee where UserName = @UserName and IsDeleted = 0",
                                  new SqlParameter("@UserName", username));
            Employee employee = new Employee();
           
            if (table.Rows.Count <= 0)
            {
                return null;
            }
            else if (table.Rows.Count == 1)
            {
                employee = ToModel(table.Rows[0]);
                return employee;
            }
            else
            {
                throw new Exception("Erro! Expetitive UserName!");
            }
        }

        public Employee getByID(Guid ID)
        {
            DataTable dtEmp = SqlHelper.ExecuteDataTable(
                                @"select * from T_Employee where ID=@id",
                                new SqlParameter("@id",ID));
            Employee employee = new Employee();

            if (dtEmp.Rows.Count <= 0)
            {
                return null;
            }
            else if (dtEmp.Rows.Count == 1)
            {
                employee = ToModel(dtEmp.Rows[0]);
                return employee;
            }
            else
            {
                throw new Exception("Erro when getting employee bu id!");
            }
        }
        public Employee[] ListAll()
        {
            DataTable table = SqlHelper.ExecuteDataTable("select * from T_Employee where IsDeleted = 0");
            Employee[] employees = new Employee[table.Rows.Count];
            for (int i = 0; i < table.Rows.Count; i++)
            {
                Employee employee = ToModel(table.Rows[i]);
                UpdateManagerIDtoDepartmentTable(employee);
                employee.ManagerName = GetManagerUserNameBydptID(employee);
                employees[i] = employee;
            }
            return employees;
        }
        public Employee[] ListSingleData(Guid id)
        {
            DataTable table = SqlHelper.ExecuteDataTable("select * from T_Employee where ID = @ID and IsDeleted = 0",
                                new SqlParameter("@ID", id));
            if (table.Rows.Count <= 0)
            {
                return null;
            }
            else
            {
                Employee Loginer = ToModel(table.Rows[0]);
                UpdateManagerIDtoDepartmentTable(Loginer);
                Loginer.ManagerName = GetManagerUserNameBydptID(Loginer);
                Employee[] Loginers = new Employee[table.Rows.Count];
                Loginers[0] = Loginer;
                return Loginers;
            }
        }
        public Employee[] SearchByDpt(Guid dptId)
        {
            DataTable table = SqlHelper.ExecuteDataTable(@"select * from T_Employee where DepartmentID = @dptId and IsDeleted = 0",
                                         new SqlParameter("@dptId", dptId));
            Employee[] employees = new Employee[table.Rows.Count];
            for (int i = 0; i < table.Rows.Count; i++)
            {
                Employee employee = ToModel(table.Rows[i]);
                employee.ManagerName = GetManagerUserNameBydptID(employee);
                UpdateManagerIDtoDepartmentTable(employee);
                employees[i] = employee;
            }
            return employees;
        }
        public Employee[] ListDepartmentManagers(Guid DepartmentID, Guid RankID)
        {
            DataTable table = SqlHelper.ExecuteDataTable("select * from T_Employee where DepartmentID = @dptid and RankID = @rankid and IsDeleted = 0",
                            new SqlParameter("@dptid", DepartmentID),
                            new SqlParameter("@rankid", RankID));
            if (table.Rows.Count <= 0)
            {
                return null;
            }
            else
            {
                Employee[] LoginerManagers = new Employee[table.Rows.Count];
                Employee manager = ToModel(table.Rows[0]);
                LoginerManagers[0] = manager;
                return LoginerManagers;
            }
        }
        public void Insert(Employee employee)
        {
            employee.ManagerName = GetManagerUserNameBydptID(employee);
            SqlHelper.ExecuteNonQuery(@"insert into T_Employee
                                     (ID,UserName,Password,RealName,GenderID,
                                      Birthday,RankID,IsDeleted,DepartmentID,
                                      ContractStartDate,ContractEndDate,
                                        ManagerName,PaidFreq,LastPaidDate
                                      ) 
                                        values
                                      (newid(),@UserName,@Password,@RealName,@GenderID,
                                      @Birthday,@RankID,0,@DepartmentID,@ContractStartDate,
                                        @ContractEndDate,@ManagerName,@PaidFreq,@LastPaidDate)",
                                 new SqlParameter("@UserName", employee.UserName),
                                 new SqlParameter("@Password", employee.Password),
                                 new SqlParameter("@RealName", employee.RealName),
                                 new SqlParameter("@GenderID", employee.GenderID),
                                 new SqlParameter("@Birthday", employee.Birthday),
                                 new SqlParameter("@RankID", employee.RankID),
                                 new SqlParameter("@DepartmentID", employee.DepartmentID),
                                 new SqlParameter("@ContractStartDate", employee.ContractStartDate),
                                 new SqlParameter("@ContractEndDate", employee.ContractEndDate),
                                 new SqlParameter("@ManagerName", SqlHelper.ToDBValue(employee.ManagerName)),
                                 new SqlParameter("@PaidFreq",SqlHelper.ToDBValue(employee.PaidFreq)),
                                 new SqlParameter("@LastPaidDate",SqlHelper.ToDBValue(employee.LastPaidDate)));
                                 //new SqlParameter("@BaseSalaryRangeID", employee.BaseSalaryRangeID));  
        }
        public void Update(Employee employee)
        {
            employee.ManagerName = GetManagerUserNameBydptID(employee);
            SqlHelper.ExecuteNonQuery(@"update T_Employee set
                                      [UserName] = @UserName
                                      ,[Password] = @Password
                                      ,[RealName] = @RealName
                                      ,[GenderID] = @GenderID
                                      ,[Birthday] = @Birthday
                                      ,[RankID] = @RankID
                                      ,[DepartmentID] = @DepartmentID
                                      ,[ContractStartDate] = @ContractStartDate
                                      ,[ContractEndDate] = @ContractEndDate
                                      ,ManagerName = @ManagerName
                                      ,PaidFreq = @PaidFreq
                                      ,LastPaidDate = @LastPaidDate where ID = @ID",
                                      new SqlParameter("@ID",employee.ID),
                                      new SqlParameter("@UserName", employee.UserName),
                                      new SqlParameter("@Password", employee.Password),
                                      new SqlParameter("@RealName", employee.RealName),
                                      new SqlParameter("@GenderID", employee.GenderID),
                                      new SqlParameter("@Birthday", employee.Birthday),
                                      new SqlParameter("@RankID", employee.RankID),
                                      new SqlParameter("@DepartmentID", employee.DepartmentID),
                                      new SqlParameter("@ContractStartDate", employee.ContractStartDate),
                                      new SqlParameter("@ContractEndDate", employee.ContractEndDate),
                                      new SqlParameter("@ManagerName", SqlHelper.ToDBValue(employee.ManagerName)),
                                      new SqlParameter("@PaidFreq",SqlHelper.ToDBValue( employee.PaidFreq)),
                                      new SqlParameter("@LastPaidDate",SqlHelper.ToDBValue( employee.LastPaidDate)));
                                      //new SqlParameter("@BaseSalaryRangeID", employee.BaseSalaryRangeID));
        }
        public void DeleteByID(Guid id)
        {
            SqlHelper.ExecuteNonQuery("update T_Employee set IsDeleted = 1 where ID = @ID",
                            new SqlParameter("@ID", id));
        }

        public bool CheckExsited(string UserName)
        {
            object obj = SqlHelper.ExecuteScalar("select count(*) from T_Employee where UserName = @UserName and IsDeleted = 0",
                              new SqlParameter("@UserName",UserName));
            return Convert.ToInt32(obj) > 0; 
        }

        public string GetManagerUserNameBydptID(Employee employee)
        {
                Guid dptid = employee.DepartmentID;
                Guid rankid = new RankDAL().GetRankIDByRankName("Manager");
                DataTable dt = SqlHelper.ExecuteDataTable("select * from T_Employee where DepartmentID =@DepartmentID and RankID = @RankID and IsDeleted = 0",
                                new SqlParameter("@DepartmentID", dptid),
                                new SqlParameter("@RankID", rankid));
                if (dt.Rows.Count == 1)
                {
                    Employee manager = ToModel(dt.Rows[0]);
                    return manager.UserName + manager.RealName;
                }
                else
                {
                    return null;
                }
        }
        public Guid? GetManagerID(Employee employee)
        {
            Guid dptid = employee.DepartmentID;
            Guid rankid = new RankDAL().GetRankIDByRankName("Manager");
            DataTable dt = SqlHelper.ExecuteDataTable("select * from T_Employee where DepartmentID =@DepartmentID and RankID = @RankID and IsDeleted = 0",
                                new SqlParameter("@DepartmentID", dptid),
                                new SqlParameter("@RankID", rankid));
            if (dt.Rows.Count == 1)
            {
                Employee manager = ToModel(dt.Rows[0]);
                return manager.ID;
            }
            else
            {
                return null;
            }
        }

        public void UpLoadManagerName(Employee employee)
        {
            employee.ManagerName = GetManagerUserNameBydptID(employee);
            SqlHelper.ExecuteNonQuery("update T_Employee set ManagerName = @ManagerName where ID = @ID",
                                new SqlParameter("@ManagerName",SqlHelper.ToDBValue( employee.ManagerName)),
                                new SqlParameter("@ID", employee.ID));
        }

        public Employee GetEmployeeByID(Guid ID)
        {
            DataTable table = SqlHelper.ExecuteDataTable(@"select * from T_Employee where ID = @ID and IsDeleted = 0",
                                new SqlParameter("@ID",ID));
            if (table.Rows.Count == 1)
            {
                Employee employee = ToModel(table.Rows[0]);
                return employee;
            }
            else
            {
                throw new Exception("GetEmployeeByID Erro");
            }
            
        }
        public void UpdateEmployeeSalarys(SalarySheetItem salaryitem)
        {
            SqlHelper.ExecuteNonQuery(@"update T_Employee set 
            BaseSalary = @BaseSalary, Bonus = @Bonus, Deduction = @Deduction, AfterTaxWage = @AfterTaxWage where ID =@ID",
                             new SqlParameter("@BaseSalary", SqlHelper.ToDBValue(salaryitem.BaseSalary)),
                             new SqlParameter("@Bonus", SqlHelper.ToDBValue(salaryitem.Bonus)),
                             new SqlParameter("@Deduction", SqlHelper.ToDBValue(salaryitem.Deduction)),
                             new SqlParameter("@AfterTaxWage", SqlHelper.ToDBValue(salaryitem.AfterTaxWage)),
                             new SqlParameter("@ID", salaryitem.EmployeeID));
        }



        //public Guid GetIDByUserName(string username)
        //{

        //}
        public void UpdateManagerIDtoDepartmentTable(Employee employee)
        {   
            Guid? managerID = GetManagerID(employee);
            Guid dptID = employee.DepartmentID;
            SqlHelper.ExecuteNonQuery("update T_Department set DepartmentManagerID = @DepartmentManagerID where DepartmentID =@DepartmentID",
                                    new SqlParameter("@DepartmentManagerID", SqlHelper.ToDBValue(managerID)),
                                    new SqlParameter("@DepartmentID", dptID));
        }
        public bool CheckManagerExisted(Employee employee)
        {
            Guid managerRankID = new RankDAL().GetRankIDByRankName("Manager");
            Guid staffRankID = new RankDAL().GetRankIDByRankName("Staff");
            if (staffRankID == employee.RankID)
            {
                return false;
            }
            else if (managerRankID == employee.RankID)
            {
                bool managerExisted = new DepartmentDAL().CheckManagerExisted(employee.DepartmentID);
                if (managerExisted)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }


    }
}
