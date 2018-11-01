
using SportClient.Definition;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SportWCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ITeamService" in both code and config file together.
    [ServiceContract]
    public interface ITeamService
    {
        //Insert
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "AddTeam", ResponseFormat =
          WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        int AddTeam(Team _team);
        //Edit
        [OperationContract]
        [WebInvoke(Method = "PUT", UriTemplate = "EditTeam", ResponseFormat =
          WebMessageFormat.Json, RequestFormat = WebMessageFormat.Json)]
        string EditTeam(Team _team);
