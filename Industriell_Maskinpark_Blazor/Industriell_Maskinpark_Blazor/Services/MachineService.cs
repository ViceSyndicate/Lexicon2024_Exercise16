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

        public async Task<bool> DeleteMachine(Guid guid)
        {
            var result = await _httpClient.DeleteAsync("api/Machines/" + guid.ToString());

            if (result.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
