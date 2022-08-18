using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CartasPorteDesarrollo.Interface.Response.Almacen
{
	/// <summary>
	/// LineasResponse
	/// </summary>
	public class LineasResponse
    {
		/// <summary>
		/// Gets or sets the lineas.
		/// </summary>
		/// <value>
		/// The lineas.
		/// </value>
		public List<LineasCamposResponse> lineas { get; set; }
    }

	/// <summary>
	/// 
	/// </summary>
	public class LineasCamposResponse
    {
		/// <summary>
		/// Gets or sets the linea.
		/// </summary>
		/// <value>
		/// The linea.
		/// </value>
		public int Linea { get; set; }
		/// <summary>
		/// Gets or sets the DES.
		/// </summary>
		/// <value>
		/// The DES.
		/// </value>
		public string Des { get; set; }
		/// <summary>
		/// Gets or sets the result.
		/// </summary>
		/// <value>
		/// The result.
		/// </value>
		public string Result { get; set; }
    }
}