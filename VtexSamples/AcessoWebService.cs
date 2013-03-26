using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using VtexSamples.WebService;

namespace VtexSamples
{
    public class AcessoWebService
    {
        private ServiceClient m_objVtexService;

        protected ServiceClient vtexService
        {
            get
            {
                if (this.m_objVtexService == null)
                {
                    this.m_objVtexService = this.getVtexService("https://webservice-nome_da_loja.vtexcommerce.com.br/service.svc", "user", "password");                    
                }

                return this.m_objVtexService;
            }
        }

        private ServiceClient getVtexService(string strWebService, string strUser, string strPassword)
        {
            bool hasValidation = !(string.IsNullOrWhiteSpace(strUser)) && !(string.IsNullOrWhiteSpace(strPassword));

            BasicHttpBinding objBinding = new BasicHttpBinding();

            int nDefaultLength = 2000000;

            objBinding.ReaderQuotas.MaxDepth = nDefaultLength;
            objBinding.ReaderQuotas.MaxArrayLength = nDefaultLength;
            objBinding.ReaderQuotas.MaxBytesPerRead = nDefaultLength;
            objBinding.ReaderQuotas.MaxNameTableCharCount = nDefaultLength;
            objBinding.ReaderQuotas.MaxStringContentLength = nDefaultLength;
            objBinding.MaxReceivedMessageSize = nDefaultLength;
            objBinding.MaxBufferPoolSize = nDefaultLength;
            objBinding.MaxBufferSize = nDefaultLength;

            objBinding.CloseTimeout = new TimeSpan(0, 2, 0);
            objBinding.OpenTimeout = objBinding.CloseTimeout;
            objBinding.ReceiveTimeout = objBinding.CloseTimeout;
            objBinding.SendTimeout = objBinding.CloseTimeout;

            if (hasValidation)
            {
                objBinding.Security.Mode = BasicHttpSecurityMode.Transport;
                objBinding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Basic;
            }

            ServiceClient objServiceClient = new ServiceClient(objBinding, new EndpointAddress(strWebService));

            if (hasValidation)
            {
                objServiceClient.ClientCredentials.UserName.UserName = strUser;
                objServiceClient.ClientCredentials.UserName.Password = strPassword;
            }

            return objServiceClient;
        }
    }
}