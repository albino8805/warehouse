using CartasPorteDesarrollo.Interface.Response.Almacen;
using CPDesarrollo22.Interface.Request;
using CPDesarrollo22.Interface.Request.Almacen;
using CPDesarrollo22.Interface.Response;
using CPDesarrollo22.Interface.Response.Almacen;
using System;
using System.Web.Mvc;
using VisualSoftErp.Interfaces;

namespace CPDesarrollo22.Controllers
{
	public class FamiliesController : Controller
    {
        // GET: Lineas
        public ActionResult Index()
        {
            return View();
        }

        //Llena Grid
        public ActionResult Grid()
        {
            FamilyResponse resp = new FamilyResponse();
            try
            {
                MalocClient cliente = new MalocClient();
                string url = System.Configuration.ConfigurationManager.AppSettings["wsurl"];
                resp = cliente.PeticionesWSPost<FamilyResponse>(url, "AlmacenyCompras.svc/FamiliasGrid", null);

                return Json(resp);
            }
            catch (Exception)
            {
                return Json(resp);
            }

        }

        public ActionResult Add(FamilyRequest request)
        {
            crudResponse resp = new crudResponse();
            try
            {
                MalocClient cliente = new MalocClient();
                string url = System.Configuration.ConfigurationManager.AppSettings["wsurl"];
                resp = cliente.PeticionesWSPost<crudResponse>(url, "AlmacenyCompras.svc/FamiliasCrud", request);

                return Json(resp);
            }
            catch (Exception ex)
            {
                resp.Result = ex.Message;
                return Json(resp);
            }
        }

        public ActionResult Eliminar(int id)
        {
            crudResponse resp = new crudResponse();

            try
            {
                FamilyRequest request = new FamilyRequest();
                request.Id = id;

                MalocClient cliente = new MalocClient();
                string url = System.Configuration.ConfigurationManager.AppSettings["wsurl"];
                resp = cliente.PeticionesWSPost<crudResponse>(url, "AlmacenyCompras.svc/FamiliasEliminar", request);

                return Json(resp);
            }
            catch (Exception ex)
            {
                resp.Result = ex.Message;
                return Json(resp);
            }
        }
    }
}