using IMAP_Survey.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Cosmos;

namespace IMAP_Survey.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DatabaseController : ControllerBase
    {
        private static readonly string EndpointUri = ApiKey.CosmosEndpoint;

        private static readonly string PrimaryKey = ApiKey.CosmosPK;

        private CosmosClient cosmosClient;
        private Database database;
        private Container container;

        private string databaseId = "SurveyFirst";
        private string containerId = "Records";

        private readonly ILogger<DatabaseController> _logger;

        public DatabaseController(ILogger<DatabaseController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Post(InputData inputData)
        {
            await InitiateService();
            var result = await AddOrUpdateSurveyRecord(inputData);

            if (result == null)
            {
                return BadRequest("failed.");
            }

            return Ok(inputData.id);
        }

        public async Task InitiateService()
        {
            if (cosmosClient != null)
            {
                return;
            }

            cosmosClient = new CosmosClient(EndpointUri, PrimaryKey, new CosmosClientOptions() { ApplicationName = "IMAP-ServeyPreferenceWASM" });
            container = cosmosClient.GetContainer(databaseId, containerId);
        }

        public async Task<ItemResponse<InputData>?> AddOrUpdateSurveyRecord(InputData inputData)
        {
            try
            {
                inputData.SubmitDate = DateTime.Now;
                if (inputData.id == default)
                {
                    return await AddSurveyRecord(inputData);
                }
                else
                {
                    return await UpdateSurveyRecord(inputData);
                }
            }
            catch
            {
                return null;
            }
        }

        public async Task<ItemResponse<InputData>> AddSurveyRecord(InputData inputData)
        {
            inputData.id = Guid.NewGuid();
            var response = await container.CreateItemAsync(inputData);
            return response;
        }

        public async Task<ItemResponse<InputData>> UpdateSurveyRecord(InputData inputData)
        {
            var updateResponse = await container.ReplaceItemAsync(inputData, inputData.id.ToString());

            return updateResponse;
        }

    }
}
