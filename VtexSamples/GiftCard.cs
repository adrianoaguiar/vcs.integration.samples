using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VtexSamples.WebService;

namespace VtexSamples
{
    class GiftCard : AcessoWebService
    {
        public void IntegraGiftCard()
        {
            try
            {
                Console.WriteLine("Início do exemplo de integração de GiftCard");

                GiftCardDTO objGiftCard = new GiftCardDTO();

                objGiftCard.MultipleCredits = true; //Permite múltiplos créditos
                objGiftCard.MultipleRedemptions = true; //Permite múltiplos resgates
                objGiftCard.StatusId = 1; //Ativo
                objGiftCard.RestrictedToOwner = true; //Restringe a um CPF
                objGiftCard.OwnerId = "111.111.111-11"; //CPF do usuário
                objGiftCard.ExpiringDate = DateTime.Now.AddYears(1);
                objGiftCard.EmissionDate = DateTime.Now;

                //objGiftCard.RedemptionCode ---->> preencher e testar caso seja necessário criar o próprio RedemptionCode

                objGiftCard = this.vtexService.GiftCardInsertUpdate(objGiftCard); //Insere o GiftCard e retorna os campos Id e RedeptionCode preenchidos

                //Valores retornados preenchidos
                //objGiftCard.Id
                //objGiftCard.RedemptionCode

                GiftCardTransactionItemDTO objGiftCardTransactionItem = new GiftCardTransactionItemDTO();

                objGiftCardTransactionItem.RedemptionCode = objGiftCard.RedeptionCode; //Vinculação da transação com o GiftCard
                objGiftCardTransactionItem.TransactionAction = TransactionAction.Credit;
                objGiftCardTransactionItem.TransactionConfirmed = true;
                objGiftCardTransactionItem.Value = 100;

                this.vtexService.GiftCardTransactionItemInsert(objGiftCardTransactionItem); //Insere o crédito de 100 reais no GiftCard
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                Console.WriteLine("Fim do exemplo de integração de GiftCard");
                Console.ReadKey();
            }
        }
    }
}
