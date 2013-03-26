using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VtexSamples.WebService;

namespace VtexSamples
{
    public class Pedido : AcessoWebService
    {
        public void integraPedido()
        {
            Console.WriteLine("Início do exemplo de integração de Pedido");

            string status = "CAP";
            
            //Método para obter todos os pedidos de um determinado status
            OrderDTO[] lstOrders = this.vtexService.OrderGetByStatus(status);

            //Verifico se existe pedido com esse status
            if (lstOrders == null ||
                lstOrders.Length == 0)
            {
                return;
            }

            //Loop para acessar cada pedido da lista obtida pelo mátodo anterior
            foreach (OrderDTO objOrder in lstOrders)
            {
                try
                {
                    //Usando o objOrder que é o objeto criado do OrderDTO, é possível acessar aos dados do cliente da classe ClientDTO
                    Console.WriteLine("Nome  = " + objOrder.Client.FirstName);

                    //Da mesma forma que é possível acessar a classe ClientDTO é possível também acessar o AddressOrderDTO, que é o endereço de entrega
                    Console.WriteLine("Rua   = " + objOrder.Address.Street + "\n");

                    //Loop Para acessar as compras entregas
                    foreach (OrderDeliveryDTO objOrderDelivery in objOrder.OrderDeliveries)
                    {
                        //nessa parte é possível acessar qualquer campo do OrderDeliveryDTO
                        Console.WriteLine("Order Id        = " + objOrderDelivery.OrderId);                        
                        Console.WriteLine("OrderDeliveryId = " + objOrderDelivery.Id);
                        Console.WriteLine("DeliveryDate    = " + objOrderDelivery.DeliveryDate + "\n");

                        //loop para acessar os itens da compra entrega
                        foreach (OrderItemDTO orderItem in objOrderDelivery.OrderItems)
                        {
                            //nessa parte é possível acessar qualquer campo do OrderItenDTO
                            Console.WriteLine("Id do item = " + orderItem.ItemId);
                            Console.WriteLine("É Kit      = " + orderItem.IsKit);
                            Console.WriteLine("Custo      = " + orderItem.Cost + "\n");
                        }
                    }

                    //Loop para acessar as formas de pagamento
                    foreach (OrderPaymentDTO objOrderPayments in objOrder.OrderPayments)
                    {
                        //nessa parte é possível acessar qualquer campo do OrderPaymentDTO
                        Console.WriteLine("OrderId        = " + objOrderPayments.OrderId);
                        Console.WriteLine("OrderPaymentId = " + objOrderPayments.Id);
                        Console.WriteLine("CardName       = " + objOrderPayments.CardName + "\n\n");
                    }

                    //Depois de integrar o pedido sem erros, é necessário alterar o status.
                    //Método para mudança do status do pedido
                    this.vtexService.OrderChangeStatus(objOrder.Id.Value, "ERP");
                }
                catch (Exception ex)
                {
                    //Mensagem de erro
                    Console.WriteLine(ex.ToString());
                }
                finally
                {
                    Console.WriteLine("Fim do exemplo de integração de Pedido");
                    Console.ReadKey();
                }
            }
        }
    }
}
