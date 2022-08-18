using CartasPorteDesarrollo.Interface.Response.Almacen;
using CPDesarrollo22.Interface.Request;
using CPDesarrollo22.Interface.Response;
using System;
using System.Web.Mvc;
using VisualSoftErp.Interfaces;

namespace CartasPorteDesarrollo.Controllers
{
	public class LineasController : Controller
    {
        // GET: Lineas
        public ActionResult Index()
        {
            return View();
        }

        //Llena Grid
        public ActionResult Grid()
        {
            LineasResponse resp = new LineasResponse();
            try
            {               

                MalocClient cliente = new MalocClient();
                string url = System.Configuration.ConfigurationManager.AppSettings["wsurl"];
                resp = cliente.PeticionesWSPost<LineasResponse>(url, "AlmacenyCompras.svc/LineasGrid", null);

                return Json(resp);
            }
            catch(Exception)
            {
                return Json(resp);
            }
           
        }

        public ActionResult Guardar(int ID,string Des)
        {
            crudResponse resp = new crudResponse();
            try
            {
                LineasCrudRequest request = new LineasCrudRequest();
                request.Des = Des;
                request.LineasID = ID;
                
                MalocClient cliente = new MalocClient();
                string url = System.Configuration.ConfigurationManager.AppSettings["wsurl"];
                resp = cliente.PeticionesWSPost<crudResponse>(url, "AlmacenyCompras.svc/LineasCrud", request);

                return Json(resp);
            }
            catch (Exception ex)
            {
                resp.Result = ex.Message;
                return Json(resp);
            }

        }

        public ActionResult Eliminar(int ID)
        {
            crudResponse resp = new crudResponse();

            try
            {
                LlenaCajasRequest request = new LlenaCajasRequest();
                request.ID = ID;

                MalocClient cliente = new MalocClient();
                string url = System.Configuration.ConfigurationManager.AppSettings["wsurl"];
                resp = cliente.PeticionesWSPost<crudResponse>(url, "AlmacenyCompras.svc/LineasEliminar", request);

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