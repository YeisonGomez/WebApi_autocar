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
	[RoutePrefix("api/paysheet")]
    public class PaysheetController : ApiController
    {
		PaysheetModel paysheetModel = new PaysheetModel();
		Response json = new Response();
		Util util = new Util();

		[Route("payment")]
		[HttpGet]
		public IHttpActionResult Payment(string type)
		{
			Object[] auth = util.Authorization();
			if ((String)auth[0] == "OK")
			{
				UserModel payload = (UserModel)auth[1];
				return Json(paysheetModel.Payment(payload.email, type));
			}
			else
			{
				return Json(json.MysqlException((String)auth[1], (String)auth[2]));
			}
		}
    }
}


