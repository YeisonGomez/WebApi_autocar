using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace road
{
	public class PaysheetModel
	{	
		public Response response = new Response();
		Connection con = new Connection();

		public DataTable Payment(string email, string type)
		{
			try
			{
				String[] keys = { "p_email", "p_type" };
				String[] values = { email, type };
				DataTable response = con.RunProcedure("GET_PAYMENT", keys, values);
				return response;
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				return null;
			}
		}

		public DataTable GetHistoryPayment(string email, string contract_id)
		{
			try
			{
				String[] keys = { "p_email", "p_contrato" };
				String[] values = { email, contract_id };
				DataTable response = con.RunProcedure("GET_HISTORY_PAYMENT", keys, values);
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


