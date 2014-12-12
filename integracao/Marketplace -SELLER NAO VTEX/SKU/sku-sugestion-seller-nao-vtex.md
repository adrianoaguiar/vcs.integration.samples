---
layout: docs
title: Inserção de Sugestão de SKU e Atualização de Condição Comercial de SKU
application: marketplace
docType: guide
---

# Inserção de Sugestão de SKU e Atualização de Condição Comercial de SKU 

Este documento tem por objetivo auxiliar na integração e atualização de condição comercial (preço, estoque, frete, SLAs de entrega) de um SKU entre um Seller não VTEX  para uma loja hospedada na versão smartcheckout da VTEX.

_Fluxo de Sugestão de SKU:_

![alt text](sku-sugestion-seller-nao-vtex.png "Fluxo de descida de pedido")

###Enviar de Notificação de Mudança de Condições Comerciais de SKU
{: #1 .slug-text}

Toda vez que houver uma inserção ou alteração na condição comercial de um SKU (preço, estoque, frete e SLAs de entrega) no Seller, se o Seller vende essa SKU no marketplace VTEX, o Seller deve enviar uma notificação de mudança de SKU para a VTEX, caso a VTEX retorne em seu serviço o response status 404, significa que a SKU **não existe na VTEX**, então o Seller deve enviar a sugestão de inserção de SKU para a loja da VTEX.


#### Exemplos de Request de Notificação de Mudança - Endpoint da VTEX


endpoint: **http://portal.vtexcommercestable.com.br/api/catalog_system/pvt/skuseller/changenotification/[idSeller]/[idSkuSeller]?an=[nomeloja]**  
verb: **POST**  
Content-Type: **application/json**  
Accept: **application/json**

###Enviar de Sugestão de SKU
{: #2 .slug-text}

####Exemplos de Request de Inserção de Sugestão de SKU - Endpoint da VTEX###

endpoint: **http://sandboxintegracao.vtexcommercebeta.com.br/api/catalog_system/pvt/sku/SuggestionInsertUpdatev2**  
verb: **POST**  
Content-Type: **application/json**  
Accept: **application/json**


*Exemplo do Request:*  

	{
	  "BrandId": null, //identificador da marca
	  "BrandName": "Editora Penguin-Companhia", //nome da marca
	  "CategoryFullPath": "Livros/Literatura Estrangeira/Romance", //path completo de categorias
	  "CategoryId": null,
	  "EAN": [
	    "9788563560476"
	  ],
	  "Height": 1, //altura
	  "Id": null,
	  "Images": [ //array de imagens
	    {
	      "ImageUrl": "http://imagens.extra.com.br/Control/ArquivoExibir.aspx?IdArquivo=6191949",
	      "ImageName": "Principal",
	      "FileId": null
	    }
	  ],
	  "IsAssociation": false,
	  "IsKit": false,
	  "IsProductSuggestion": false,
	  "Length": 1, //comprimento
	  "ListPrice": 22.76, //preço DE
	  "ModalId": null, //opicional, idntifica o prefixo do estoque da sku, geralmente usa se 1
	  "Price": 22.76, //preço POR
	  "ProductDescription": "<p style=\"text-align: center\"> <strong>Considerado o grande romance do ingl&ecirc;s Charles Dickens, Grandes esperan&ccedil;as conta uma hist&oacute;ria de desilus&atilde;o e reden&ccedil;&atilde;o pessoal, saudada por gera&ccedil;&otilde;es de escritores e estudiosos por sua perfei&ccedil;&atilde;o narrativa</strong></p>",
	  "ProductId": null,
	  "ProductName": "Livro - Grandes Esperanças - Charles Dickens",
	  "ProductSpecifications": [ //Especificaçãoes da SKU do Seller
	    {
	      "FieldId": 0,
	      "FieldName": "Título",
	      "FieldValueIds": null,
	      "FieldValues": [
	        "Grandes Esperanças"
	      ]
	    },
	    {
	      "FieldId": 0,
	      "FieldName": "Autor",
	      "FieldValueIds": null,
	      "FieldValues": [
	        "Charles Dickens"
	      ]
	    },
	    {
	      "FieldId": 0,
	      "FieldName": "Tradução",
	      "FieldValueIds": null,
	      "FieldValues": [
	        "Paulo Henriques Britto"
	      ]
	    },
	    {
	      "FieldId": 0,
	      "FieldName": "Assunto",
	      "FieldValueIds": null,
	      "FieldValues": [
	        "Romance"
	      ]
	    },
	    {
	      "FieldId": 0,
	      "FieldName": "Editora",
	      "FieldValueIds": null,
	      "FieldValues": [
	        "Penguin-Companhia"
	      ]
	    },
	    {
	      "FieldId": 0,
	      "FieldName": "Edição",
	      "FieldValueIds": null,
	      "FieldValues": [
	        "1ª"
	      ]
	    },
	    {
	      "FieldId": 0,
	      "FieldName": "Número de Páginas",
	      "FieldValueIds": null,
	      "FieldValues": [
	        "704"
	      ]
	    },
	    {
	      "FieldId": 0,
	      "FieldName": "ISBN",
	      "FieldValueIds": null,
	      "FieldValues": [
	        "8563560476"
	      ]
	    },
	    {
	      "FieldId": 0,
	      "FieldName": "ISBN-13",
	      "FieldValueIds": null,
	      "FieldValues": [
	        "9788563560476"
	      ]
	    },
	    {
	      "FieldId": 0,
	      "FieldName": "Origem",
	      "FieldValueIds": null,
	      "FieldValues": [
	        "Nacional"
	      ]
	    },
	    {
	      "FieldId": 0,
	      "FieldName": "Idioma",
	      "FieldValueIds": null,
	      "FieldValues": [
	        "Português"
	      ]
	    },
	    {
	      "FieldId": 0,
	      "FieldName": "Data de Lançamento",
	      "FieldValueIds": null,
	      "FieldValues": [
	        "2012"
	      ]
	    },
	    {
	      "FieldId": 0,
	      "FieldName": "Acabamento",
	      "FieldValueIds": null,
	      "FieldValues": [
	        "Brochura"
	      ]
	    },
	    {
	      "FieldId": 0,
	      "FieldName": "Formato",
	      "FieldValueIds": null,
	      "FieldValues": [
	        "Médio"
	      ]
	    },
	    {
	      "FieldId": 0,
	      "FieldName": "Medidas (cm)",
	      "FieldValueIds": null,
	      "FieldValues": [
	        "13 x 20 cm"
	      ]
	    }
	  ],
	  "ProductSupplementaryFields": null,
	  "RefId": null,
	  "SellerId": "fastshop",
	  "SellerModifiedDate": null,
	  "SellerStockKeepingUnitId": "1692444",
	  "SkuId": null,
	  "SkuName": "Livro - Grandes Esperanças - Charles Dickens",
	  "SkuSpecifications": null,
	  "SkuSupplementaryFields": null,
	  "SynonymousPropertyNames": null,
	  "WeightKg": 1,
	  "Width": 1
	}

reposnse: 200


### Atualização de Condição Comercial de SKU - Fluxo
{: #3 .slug-text}

Toda vez que houver uma alteração na condição comercial de um SKU (preço, estoque, frete e SLAs de entrega), o Seller NÂO VTEX deve enviar uma notificação de mudança de SKU para a VTEX, caso a VTEX retorne em seu serviço o response status 200 ou 204, significa que a SKU **existe** na VTEX, então a VTEX vai no Seller consultar as novas condições comerciais oferecidas pelo Seller.

####Exemplos de Request de Busca de Condições Comerciais - Endpoint do Seller###

endpoint: **https://[sellerendpoint]/api/fulfillment/pvt/orderForms/simulation?sc=[idcanal]&an=[nomedaloja]**  
verb: **POST**  
Content-Type: **application/json**  
Accept: **application/json**  
Parametro: **an** // parametro a ser retornado no items.merchantName caso o pagamento for processado pelo Seller
Parametro: **sc** // sc é o canal de vendas cadastrado no marketplace, serve para destacar o canal que esta pedindo a simulação

*Exemplo do Request:*  

	{
        "postalCode":"22251-030",            //obrigatório se country estiver preenchido, string
        "country":"BRA",                     //obrigatório se postalCode estiver preenchido, string      
        "items": [                           //obrigatório: deve conter pelo menos um objeto item
            {
                "id":"287611",               //obrigatório, string
                "quantity":1,                //obrigatório-quantidade do item a ser simulada, int
                "seller":"seller1"           //sigla do do seller criado no admin // obrigatório, string
            },
            {
                "id":"5837",
                "quantity":5,
                "seller":"seller1"
            }
        ]
    }


*Exemplo do Response:*

	    {
        "items": [                                                     //pode vir um array vazio
            {
                "id": "287611",                                        //obrigatório, string
                "requestIndex": 0,                                     //obrigatório, int - representa a posição desse item no array original (request)
                "price": 7390,                                         //Os dois dígitos menos significativos são os centavos //obrigatório, int
                "listPrice": 7490,                                     //Os dois dígitos menos significativos são os centavos //obrigatório, int
                "quantity": 1,                                         //obrigatório, int
                "seller": "1",                                         //Id do seller cadastrado na loja // obrigatório, string,
            	"merchantName": "shopfacilfastshop",				   //**devolver o parametro an, so deve ser preenchido quando o pagamento for processado no seller.
                "priceValidUntil": "2014-03-01T22:58:28.143"           //data, pode ser nulo
                "offerings":[                                           //Array opcional, porém não pode ser nulo: enviar array vazio ou não enviar a propriedade
                    {
                        "type":"Garantia",                               //obrigatório, string
                        "id":"5",                                       //obrigatório, string
                        "name":"Garantia de 1 ano",                       //obrigatório, string
                        "price":10000                                   //Os dois dígitos menos significativos são os centavos //obrigatório, int
                    },
                    {
                        "type":"Embalagem de Presente",
                        "id":"6",
                        "name":"Embalagem de Presente",
                        "price":250                                       
                    }
                ]
            },
            {
                "id": "5837",
                "requestIndex": 1,
                "price": 890,                                          // Os dois dígitos menos significativos são os centavos
                "listPrice": 990,                                      // Os dois dígitos menos significativos são os centavos
                "quantity": 5,
                "seller": "1",
				"merchantName": "shopfacilfastshop",	
                "priceValidUntil": null
            }
        ],
        "logisticsInfo": [                                            //obrigatório (se vier vazio é considerado que o item não está disponível) -  todos os itens devem ter os mesmos SLAs
            {
                "itemIndex": 0,                                       //obrigatório, int - representa os dados de sla do item de resposta (response)
                "stockBalance": 99,                                   //obrigatório  quando o CEP foi passado no request, estoque, int
                "quantity": 1,                                        //obrigatório quando o CEP foi passado no request, qauntidade pasada no request, int
                "shipsTo": [ "BRA", "USA" ],                          //obrigatório, array de string com as siglas dos países de entrega
                "slas": [                                             //obrigatório quando o CEP foi passado no request. Pode ser um array vazio
                    {
                        "id": "Expressa",                             //obrigatório, id tipo entrega, string
                        "name": "Entrega Expressa",                   //obrigatório, nome do tipo entrega, string
                        "shippingEstimate": "2bd",                    // bd == "business days" //obrigatório, string
                        "price": 1000                                 // Os dois dígitos menos significativos são os centavos, obrigatório, int
                        "availableDeliveryWindows": [                 //opcional, podendo ser um array vazio
                        ]
                    },
                    {
                        "id": "Agendada",
                        "name": "Entrega Agendada",
                        "shippingEstimate": "5d",                     // d == "days, bd == "business days"
                        "price": 800,
                        "availableDeliveryWindows": [
                             {
                                "startDateUtc": "2013-02-04T08:00:00+00:00",       //date, obrigatório se for enviado delivery window
                                "endDateUtc": "2013-02-04T13:00:00+00:00",         //date, obrigatório se for enviado delivery window
                                "price": 0        //int, obrigatório se for enviado delivery window - o valor total da entrega agendada é o valor base mais o valor desse campo
                            },
                        ]
                    }
                ]
            },
            {
                "itemIndex": 1,
                "stockBalance": 1237,
                "quantity": 5,
                "shipsTo": [ "BRA" ],
                "slas": [
                    {
                        "id": "Normal",
                        "name": "Entrega Normal",
                        "shippingEstimate": "5bd",                                  // bd == "business days"
                        "price": 200
                    }
                ]
            }
        ],
        "country":"BRA",                                           //string, nulo se não enviado
        "postalCode":"22251-030"                                   //string, nulo se não enviado    
    }

**O Seller só deve mandar esse campo no retorno quando o pagamento for enviado e processado no Seller.


### Considerações

#### Header nas Chamadas a API REST da VTEX
Todas chamadas as API REST devem conter no Headear as seguintes Keys:  
X-VTEX-API-AppToken:**[Value]**  
X-VTEX-API-AppKey:**[Value]**  
Content-Type: **application/json**      
Accept: **application/json**  

*O integrador deverá solitar junto ao contato VTEX a sua chave e token para uso exclusivo na integração,
assim como solicitar a criação do Seller dentro da loja VTEX.  

#### Ferramentas de apoio ao integrador ####
Ferramentas são de extrema importância para qualquer integrador:

**Postman - REST Client** (_chrome://extensions/_)
Nesta ferramente pode se testar, armazenar histórico, salvar coleções de requests do acesso de todas as APIs dos modulos VTEX  (OMS, Logistics, Pricing, GCS, etc).  

![alt text](postman.png "POSTMAN picture")

É de suma importancia que o integrador tenha o conhecimento de ferramentas desse tipo, ou outras parecidas, antes de inciar um processo de integração usando APIs REST VTEX.

####Glossário
Seller - Responsável por fazer a entrega do pedido.  
SKU - Define uma variação de um produto.


####Versão:Beta 1.1
Essa versão de documentação suporta a integração na versão da plataforma VTEX smartcheckout. Ela foi escrita para auxiliar um integração e a idéia e que através dela, não  restem nenhuma dúvida de como se integrar com a VTEX. Se recebeu essa documentação e ainda restaram dúvidas, por favor, detalhe as suas dúvidas abaixo no comentário, para chegarmos a um documento rico e funcional.


Autor: _Jonas Bolognim_
Propriedade: _VTEX_