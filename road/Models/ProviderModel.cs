using System;
using System.Data;

namespace road
{
	public class ProviderModel
	{
		public Response response = new Response();
		Connection con = new Connection();

		public DataTable getVehicleProvider(string email)
		{
			try
			{
				String[] keys = { "p_email" };
				String[] values = { email };
				DataTable response = con.RunProcedure("GET_VEHICLE_PROVEDOR", keys, values);
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
