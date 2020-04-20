using EARGE.DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EARGE.Team.Controllers {
    public class BaseController : Controller {

        public earge_teamDb db = new earge_teamDb();

        public TeamMember CURRENT_TEAM_MEMBER {
            get {
                if (System.Web.HttpContext.Current.Session["MEMBER"] != null) {
                    return (TeamMember)System.Web.HttpContext.Current.Session["MEMBER"];
                }
                return null;
            }
        }


        public void SET_CURRENT_TEAM_MEMBER(TeamMember tm) {
            System.Web.HttpContext.Current.Session["MEMBER"] = tm;
        }

    }
}