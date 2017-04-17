using System;
using System.Data;
using System.Web.Http;

namespace road
{
	[RoutePrefix("api/vehicle")]
	public class VehicleController : ApiController
	{
		VehicleModel vehicleModel = new VehicleModel();
		Util util = new Util();

		[Route("all")]
		[HttpGet]
		public IHttpActionResult getAll(String empresa_id, String limit, String offset)
		{
			String email = "0";
			Object[] auth = util.Authorization();
			if ((String)auth[0] == "OK")
			{
				UserModel payload = (UserModel)auth[1];
				email = payload.email;
			}
			return Json(vehicleModel.GetAll(limit, offset, empresa_id, email));
		}

		[Route("get")]
		[HttpGet]
		public IHttpActionResult getDetailVehicle(String id)
		{
			return Json(vehicleModel.GetVehicle(id));
		}

		[Route("reserve")]
		[HttpGet]
		public IHttpActionResult getReserveVehicle(String vehicle_id)
		{
			return Json(vehicleModel.getReserveVehicle(vehicle_id));
		}
	}
}
