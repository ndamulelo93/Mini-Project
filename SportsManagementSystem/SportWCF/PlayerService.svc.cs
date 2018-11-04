using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SportClient.Definition.Users;

namespace SportWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "PlayerService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select PlayerService.svc or PlayerService.svc.cs at the Solution Explorer and start debugging.
    public class PlayerService : IPlayerService
    {
        public string Dl_PlayersBySportID(string ID)
        {
            int _id = Convert.ToInt32(ID);
            try
            {
                using (SPORT_LINK_DBDataContext db = new SPORT_LINK_DBDataContext())
                {
                    List<TEAMPLAYER> toDelete = (from dl in db.TEAMPLAYERs where dl.Sport_Id == _id select dl).ToList();
                    if (toDelete == null)
                    {
                        return "Failed: Ticket Not Found";
                    }
                    else
                    {
                        db.TEAMPLAYERs.DeleteAllOnSubmit(toDelete);
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
