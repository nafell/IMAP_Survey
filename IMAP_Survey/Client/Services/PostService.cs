using IMAP_Survey.Shared;
using System.Net.Http.Json;

namespace IMAP_Survey.Client.Services
{
    public class PostService
    {
        public async Task Post(InputData inputData, HttpClient http, LocalStorageService local)
        {
            try
            {
                var result = await http.PostAsJsonAsync("api/Database", inputData);

                if (result.IsSuccessStatusCode)
                {
                    var id = result.Content.ReadAsStringAsync();
                    
                    await local.SaveInputData(inputData);

                    return;
                }
            }
            catch (Exception ex)
            {
                ;
            }
        }
    }
}