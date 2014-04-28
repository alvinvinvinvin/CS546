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
    public class RankDAL
    {
        public Rank ToModel(DataRow row)
        {
            Rank rank = new Rank();
            rank.RankID = (Guid)row["RankID"];
            rank.RankName = (string)row["RankName"];
            return rank;
        }
        public Rank GetByID(Guid rankid)
        {
            DataTable table = SqlHelper.ExecuteDataTable("select * from T_Rank where RankID = @RankID",
                                new SqlParameter("@RankID", rankid));
            Rank rank = new Rank();
            if (table.Rows.Count == 1)
            {
                return ToModel(table.Rows[0]);
            }
            else if (table.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                throw new Exception("Erro! No Such RankID!");
            }
        }
        public Rank[] ListAll()
        {
            DataTable table = SqlHelper.ExecuteDataTable("select * from T_Rank");
            Rank[] ranks = new Rank[table.Rows.Count];
            for (int i = 0; i < table.Rows.Count; i++)
            {
                Rank rank = ToModel(table.Rows[i]);
                ranks[i] = rank;
            }
            return ranks;
        }
        public Guid GetRankIDByRankName(string rankname)
        {
            DataTable table = SqlHelper.ExecuteDataTable("select * from T_Rank where RankName = @rankname",
                                new SqlParameter("@rankname",rankname));
            Rank manager = ToModel(table.Rows[0]);
            return manager.RankID;
        }
    }
}
