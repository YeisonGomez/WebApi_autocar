using System;
using System.Data;

namespace road
{
	public class UserModel
	{

		public int id { get; set; }
		public int empresa_id { get; set; }
		public String nombres { get; set; }
		public String apellidos { get; set; }
		public int genero { get; set; }
		public String email { get; set; }
		public String password { get; set; }
		public int celular { get; set; }
		public int fecha_registro { get; set; }

		public UserModel()
		{
		}

		Connection con = new Connection();

		public DataTable Login(String email, String password)
		{
			String[] keys = { "p_email", "p_password" };
			String[] values = { email, password };
			DataTable response = con.RunProcedure("AUTORIZACION_LOGIN", keys, values);
			return response;
		}
	}
}
