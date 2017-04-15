﻿using System;
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

		public DataTable GetAll()
		{
			DataTable response = con.RunProcedure("CONSULTAR_VEHICULOS", null, null);
			return response;
		}
	}
}
