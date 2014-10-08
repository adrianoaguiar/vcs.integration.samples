# ERP - Integração de Pedidos e Tracking com a VTEX - Dicas Importantes 

Este documento tem por objetivo auxiliar o integrador na integração pedidos entre ERP euma loja hospedada na versão smartcheckout da VTEX. Ler os pedidos na VTEX, inserir os pedidos no ERP, e receber as informações de nota fiscal e tracking e ou Cancelamento de pedido.

##1 - Pedidos##
Obter a lista de pedidos na VTEX e inserir os pedidos no ERP, atualizando a VTEX que o pedido já está no ERP.

###1.1 - Obter a Lista de Pedidos por Status na API do OMS###

Através da API do OMS pegar a lista de pedidos pagos paginados:

endpoint: **nomedaloja/api/oms/pvt/orders?f_status=ready-for-handling&per_page=30**  
verb: **GET**  
Content-Type: **application/json**  
Accept: **application/json**


*Exemplo do Response:*  

		{
	    "list": [
	        {
	            "orderId": "v1233363wlmr-02", //id do pedido, campo usado para busca o pedido
	            "creationDate": "2014-09-16T19:40:46",
	            "clientName": "Saul Goodman",
	            "items": [
	                {
	                    "seller": "1",
	                    "quantity": 1,
	                    "description": "Notebook Samsung Intel® Core™ i3 380M, RV411-AD2, 2GB, HD 320GB, 14,1\", HDMI, Bluetooth, Webcam - Windows® 7 Home Basic",
	                    "ean": null,
	                    "refId": "14568"
	                }
	            ],
	            "totalValue": 28880,
	            "paymentNames": "American Express",
	            "status": "ready-for-handling",
	            "statusDescription": "Pronto para o manuseio",
	            "marketPlaceOrderId": null,
	            "sequence": "1233365",
	            "salesChannel": "1",
	            "affiliateId": "",
	            "origin": "Marketplace",
	            "workflowInErrorState": false,
	            "workflowInRetry": false,
	            "lastMessageUnread": "VTEX MKP - QA Seu pagamento foi aprovado! pedido realizado em: 16/09/2014 Olá, Saul. Seu pagamento foi efetuado com sucesso. Você receberá o",
	            "ShippingEstimatedDate": "2014-10-02T19:46:23",
	            "orderIsComplete": true,
	            "listId": null,
	            "listType": null
	        },
	        {
	            "orderId": "v1233353wlmr-01",
	            "creationDate": "2014-09-16T19:40:14",
	            "clientName": "Saul Goodman",
	            "items": [
	                {
	                    "seller": "1",
	                    "quantity": 1,
	                    "description": "Notebook Samsung Intel® Core™ i3 380M, RV411-AD2, 2GB, HD 320GB, 14,1\", HDMI, Bluetooth, Webcam - Windows® 7 Home Basic",
	                    "ean": null,
	                    "refId": "14568"
	                }
	            ],
	            "totalValue": 29880,
	            "paymentNames": "Elo",
	            "status": "ready-for-handling",
	            "statusDescription": "Pronto para o manuseio",
	            "marketPlaceOrderId": null,
	            "sequence": "1233353",
	            "salesChannel": "1",
	            "affiliateId": "",
	            "origin": "Marketplace",
	            "workflowInErrorState": false,
	            "workflowInRetry": false,
	            "lastMessageUnread": "VTEX MKP - QA Seu pagamento foi aprovado! pedido realizado em: 16/09/2014 Olá, Saul. Seu pagamento foi efetuado com sucesso. Você receberá o",
	            "ShippingEstimatedDate": "2014-10-02T19:45:58",
	            "orderIsComplete": true,
	            "listId": null,
	            "listType": null
	        }
	    ],
		...
		...
		}

Esse exemplo retorna uma lista com o resumo de cada pedido (2 pedidos), onde para cada pedido, deve fazer uma chamada na API do OMS para pegar o pedido completo, passando o "orderId" de pedido. Segue exemplo de chamada a API REST para pegar um pedido.

###1.2 - Obter um Pedido na API do OMS###

endpoint: **nomedaloja/api/oms/pvt/orders/{orderId}**  
verb: **GET**  
Content-Type: **application/json**  
Accept: **application/json**

*Exemplo do Response:*

	{
	    "orderId": "v1233363wlmr-02", //id do pedido
	    "sequence": "1233365", //id numerico do pedido
	    "marketplaceOrderId": "", //se foi um pedido originado no em marketplace, terá o id do pedido no marketplace
	    "marketplaceServicesEndpoint": "", //se foi um pedido originado no em marketplace, o end point do marketplace para informação de Tracking e NF
	    "sellerOrderId": "00-v1233363wlmr-02", //id do pedido no seller
	    "origin": "Marketplace", origin do pedido: Marketplace(própria loja) | Fulfillment(pedido que veio por canal de vendas
	    "affiliateId": "", //id do affiliado que fez pedido.
	    "salesChannel": "1", //canal de vendas por onde entrou o pedido: 1= lojaprincipal
	    "merchantName": null, // relacionado ao gatway por onde foi o pagamento
	    "status": "ready-for-handling", //status do pedido
	    "statusDescription": "Pronto para o manuseio", //descrição do status do pedido
	    "value": 28880, //valor total do pedido multiplicado por 100
	    "creationDate": "2014-09-16T19:40:46.492703Z", //data de criação
	    "lastChange": "2014-09-16T19:48:46.0139779Z", //data da ultima mudança
	    "orderGroup": "v1233363wlmr", //se foi originado de um pedido splitado, esse é o agrupador
	    "totals": [ //totais do pedido
	        {
	            "id": "Items", //valor do itens
	            "name": "Items Total",
	            "value": 30000
	        },
	        {
	            "id": "Discounts", valor dos descontos
	            "name": "Discounts Total",
	            "value": -1120
	        },
	        {
	            "id": "Shipping", valor de custo de entrega
	            "name": "Shipping Total",
	            "value": 0
	        },
	        {
	            "id": "Tax", //impostos
	            "name": "Tax Total",
	            "value": 0
	        }
	    ],
	    "items": [ //itens do pedido
	        {
	            "id": "270851", // id da sku
	            "productId": "100057806", //id do produto pai da sku
	            "ean": null, //código de barras
	            "lockId": "00-v1233363wlmr-02", // id da reserva
	            "itemAttachment": { //adendos ao item: Exemplo(camisa número 10 com nome customizado)
	                "content": {},
	                "name": null
	            },
	            "itemAttachments": null,
	            "quantity": 1,
	            "seller": "1",
	            "name": "Notebook Samsung Intel® Core™ i3 380M, RV411-AD2, 2GB, HD 320GB, 14,1\", HDMI, Bluetooth, Webcam - Windows® 7 Home Basic",
	            "refId": "14568",
	            "price": 30000,
	            "listPrice": 129800,
	            "priceTags": [
	                {
	                    "name": "discount@price-203#DiscountResource",
	                    "value": -120,
	                    "isPercentual": false,
	                    "identifier": "203"
	                },
	                {
	                    "name": "discount@shipping-138#DiscountResource",
	                    "value": -49,
	                    "isPercentual": false,
	                    "identifier": "138"
	                },
	                {
	                    "name": "discount@price-220#DiscountResource",
	                    "value": -1000,
	                    "isPercentual": false,
	                    "identifier": "220"
	                },
	                {
	                    "name": "discount@shipping-167#DiscountResource",
	                    "value": -252,
	                    "isPercentual": false,
	                    "identifier": "167"
	                },
	                {
	                    "name": "discount@shipping-218#DiscountResource",
	                    "value": -238,
	                    "isPercentual": false,
	                    "identifier": "218"
	                }
	            ],
	            "imageUrl": "/arquivos/ids/959883-55-55/270851_292_292.jpg",
	            "detailUrl": "/270851-notebook-14-intel-core-i3-processor-380m/p",
	            "components": [],
	            "bundleItems": [],
	            "params": [],
	            "offerings": [],
	            "sellerSku": "270851",
	            "priceValidUntil": null,
	            "commission": 0,
	            "tax": 0,
	            "preSaleDate": null,
	            "additionalInfo": {
	                "brandName": "Samsung",
	                "brandId": "3025",
	                "categoriesIds": "/247/254/3058/",
	                "productClusterId": "136,138",
	                "commercialConditionId": "1"
	            },
	            "measurementUnit": "un",
	            "unitMultiplier": 1,
	            "sellingPrice": 28880,
	            "isGift": false,
	            "shippingPrice": null
	        }
	    ],
	    "marketplaceItems": [],
	    "clientProfileData": {
	        "id": "clientProfileData",
	        "email": "4f1431877bb6410798bebf34c6e46b28@ct.vtex.com.br",
	        "firstName": "Saul",
	        "lastName": "Goodman",
	        "documentType": "cpf",
	        "document": "77564538910",
	        "phone": "+552199998888",
	        "corporateName": null,
	        "tradeName": null,
	        "corporateDocument": null,
	        "stateInscription": null,
	        "corporatePhone": null,
	        "isCorporate": false,
	        "userProfileId": "dd013258-7be9-4555-bbfe-7207fadcdd62"
	    },
	    "giftRegistryData": null,
	    "marketingData": null,
	    "ratesAndBenefitsData": {
	        "id": "ratesAndBenefitsData",
	        "rateAndBenefitsIdentifiers": [
	            {
	                "description": "",
	                "featured": false,
	                "id": "220",
	                "name": "Teste Desconto preco carrinho"
	            },
	            {
	                "description": "Teste frete Nominal",
	                "featured": false,
	                "id": "167",
	                "name": "Teste frete Nominal"
	            },
	            {
	                "description": "",
	                "featured": true,
	                "id": "218",
	                "name": "N2 Absoluto"
	            },
	            {
	                "description": "Teste frete nominal fulfillment por valor acumulado",
	                "featured": false,
	                "id": "203",
	                "name": "Teste frete nominal fulfillment por valor acumulad"
	            },
	            {
	                "description": "Teste frete percentual fulfillment",
	                "featured": true,
	                "id": "138",
	                "name": "Teste frete percentual fulfillment"
	            }
	        ]
	    },
	    "shippingData": {
	        "id": "shippingData",
	        "address": {
	            "addressType": "residential",
	            "receiverName": "Gustavo Almeida",
	            "addressId": "2210176a84224e109874e6ed29a6471d",
	            "postalCode": "20010-060",
	            "city": "Rio De Janeiro",
	            "state": "RJ",
	            "country": "BRA",
	            "street": "Rua Visconde De Itaboraí",
	            "number": "70",
	            "neighborhood": "Centro",
	            "complement": null,
	            "reference": null
	        },
	        "logisticsInfo": [
	            {
	                "itemIndex": 0,
	                "selectedSla": "performance",
	                "lockTTL": "8d",
	                "price": 0,
	                "deliveryWindow": null,
	                "deliveryCompany": "Teste de Performance",
	                "shippingEstimate": "12bd",
	                "shippingEstimateDate": "2014-10-02T19:46:23.686688Z",
	                "slas": [
	                    {
	                        "id": "performance",
	                        "name": "performance",
	                        "shippingEstimate": "12bd",
	                        "deliveryWindow": null,
	                        "price": 0
	                    },
	                    {
	                        "id": "Entrega Agendada",
	                        "name": "Entrega Agendada",
	                        "shippingEstimate": "4bd",
	                        "deliveryWindow": null,
	                        "price": 15
	                    },
	                    {
	                        "id": "PAC",
	                        "name": "PAC",
	                        "shippingEstimate": "8d",
	                        "deliveryWindow": null,
	                        "price": 990
	                    }
	                ],
	                "shipsTo": [
	                    "BRA"
	                ],
	                "sellingPrice": 0,
	                "deliveryIds": [
	                    {
	                        "courierId": "1427277",
	                        "courierName": "Teste de Performance",
	                        "dockId": "1_1_1",
	                        "quantity": 1,
	                        "warehouseId": "1_1"
	                    }
	                ]
	            }
	        ]
	    },
	    "paymentData": {
	        "transactions": [
	            {
	                "isActive": true,
	                "transactionId": "33CD3CC4D11A4FA49A2C9EE20D771F98",
	                "payments": [
	                    {
	                        "id": "CCAA6D854D934ADD9DAC301859D19D22",
	                        "paymentSystem": "1",
	                        "paymentSystemName": "American Express",
	                        "value": 28880,
	                        "installments": 1,
	                        "referenceValue": 28880,
	                        "cardHolder": null,
	                        "cardNumber": null,
	                        "firstDigits": "376441",
	                        "lastDigits": "2018",
	                        "cvv2": null,
	                        "expireMonth": null,
	                        "expireYear": null,
	                        "url": null,
	                        "giftCardId": null,
	                        "giftCardName": null,
	                        "giftCardCaption": null,
	                        "redemptionCode": null,
	                        "group": "creditCard",
	                        "tid": "872b5b22-92ab-4062-abff-3325cf2bdae3",
	                        "dueDate": null,
	                        "connectorResponses": {
	                            "Tid": "872b5b22-92ab-4062-abff-3325cf2bdae3",
	                            "ReturnCode": "0",
	                            "Message": null,
	                            "authId": "783994",
	                            "transactionIdentifier": "322363",
	                            "orderKey": "872b5b22-92ab-4062-abff-3325cf2bdae3",
	                            "nsu": "185140",
	                            "acquirer": "Simulator"
	                        }
	                    }
	                ]
	            }
	        ]
	    },
	    "packageAttachment": {
	        "packages": []
	    },
	    "sellers": [
	        {
	            "id": "1",
	            "name": "WalmartV5",
	            "logo": "http://portal.vtexcommerce.com.br/arquivos/logo.jpg"
	        }
	    ],
	    "callCenterOperatorData": null,
	    "followUpEmail": "81acb5b2b0e942e6aac05490a6351278@ct.vtex.com.br",
	    "lastMessage": "VTEX MKP - QA Seu pagamento foi aprovado! pedido realizado em: 16/09/2014 Olá, Saul. Seu pagamento foi efetuado com sucesso. Você receberá o",
	    "hostname": "walmartv5",
	    "changesAttachment": null,
	    "openTextField": null
	}



###1.2.1 - Obter Informações Complementares de Pedido###
Caso necessário obter informações complemtares do pedido com endereço de cobrança por exemplo, deve acessa a API REST de **Payments** passando o *TID ("transactionId": "33CD3CC4D11A4FA49A2C9EE20D771F98") do gateway VTEX.Segue exemplo de chamada a API REST para pegar um pagamento.


endpoint: **nomedaloja/api/oms/pvt/orders/{orderId}**  
verb: **GET**  
Content-Type: **application/json**  
Accept: **application/json**

###1.3 - Pedido Está no ERP - Preparando Entrega###

##2 - Nota Fiscal ##

##3 - Tracking##

##4 - Cancelamento ##

##5 - Considerações ##


####5.1 Pooling (loop de atualização executado de tempos em tempos) ####
O envio ou consumo de dados num processo de integração deve ser executado somente quando necessário, ou seja, o dado só deve ser enviado do ERP para a plataforma VTEX quando ele realmente for alterado. **NÂO** se deve fazer uma integração que varre entidades inteiras do ERP e atualiza todos os dados na plataforma VTEX de tempos  em tempos, ou vice e versa. Além de consumir e processar dados desnecessáriamente, isso não funcionaria para lojas com mais de 5 mil Skus no catálogo.


####5.2 Ferramentas de apoio ao integrador ####
Ferramentas são de extrema importância para qualquer integrador:

**Postman - REST Client** (_chrome://extensions/_)
Nesta ferramente pode se testar, armazenar histórico, salvar coleções de requests do acesso de todas as APIs dos modulos VTEX  (OMS, Logistics, Pricing, GCS, etc).  

![alt text](postman.png "Title")  

É de suma importancia que o integrador tenha o conhecimento de ferramentas desse tipo, ou outras parecidas, antes de inciar um processo de integração usando APIs REST VTEX.



####5.3 Versão:Beta 1.0####
Essa versão de documentação suporta a integração na versão da plataforma VTEX smartcheckout. Ela foi escrita para auxiliar um integração e a idéia e que através dela, não  restem nenhuma dúvida de como se integrar com a VTEX. Se recebeu essa documentação e ainda restaram dúvidas, por favor, detalhe as suas dúvidas abaixo no comentário, para chegarmos a um documento rico e funcional.


autor: Jonas Bolognim