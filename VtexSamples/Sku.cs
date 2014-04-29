using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VtexSamples.WebService;

namespace VtexSamples
{
    public class Sku : AcessoWebService
    {
        public void IntegraSku()
        {
            try
            {
                // teste
                Console.WriteLine("Início do exemplo de integração de Pedido");

                int idSku = 101;

                //Instanciando um objeto do tipo StockKeepingUnitDTO
                StockKeepingUnitDTO objSku = this.vtexService.StockKeepingUnitGet(idSku);

                if(objSku != null)
                {
                    //Instanciamos um objeto do tipo StockKeepingUnitDTO caso este Sku não exista na VTEX
                    objSku = new StockKeepingUnitDTO();
                }

                objSku.Id = idSku;
                objSku.IsActive = true;
                objSku.Name = "TesteWeb";

                objSku.RefId = "1q2w3e4r";//Código de referência
                objSku.CostPrice = Convert.ToDecimal(12.10);//Preço de custo
                objSku.ListPrice = Convert.ToDecimal(12.10);//Preço De
                objSku.Price = Convert.ToDecimal(12.10); //Preço Por (preço de venda)
                objSku.Height = Convert.ToDecimal(12.10); //Altura
                objSku.Length = Convert.ToDecimal(12.10); //Comprimento
                objSku.Width = Convert.ToDecimal(12.10);//Largura
                objSku.WeightKg = Convert.ToDecimal(12.10);//Peso
                objSku.RealHeight = Convert.ToDecimal(12.10);//Altura real
                objSku.RealLength = Convert.ToDecimal(12.10);//Comprimento real
                objSku.RealWidth = Convert.ToDecimal(12.10);//Largura real
                objSku.RealWeightKg = Convert.ToDecimal(12.10);//Peso real
                objSku.ModalId = 1;//Tipo de modal
                objSku.CubicWeight = Convert.ToDecimal(30.00);//Peso cubico
                objSku.IsKit = false;
                objSku.ProductId = 100;
                objSku.ProductName = "teste";
                objSku.StockKeepingUnitEans = null;//Código de barras Ean13
                objSku.DateUpdated = DateTime.Now;//Data da atualização
                objSku.RewardValue = Convert.ToDecimal(1.1);//Código de Fidelidade
                objSku.EstimatedDateArrival = null;//Data da Pré-venda
                objSku.ManufacturerCode = "CODIGO DO FABRICANTE";
                objSku.CommercialConditionId = null;//Condição comercial id

                //Campos Inutilizados -- [objSku.InternalNote = "Não utilizado";] e [objSku.IsAvaiable = false;]

                //Enviando os dados para serem inseridos ou atualizados pelo WebService
                this.vtexService.StockKeepingUnitInsertUpdate(objSku);

                //Mensagem de sucesso
                Console.WriteLine("Sku inserido com sucesso");
            }
            catch (Exception ex)
            {
                //Mensagem de erro
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                Console.WriteLine("Fim do exemplo de integração de Sku");
                Console.ReadKey();
            }
        }
    }
}
