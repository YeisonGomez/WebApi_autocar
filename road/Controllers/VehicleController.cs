using System;
using System.Data;
using System.Web.Http;

namespace road
{
	[RoutePrefix("api/vehicle")]
    public class VehicleController : ApiController
    {
		VehicleModel vehicleModel = new VehicleModel();

        [Route("all")]
		[HttpGet]
		public IHttpActionResult Test()
		{
			return Json(vehicleModel.GetAll());
		}
    }
}
