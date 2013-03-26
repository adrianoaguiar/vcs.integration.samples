using System;
using VtexSamples.WebService;

namespace VtexSamples
{
    public class Estoque : AcessoWebService
    {
        public void IntegraEstoque()
        {
            try
            {
                Console.WriteLine("Inicio do exemplo da integração de Estoque");

                int nIdSku = 1;//Id do sku que queremos inserir estoque

                //Buscamos o sku que queremos integrar estoque
                StockKeepingUnitDTO objSkuEstoque = this.vtexService.StockKeepingUnitGet(nIdSku);

                if (objSkuEstoque != null)//Verifico se o sku existe 
                {
                    int nQuantidade = 10;//Quantidade de estoque que vai ser inserida
                    int nIdEstoque = 1;//Estoque em que vai ser inserido

                    //Método que da update no estoque do sku
                    this.vtexService.WareHouseIStockableUpdate(nIdEstoque, objSkuEstoque.Id.Value, nQuantidade, DateTime.Today);

                    //Mensagem de sucesso
                    Console.WriteLine("Estoque inserido com sucesso");
                }
            }
            catch (Exception ex)
            {
                //Mensagem de erro
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                Console.WriteLine("Fim do exemplo de integração de Estoque");
                Console.ReadKey();
            }
        }
    }
}
