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
	[RoutePrefix("api/favorite")]
    public class FavoriteController : ApiController
    {
		FavoriteModel favoriteModel = new FavoriteModel();
		Response json = new Response();
		Util util = new Util();

		[Route("user-add")]
		[HttpPost]
		public IHttpActionResult AddFavorite([FromBody] ReserveModel vehicle)
		{
			Object[] auth = util.Authorization();
			if ((String)auth[0] == "OK")
			{
				UserModel payload = (UserModel)auth[1];
				if (vehicle.vehiculo_id != null)
				{
					return Json(favoriteModel.AddFavorite(payload.email, vehicle.vehiculo_id, vehicle.state));
				}
				else
				{
					return Json(json);
				}
			}
			else
			{
				return Json(json.MysqlException((String)auth[1], (String)auth[2]));
			}
		}

		[Route("user-favorites")]
		[HttpGet]
		public IHttpActionResult GetFavorites()
		{
			Object[] auth = util.Authorization();
			if ((String)auth[0] == "OK")
			{
				UserModel payload = (UserModel)auth[1];
				return Json(favoriteModel.GetFavorites(payload.email));
			}
			else
			{
				return Json(json.MysqlException((String)auth[1], (String)auth[2]));

			}
		}
    }
}
