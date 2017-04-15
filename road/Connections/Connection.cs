using System;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;

namespace road
{
	public class Connection
	{
		private static MySqlConnection conexion = new MySqlConnection(ConfigurationManager.ConnectionStrings["road_local"].ConnectionString);

		private static bool Conectar()
		{
			try
			{
				conexion.Open();
				return true;
			}
			catch (Exception)
			{

				return false;
			}
		}

		private static void Desconectar()
		{
			conexion.Close();
		}

		public DataTable RunProcedure(string name_procedure, string[] keys, string[] values)
		{
			using (MySqlConnection con = new MySqlConnection(ConfigurationManager.ConnectionStrings["road_local"].ConnectionString))
			{
				using (MySqlCommand cmd = new MySqlCommand(name_procedure, con))
				{
					cmd.CommandType = CommandType.StoredProcedure;
					if (keys != null)
					{
						for (int i = 0; i < keys.Length; i++)
						{
							cmd.Parameters.AddWithValue(keys[i], values[i]);
						}
					}

					using (MySqlDataAdapter sda = new MySqlDataAdapter(cmd))
					{
						DataTable dt = new DataTable();
						sda.Fill(dt);
						return dt;
					}
				}
			}
		}

		public DataTable EjecutarConsulta(string sentencia, CommandType TipoComando)
		{
			MySqlDataAdapter adaptador = new MySqlDataAdapter();
			adaptador.SelectCommand = new MySqlCommand(sentencia, conexion);
			adaptador.SelectCommand.CommandType = TipoComando;

			DataSet resultado = new DataSet();
			adaptador.Fill(resultado);

			return resultado.Tables[0];
		}

		public bool RealizarTransaccion(string[] cadena)
		{
			bool state = false;
			if (Conectar())
			{
				MySqlTransaction Transa = conexion.BeginTransaction();
				MySqlCommand cmd = null;
				try
				{
					for (int i = 0; i < cadena.Length; i++)
					{
						if (cadena[i].Length > 0)
						{
							cmd = new MySqlCommand(cadena[i], conexion);
							cmd.Transaction = Transa;
							cmd.ExecuteNonQuery();
						}
					}
					Transa.Commit();
					conexion.Close();
					conexion.Dispose();
					Transa.Dispose();
					Desconectar();
					state = true;
				}
				catch
				{
					Transa.Rollback();
					conexion.Close();
					conexion.Dispose();
					Desconectar();
					state = false;
				}
				finally
				{
					// Recolectamos objetos para liberar su memoria.
					if (cmd != null)
					{
						cmd.Dispose();
					}
				}
			}

			return state;
		}
	}
}
