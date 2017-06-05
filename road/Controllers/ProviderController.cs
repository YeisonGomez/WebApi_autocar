using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Newtonsoft.Json;

namespace road.Controllers
{
	[RoutePrefix("api/provider")]
	public class ProviderController : ApiController
	{
		ProviderModel providerModel = new ProviderModel();
		Response json = new Response();
		Util util = new Util();

		[Route("get-vehicles")]
		[HttpGet]
		public IHttpActionResult getVehicleProvider()
		{
			Object[] auth = util.Authorization();
			if ((String)auth[0] == "OK")
			{
				UserModel payload = (UserModel)auth[1];
				return Json(providerModel.getVehicleProvider(payload.email));
			}
			else
			{
				return Json(json.MysqlException((String)auth[1], (String)auth[2]));

			}
		}

		[Route("contracts")]
		[HttpGet]
		public IHttpActionResult getContracts()
		{
			Object[] auth = util.Authorization();
			if ((String)auth[0] == "OK")
			{
				UserModel payload = (UserModel)auth[1];
				return Json(providerModel.getContracts(payload.email));
			}
			else
			{
				return Json(json.MysqlException((String)auth[1], (String)auth[2]));
			}
		}

	}
}
