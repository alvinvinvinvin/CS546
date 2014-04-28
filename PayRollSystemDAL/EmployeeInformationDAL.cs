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
    public class EmployeeInformationDAL
    {
        public EmployeeInformation ToModel(DataRow row)
        {
            EmployeeInformation employeeInformation = new EmployeeInformation();
            employeeInformation.InformationID = (Guid)row["InformationID"];
            employeeInformation.InformationName = (string)row["InformationName"];
            employeeInformation.InformationCategory = (string)row["InformationCategory"];
            return employeeInformation;
        }
        public EmployeeInformation[] GetNameByCategory(string category)
        {
            DataTable table = SqlHelper.ExecuteDataTable(@"select * from T_EmployeeInformation
                                        where InformationCategory = @InformationCategory",
                                       new SqlParameter("@InformationCategory", category));
            EmployeeInformation[] items = new EmployeeInformation[table.Rows.Count];
            for (int i = 0; i < table.Rows.Count; i++)
            {
                //DataRow row = table.Rows[i];
                //EmployeeInformation item = new EmployeeInformation();
                //item.InformationID = (Guid)row["InformationID"];
                //item.InformationName = (string)row["InformationName"];
                EmployeeInformation item = ToModel(table.Rows[i]);
                items[i] = item;
            }
            return items;
        }
    }
}
