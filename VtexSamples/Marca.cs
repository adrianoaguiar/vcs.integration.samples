using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VtexSamples.WebService;

namespace VtexSamples
{
    public class Marca : AcessoWebService
    {
        public void IntegraMarca()
        {
            try
            {
                Console.WriteLine("Início do exemplo de integração de Marca");

                int idMarca = 100;
                //Instanciando um objeto do tipo BrandDTO
                BrandDTO objBrand = this.vtexService.BrandGet(idMarca);

                if (objBrand == null)
                {
                    //Instanciamos um objeto do tipo BrandDTO caso esta Marca não exista na VTEX
                    objBrand = new BrandDTO();
                }

                objBrand.Id = idMarca;
                objBrand.Name = "Nome da Marca";
                objBrand.Title = "Titulo da marca";
                objBrand.Description = "Descrição";
                objBrand.IsActive = true;

                //Enviando os dados para serem inseridos ou atualizados pelo WebService
                this.vtexService.BrandInsertUpdate(objBrand);

                //Mensagem de sucesso	
                Console.WriteLine("Marca inserida com sucesso");
            }
            catch (Exception ex)
            {
                //Mensagem de erro
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                Console.WriteLine("Fim do exemplo de integração de Marca");
                Console.ReadKey();
            }
        }
    }
}
