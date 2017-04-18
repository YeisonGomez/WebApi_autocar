using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace road
{
	public class UserModel
	{
		public Response response = new Response();
		public int id { get; set; }
		public String empresa_id { get; set; }
		public String nombres { get; set; }
		public String apellidos { get; set; }
		public int genero { get; set; }
		public String email { get; set; }
		public String password { get; set; }
		public int celular { get; set; }
		public int fecha_registro { get; set; }
		public String foto { get; set; }

		public UserModel()
		{
		}

		Connection con = new Connection();

		public DataTable Login(String email, String password)
		{
			try
			{
				String[] keys = { "p_email", "p_password" };
				String[] values = { email, password };
				DataTable response = con.RunProcedure("AUTORIZACION_LOGIN", keys, values);
				return response;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return null;
			}
		}

		public DataTable Signup(String empresa, String nombres, String apellidos, String email, String password)
		{
			DataTable respons = null;
			try
			{
				String[] keys = { "p_empresa", "p_nombres", "p_apellidos", "p_email", "p_password" };
				String[] values = { empresa, nombres, apellidos, email, password };
				respons = con.RunProcedure("CREATE_USER", keys, values);
			}
			catch (MySqlException ex)
			{
				if (ex.Number == 1062) {
					respons = response.MysqlException("duplicate_email", "El correo ya existe.");	
				}
			}
			return respons;
		}

		public DataTable GetPermissions(String email) { 
			String[] keys = { "p_email" };
			String[] values = { email };
			DataTable respons = con.RunProcedure("GET_PERMISSIONS", keys, values);
			return respons;
		}

		public DataTable GetRols(String email)
		{
			String[] keys = { "p_email" };
			String[] values = { email };
			DataTable respons = con.RunProcedure("GET_ROLS", keys, values);
			return respons;
		}

		public DataTable GetUserReserve(String email)
		{
			String[] keys = { "p_email" };
			String[] values = { email };
			DataTable respons = con.RunProcedure("GET_USER_RESERVE", keys, values);
			return respons;
		}
	}
}
