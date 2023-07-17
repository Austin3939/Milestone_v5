using Inscript_v5.Data.Inscriptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inscript_v5.Controllers
{
    public class UserPortalController : Controller
    {
        // GET: UserPortal
        public ActionResult Index()
        {
            return View(InscriptionsData.GetList());

            
        }

        public ActionResult UserInscriptionsView() {

            return PartialView(UserInscriptionsData.GetList());
        }

        

    }
}