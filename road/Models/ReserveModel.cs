using System;
using System.Data;

namespace road
{
	public class ReserveModel
	{
		Connection con = new Connection();

		public DataTable GetAll(String empresa_id)
		{
			String[] keys = { "p_empresa_id" };
			String[] values = { empresa_id };
			DataTable response = con.RunProcedure("GET_SUCURSALES", keys, values);
			return response;
		}
	}
}
