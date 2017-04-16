using System;
using System.Collections.Generic;
using System.Web;
using System.Data;
using JWT;
using JWT.Serializers;
using Newtonsoft.Json;
using static JWT.JsonWebToken;

namespace road
{
	public class Util
	{
		private String secret = "webapiautocar23";

		public String tokenSesion(String empresa_id, String name, String lastname, String email, String photo)
		{
			var payload = new Dictionary<string, object>()
					{
						{ "empresa_id", empresa_id },
						{ "name", name },
						{ "lastname", lastname },
						{ "email", email },
						{ "photo", photo }
					};

			return Encode(payload, secret, JWT.JwtHashAlgorithm.HS256);
		}

		public Object[] Authorization() {
			string[] token = HttpContext.Current.Request.Headers.GetValues("Authorization");
			Object[] response = new Object[3];
			if (token != null)
			{
				try
				{
					IJsonSerializer serializer = new JsonNetSerializer();
					IDateTimeProvider provider = new UtcDateTimeProvider();
					IJwtValidator validator = new JwtValidator(serializer, provider);
					IBase64UrlEncoder urlEncoder = new JwtBase64UrlEncoder();
					IJwtDecoder decoder = new JwtDecoder(serializer, validator, urlEncoder);

					var json = decoder.Decode(token[0], secret, verify: true);
					DataTable payload = (DataTable)JsonConvert.DeserializeObject<DataTable>("[" + json + "]");

					UserModel user = new UserModel();
					user.empresa_id = payload.Rows[0].ItemArray.GetValue(0).ToString();
					user.nombres = payload.Rows[0].ItemArray.GetValue(1).ToString();
					user.apellidos = payload.Rows[0].ItemArray.GetValue(2).ToString();
					user.email = payload.Rows[0].ItemArray.GetValue(3).ToString();
					user.foto = payload.Rows[0].ItemArray.GetValue(4).ToString();

					response[0] = "OK";
					response[1] = user;
				}
				catch (TokenExpiredException)
				{
					response[0] = "ERROR";
					response[1] = "token_expired";
					response[2] = "El token ha expirado.";
				}
				catch (SignatureVerificationException)
				{
					response[0] = "ERROR";
					response[1] = "token_invalid";
					response[2] = "El token de sesión es invalido.";
				}
			}
			else
			{
				response[0] = "ERROR";
				response[1] = "token_null";
				response[2] = "No fue suministrado un token.";
			}
			return response;
		}
	}
}
