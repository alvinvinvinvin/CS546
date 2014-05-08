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
    public class participationDAL
    {
        public Participation ToModel(DataRow row)
        {
            Participation parti = new Participation();
            parti.participatingID = (Guid)row["participatingID"];
            parti.projectID = (Guid?)SqlHelper.FromDBValue(row["projectID"]);
            parti.employeeID = (Guid)SqlHelper.FromDBValue(row["employeeID"]);
            parti.startDate = (DateTime?)SqlHelper.FromDBValue(row["startDate"]);
            parti.quitDate = (DateTime?)SqlHelper.FromDBValue(row["quitDate"]);
            return parti;
        }

        public int? countEmployeeAssignedPeriod(Participation parti)
        {
            DateTime? startDate = parti.startDate;
            DateTime? quitDate = parti.quitDate;
            DataTable dtDiff = SqlHelper.ExecuteDataTable(
                @"select datediff(day, @startDate, @quitDate)",
                new SqlParameter("@startDate", SqlHelper.ToDBValue(startDate)),
                new SqlParameter("@quitDate", SqlHelper.ToDBValue(quitDate)));
            int? period = (int?)SqlHelper.FromDBValue(dtDiff.Rows[0][0]);
            return period / 7;
        }

//        public Participation getByPrj_Emp(Project prj, Employee emp)
//        {
//            DataTable dtParti = SqlHelper.ExecuteDataTable(@"select * from 
//            T_PrjParticipation where projectID=@prjID and employeeID=@empID",
//            new SqlParameter("@prjID",SqlHelper.ToDBValue(prj.projectID)),
//            new SqlParameter("@empID",SqlHelper.ToDBValue(emp.ID)));
//            if (dtParti.Rows.Count > 0)
//            {
//                Participation parti = new Participation();
//                parti = ToModel(dtParti.Rows[0]);
//                return parti;
//            }
//            else return null;           
//        }
        
        
        public void insertParti(Participation parti)
        {
            SqlHelper.ExecuteNonQuery("@insert into T_PrjParticipation() ");
        }
        public void updateDateByEmp(
            Project prj, Employee emp, DateTime? startDate, DateTime? quitDate)
        {
            SqlHelper.ExecuteNonQuery(@"UPDATE T_PrjParticipation
                               SET 
                                  [startDate] = @startDate
                                  ,[quitDate] = @quitDate
                             WHERE projectID = @prjID and
                                  employeeID] = @empID",
                              new SqlParameter("@startDate",SqlHelper.ToDBValue(startDate)),
                              new SqlParameter("@quitDate",SqlHelper.ToDBValue(quitDate)),
                              new SqlParameter("@prjID",SqlHelper.ToDBValue(prj.projectID)),
                              new SqlParameter("@empID",SqlHelper.ToDBValue(emp.ID)));
        }
    }
}
