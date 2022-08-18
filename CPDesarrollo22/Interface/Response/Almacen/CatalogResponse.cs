using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CPDesarrollo22.Interface.Response.Almacen
{
	/// <summary>
	/// CatalogResponse
	/// </summary>
	public class CatalogResponse
	{
		/// <summary>
		/// Gets or sets the families.
		/// </summary>
		/// <value>
		/// The families.
		/// </value>
		[JsonProperty("Familias")]
		public List<Family> Families {get; set;}
		/// <summary>
		/// Gets or sets the currencies.
		/// </summary>
		/// <value>
		/// The currencies.
		/// </value>
		[JsonProperty("Monedas")]
		public List<Currency> Currencies { get; set; }
		/// <summary>
		/// Gets or sets the suppliers.
		/// </summary>
		/// <value>
		/// The suppliers.
		/// </value>
		[JsonProperty("Proveedores")]
		public List<Supplier> Suppliers { get; set; }
		/// <summary>
		/// Gets or sets the um.
		/// </summary>
		/// <value>
		/// The um.
		/// </value>
		[JsonProperty("UM")]
		public List<UM> UM { get; set; }
	}

	/// <summary>
	/// Family
	/// </summary>
	public class Family
	{
		/// <summary>
		/// Gets or sets the identifier.
		/// </summary>
		/// <value>
		/// The identifier.
		/// </value>
		[JsonProperty("ID")]
		public int Id { get; set; }
		/// <summary>
		/// Gets or sets the description.
		/// </summary>
		/// <value>
		/// The description.
		/// </value>
		[JsonProperty("Des")]
		public string Description { get; set; }
	}

	/// <summary>
	/// Currency
	/// </summary>
	public class Currency
	{
		/// <summary>
		/// Gets or sets the identifier.
		/// </summary>
		/// <value>
		/// The identifier.
		/// </value>
		[JsonProperty("ID")]
		public string Id { get; set; }
		/// <summary>
		/// Gets or sets the description.
		/// </summary>
		/// <value>
		/// The description.
		/// </value>
		[JsonProperty("Des")]
		public string Description { get; set; }
	}

	/// <summary>
	/// Supplier
	/// </summary>
	public class Supplier
	{
		/// <summary>
		/// Gets or sets the identifier.
		/// </summary>
		/// <value>
		/// The identifier.
		/// </value>
		[JsonProperty("ID")]
		public int Id { get; set; }
		/// <summary>
		/// Gets or sets the description.
		/// </summary>
		/// <value>
		/// The description.
		/// </value>
		[JsonProperty("Des")]
		public string Description { get; set; }
	}

	/// <summary>
	/// UM
	/// </summary>
	public class UM
	{
		/// <summary>
		/// Gets or sets the identifier.
		/// </summary>
		/// <value>
		/// The identifier.
		/// </value>
		[JsonProperty("ID")]
		public int Id { get; set; }
		/// <summary>
		/// Gets or sets the description.
		/// </summary>
		/// <value>
		/// The description.
		/// </value>
		[JsonProperty("Des")]
		public string Description { get; set; }
	}
}