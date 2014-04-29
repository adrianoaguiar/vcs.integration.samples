using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using RestSharp;

namespace VtexSamples.REST
{
    public class AcessoRest
    {
        /// <summary>
        /// Retorna a URL base da API da loja
        /// </summary>
        protected string baseURL
        {
            get
            {
                return "http://{nomedaloja}.vtexcommercestable.com.br/api";
            }
        }

        // Retorne aqui o AppKey
        /// <summary>
        /// 1)	No módulo LicenseManager,
        /// 2)	Click em Contas.
        /// 3)	Depois, faça uma busca pela conta
        /// 4)	Clique em Editar
        /// 5)  Pegar as informações na área "Segurança"
        /// </summary>
        protected string strAppKey
        {
            get
            {
                return "";
            }
        }

        // Retorne aqui o AppToken
        /// <summary>
        /// 1)	No módulo LicenseManager,
        /// 2)	Click em Contas.
        /// 3)	Depois, faça uma busca pela conta
        /// 4)	Clique em Editar
        /// 5)  Pegar as informações na área "Segurança"
        /// </summary>
        protected string strAppToken
        {
            get
            {
                return "";
            }
        }

        protected WebHeaderCollection HeaderCollection
        {
            get
            {
                WebHeaderCollection objWebHeaderCollection = new System.Net.WebHeaderCollection();
                objWebHeaderCollection.Add("Accept", "application/json");
                objWebHeaderCollection.Add("Content-Type", "application/json");
                objWebHeaderCollection.Add("X-VTEX-API-AppToken", strAppToken);
                objWebHeaderCollection.Add("X-VTEX-API-AppKey", strAppKey);

                return objWebHeaderCollection;
            }
        }

        protected WebClient vtexServiceWebClient
        {
            get
            {
                WebClient objWebClient = new WebClient();
                objWebClient.Headers = this.HeaderCollection;
                return objWebClient;
            }

        }

        protected RestClient vtexServiceRestClient
        {
            get
            {
                return new RestClient(baseURL);
            }

        }
        

    }
}
