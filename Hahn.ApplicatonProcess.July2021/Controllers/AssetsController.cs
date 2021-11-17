using Hahn.ApplicatonProcess.July2021.Web.DTOs.Assets;
using Hahn.ApplicatonProcess.July2021.Web.Services.Assets;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Hahn.ApplicatonProcess.July2021.Web.Controllers
{
    /// <summary>
    /// Assets Controller
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AssetsController : ControllerBase
    {
        private readonly AssetsService _service;
        private readonly ILogger<AssetsController> _logger;

        /// <summary>
        /// Constructor for User Controller
        /// </summary>
        public AssetsController(ILogger<AssetsController> logger
            , AssetsService service)
        {
            _service = service;
            _logger = logger;
        }

        /// <summary>
        /// Retrieves a specific asset by symbol
        /// </summary>
        /// <response code="200">asset retrieved</response>
        /// <response code="404">asset not found</response>
        [HttpGet("asset")]
        public async Task<IActionResult> Get([FromQuery] GetAssetListRequest request)
        {
            var asset = await _service.SearchAsync(request);
            if (asset == null)
            {
                _logger.LogInformation($"Asset doesn't exist in the database.");
                return NotFound();
            }
            return Ok(asset);
        }

        /// <summary>
        /// Creates a new asset
        /// </summary>
        /// <response code="201">Asset added</response>
        /// <response code="400">Bad Request</response>
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] AddAssetRequest request)
        {
            var assets = await _service.AddNewAsync(request);
            
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            
            return Ok(assets);
        }

        /// <summary>
        /// Retrieves all assets
        /// </summary>
        /// <response code="200">Assets retrieved</response>
        [HttpGet("assets")]
        public async Task<IActionResult> GetAll()
        {
            var assets = await _service.GetAllAsync();
            return Ok(assets);
        }

        /// <summary>
        /// Deletes an asset
        /// </summary>
        /// <response code="204">Asset deleted</response>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(DeleteAssetRequest request)
        {
            var assets = await _service.DeleteAsync(request);
            return Ok(assets);
        }

        /// <summary>
        /// Updates an asset
        /// </summary>
        /// <response code="200">Asset updated</response>
        /// <response code="400">Bad Request</response>
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateAssetRequest request, int Id)
        {
            var assets = await _service.UpdateAsync(request, Id);
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            return Ok(assets);
        }
    }
}
