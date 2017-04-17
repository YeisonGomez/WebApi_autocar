using System;
using System.Data;

namespace road
{
	public class ReserveModel
	{
		Connection con = new Connection();

		public DataTable GetAll(String fecha_inicio, String fecha_fin, String sucursal_entrega, String vehiculo_id, String usuario_id, String sucursal_id, String conductor)
		{
			String[] keys = {"p_fecha_inicia", "p_fecha_final", "p_sucursal_entrega", "p_vehiculo_id", "p_usuario_id", "p_sucursal_id", "p_conductor" };
			String[] values = { fecha_inicio, fecha_fin, sucursal_entrega, vehiculo_id, usuario_id, sucursal_id, conductor };
			DataTable response = con.RunProcedure("RESERVE_VEHICLE", keys, values);
			return response;
		}
	}
}
