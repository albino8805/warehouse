using CPDesarrollo22.Interface.Response.Almacen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VisualSoftErp.Interfaces;

namespace CPDesarrollo22.Controllers
{
	/// <summary>
	/// CatalogsController
	/// </summary>
	/// <seealso cref="System.Web.Mvc.Controller" />
	public class CatalogsController : Controller
	{
		/// <summary>
		/// Grids this instance.
		/// </summary>
		/// <returns></returns>
		public ActionResult Grid()
		{
			CatalogResponse resp = new CatalogResponse();
			try
			{

				MalocClient cliente = new MalocClient();
				string url = System.Configuration.ConfigurationManager.AppSettings["wsurl"];
				resp = cliente.PeticionesWSPost<CatalogResponse>(url, "AlmacenyCompras.svc/ArticulosInventarioCombos", null);

				return Json(resp);
			}
			catch (Exception)
			{
				return Json(resp);
			}
		}
	}
}