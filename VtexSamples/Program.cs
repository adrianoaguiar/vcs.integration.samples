using System;
using VtexSamples.REST;

namespace VtexSamples
{
    class Program
    {
        static void Main(string[] args)
        {

            #region REST

            // Pedidos
            PedidoREST objPedidoRest = new PedidoREST();
            objPedidoRest.SearchByStatus();
            objPedidoRest.StartHandling();

            // Estoque
            InventoryREST objInventory = new InventoryREST();
            objInventory.UpdateInventory();

            #endregion

            Categoria objCategoria = new Categoria();
            objCategoria.IntegraCategoria();

            Marca objMarca = new Marca();
            objMarca.IntegraMarca();

            Produto objProduto = new Produto();
            objProduto.IntegraProduto();

            Sku objSku = new Sku();
            objSku.IntegraSku();

            Estoque objEstoque = new Estoque();
            objEstoque.IntegraEstoque();

            GiftCard objGiftCard = new GiftCard();
            objGiftCard.IntegraGiftCard();

            Pedido objPedido = new Pedido();
            objPedido.integraPedido();

            Console.ReadKey();
        }
    }
}