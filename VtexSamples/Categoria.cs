using System;
using VtexSamples.WebService;

namespace VtexSamples
{
    public class Categoria : AcessoWebService
    {
        public void IntegraCategoria()
        {
            try
            {
                Console.WriteLine("Início do exemplo de integração de categoria");

                int nIdCategoria = 100; //Id da categoria que queremos inserir no exemplo

                //Primeiro buscamos a categoria para ver se esta já existe na VTEX. Esta busca é muito importante
                //para que seja mantido novos dados que venham a existir, fazendo com que seja necessária a alteração
                //apenas dos campos que realmente devem ser preenchidos
                CategoryDTO objCategory = this.vtexService.CategoryGet(nIdCategoria);

                if (objCategory == null)
                {
                    //Instanciamos um objeto do tipo CategoryDTO caso esta categoria não exista na VTEX
                    objCategory = new CategoryDTO();
                }

                objCategory.Id = nIdCategoria;
                objCategory.FatherCategoryId = null; //Nesse caso está sendo criado um departamento, que é uma categoria sem categoria pai
                objCategory.Name = "Nome da categoria";
                objCategory.Title = "Título da categoria";
                objCategory.Description = "Descrição da categoria";
                objCategory.IsActive = true;

                //Enviando os dados para serem inseridos ou atualizados. Note que o retorno padrão dos métodos InsertUpdate
                //é o próprio objeto enviado. Isto ocorre para que se possa recuperar ids auto-incrementos ou mesmo para verificação
                //dos dados por parte do integrador.
                objCategory = this.vtexService.CategoryInsertUpdate(objCategory);

                //Mensagem de sucesso
                Console.WriteLine("Categoria inserida com sucesso");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                Console.WriteLine("Fim do exemplo de integração de categoria");
                Console.ReadKey();
            }
        }
    }
}