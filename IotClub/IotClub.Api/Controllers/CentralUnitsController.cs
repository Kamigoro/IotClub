using IotClub.Api.Contracts.V1.Requests;
using IotClub.Api.Contracts.V1.Responses;
using IotClub.Libraries.CentralUnits.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace IotClub.Api.Controllers
{
    [Route("centralunit")]
    public class CentralUnitsController : ControllerBase
    {
        private readonly ICentralUnitRepository _centralUnitRepository;
        public CentralUnitsController(ICentralUnitRepository centralUnitRepository)
        {
            _centralUnitRepository = centralUnitRepository;
        }

        [HttpPost]
        [Route("{tenantId}")]
        public async Task<IActionResult> StoreNewCentralUnitAsync(string tenantId, [FromBody] CentralUnitRequest centralUnitRequest)
        {
            var centralUnit = centralUnitRequest.ToCentralUnitEntity(tenantId);
            var centralUnitStored = await _centralUnitRepository.StoreCentralUnitAsync(centralUnit);
            if(centralUnitStored != null)
            {
                return Ok(CentralUnitReponse.FromCentralUnitEntity(centralUnitStored));
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("{tenantId}/{centralUnitId}")]
        public async Task<IActionResult> GetCentralUnitByIdAsync(string tenantId, string centralUnitId)
        {
            var centralUnit = await _centralUnitRepository.GetCentralUnitByIdAsync(tenantId, centralUnitId);
            if(centralUnit != null)
            {
                return Ok(CentralUnitReponse.FromCentralUnitEntity(centralUnit));
            }
            else{
                return NotFound();
            }
        }

        [HttpPut]
        [Route("{tenantId}/{centralUnitId}")]
        public async Task<IActionResult> UpdateCentralUnitByIdAsync(string tenantId, string centralUnitId, [FromBody] CentralUnitRequest centralUnitRequest)
        {
            var centralUnitUpdate = centralUnitRequest.ToCentralUnitEntity(tenantId, centralUnitId);
            var centralUnitUpdated = await _centralUnitRepository.UpdateCentralUnitAsync(tenantId, centralUnitId, centralUnitUpdate);
            if(centralUnitUpdated != null)
            {
                return Ok(CentralUnitReponse.FromCentralUnitEntity(centralUnitUpdated));
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete]
        [Route("{tenantId}/{centralUnitId}")]
        public async Task<IActionResult> DeleteCentralUnitByIdAsync(string tenantId, string centralUnitId)
        {
            var hasBeenDeleted = await _centralUnitRepository.DeleteCentralUnitAsync(tenantId, centralUnitId);
            if (hasBeenDeleted)
            {
                return Ok();
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("{tenantId}/{centralUnitId}/sensors/{position}")]
        public async Task<IActionResult> StoreSensorConfigurationAsync(string tenantId, string centralUnitId,
            int position, [FromBody] SensorConfigurationRequest sensorConfigurationRequest)
        {
            var sensorConfiguration = sensorConfigurationRequest.ToSensorConfigurationEntity(position);
            var sensorConfigurationStored = await _centralUnitRepository.StoreSensorConfigurationAsync(tenantId, centralUnitId, sensorConfiguration);
            if(sensorConfigurationStored != null)
            {
                return Ok(SensorConfigurationResponse.FromSensorConfigurationEntity(sensorConfigurationStored));
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("{tenantId}/{centralUnitId}/sensors/{position}")]
        public async Task<IActionResult> GetSensorConfigurationByPositionAsync(string tenantId, string centralUnitId, int position)
        {
            var sensorConfiguration = await _centralUnitRepository.GetSensorConfigurationByPositionAsync(tenantId, centralUnitId, position);
            if (sensorConfiguration != null)
            {
                return Ok(SensorConfigurationResponse.FromSensorConfigurationEntity(sensorConfiguration));
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        [Route("{tenantId}/{centralUnitId}/sensors")]
        public async Task<IActionResult> GetSensorsConfigurationAsync(string tenantId, string centralUnitId)
        {
            var sensorsConfiguration = await _centralUnitRepository.GetSensorsConfigurationAsync(tenantId, centralUnitId);
            if (!sensorsConfiguration.Any())
            {
                return NoContent();
            }
            else
            {
                return Ok(sensorsConfiguration.Select(SensorConfigurationResponse.FromSensorConfigurationEntity).ToArray());
            }
        }
    }
}
