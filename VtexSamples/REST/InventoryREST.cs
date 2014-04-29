using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VtexSamples.REST
{
    public class InventoryREST : AcessoRest
    {

        /// <summary>
        /// Atualiza estoque
        /// </summary>
        public void UpdateInventory()
        {
            string requestRoute = "/logistics/pvt/inventory/warehouseitembalances";

            #region RestSharp
            //Utilizando RestSharp (http://restsharp.org/)

            string strBody = "[{\"wareHouseId\":\"1_1\",\"itemId\":\"1\",\"quantity\":1}]";

            var request = new RestRequest(requestRoute, Method.POST);
            request.AddHeader("X-VTEX-API-AppKey", strAppKey);
            request.AddHeader("X-VTEX-API-AppToken", strAppToken);
            request.AddParameter("application/json", strBody, ParameterType.RequestBody);

            // execute the request
            var response = vtexServiceRestClient.Execute(request);
            var content = response.Content; // raw content as string
            #endregion

        }
        
    }
}
