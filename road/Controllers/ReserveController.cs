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
	[RoutePrefix("api/reserve")]
    public class ReserveController : ApiController
    {
		Response json = new Response();
		//UserModel userModel = new UserModel();
		ReserveModel reserveModel = new ReserveModel();
		Util util = new Util();

		[Route("pre")]
		[HttpPost]
		public IHttpActionResult PreReserve([FromBody] ReserveModel reserve)
		{
			Object[] auth = util.Authorization();
			if ((String)auth[0] == "OK")
			{
				UserModel payload = (UserModel)auth[1];
				return Json(reserveModel.GetAll(reserve.fecha_inicio, reserve.fecha_fin, reserve.sucursal_entrega, reserve.vehiculo_id, payload.email, reserve.sucursal_id, reserve.conductor));
			}
			else
			{
				return Json(json.MysqlException((String)auth[1], (String)auth[2]));
			}
		}
    }
}
