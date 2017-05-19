using System;
using System.Data;

namespace road
{
	public class ReserveModel
	{
		public String id { get; set; }
		public String description { get; set; }
		public String fecha_inicio { get; set; }
		public String fecha_fin { get; set; }
		public String sucursal_entrega { get; set; }
		public String vehiculo_id { get; set; }
		public String sucursal_id { get; set; }
		public String conductor { get; set; }
		public String state { get; set; }

		Connection con = new Connection();

		public DataTable GetAll(String fecha_inicio, String fecha_fin, String sucursal_entrega, String vehiculo_id, String email, String sucursal_id, String conductor)
		{
			String[] keys = {"p_fecha_inicia", "p_fecha_final", "p_sucursal_entrega", "p_vehiculo_id", "p_email", "p_sucursal_id", "p_conductor" };
			String[] values = { fecha_inicio, fecha_fin, sucursal_entrega, vehiculo_id, email, sucursal_id, conductor };
			DataTable response = con.RunProcedure("RESERVE_VEHICLE", keys, values);
			return response;
		}

		public DataTable ReserveReject(String email, String id, String description)
		{
			String[] keys = { "p_email", "p_id", "p_description" };
			String[] values = { email, id, description };
			DataTable response = con.RunProcedure("REJECT_RESERVE", keys, values);
			return response;
		}

		public DataTable getClienteReserve(String email)
		{
			String[] keys = { "p_email" };
			String[] values = { email };
			DataTable response = con.RunProcedure("GET_RESERVES_CLIENT", keys, values);
			return response;
		}
	}
}
