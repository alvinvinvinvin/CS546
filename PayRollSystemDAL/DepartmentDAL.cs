﻿using PayRollSystemModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayRollSystemDAL
{
    public class DepartmentDAL
    {
        public Department ToModel(DataRow row)
        {
            Department department = new Department();
            department.DepartmentID = (Guid)row["DepartmentID"];
            department.DepartmentName = (string)row["DepartmentName"];
            department.DepartmentManagerID = (Guid?)SqlHelper.FromDBValue(row["DepartmentManagerID"]);
            department.IsDeleted = (bool)row["IsDeleted"];
            return department;
        }

        public Department getByID(Guid dptID)
        {
            DataTable dt = SqlHelper.ExecuteDataTable(@"select * from T_Department where DepartmentID=@dptID",
                new SqlParameter("@dptID", dptID));
            Department dpt = new Department();
            if (dt.Rows.Count <= 0)
            {
                return null;
            }
            else if (dt.Rows.Count == 1)
            {
                dpt = ToModel(dt.Rows[0]);
                return dpt;
            }
            else
            {
                throw new Exception("Erro when getting Department bu id!");
            }
        }
        public Department[] ListAll()
        {
            DataTable table = SqlHelper.ExecuteDataTable("select * from T_Department");
            Department[] departments = new Department[table.Rows.Count];
            for (int i = 0; i < table.Rows.Count; i++)
            {
                Department department = ToModel(table.Rows[i]);
                departments[i] = department;
            }
            return departments;
        }
        public Department[] GetDepartmentManager(Guid dptid)
        {
            DataTable table = SqlHelper.ExecuteDataTable("select * from T_Department where DepartmentID = @DepartmentID",
                                new SqlParameter("@DepartmentID", dptid));
            if (table.Rows.Count <= 0)
            {
                return null;
            }
            else
            {
                Department[] departments = new Department[table.Rows.Count];
                for(int i= 0; i< table.Rows.Count; i++)
                {
                    Department dpt = ToModel(table.Rows[i]);
                    departments[i] = dpt;
                }
                return departments;

            }

        }
        public bool CheckManagerExisted(Guid dptID)
        {
            object obj = SqlHelper.ExecuteScalar(@"select count(DepartmentManagerID) 
                    from T_Department where DepartmentID = @DepartmentID",
                     new SqlParameter("@DepartmentID",dptID));
            return Convert.ToInt32(obj) > 0;
        }
        public void CleanManagerID(Guid dptid)
        {
            SqlHelper.ExecuteNonQuery(@"update T_Department set DepartmentManagerID = NULL 
                    where DepartmentID = @dptid",
                     new SqlParameter("@dptid",dptid));
        }

        public void addDepartment(Department department)
        {

            SqlHelper.ExecuteNonQuery(@"INSERT INTO [dbo].[T_Department]
                                       (DepartmentID
                                       ,DepartmentName
                                       ,DepartmentManagerID
                                       ,IsDeleted
                                       ,DepartmentManagerName)
                                 VALUES
                                       (@DepartmentID
                                       ,@DepartmentName
                                       ,@DepartmentManagerID
                                       ,0
                                       ,@DepartmentManagerName)",
              new SqlParameter("@DepartmentID", department.DepartmentID),
              new SqlParameter("@DepartmentName",SqlHelper.ToDBValue(department.DepartmentName)),
              new SqlParameter("@DepartmentManagerID",SqlHelper.ToDBValue(department.DepartmentManagerID)),
              new SqlParameter("@DepartmentManagerName", SqlHelper.ToDBValue(null)));
        }

    }
}
