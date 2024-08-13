using System.Text;
using System.Text.Json.Serialization;
using CRUDModels;
using CRUDService.Interface;
using Newtonsoft.Json;

namespace CRUDService
{
    public class CRUDSrvices : ICreateService
    {
        public async Task<List<CreateViewModel>> GetAllDetails()
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:7248/api/GetAllDetails");

                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var responseData = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<List<CreateViewModel>>(responseData);
            }
            catch (HttpRequestException ex)
            {
                
                Console.WriteLine($"HTTP request error: {ex.Message}");
                throw; 
            }
            catch (JsonSerializationException ex)
            {
                
                Console.WriteLine($"JSON deserialization error: {ex.Message}");
                throw;
            }
        }



        public async Task<List<CreateViewModel>> CreateAllDetails(CreateViewModel student)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost:7248/api/CreateDetails");
            var jsonContent = JsonConvert.SerializeObject(student);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            request.Content = content;
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            return JsonConvert.DeserializeObject<List<CreateViewModel>>(await response.Content.ReadAsStringAsync());
        }

        

        public async Task<bool> DeleteStudentAsync(int? id)
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost:7248/api/DeactivateDetails");
            var jsonContent = JsonConvert.SerializeObject(id);
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            request.Content = content;
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            return response.IsSuccessStatusCode;
        }


        public async Task<CreateViewModel> GetDataBasedOnId(int? id)
        {
           

            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost:7248/api/GetDataBasedOnId");

            
            var jsonContent = JsonConvert.SerializeObject(new { id });
            var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
            request.Content = content;

            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            
            var jsonResponse = await response.Content.ReadAsStringAsync();
            CreateViewModel existingData = JsonConvert.DeserializeObject<CreateViewModel>(jsonResponse);

            return existingData;
        }

        public async Task<CreateViewModel> UpdateData(CreateViewModel createViewModel)
        {
            try
            {
                var client = new HttpClient();
                var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost:7248/api/UpdateDetails");
                var jasonContent = JsonConvert.SerializeObject(createViewModel);
                var content = new StringContent(jasonContent, Encoding.UTF8, "application/json");
                request.Content = content;
                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                var result = JsonConvert.DeserializeObject<CreateViewModel>(await response.Content.ReadAsStringAsync());
                return result;
            }
            catch (Exception)
            {

                throw;
            }
           
        }

       


    }
}