using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace road
{
	public class FavoriteModel
	{
		public Response response = new Response();
		Connection con = new Connection();

		public DataTable AddFavorite(string user_id, string vehicle_id)
		{
			try
			{
				String[] keys = { "p_user_id", "p_vehicle_id" };
				String[] values = { user_id, vehicle_id };
				DataTable response = con.RunProcedure("ADD_FAVORITE", keys, values);
				return response;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return null;
			}
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
