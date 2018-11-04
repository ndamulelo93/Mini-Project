using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using SportClient.Definition.Users;

namespace SportWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "RegistrationService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select RegistrationService.svc or RegistrationService.svc.cs at the Solution Explorer and start debugging.
    public class RegistrationService : IRegistrationService
    {
        public string registerPlayer(Player player)
        {

            
            using (SPORT_LINK_DBDataContext db = new SPORT_LINK_DBDataContext())
            {
                try
                {
                    int isAvail = (from eh in db.TEAMPLAYERs where eh.Name.Equals(player.Name) &&
                                   eh.Sport_Id.Equals(player.SportID) select eh).Count();
                    if (isAvail == 0)
                    {
                        TEAMPLAYER _player = new TEAMPLAYER();
                        _player.Name = player.Name;
                        _player.Position = player.Position;
                        _player.PerformanceRate = player.PerformanceRate;
                        _player.Description = player.Desc;
                        _player.Sport_Id = player.SportID;
                        db.TEAMPLAYERs.InsertOnSubmit(_player);
                        db.SubmitChanges();
                        return "Registered " + _player.Name + " successfully";
                    }
                    else
                    {
                        return "Error: Account already taken";
                    }
                }
                catch (Exception e)
                {
                    return e.GetBaseException().ToString();
                }
            };
        }
