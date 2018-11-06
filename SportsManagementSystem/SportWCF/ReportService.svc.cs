using SportClient.Definition;
using SportClient.Definition.Reporting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace SportWCF
{
  
  // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ReportService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ReportService.svc or ReportService.svc.cs at the Solution Explorer and start debugging.
    public class ReportService : IReportService
    {
     //=========GENERAL REPORT===============================================================
        /// <summary>
        /// Get game stats
        /// </summary>
        /// <param name="Game_ID"></param>
        /// <param name="type"> type of game stat request</param>
        /// <returns> list of number of yellow cards, position 0 stores team 1 and position 1 stores team 2'a card</returns>
        public List<int> gt_GameStats(string Game_ID, string type)
        {
            List<int> stats = new List<int>();
            int g_id = Convert.ToInt32(Game_ID);
            using (SPORT_LINK_DBDataContext db = new SPORT_LINK_DBDataContext())
            {
                try
                {
                    
                    var query = (from gs in db.GAME_STATs
                                 where gs.Game_Id.Equals(g_id)
                                 select
                                new gamestats
                                {
                                    g_id = Convert.ToInt32(gs.Game_Id),
                                   
                                    t1_Corner_Kicks = Convert.ToInt32(gs.Team1_NumCornerKick),
                                    t1_fouls = Convert.ToInt32(gs.Team1_Fouls),
                                    t1_goalScored = Convert.ToInt32(gs.Team1_GoalScored),
                                    t1_pos = Convert.ToInt32(gs.Team1_Position),
                                    t1_Red_Card = Convert.ToInt32(gs.Team1_RedCard),
                                    t1_Yellow_Card = Convert.ToInt32(gs.Team1_YellowCard),

                                    t2_fouls = Convert.ToInt32(gs.Team2_Fouls),
                                    t2_Corner_Kicks = Convert.ToInt32(gs.Team2_NumCornerKick),
                                    t2_goalScored = Convert.ToInt32(gs.Team2_GoalScored),
                                    t2_pos = Convert.ToInt32(gs.Team2_Position),
                                    t2_Red_Card = Convert.ToInt32(gs.Team2_RedCard),
                                    t2_Yellow_Card = Convert.ToInt32(gs.Team2_YellowCard),
                                }).First();
                   if(query != null || type != null)
                    {
                        //Check stats type
                        if(type.Equals("YellowCards"))
                        {
                            stats.Add(query.t1_Yellow_Card);
                            stats.Add(query.t2_Yellow_Card);
                        }else if (type.Equals("RedCards"))
                        {
                            stats.Add(query.t1_Red_Card);
                            stats.Add(query.t2_Red_Card);
                        }
                        else if (type.Equals("Fouls"))
                        {
                            stats.Add(query.t1_fouls);
                            stats.Add(query.t2_fouls);
                        }
                        else if (type.Equals("Position"))
                        {
                            stats.Add(query.t1_pos);
                            stats.Add(query.t2_pos);
                        }
                        else if (type.Equals("CornerKicks"))
                        {
                            stats.Add(query.t1_Corner_Kicks);
                            stats.Add(query.t2_Corner_Kicks);
                        }
                        else if (type.Equals("GoalsScored"))
                        {
                            stats.Add(query.t1_goalScored);
                            stats.Add(query.t2_goalScored);
                        }
                        else
                        {
                            stats.Add(0);
                            stats.Add(0);
                        }
                    }
                    else
                    {
                        stats.Add(0);
                        stats.Add(0);
                    }
                    return stats;
                }
                catch (Exception)
                {
                    stats.Add(0);
                    stats.Add(0);
                    return stats;
                }
            };
        }
