using CartasPorteDesarrollo.Interface.Response.Almacen;
using CPDesarrollo22.Interface.Request;
using CPDesarrollo22.Interface.Request.Almacen;
using CPDesarrollo22.Interface.Response;
using CPDesarrollo22.Interface.Response.Almacen;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using VisualSoftErp.Interfaces;

namespace CPDesarrollo22.Controllers
{
	public class ItemsController : Controller
    {
        private readonly string ImagePath = System.Configuration.ConfigurationManager.AppSettings["imagePath"];
        private readonly string ImagePathFront = System.Configuration.ConfigurationManager.AppSettings["imagePathFront"];

        // GET: Lineas
        public ActionResult Index()
        {
            return View();
        }

        //Llena Grid
        public ActionResult Grid()
        {
            ItemResponse resp = new ItemResponse();
            try
            {
                MalocClient cliente = new MalocClient();
                string url = System.Configuration.ConfigurationManager.AppSettings["wsurl"];
                resp = cliente.PeticionesWSPost<ItemResponse>(url, "AlmacenyCompras.svc/ArticulosInventarioGrid", null);

                foreach(var item in resp.Items)
				{
					if (!String.IsNullOrEmpty(item.Imagen))
					{
                        item.Imagen = ImagePathFront + "/" + item.Imagen;
                    }
				}

                return Json(resp);
            }
            catch (Exception)
            {
                return Json(resp);
            }
        }

        [HttpPost]
        public ActionResult UploadImage()
        {
            crudResponse resp = new crudResponse();

            if (Request.Files.Count > 0)
            {
                try
                {
                    HttpFileCollectionBase files = Request.Files;
                    for (int i = 0; i < files.Count; i++)
                    {
                        HttpPostedFileBase file = files[i];
                        string fileName;

                        var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
                        fileName = Guid.NewGuid().ToString() + extension;

                        var pathBuilt = Path.Combine(ImagePath);

                        if (!Directory.Exists(pathBuilt))
                        {
                            Directory.CreateDirectory(pathBuilt);
                        }

                        var path = Path.Combine(Server.MapPath(ImagePath),
                           fileName);

                        file.SaveAs(path);

                        resp.Result = fileName;
                    }
                }
                catch (Exception ex)
                {
                    resp.Result = ex.Message;
                    return Json(resp);
                }
            }

            return Json(resp);
        }

        public ActionResult Add(ItemRequest request)
        {
            crudResponse resp = new crudResponse();
            try
            {
                Console.WriteLine(JsonConvert.SerializeObject(request));
                MalocClient cliente = new MalocClient();
                string url = System.Configuration.ConfigurationManager.AppSettings["wsurl"];
                resp = cliente.PeticionesWSPost<crudResponse>(url, "AlmacenyCompras.svc/ArticulosInventarioCrud", request);

                return Json(resp);
            }
            catch (Exception ex)
            {
                resp.Result = ex.Message;
                return Json(resp);
            }
        }

        public ActionResult Delete(int ID)
        {
            crudResponse resp = new crudResponse();

            try
            {
                LlenaCajasRequest request = new LlenaCajasRequest();
                request.ID = ID;

                MalocClient cliente = new MalocClient();
                string url = System.Configuration.ConfigurationManager.AppSettings["wsurl"];
                resp = cliente.PeticionesWSPost<crudResponse>(url, "AlmacenyCompras.svc/ArticulosInventarioEliminar", request);

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