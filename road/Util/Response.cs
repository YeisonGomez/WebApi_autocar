using System;
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

	}
	
}