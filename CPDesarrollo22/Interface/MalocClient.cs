using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisualSoftErp.Interfaces
{
    public class MalocClient
    {
        public T PeticionesWSGet<T>(string url,string action) where T : class, new()
        {
            T modelo = new T();   //T es un tipo de dato X (cualquier tipo de dato)
            var cliente = new RestClient(url);
            try
            {
                RestClient restclient = new RestClient(url + action);
                var request = new RestRequest(Method.GET);
                IRestResponse restResponse = restclient.Execute(request);
                modelo = JsonConvert.DeserializeObject<T>(restResponse.Content);

            }
            catch(Exception ex)
            {
                throw ex;
            }

            return modelo;
        } //Eof:PeticionesWSGet

        public T PeticionesWSPost<T>(string url,string action,object Datos=null) where T : class, new()
        {
            T modelo = new T();

            //Para hacerlo variable desde el config
           
            var cliente = new RestClient(url);

            try
            {
                RestClient restclient = new RestClient(url + action);
                var request = new RestRequest(Method.POST);
                if (Datos!=null)
                {
                    JObject dataRequest = JObject.FromObject(Datos);
                    request.AddParameter("application/json", dataRequest.ToString(Newtonsoft.Json.Formatting.None),ParameterType.RequestBody);
                }
                IRestResponse restResponse = restclient.Execute(request);
                modelo = JsonConvert.DeserializeObject<T>(restResponse.Content);
            }
            catch(Exception ex)
            {
                throw ex;
            }

            return modelo;
        }

        public T PeticionesWSBanxico<T>(string url, string action, object Datos = null) where T : class, new()
        {
            T modelo = new T();
            var cliente = new RestClient(url);

            try
            {

                RestClient restclient = new RestClient(url + action);

                var request = new RestRequest();

                request.AddHeader("Bmx-Token", "46a42c0687f804ffb0a6bae1c5d405672bbd1b4db67470c1d1c7a169e47e633f");
                IRestResponse restResponse = restclient.Get(request);


                //teskloginresponse login = new teskloginresponse();
                //
                modelo = JsonConvert.DeserializeObject<T>(restResponse.Content);
                //string jsonString = JsonConvert.SerializeObject(login);

                if (modelo == null)
                    return modelo;
                //else
                //    modelo = JsonConvert.DeserializeObject<T>(jsonString);
            }
            catch (Exception)
            {
                return null;
                //throw ex;
            }

            return modelo;
        }
    } //Eof:MalocClient
}



