using System.Web.Http;
using System.Web.Http.Controllers;

namespace road
{
	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{
			// Web API configuration and services

			// Web API routes
			config.MapHttpAttributeRoutes();

			config.Routes.MapHttpRoute(
				name: "DefaultApi",
				routeTemplate: "api/{controller}/{id}",
				defaults: new { id = RouteParameter.Optional }
			);
		}
	}

	public class LocalRequestOnlyAttribute : AuthorizeAttribute
	{
		protected override bool IsAuthorized(HttpActionContext context)
		{
			return context.RequestContext.IsLocal;
		}
	}
}
