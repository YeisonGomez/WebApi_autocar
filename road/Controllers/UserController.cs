using System;
using System.Web.Http;

namespace road
{
	[RoutePrefix("api/user")]
	public class UserController : ApiController
	{

		UserModel userModel = new UserModel();
		Response json = new Response();

		[Route("login")]
		[HttpPost]
		public IHttpActionResult Login([FromBody] UserModel user)
		{
			if (user != null && user.email != null && user.password != null && user.email.Length <= 100 && user.password.Length <= 100)
			{
				return Json(userModel.Login(user.email, user.password));
			}
			else
			{
				return Json(json);
			}
		}

		[Route("login2")]
		[HttpGet]
		public IHttpActionResult Test()
		{
			return Json("hola");
		}
	}
}
