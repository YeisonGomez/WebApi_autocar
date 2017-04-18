using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Newtonsoft.Json;

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
				if (response != null && response.Rows[0].ItemArray.GetValue(0).ToString() == "OK")
				{
					Token token = new Token();
					String nombres = response.Rows[0].ItemArray.GetValue(1).ToString();
					String apellidos = response.Rows[0].ItemArray.GetValue(2).ToString();
					String foto = response.Rows[0].ItemArray.GetValue(3).ToString();
					String empresa_id = response.Rows[0].ItemArray.GetValue(4).ToString();

					token.token = util.tokenSesion(empresa_id, nombres, apellidos, user.email, foto);
					return Json(token);
				}
				else 
				{
					/*return new System.Web.Http.Results.ResponseMessageResult(
		                Request.CreateErrorResponse(
		                    (HttpStatusCode)422,
		                    new HttpError("Something goes wrong")
		                )
		            );*/
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
				DataTable response = userModel.Signup(user.empresa_id, user.nombres, user.apellidos, user.email, user.password);
				if (response != null && response.Rows[0].ItemArray.GetValue(0).ToString() == "OK")
				{
					Token token = new Token();
					token.token = util.tokenSesion(user.empresa_id.ToString(), user.nombres, user.apellidos, user.email, null);
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
		[HttpGet]
		public IHttpActionResult Permissions()
		{
			Object[] auth = util.Authorization();
			if ((String)auth[0] == "OK")
			{
				UserModel payload = (UserModel)auth[1];
				return Json(userModel.GetPermissions(payload.email));
			}
			else 
			{
				return Json(json.MysqlException((String)auth[1], (String)auth[2]));
			}
		}

		[Route("get-rol")]
		[HttpGet]
		public IHttpActionResult GetRols()
		{
			Object[] auth = util.Authorization();
			if ((String)auth[0] == "OK")
			{
				UserModel payload = (UserModel)auth[1];
				return Json(userModel.GetRols(payload.email));
			}
			else
			{
				return Json(json.MysqlException((String)auth[1], (String)auth[2]));
			}
		}

		[Route("get-reserve")]
		[HttpGet]
		public IHttpActionResult GetUserReserve()
		{
			Object[] auth = util.Authorization();
			if ((String)auth[0] == "OK")
			{
				UserModel payload = (UserModel)auth[1];
				return Json(userModel.GetUserReserve(payload.email));
			}
			else
			{
				return Json(json.MysqlException((String)auth[1], (String)auth[2]));
			}
		}
	}

	public class Token {
		public String token { get; set; }
	}

}
