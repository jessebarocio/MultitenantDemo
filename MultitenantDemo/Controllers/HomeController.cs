using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MultitenantDemo.Controllers
{
    public class HomeController : MultitenantBaseController
    {
        public ActionResult Index()
        {
			// The CurrentTenant property contains the configuration for the 
			// tenant that is making this request.
			ViewBag.TenantName = CurrentTenant.TenantName;
			ViewBag.FavoriteColor = CurrentTenant.FavoriteColor;
            return View();
        }
    }
}