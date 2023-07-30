using System.Text;
using System.Text.Json;
using PlatformService.Dtos;

namespace PlatformService.SyncDataServices.Http
{
    public class HttpCommandDataClient : ICommandDataClient
    {
        private readonly HttpClient httpClient;

        public HttpCommandDataClient(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task SendPlatformToCommand(PlatformReadDto dto)
        {
            var httpContent = new StringContent(JsonSerializer.Serialize(dto), Encoding.UTF8, "application/json");

            var response = await httpClient.PostAsync("http://commands-clusterip-srv/api/commands/platforms", httpContent);

            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("--> Sync POST to Command Service was OK");
            }
            else
            {
                Console.WriteLine("--> Sync POST to Command Service was NOT OK");
            }
        }
    }
}