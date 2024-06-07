using Industriell_Maskinpark_API.Models;

namespace Industriell_Maskinpark_Blazor.Services
{
    public class MachineService
    {
        private readonly HttpClient _httpClient;

        public MachineService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Machine>> GetMachinesAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Machine>>("api/Machines");
        }
    }
}
