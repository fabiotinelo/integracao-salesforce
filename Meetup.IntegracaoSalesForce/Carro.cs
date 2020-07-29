using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Meetup.IntegracaoSalesForce
{
    public class Carro
    {

        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("Ano_Modelo__c")]
        public int AnoModelo { get; set; }


        [JsonProperty("Data_da_Compra__c")]
        public DateTime DataCompra { get; set; }


        [JsonProperty("Marca__c")]
        public string Marca { get; set; }


        [JsonProperty("Observacao__c")]
        public string Observacao { get; set; }
    }
}
