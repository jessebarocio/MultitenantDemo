using MultitenantDemo.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MultitenantDemo.Controllers
{
    public abstract class MultitenantBaseController : Controller
    {
        protected TenantConfig CurrentTenant { get; private set; }

		protected override void OnActionExecuting(
			ActionExecutingContext filterContext)
		{
			// Read the hostname the site is being accessed from.
			string hostname = filterContext.RequestContext.HttpContext
				.Request.Url.Host;

			// TenantResolver is responsible for retrieving the tenant specific
			// configuration based on the hostname we pass it.
			var tenantResolver = new TenantResolver();
			TenantConfig config = tenantResolver.GetByHostname(hostname);

			// If TenantResolver returns null then this hostname is not 
			// configured. Return a 404 Not Found. Otherwise set the 
			// CurrentTenant property.
			if (config == null)
			{
				filterContext.Result = HttpNotFound();
			}
			else
			{
				CurrentTenant = config;
				base.OnActionExecuting(filterContext);
			}
		}
	}
}