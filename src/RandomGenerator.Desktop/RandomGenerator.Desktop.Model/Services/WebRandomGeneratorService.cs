using Newtonsoft.Json;
using RandomGenerator.Desktop.Model.Interfaces;
using RandomGenerator.Shared.ApiModels.Responses;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace RandomGenerator.Desktop.Model.Services
{
    public class WebRandomGeneratorService : IRandomGeneratorService
    {
        private readonly string _source;

        public WebRandomGeneratorService(string source)
        {
            _source = source;
        }

        public async Task<int> GetRandomValueAsync()
        {
            var request = WebRequest.Create(_source);
            request.Method = "GET";
            var response = await request.GetResponseAsync();
            var data = await new StreamReader(response.GetResponseStream()).ReadToEndAsync();
            return JsonConvert.DeserializeObject<GetRandomResponse>(data).Value;
        }
    }
}
