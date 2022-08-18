using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CPDesarrollo22.Interface.Request.Almacen
{
	public class FamilyRequest
	{
		[JsonProperty("Familia")]
		public int Id { get; set; }
		[JsonProperty("Des")]
		public string Description { get; set; }		
		[JsonProperty("Linea")]
		public string Line { get; set; }
	}
}