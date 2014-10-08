# ERP - Integração Completa de Catálogo e Condições Comerciais com a VTEX - Dicas Importantes 


Este documento tem por objetivo auxiliar o integrador na integração de catálogo, condição comercial(preço e estoque) do ERP para a uma loja hospedada na versão smartcheckout da VTEX, de uma maneira rápida. Nesse tipo de integração a adminstração da loja está no admin da VTEX, sendo o ERP apenas uma fonte de onde nascem os produstos e SKUs.

##1 - Catalogo Fluxo Básico (Express)##
Nesse cenário de fluxo básico, apenas os dados básicos de produtos e SKUs são manipulados pelo ERP, e todo o enriquecimento (marca, fornecedor, imagens, categoria, ativação, etc...) será feito pelo admin da loja na plataforma VTEX.

Para o ERP integrar se ao catálogo da loja na VTEX, deverá usar o webservice da própria loja, que por definição atenderá em [https:webservice-nomedaloja-vtexcommerce.com.br/service.svc?wsdl](https:webservice-nomedaloja-vtexcommerce.com.br/service.svc?wsdl "web service da loja"). As credenciais de acesso ao webservice deverão ser solicitadas junto ao administrador da loja.

Futuramente além do serviço SOAP (webservice) estaremos também oferecendo integração de catálogo por APIs REST (JSON) bem definidas e de alta performance.

###1.1 - Organização dos Produtos Dentro da Loja###

Geralmente, os produtos são organizados dentro da loja em estruturas mercadológicas formadas por:

1. **Departamento** - categoria cujo id de categoria pai é **nulo**, 
2. **Categoria** - categoria cujo id de categoria pai é um **departamento**,
3. **SubCategoria**. categoria cujo id de categoria pai é um **categoria**

*Exemplo:*  
*Departamento/Categoria/SubCategoria/Produto*  
*Ferramentas/Eletricas/Furradeiras/Super Drill*  


O cadastro da estrutura mercadologica deve ser feito diretamente no admin da própria loja (_http://sualoja.com.br/admin/Site/Categories.aspx_), e para atender a integração vinda do ERP, é criado um departamento padrão para produtos que vem do ERP, ou seja, todos os produtos caem no admin da loja nesse departamento padrão, e depois no momento do enriquecimento é colocado na categoria desejada.

###1.2 - Produtos e SKUs###

Qual é a diferença entre produto e SKU?

**Produto** é uma definição mais genérica de algo que é ofertado ao cliente. 

*Exemplo: Geladeria, Camiseta, Bola*
 

**SKU** é uma sigla em ingles de "Stock Keeping Unit", em português Unidade de Manutenção de Estoque,
ou seja, uma SKU define uma variação de um produto.

*Exemplo: Geladeira Branca 110V, Camiseta Amarela Grande*

No modelo de cadastro de Produtos e SKUs da VTEX, um SKU sempre será filha de um Produto (não existe SKU sem produto), mesmo que esse produto não tenha variçãoes, e nesse caso será 1 SKU para 1 produto.

*Exemplo: Produto Bola Jabulani com a SKU Bola Jabulani*

###1.3 - Integração de Produtos e SKUs###

Após definida as variações e a estrutura mecadológica da loja, o próximo passo é enviar os produtos e as SKUs do ERP para a loja VTEX.

Cadastrar produto na loja: webservice.ProductInsertUpdate(ProductDTO).

#### ProductDTO: ####

| Propriedade | Tipo | Tamanho | Descrição|
|-----------|------------|------------|------------|
|Id|    int nulável    |-    |Id do produto, caso o ID no ERP seja maior que um inteiro, enviar nulo nesse campo, e colocar o ID do produto no ERP no campo RefId|
|Name    |string	|150	|Nome do produto|
|DepartmentId	|int nulável	|-	|Id do departamento| 
|CategoryId|	int nulável	|-	|Id da categoria. Caso possua sku e não seja preenchido, desativar-se-á os skus referentes a este produto e o próprio produto.|
|BrandId	|int nulável	|-	|Id da marca|
|LinkId	|string	|255	|Url do produto (sem espaços e sem caracteres especiais)|
|RefId	|string	|200	|Código de referência, geralmente nesse campo se coloca o ID do produto no ERP|
|IsVisible	|bool nulável	|-	|Visível no site
|Description	|string	|max	|Descrição|
|DescriptionShort	|string	|max	|Descrição resumida (vitrine)|
|ReleaseDate	|DateTime nulável	|-	|Data de lançamento
|KeyWords	|string	|max	|Palavras-chaves|
|Title	|string	|150	|Texto que será inserido na tag TITLE do html|
|IsActive	|bool nulável	|-	|Define se o produto está ativo ou inativo|
|TaxCode	|string	|50	|Código fiscal|
|MetaTagDescription	|string	|max	|Descrição da meta tag description do header da página de produtos|
|SupplierId	|int nulável	|-	|Id do fornecedor|
|ShowWithoutStock	|bool	|-	|Exibe sem estoque|
|ListStoreId	|lista de int	|-	|Lista com os ids das lojas em que o produto pode ser exibido (multiloja)|
|AdWordsRemarketingCode	|string	|200	|Código do AdWords, , mandar vazio na ausencia|
|LomadeeCampaignCode	|string	|200	|Código da campanha do Lomadee, mandar vazio na ausencia |



*Exemplo do POST:*    

    <soapenv:Envelope xmlns:soapenv="http://schemas.xmlsoap.org/soap/envelope/" xmlns:tem="http://tempuri.org/" xmlns:vtex                                ="http://schemas.datacontract.org/2004/07/Vtex.Commerce.WebApps.AdminWcfService.Contracts" xmlns:arr="http://schemas.microsoft.com/2003/10/Serialization/Arrays">
   	<soapenv:Header/>
   	<soapenv:Body>
      <tem:ProductInsertUpdate>
         <tem:productVO>
            <vtex:AdWordsRemarketingCode></vtex:AdWordsRemarketingCode>
            <vtex:BrandId>1</vtex:BrandId>
            <vtex:CategoryId>3</vtex:CategoryId>
            <vtex:DepartmentId>1</vtex:DepartmentId>
            <vtex:Description>Descricao longa do seu produto</vtex:Description>
            <vtex:DescriptionShort>Descricao curta do seu produto</vtex:DescriptionShort>
            <vtex:Id>1</vtex:Id>
            <vtex:IsActive>true</vtex:IsActive>
            <vtex:IsVisible>true</vtex:IsVisible>
            <vtex:KeyWords>Palavras chaves</vtex:KeyWords>
            <vtex:LinkId>meu_produto</vtex:LinkId>
            <vtex:ListStoreId>
               <arr:int>1</arr:int>
			   <arr:int>2</arr:int>
            </vtex:ListStoreId>
            <vtex:LomadeeCampaignCode></vtex:LomadeeCampaignCode>
            <vtex:MetaTagDescription>Descricao para SEO</vtex:MetaTagDescription>
            <vtex:Name>Meu produto</vtex:Name>
            <vtex:RefId>1234567890</vtex:RefId>
            <vtex:ReleaseDate>2014-01-01</vtex:ReleaseDate>
            <vtex:ShowWithoutStock>false</vtex:ShowWithoutStock>
            <vtex:SupplierId>1</vtex:SupplierId>
            <vtex:TaxCode>codigo fiscal</vtex:TaxCode>
            <vtex:Title>meu produto</vtex:Title>
         	</tem:productVO>
      	</tem:ProductInsertUpdate>
   	</soapenv:Body>
	</soapenv:Envelope>

Uma vez inseridos todos os produtos, que teoricamente são os pais das SKUs, chegou o momento de enviar as SKUs.

Cadastrar SKU na loja: webservice.StockKeepingUnitInsertUpdate(StockKeepingUnitDTO).

#### StockKeepingUnitDTO: ####
|Propriedade    |Tipo	|Tamanho	|Descrição|
|-----------|------------|------------|------------|
|Id	|int nulável	|-	|Id do sku, caso o ID no ERP seja maior que um inteiro, enviar nulo nesse campo, e colocar o ID do SKU no ERP no campo RefId|
|ProductId	|int nulável	|-	|Id do produto pai da SKU|
|IsActive	|bool nulável	|-	|O campo isActive define se o sku está ativo ou inativo. O SKU só se ativa se todos os pré-requisitos (imagem, preço, estoque, etc...) estiverem OK|
|Name	|string	|200	|Nome do sku|
|RefId	|string	|50	|Código de referência|
|CostPrice	|decimal nulável	|(18,2)	|Preço de custo*|
|ListPrice	|decimal nulável	|(18,2)	|Preço De*|
|Price	|decimal nulável	|(18,2)	|Preço Por (preço normal) *|
|Height	|decimal nulável	|(18,4)	|Altura|
|Length	|decimal nulável	|(18,4)	|Comprimento|
|Width	|decimal nulável	|(18,4)	|Largura|
|WeightKg	|decimal nulável	|(18,4)	|Peso em grama(g)|
|RealHeight	|decimal nulável	|(18,4)	|Altura real|
|RealLength	|decimal nulável	|(18,4)	|Comprimento real|
|RealWidth	|decimal nulável	|(18,4)	|Largura real|
|RealWeightKg	|decimal nulável	|(18,4)	|Peso em grama(g) real*|
|ModalId	|int nulável	|-	|define o prefixo do estoque da SKU, 1,2,3,4|
|ModalType|string| 100|Refere-se à modalidade de frete (leve,pesado,refrigerado,químico)|
|CubicWeight	|decimal nulável	|(18,4)	|Peso cúbico|
|InternalNote	|string	|max	| depreciado - enviar vazio|
|IsKit	|bool nulável	|-	|Sku é do tipo kit (uma vez kit, o sku não poderá deixar de ser kit)|
|ProductName	|string	|150	|Nome do produto pai da SKU|
|IsAvaiable	|bool nulável	|-	|depreciado|
|StockKeepingUnitEans	|lista de StockKeepingUnitEanDTO|	|-	|Código de barras (EAN13)-geralmete uma SKU só tem 1 EAN e é exclusivo.|
|DateUpdated	|DateTime nulável	|-	|Data de atualização|
|RewardValue	|decimal nulável	|(18,2)	|valor de fidelidade|
|EstimatedDateArrival	|DateTime nulável	|-	|Data de pré-venda|
|ManufacturerCode	|string	|100	|Código-Nome do fabricante|
|ComercialConditionId	|int nulável	|-	|Id da condição comercial|
|MeasurementUnit	|string	|-	|Unidade de medida, enviar "un" (unidade)|
|UnitMultiplier	|decimal nulável	|-	|Multiplicador da unidade, geralmente 1, é diferente de 1 quando se vende em metros ou em kilos|


*Exemplo do POST:* 


	<soapenv:Envelope xmlns:soapenv="http://schemas.xmlsoap.org/soap/envelope/" xmlns:tem="http://tempuri.org/" xmlns:vtex="http://schemas.datacontract.org/2004/07/Vtex.Commerce.WebApps.AdminWcfService.Contracts">
   	<soapenv:Header/>
   	<soapenv:Body>
      <tem:StockKeepingUnitInsertUpdate>
         <tem:stockKeepingUnitVO>
            <vtex:CommercialConditionId>?</vtex:CommercialConditionId>
            <vtex:CubicWeight>100</vtex:CubicWeight>
            <vtex:DateUpdated>2014-01-01</vtex:DateUpdated>
            <vtex:EstimatedDateArrival>2014-01-01</vtex:EstimatedDateArrival>
            <vtex:Height>120</vtex:Height>
            <vtex:Id>100</vtex:Id>
            <vtex:InternalNote></vtex:InternalNote>
            <vtex:IsActive>true</vtex:IsActive>
            <vtex:IsKit>false</vtex:IsKit>
            <vtex:Length>100</vtex:Length>
            <vtex:ManufacturerCode>1</vtex:ManufacturerCode>
            <vtex:MeasurementUnit>un</vtex:MeasurementUnit>
            <vtex:ModalId>1</vtex:ModalId>
            <vtex:ModalType>leve</vtex:ModalType>
            <vtex:Name>Amarela Grande</vtex:Name>
 			<vtex:CostPrice>80.00</vtex:CostPrice>
 			<vtex:ListPrice>120.00</vtex:ListPrice>
            <vtex:Price>102.00</vtex:Price>
            <vtex:ProductId>1</vtex:ProductId>
            <vtex:ProductName>Camisa Polo</vtex:ProductName>
            <vtex:RealHeight>10</vtex:RealHeight>
            <vtex:RealLength>120</vtex:RealLength>
            <vtex:RealWeightKg>90</vtex:RealWeightKg>
            <vtex:RealWidth>100</vtex:RealWidth>
            <vtex:RefId>987654321</vtex:RefId>
            <vtex:RewardValue>0</vtex:RewardValue>
            <vtex:StockKeepingUnitEans>
               <vtex:StockKeepingUnitEanDTO>
                  <vtex:Ean>1234567890123</vtex:Ean>
               </vtex:StockKeepingUnitEanDTO>
            </vtex:StockKeepingUnitEans>
            <vtex:UnitMultiplier>1</vtex:UnitMultiplier>
            <vtex:WeightKg>100</vtex:WeightKg>
            <vtex:Width>100</vtex:Width>
         </tem:stockKeepingUnitVO>
      	</tem:StockKeepingUnitInsertUpdate>
   	</soapenv:Body>
	</soapenv:Envelope>

##2 - Preço e Estoque##
Uma vez cadastradas os produtos e as SKUs na loja da VTEX, é necessário alimentar o estoque e acertar o preço na tabela de preço (se no momento de inserir a SKU não enviou o preço).


####2.1 - Preço ####
Se no momento sa inserção da SKU não foi enviado um preço válido para a SKU é necessário inserir o preço da mesma. Isso pode ser feito direto no admin da loja na VTEX (_urldaloja/admin/Site/SkuTabelaValor.aspx_), ou usando a API REST do sistema de **Pricing**.

O primeiro passo a ser tomado para acessar as APIs da VTEX é solicitar os token de acesso (X-VTEX-API-AppToken e X-VTEX-API-AppKey) ao administrador da loja. Após isso fazer um POST como segue o exemplo:

endpoint: **nomedaloja/api/pricing/pvt/price-sheet**  
verb: **POST**  
Content-Type: **application/json**  
Accept: **application/json**


*Exemplo do POST:* 

	[
	  	{
	    	"Id": null, //caso saiba o id que vai alterar, preencher
	    	"itemId": 11, //id do sku que deseja manipular
	    	"salesChannel": 1, //canal de vendas onde vai vender
	    	"price": 241.0, // preço por
	    	"listPrice": 239.0, //preço de
	    	"validFrom": "2013-12-05T17:00:03.103", //data validade de
	    	"validTo": "2113-12-05T17:00:03.103" //data de validade até
	  	},
	  	{
	    	"Id": null,
	    	"itemId": 2000014472,
	    	"salesChannel": 1,
	    	"price": 2.5,
	    	"listPrice": 15.0,
	    	"validFrom": "2011-03-04T00:00:00",
	    	"validTo": "2015-03-28T00:00:00"
	  	}
	]

A documentação completa sobre a API de **Pricing** se encontra em:
http://lab.vtex.com/docs/logistics/api/latest/carrier/index.html

####2.2 - Estoque ####
Isso pode ser feito direto no admin da loja na VTEX (_urldaloja/admin/logistics/#/dashboard_), maneira rápida:

1. Criar o estoque,  
2. Criar a transpotadora,  
3. Criar a doca,
4. Colocar estoque nos itens  

Manipulando estoque através da API REST do sistema de **Logistics**:

Criar o estoque, criar a transpotadora e criar a doca no admin da VTEX, 
e depois usar a API REST do **Logistics** para manipular o estoque, como segue exemplo:

endpoint: **nomedaloja/api/logistics/pvt/inventory/warehouseitems/setbalance**    
verb: **POST**    
Content-Type: **application/json**    
Accept: **application/json**    


*Exemplo do POST:* 

	[
  		{
    		"wareHouseId": "1", //id do estoque
    		"itemId": "12", //id do sku que vai manipular
    		"quantity": 100 //quantidade do estoque que deseja atualizar
  		},
	  	{
	    	"wareHouseId": "1",
	    	"itemId": "45",
	    	"quantity": 8
	  	},
	  	{
	    	"wareHouseId": "2",
	    	"itemId": "45"
	  	}
	]


A documentação completa sobre a API de **Logistics** se encontra em:
_http://lab.vtex.com/docs/logistics/api/latest/carrier/index.html_

##3 - Considerações ##

####3.1 - Uso do webservice ####
O webservice VTEX deve ser usado o mínimo possível para os processo de integração, hoje com excessão do **Catalog**, que está com sua API REST em desenvolvimento, todos os outros módulos da VTEX possúem APIs REST bem definidas e de alta performance. É altemante recomendado que se use as APIs REST nos módulos que não seja o **Catalog**

####3.2 APIs REST (formato JSON) ####

As APIs REST deve ser usada sempre que possível, pois ela é muito melhor do que o webservice, pois é mais performática e é muito mais completa em dados. Documentação de todas as **APIs VTEX** está em:
_http://lab.vtex.com/docs/_

####3.3 Pooling (loop de atualização executado de tempos em tempos) ####
O envio ou consumo de dados num processo de integração deve ser executado somente quando necessário, ou seja, o dado só deve ser enviado do ERP para a plataforma VTEX quando ele realmente for alterado. **NÂO** se deve fazer uma integração que varre entidades inteiras do ERP e atualiza todos os dados na plataforma VTEX de tempos  em tempos. Além de consumir e processar dados desnecessáriamente, isso não funcionaria para lojas com mais de 5 mil Skus no catálogo.

####3.4 Integração Completa ####
A integração completa se aplica quando o cliente já pussui o ERP com a estrutura mercadologica definida, assim como as marcas, produtos e SKUs e usa esse ERP antes de possuir o comércio eletrônico.  
A integração completa demanda mais tempo, pois envolve mais interfaces, e deve seguir as mesmas boas práticas da integração expressa, ou seja, usar o web service somente para os recursos do **Catalog**(documentação completa do webservice: _https://github.com/vtex/vcs.integration.sampleshttps://github.com/vtex/vcs.integration.samples_), os outros recursos devem ser atualizados usando **API REST** dos módulos.

####3.5 Pedidos e Tracking ####
Toda a integração de pedidos, assim como atualizações de Notas Fiscais e Tracking devem ser feitas pela API REST do OMS (Order Managment System) da VTEX.  Um outro documento parecido com esse está sendo desenvolvido para citar a integração de pedidos e tracking.

Segue o link da API completa do OMS: _http://docs.vtex.com.br/pt-br/oms/api/orders/_ 

####3.6 Ferramentas de apoio ao integrador ####
Recomendamos algumas ferramentas que são de extrema importância para qualquer integrador:

**soapUI 3.6.1** (_http://www.soapui.org/Downloads/older-versions.html_)
Está ferramente é muito importante no processo de integração, pois ela permite simular os metodos do webservice, gerando automaticamente o request XML. Nesta ferramenta pode fazer as chamdas para as APIs REST também.

**Postman - REST Client** (_chrome://extensions/_)
Nesta ferramente pode se testar, armazenar histórico, salvar coleções de requests do acesso de todas as APIs dos modulos VTEX  (OMS, Logistics, Pricing, GCS, etc).

É de suma importancia que o integrador tenha o conhecimento de ferramentas desse tipo, ou outras parecidas, antes de inciar um processo de integração usando webservice SOAP ou APIs REST VTEX.



####3.7 Versão:Beta 1.0####
Essa versão de documntação suporta a integração na versão da plataforma VTEX smartcheckout. Ela foi escrita para auxiliar um integração e a idéia e que através dela, não  restem nenhuma dúvida de como se integrar com a VTEX. Se recebeu essa documentação e ainda restaram dúvidas, por favor, detalhe as suas dúvidas abaixo no comentário, para chegarmos a um documento rico e funcional.


autor: Jonas Bolognim