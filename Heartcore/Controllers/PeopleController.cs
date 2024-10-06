using Heartcore.Logic.Managers;
using Microsoft.AspNetCore.Mvc;

namespace Heartcore.Controllers;

[ApiController]
[Route("[controller]")]
public class PeopleController : ControllerBase
{
    private readonly IDataManager _dataManager;

    private readonly ILogger<PeopleController> _logger;

    public PeopleController(ILogger<PeopleController> logger, IDataManager dataManager)
    {
        _logger = logger;
        _dataManager = dataManager;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        // Uncomment me to create 10 people in Umbraco using the public api data
        // await _dataManager.ImportDataToUmbraco();

        var data = await _dataManager.GetExistingData();
        return Ok(data);
    }
}

