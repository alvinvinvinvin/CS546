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
    public class BaseSalaryRangeDAL
    {
        public BaseSalaryRange ToModel(DataRow row)
        {
            BaseSalaryRange range = new BaseSalaryRange();
            range.BaseSalaryRangeID = (Guid)row["BaseSalaryRangeID"];
            range.RankID = (Guid)row["RankID"];
            range.BaseSalaryUperLimit = (decimal)row["BaseSalaryUperLimit"];
            range.BaseSalaryLowerLimit = (decimal)row["BaseSalaryLowerLimit"];
            range.RankName = (string)row["RankName"];
            return range;
        }
        public Guid GetBaseSalaryRangeIDByRankID(Employee employee)
        {
            Guid rankid = employee.RankID;
            DataTable table = SqlHelper.ExecuteDataTable("select * from T_BaseSalaryRange where RankID = @RankID",
                                new SqlParameter("@RankID",rankid));
            BaseSalaryRange range = ToModel(table.Rows[0]);
            return range.BaseSalaryRangeID;
        }
        public decimal GetBaseSalaryUperLimitByRankID(Employee employee)
        {
            Guid rankid = employee.RankID;
            DataTable table = SqlHelper.ExecuteDataTable("select * from T_BaseSalaryRange where RankID = @RankID",
                                new SqlParameter("@RankID", rankid));
            BaseSalaryRange range = ToModel(table.Rows[0]);
            return range.BaseSalaryUperLimit;
        }
        public decimal GetBaseSalaryLowerLimitByRankID(Employee employee)
        {
            Guid rankid = employee.RankID;
            DataTable table = SqlHelper.ExecuteDataTable("select * from T_BaseSalaryRange where RankID = @RankID",
                                new SqlParameter("@RankID", rankid));
            BaseSalaryRange range = ToModel(table.Rows[0]);
            return range.BaseSalaryLowerLimit;
        }
    }
}
