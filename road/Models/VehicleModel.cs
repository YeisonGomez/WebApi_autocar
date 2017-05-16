using System;
using System.Data;

namespace road
{
	public class VehicleModel
	{
		public int sucursal_id { get; set; }
		public int sucursal_nombre { get; set; }
		public int modelo { get; set; }
		public int marca_id { get; set; }
		public int marca_nombre { get; set; }
		public int proveedor_id { get; set; }
		public int tipo_combustible_id { get; set; }
		public int tipo_combustible_name { get; set; }
		public int tipo_vehiculo_id { get; set; }
		public int tipo_vehiculo_nombre { get; set; }
		public int precio_dia { get; set; }
		public int img { get; set; }

		Connection con = new Connection();

		public DataTable GetAll(String limit, String after, String empresa_id, String email)
		{
			String[] keys = { "p_limit", "p_after", "p_empresa_id", "p_email" };
			String[] values = { limit, after, empresa_id, email };
			DataTable response = con.RunProcedure("GET_VEHICLES", keys, values);
			return response;
		}

		public DataTable GetVehicle(String vehicle_id, String email)
		{
			String[] keys = { "p_vehicle_id", "p_email" };
			String[] values = { vehicle_id, email };
			DataTable response = con.RunProcedure("GET_VEHICLE", keys, values);
			return response;
		}

		public DataTable getReserveVehicle(String vehicle_id)
		{
			String[] keys = { "p_vehicle_id" };
			String[] values = { vehicle_id };
			DataTable response = con.RunProcedure("GET_RESERVE_VEHICLE", keys, values);
			return response;
		}

	}
}
