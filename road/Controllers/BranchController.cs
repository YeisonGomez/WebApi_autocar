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
	[RoutePrefix("api/branch")]
    public class BranchController : ApiController
    {	
		Response json = new Response();
		UserModel userModel = new UserModel();
		BranchModel branchModel = new BranchModel();
		Util util = new Util();

		[Route("all")]
		[HttpGet]
		public IHttpActionResult GetAll(String empresa_id)
		{
			return Json(branchModel.GetAll(empresa_id));
		}
	}
}
