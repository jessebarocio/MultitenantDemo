# A (Very) Simplistic Multitenant Architecture Demo

This demo is a very simplistic architecture for building multitenant applications in ASP.NET MVC. It's far from perfect. The intent is to introduce the concept of designing for multitenancy to people who have never done it.

## How it works

Different tenant configurations are loaded based on the hostname the user is using to access the site. For example, `abc.myapp.com` and `xyc.myapp.com` point to the same application instance on the same web server but different configurations are loaded to process the requests. This is accomplished by having all controllers extend a common base controller (`MultitenantBaseController`) that contains logic for loading the proper configuration in it's `OnActionExecuting` method. A protected property on the base controller, called `CurrentTenant`, is then populated with the configuration for the current tenant making the request.

The `TenantResolver` class is responsible for determining which tenant config to load based on the hostname. In this simple example it loads the tenant configurations from `Tenants.json` and resolves the correct tenant based on the hostname configured in that file. In the real world tenant configuration would likely be stored in a database and/or cached on the web server for fast access.