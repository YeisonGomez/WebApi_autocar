using System;
using System.Web.Http;

namespace road
{
	[RoutePrefix("api/user")]
	public class UserController : ApiController
	{

		UserModel userModel = new UserModel();

		[Route("login2")]
		[HttpPost]
		public IHttpActionResult Login([FromBody] UserModel user)
		{
			return Json(userModel.Login(user.email, user.password));
		}

		[Route("login2")]
		[HttpGet]
		public IHttpActionResult Login2()
		{
			return Json("hola");
		}
	}
}
