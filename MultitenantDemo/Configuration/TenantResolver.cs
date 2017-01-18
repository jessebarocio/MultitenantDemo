using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace MultitenantDemo.Configuration
{
	internal interface ITenantResolver
	{
		TenantConfig GetByHostname(string name);
	}

	/// <summary>
	/// Resolves a Tenant's configuration based on hostname. Tenants are configured in Tenants.json.
	/// In the real world this class would probably read and cache tenant data from a database rather
	/// than reading it from a file.
	/// </summary>
	internal class TenantResolver : ITenantResolver
	{
		private IEnumerable<TenantConfig> tenantConfigs;

		public TenantResolver()
		{
			tenantConfigs = JsonConvert.DeserializeObject<IEnumerable<TenantConfig>>(
				File.ReadAllText(HttpContext.Current.Server.MapPath("~/Tenants.json")));
		}

		public TenantConfig GetByHostname(string hostname)
		{
			return tenantConfigs.FirstOrDefault(t => t.Hostname == hostname);
		}
	}
}