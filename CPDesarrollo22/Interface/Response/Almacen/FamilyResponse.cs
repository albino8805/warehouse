using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CPDesarrollo22.Interface.Response.Almacen
{
	/// <summary>
	/// FamilyResponse
	/// </summary>
	public class FamilyResponse
	{
		/// <summary>
		/// Gets or sets the families.
		/// </summary>
		/// <value>
		/// The families.
		/// </value>
		[JsonProperty("Familias")]
		public List<FamilyFieldResponse> Families { get; set; }
	}

	/// <summary>
	/// FamilyFieldResponse
	/// </summary>
	public class FamilyFieldResponse
	{
		/// <summary>
		/// Gets or sets the description.
		/// </summary>
		/// <value>
		/// The description.
		/// </value>
		[JsonProperty("Des")]
		public string Description { get; set; }
		/// <summary>
		/// Gets or sets the family.
		/// </summary>
		/// <value>
		/// The family.
		/// </value>
		[JsonProperty("Familia")]
		public string Family { get; set; }
		/// <summary>
		/// Gets or sets the line.
		/// </summary>
		/// <value>
		/// The line.
		/// </value>
		[JsonProperty("Linea")]
		public string Line { get; set; }
		/// <summary>
		/// Gets or sets the result.
		/// </summary>
		/// <value>
		/// The result.
		/// </value>
		public string Result { get; set; }
	}
}