using System;

namespace VtexSamples
{
    class Program
    {
        static void Main(string[] args)
        {
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