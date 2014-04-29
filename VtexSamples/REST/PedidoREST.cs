
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VtexSamples.REST
{
    public class PedidoREST : AcessoRest
    {

        /// <summary>
        /// Busca pedidos por status
        /// </summary>
        public void SearchByStatus()
        {
            string strStatus = "ready-for-handling";
            string requestRoute = "/oms/pvt/orders/?f_status=" + strStatus;

            #region RestSharp
            //Utilizando RestSharp (http://restsharp.org/)

            var request = new RestRequest(requestRoute, Method.GET);
            request.AddHeader("X-VTEX-API-AppKey", strAppKey);
            request.AddHeader("X-VTEX-API-AppToken", strAppToken);

            // execute the request
            var response = vtexServiceRestClient.Execute(request);
            var content = response.Content; // raw content as string
            #endregion
            
            #region WebClient
            // Utilizando WebClient
            //string strJsonGetOrderByStatus = vtexServiceWebClient.DownloadString(baseURL + requestRoute);
            #endregion
        }

        /// <summary>
        /// Inicia processamento do pedido
        /// </summary>
        public void StartHandling()
        {
            string strOrderId = "v00000000XXXX-01";
            string requestRoute = "/oms/pvt/orders/" + strOrderId + "/start-handling";

            #region RestSharp
            //Utilizando RestSharp (http://restsharp.org/)

            var request = new RestRequest(requestRoute, Method.POST);
            request.AddHeader("X-VTEX-API-AppKey", strAppKey);
            request.AddHeader("X-VTEX-API-AppToken", strAppToken);

            // execute the request
            var response = vtexServiceRestClient.Execute(request);
            var content = response.Content; // raw content as string
            #endregion


            #region WebClient

            //System.Net.HttpWebRequest objRequest = (System.Net.HttpWebRequest)System.Net.WebRequest.Create(baseURL + "pvt/orders/" + strOrderId + "/start-handling");
            //objRequest.Headers = HeaderCollection;
            //objRequest.Accept = "application/json";
            //objRequest.Method = "POST";

            //StreamReader objStreamReader = new StreamReader(objRequest.GetResponse().GetResponseStream());
            //string strResult = objStreamReader.ReadToEnd();
            #endregion
        }


        
    }
}
