
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
        
        public List<Log> GetLogByLeagueID(string ID)
        {
            int _id = Convert.ToInt32(ID);
            using (SPORT_LINK_DBDataContext db = new SPORT_LINK_DBDataContext())
            {
                try
                {
                    var query = (from log in db.LOGs where log.League_Id.Equals(_id)
                                 select new Log
                                 {
                                     ID = log.Log_Id,
                                     TeamName = log.TeamName,
                                     LeagueName = log.LEAGUE.Name,
                                     Position = Convert.ToInt32(log.Position),
                                     MatchPlayed = Convert.ToInt32(log.MatchPlayed),
                                     Wins = Convert.ToInt32(log.Wins),
                                     Loose = Convert.ToInt32(log.Loose),
                                     Draws = Convert.ToInt32(log.Draws),
                                     Points = Convert.ToInt32(log.Points),
                                 }).ToList();
                    List<Log> items = new List<Log>();
                    foreach(Log lg in query)
                    {
                        items.Add(lg);
                    }
                    return items;
                    //if(query != null)
                    //{
                    //    Log res = new Log();
                    //    res.ID = query.ID;
                    //    res.League_ID = query.League_ID;
                    //    res.TeamName = query.TeamName;
                    //    res.LeagueName = query.LeagueName;
                    //    res.Position = query.Position;
                    //    res.MatchPlayed = query.MatchPlayed;
                    //    res.Wins = query.Wins;
                    //    res.Loose = query.Loose;
                    //    res.Draws = query.Draws;
                    //    res.Points = query.Points;
                    //    return res;
                    //}else
                    //{
                    //    return null;
                    //}

                }catch(Exception)
                {
                    return null;
                }
            };
        }
         public string UpdateLog(Log log)
        {
            using (SPORT_LINK_DBDataContext db = new SPORT_LINK_DBDataContext())
            {
                try
                {
                    var query = (from tm in db.LOGs where tm.Log_Id.Equals(log.ID) select tm);
                    if (query.Count() != 0)
                    {
                        LOG toinsert = query.Single();
                        toinsert.TeamName = log.TeamName;
                        toinsert.Position = log.Position;
                        toinsert.MatchPlayed = log.MatchPlayed;
                        toinsert.Wins = log.Wins;
                        toinsert.Loose = log.Loose;
                        toinsert.Draws = log.Draws;
                        toinsert.Points = log.Points;
                     //   toinsert.League_Id = log.League_ID;
                        db.SubmitChanges();
                        return "success";
                    }
                    else
                    {
                        return "failed: No Such team exist";
                    }
                }
                catch (Exception)
                {
                    return "failed";
                }
            };
        }
    }
}

        
        
