
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SportClient.Definition;

namespace SportWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "LogService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select LogService.svc or LogService.svc.cs at the Solution Explorer and start debugging.
    public class LogService : ILogService
    {
        public string CreateLog(Log log)
        {
            try
            {
                using (SPORT_LINK_DBDataContext db = new SPORT_LINK_DBDataContext())
                {
                    var query = (from res in db.LOGs where res.Log_Id.Equals(log.ID) && res.League_Id.Equals(log.League_ID) select res);
                    if (query.Count() == 0) //AddTeam
                    {
                        LOG toinsert = new LOG();
                        toinsert.TeamName = log.TeamName;
                        toinsert.Position = log.Position;
                        toinsert.MatchPlayed = log.MatchPlayed;
                        toinsert.Wins = log.Wins;
                        toinsert.Draws = log.Draws;
                        toinsert.Points = log.Points;
                        toinsert.League_Id = log.League_ID;
                        db.LOGs.InsertOnSubmit(toinsert);
                        db.SubmitChanges();
                        return "success";
                    }else
                    {
                        return "failed: log already exist";
                    }
                };
            }
            catch (Exception)
            {
                return "failed: catched";
            }
        }
        
                public string DeletLogbyLeagueID(string ID)
        {
            int _id = Convert.ToInt32(ID);
            try
            {
                using (SPORT_LINK_DBDataContext db = new SPORT_LINK_DBDataContext())
                {
                    List<LOG> toDelete = (from dl in db.LOGs where dl.League_Id == _id select dl).ToList();
                    if (toDelete == null)
                    {
                        return "Failed: Log Not Found";
                    }
                    else
                    {
                        db.LOGs.DeleteAllOnSubmit(toDelete);
                        db.SubmitChanges();
                        return "success";
                    }
                };
            }
            catch (Exception)
            {
                return "Failed";
            }
        }
