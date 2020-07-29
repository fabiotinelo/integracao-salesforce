using Flurl;
using Flurl.Http;
using System;
using System.IO;

namespace Meetup.IntegracaoSalesForce
{
    class Program
    {
        static Access access;
        static string instanceURL;
        static string versionAPI = "v41.0";
        static string accessToken;

        static void Main(string[] args)
        {
        
            Authenticate();


            //Bulk();
            //https://developer.salesforce.com/docs/atlas.en-us.api_bulk_v2.meta/api_bulk_v2/introduction_bulk_api_2.htm
            //https://developer.salesforce.com/docs/atlas.en-us.api_bulk_v2.meta/api_bulk_v2/creating_bulk_requests.htm
            //https://developer.salesforce.com/docs/atlas.en-us.salesforce_app_limits_cheatsheet.meta/salesforce_app_limits_cheatsheet/salesforce_app_limits_platform_bulkapi.htm#:~:text=Batches%20for%20data%20loads%20can,a%20maximum%20of%2032%2C000%20characters.

            //https://developer.salesforce.com/docs/atlas.en-us.api_rest.meta/api_rest/dome_query.htm
            //Select();

            //https://developer.salesforce.com/docs/atlas.en-us.api_rest.meta/api_rest/dome_sobject_create.htm
            //Insert();

            //https://developer.salesforce.com/docs/atlas.en-us.api_rest.meta/api_rest/dome_delete_record.htm
            //Delete();

            //https://developer.salesforce.com/docs/atlas.en-us.api_rest.meta/api_rest/dome_update_fields.htm
            //Update();
        }

        static void Authenticate()
        {
            string url = "https://login.salesforce.com/services/oauth2/token";

            Console.WriteLine("Autenticando no Salesforce");

            access = url.PostUrlEncodedAsync(new
            {
                grant_type = "password",
                client_id = "3MVG9Kip4IKAZQEVUr7ugZ6sLz6IgXXXXXXxvXoHIs5_my4yk1k6QVXGQDeRcjSoF4dawmcw5Q82Z7KpVm0i_",
                client_secret = "AA9499F21BC3F96E545686D116FXXXXXX65A7A657411177D53B37DF067665807",
                password = Security.Password + Security.Token,
                username = "usuario.alguem@gmail.com"
            }).ReceiveJson<Access>().Result;

            instanceURL = access.InstanceURL;
            accessToken = access.AccessToken;

            Console.WriteLine($"Autenticação realizada com sucesso - token {accessToken}");

        }

        static void Select()
        {
            string query = "SELECT Id, Name, Ano_Modelo__c, Data_da_Compra__c, Marca__c, Observacao__c FROM Carro__c";

            string url = Url.Combine(instanceURL, $"/services/data/{versionAPI}/query/?q={query}");

            dynamic result = url.WithHeader("Content-Type", "application/json; charset=UTF-8")
                               .WithHeader("Accept", "application/json")
                               .WithOAuthBearerToken(accessToken).GetJsonAsync<dynamic>().Result;
        }

        static void Insert()
        {
            string objectName = "Carro__c";
            Carro carro = new Carro
            {
                Name = "Monza",
                AnoModelo = 1989,
                DataCompra = Convert.ToDateTime("2000-03-22"),
                Marca = "Chevrolet",
                Observacao = "Teste de inclusão do Monza"
            };

            string url = Url.Combine(instanceURL, $"/services/data/{versionAPI}/sobjects/{objectName}");
            var result = url.WithHeader("Content-Type", "application/json; charset=UTF-8")
                           .WithHeader("Accept", "application/json")
                           .WithOAuthBearerToken(accessToken).PostJsonAsync(carro).Result.Content.ReadAsStringAsync().Result;
        }

        static void Delete()
        {
            string objectName = "Carro__c";
            string idCarro = "a003h000005dc4BAAQ";

            string url = Url.Combine(instanceURL, $"/services/data/{versionAPI}/sobjects/{objectName}/{idCarro}");
            var result = url.WithOAuthBearerToken(accessToken).DeleteAsync().Result.Content;
        }

        static void Update()
        {
            var carro = new { Name = "Fusca" };

            string objectName = "Carro__c";
            string idCarro = "a003h000005dX86AAE";

            string url = Url.Combine(instanceURL, $"/services/data/{versionAPI}/sobjects/{objectName}/{idCarro}");
            var result = url.WithOAuthBearerToken(accessToken).PatchJsonAsync(carro).Result.Content.ReadAsStringAsync().Result;
        }

        #region Bulk 

        static void Bulk()
        {
            RequestJob requestJob = new RequestJob("Carro__c", OperationEnum.upsert, "Name");
            SendCSV(requestJob, File.ReadAllText(@"D:\temp\carros.csv"));
        }

        static ResponseJob SendCSV(RequestJob requestJob, string csv)
        {
            ResponseJob responseJob = CreateJob(requestJob);
            PutFile(responseJob, csv);
            CloseJob(responseJob.ID);
            return responseJob;
        }

        static ResponseJob CreateJob(RequestJob requestJob)
        {
            return Url.Combine(instanceURL, $"/services/data/{versionAPI}/jobs/ingest")
                                            .WithHeader("Content-Type", "application/json; charset=UTF-8")
                                            .WithHeader("Accept", "application/json")
                                            .WithOAuthBearerToken(access.AccessToken)
                                            .WithTimeout(200)
                                            .PostJsonAsync(requestJob).ReceiveJson<ResponseJob>().Result;
        }

        static void PutFile(ResponseJob responseJob, string csv)
        {
            string url = Url.Combine(instanceURL, $"/services/data/{versionAPI}/jobs/ingest/{responseJob.ID}/batches");

            string result = url
                                .WithHeader("Content-Type", "text/csv")
                                .WithHeader("Accept", "application/json")
                                .WithOAuthBearerToken(access.AccessToken)
                                .WithTimeout(200)
                                .PutStringAsync(csv).ReceiveString().Result;
        }

        static JobInfo CloseJob(string jobID)
        {
            string url = Url.Combine(instanceURL, $"/services/data/{versionAPI}/jobs/ingest/{jobID}");

            return url
                        .WithHeader("Content-Type", "application/json; charset=UTF-8")
                        .WithHeader("Accept", "application/json")
                        .WithOAuthBearerToken(access.AccessToken)
                        .WithTimeout(200)
                        .PatchJsonAsync(new
                        {
                            state = "UploadComplete"
                        }).ReceiveJson<JobInfo>().Result;
        }

        #endregion
    }
}
