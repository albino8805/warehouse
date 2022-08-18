using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CPDesarrollo22.Interface.Request.Almacen
{
	/// <summary>
	/// ItemRequest
	/// </summary>
	public class ItemRequest
	{
		/// <summary>
		/// Gets or sets the activo.
		/// </summary>
		/// <value>
		/// The activo.
		/// </value>
		public int Activo { get; set; }
		/// <summary>
		/// Gets or sets the articulo.
		/// </summary>
		/// <value>
		/// The articulo.
		/// </value>
		public string Articulo { get; set; }
		/// <summary>
		/// Gets or sets the articulos identifier.
		/// </summary>
		/// <value>
		/// The articulos identifier.
		/// </value>
		public int ArticulosID { get; set; }
		/// <summary>
		/// Gets or sets the clave sat.
		/// </summary>
		/// <value>
		/// The clave sat.
		/// </value>
		public string ClaveSat { get; set; }
		/// <summary>
		/// Gets or sets the codigodebarras.
		/// </summary>
		/// <value>
		/// The codigodebarras.
		/// </value>
		public string Codigodebarras { get; set; }
		/// <summary>
		/// Gets or sets the costo.
		/// </summary>
		/// <value>
		/// The costo.
		/// </value>
		public decimal Costo { get; set; }
		/// <summary>
		/// Gets or sets the diasstock.
		/// </summary>
		/// <value>
		/// The diasstock.
		/// </value>
		public int Diasstock { get; set; }
		/// <summary>
		/// Gets or sets the esunkit.
		/// </summary>
		/// <value>
		/// The esunkit.
		/// </value>
		public int Esunkit { get; set; }
		/// <summary>
		/// Gets or sets the familias identifier.
		/// </summary>
		/// <value>
		/// The familias identifier.
		/// </value>
		public int FamiliasID { get; set; }
		/// <summary>
		/// Gets or sets the imagen.
		/// </summary>
		/// <value>
		/// The imagen.
		/// </value>
		public string Imagen { get; set; }
		/// <summary>
		/// Gets or sets the maneja existencia.
		/// </summary>
		/// <value>
		/// The maneja existencia.
		/// </value>
		public int ManejaExistencia { get; set; }
		/// <summary>
		/// Gets or sets the manejapedimentos.
		/// </summary>
		/// <value>
		/// The manejapedimentos.
		/// </value>
		public int Manejapedimentos { get; set; }
		/// <summary>
		/// Gets or sets the maximo.
		/// </summary>
		/// <value>
		/// The maximo.
		/// </value>
		public int Maximo { get; set; }
		/// <summary>
		/// Gets or sets the minimo.
		/// </summary>
		/// <value>
		/// The minimo.
		/// </value>
		public int Minimo { get; set; }
		/// <summary>
		/// Gets or sets the monedas identifier.
		/// </summary>
		/// <value>
		/// The monedas identifier.
		/// </value>
		public string MonedasID { get; set; }
		/// <summary>
		/// Gets or sets the nombre.
		/// </summary>
		/// <value>
		/// The nombre.
		/// </value>
		public string Nombre { get; set; }
		/// <summary>
		/// Gets or sets the nombre oc.
		/// </summary>
		/// <value>
		/// The nombre oc.
		/// </value>
		public string NombreOC { get; set; }
		/// <summary>
		/// Gets or sets the obsoleto.
		/// </summary>
		/// <value>
		/// The obsoleto.
		/// </value>
		public int Obsoleto { get; set; }
		/// <summary>
		/// Gets or sets the proveedores identifier.
		/// </summary>
		/// <value>
		/// The proveedores identifier.
		/// </value>
		public int ProveedoresID { get; set; }
		/// <summary>
		/// Gets or sets the ptje ieps.
		/// </summary>
		/// <value>
		/// The ptje ieps.
		/// </value>
		public decimal PtjeIeps { get; set; }
		/// <summary>
		/// Gets or sets the ptje iva.
		/// </summary>
		/// <value>
		/// The ptje iva.
		/// </value>
		public decimal PtjeIva { get; set; }
		/// <summary>
		/// Gets or sets the reorden.
		/// </summary>
		/// <value>
		/// The reorden.
		/// </value>
		public int Reorden { get; set; }
		/// <summary>
		/// Gets or sets the tiempodeentrega.
		/// </summary>
		/// <value>
		/// The tiempodeentrega.
		/// </value>
		public int Tiempodeentrega { get; set; }
		/// <summary>
		/// Gets or sets the ubicacion.
		/// </summary>
		/// <value>
		/// The ubicacion.
		/// </value>
		public string Ubicacion { get; set; }
		/// <summary>
		/// Gets or sets the unidadesdemedida identifier.
		/// </summary>
		/// <value>
		/// The unidadesdemedida identifier.
		/// </value>
		public int UnidadesdemedidaID { get; set;}
	}
}