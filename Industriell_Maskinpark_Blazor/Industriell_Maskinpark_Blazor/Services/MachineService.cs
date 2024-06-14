using Industriell_Maskinpark_API.Models;
using System.Text.Json;

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

        public async Task<Machine> GetMachineAsync(string id)
        {
            Guid guid = Guid.Parse(id);
            return await _httpClient.GetFromJsonAsync<Machine>("api/Machines/" + guid);
        }

        public async Task<bool> CreateMachine(string name)
        {
            // create new machine with the name provided.
            Machine machine = new Machine(name);

            string json = JsonSerializer.Serialize(machine);

            HttpContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var result = await _httpClient.PostAsync("api/Machines/", httpContent);

            return result.IsSuccessStatusCode;
        }

        public async Task<bool> FlipPowerSwitch(Machine machine)
        {
            if (machine.Status)
            {
                machine.Status = false;
            } 
            else
            {
                machine.Status = true;
            }
            return await UpdateMachine(machine);
        }

        public async Task<bool> UpdateMachine(Machine machine)
        {
            string json = JsonSerializer.Serialize(machine);

            HttpContent httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
            var result = await _httpClient.PutAsync("api/Machines/" + machine.Id, httpContent);

            return result.IsSuccessStatusCode;
            
            //if (result.IsSuccessStatusCode) {
            //    return true;
            //} else
            //{
            //    return false;
            //}
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
