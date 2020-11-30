using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Entities;

namespace WebAPI.Services
{
    public class EnderecoService : IEnderecoService
    {
        private static string url = @"https://viacep.com.br/ws/";
        private static string requestUrl = @"/json/";

        public endereco GetByCep(string Cep)
        {
            try
            {
                var restClient = new RestClient(url);
                var request = new RestRequest(Method.GET);
                request.Resource = Cep + requestUrl;
                var response = restClient.Execute(request);

                return JsonConvert.DeserializeObject<endereco>(response.Content);
            }
            catch
            {
                return null;
            }
        }
    }
}
