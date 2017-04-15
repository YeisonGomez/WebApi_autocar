using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.Http;

namespace road
{
	[RoutePrefix("api/user")]
	public class UserController : ApiController
	{

		UserModel userModel = new UserModel();
		Response json = new Response();
		Util util = new Util();

		[Route("login")]
		[HttpPost]
		public IHttpActionResult Login([FromBody] UserModel user)
		{
			if (user != null && user.email != null && user.password != null && user.email.Length <= 100 && user.password.Length <= 100){
				//HttpContext.Current.Request.UserAgent
				DataTable response = userModel.Login(user.email, user.password);
				if (response.Rows[0].ItemArray.GetValue(0).ToString() == "OK")
				{
					Token token = new Token();
					String nombres = response.Rows[0].ItemArray.GetValue(1).ToString();
					String apellidos = response.Rows[0].ItemArray.GetValue(2).ToString();
					String foto = response.Rows[0].ItemArray.GetValue(3).ToString();

					token.token = util.tokenSesion(nombres, apellidos, user.email, foto);
					return Json(token);
				}
				else 
				{ 
					return Json(response);
				}
			}
			else
			{
				return Json(json);
			}
		}

		[Route("signup")]
		[HttpPost]
		public IHttpActionResult Signup([FromBody] UserModel user)
		{
			if (user != null &&
			    user.nombres != null && user.nombres.Length <= 100 && 
			    user.apellidos != null && user.apellidos.Length <= 100 && 
			    user.email != null && user.password != null && 
			    user.email.Length <= 100 && user.password.Length <= 100)
			{
				//HttpContext.Current.Request.UserAgent
				DataTable response = userModel.Signup(user.empresa_id.ToString(), user.nombres, user.apellidos, user.email, user.password);
				if (response.Rows[0].ItemArray.GetValue(0).ToString() == "OK")
				{
					Token token = new Token();
					token.token = util.tokenSesion(user.nombres, user.apellidos, user.email, null);
					return Json(token);
				}
				else
				{
					return Json(response);
				}
			}
			else
			{
				return Json(json);
			}
		}

		[Route("permissions")]
		[HttpPost]
		public IHttpActionResult Permissions([FromBody] UserModel user)
		{
			if (user != null && user.email != null && user.password != null && user.email.Length <= 100 && user.password.Length <= 100)
			{
				//HttpContext.Current.Request.UserAgent
				DataTable response = userModel.Login(user.email, user.password);
				if (response.Rows[0].ItemArray.GetValue(0).ToString() == "OK")
				{
					Token token = new Token();
					String nombres = response.Rows[0].ItemArray.GetValue(1).ToString();
					String apellidos = response.Rows[0].ItemArray.GetValue(2).ToString();
					String foto = response.Rows[0].ItemArray.GetValue(3).ToString();

					token.token = util.tokenSesion(nombres, apellidos, user.email, foto);
					return Json(token);
				}
				else
				{
					return Json(response);
				}
			}
			else
			{
				return Json(json);
			}
		}

		[Route("test")]
		[HttpGet]
		public IHttpActionResult Test()
		{
			return Json("hola");
		}
	}

	public class Token {
		public String token { get; set; }
	}

}
