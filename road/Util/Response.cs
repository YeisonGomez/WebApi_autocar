using System;
using System.Data;

namespace road
{
	public class Response { 
		public String status { get; set; }
		public String type { get; set; }
		public String description { get; set; }

		public Response() {
			this.clearJSON();
		}

		public void clearJSON() { 
			this.status = "ERROR";
			this.type = "error_null";
			this.description = "No se han suministrado datos.";
		}

		public DataTable MysqlException(String type, String description) {
			DataTable table = new DataTable();
			DataColumn column;
			DataRow row;

			// Create new DataColumn, set DataType, ColumnName and add to DataTable.    
			column = new DataColumn();
			column.DataType = System.Type.GetType("System.String");
		    column.ColumnName = "status";
		    table.Columns.Add(column);

		    // Create second column.
		    column = new DataColumn();
			column.DataType = System.Type.GetType("System.String");
		    column.ColumnName = "type";
		    table.Columns.Add(column);

			// Create tree column.
		    column = new DataColumn();
			column.DataType = System.Type.GetType("System.String");
		    column.ColumnName = "description";
		    table.Columns.Add(column);


			row = table.NewRow();
        	row["status"] = "ERROR";
        	row["type"] = type;
			row["description"] = description;
        	table.Rows.Add(row);
			return table;
		}

	}
	
}