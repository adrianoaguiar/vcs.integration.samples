using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VtexSamples.WebService;

namespace VtexSamples
{
    public class Produto : AcessoWebService
    {
        public void IntegraProduto()
        {
            try
            {

                Console.WriteLine("Início do exemplo de integração de Produto");

                int idProduct = 100;

                //Instanciando um objeto do tipo ProductDTO
                ProductDTO objProduct = this.vtexService.ProductGet(idProduct);

                if(objProduct != null)
                {
                    //Instanciamos um objeto do tipo ProductDTO caso este Produto não exista na VTEX
                    objProduct = new ProductDTO();
                }

                objProduct.Id = idProduct;
                objProduct.CategoryId = 100;
                objProduct.BrandId = 100;
                objProduct.DepartmentId = 10;
                objProduct.Name = "Teste";
                objProduct.Description = "Teste";
                objProduct.LinkId = "URL_do_Produto";//URL do produto
                objProduct.RefId = "12344321";//Código de referencia
                objProduct.SupplierId = 1;//Id do fornecedor
                objProduct.TaxCode = "12345678";//Código fiscal
                objProduct.DescriptionShort = "Teste";//Descrição resumida(Vitrine)
                objProduct.KeyWords = "Teste,integração,produto";
                objProduct.MetaTagDescription = "";
                objProduct.ReleaseDate = DateTime.Now;//Data de lançamento
                objProduct.ShowWithoutStock = true;//Exibe Produto sem estoque
                objProduct.Title = "Teste";//Texto da tag title
                objProduct.IsVisible = true;
                objProduct.IsActive = true;

                //Enviando os dados para serem inseridos ou atualizados pelo WebService
                this.vtexService.ProductInsertUpdate(objProduct);

                //Mensagem de sucesso
                Console.WriteLine("Produto inserido com sucesso");
            }
            catch (Exception ex)
            {
                //Mensagem de erro
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                Console.WriteLine("Fim do exemplo de integração de Produto");
                Console.ReadKey();
            }
        }
    }
}
