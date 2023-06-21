using Blazored.LocalStorage;
using IMAP_Survey.Shared;

namespace IMAP_Survey.Client.Services
{
    public class LocalStorageService
    {
        private readonly ILocalStorageService _localStorageService;

        private const string keyName = "surveyInput";

        public LocalStorageService(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }

        public async Task<InputData> LoadInputData()
        {
            return await _localStorageService.GetItemAsync<InputData>(keyName)
                ?? new InputData();
        }

        public async Task SaveInputData(InputData inputData)
        {
            await _localStorageService.SetItemAsync(keyName, inputData);
        }
    }
}
