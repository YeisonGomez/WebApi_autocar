using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace road
{
	public class FavoriteModel
	{
		public Response response = new Response();
		Connection con = new Connection();

		public DataTable AddFavorite(string email, string vehicle_id, string state)
		{
			try
			{
				String[] keys = { "p_email", "p_vehicle_id", "p_state" };
				String[] values = { email, vehicle_id, state };
				DataTable response = con.RunProcedure("ADD_FAVORITE", keys, values);
				return response;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return null;
			}
		}
	}
}
