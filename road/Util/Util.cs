using System;
using System.Collections.Generic;
using JWT;

namespace road
{
	public class Util
	{
		private String secret = "webapiautocar23";

		public String tokenSesion(String name, String lastname, String email, String photo)
		{
			var payload = new Dictionary<string, object>()
					{
						{ "name", name },
						{ "lastname", lastname },
						{ "email", email },
						{ "photo", photo }
					};

			return JWT.JsonWebToken.Encode(payload, secret, JWT.JwtHashAlgorithm.HS256);
		}
	}
}
