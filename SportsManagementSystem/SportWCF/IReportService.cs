
using SportClient.Definition;
using SportClient.Definition.Reporting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SportWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IReportService" in both code and config file together.
    [ServiceContract]
    public interface IReportService
    {
        /// <summary>
        /// Get game stats
        /// </summary>
        /// <param name="Game_ID"></param>
        /// <param name="type"> type of game stat request</param>
        /// <returns> list of number of yellow cards, position 0 stores team 1 and position 1 stores team 2'a card</returns>
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "gt_GameStats/{Game_ID},{type}", ResponseFormat =
            WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<int> gt_GameStats(string Game_ID, string type);


        //Compare all leagues: Useful for general users to make decisions about which league to follow
        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "gt_LeaguesStats", ResponseFormat =
          WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        List<rep_league> gt_LeaguesStats();
