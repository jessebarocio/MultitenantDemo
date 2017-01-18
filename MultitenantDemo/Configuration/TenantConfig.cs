using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MultitenantDemo.Configuration
{
	public class TenantConfig
	{
		public string TenantName { get; set; }
		public string Hostname { get; set; }
		public string FavoriteColor { get; set; }
	}
}