using IotClub.Libraries.CentralUnits.Models;
using IotClub.Libraries.SensorsConfiguration.Models;
using System.ComponentModel.DataAnnotations;

namespace IotClub.Api.Contracts.V1.Requests
{
    public class CentralUnitRequest
    {
        /// <summary>
        /// Name given to the central unit.
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// Sensors configuration attached to the central unit.
        /// </summary>
        public List<SensorConfiguration> Sensors { get; set; }

        /// <summary>
        /// Transform central unit request into a central unit entity.
        /// </summary>
        /// <param name="tenantId"></param>
        /// <param name="unitId"></param>
        /// <returns>Central unit entity with the specified id or a newly generated one if empty</returns>
        public CentralUnit ToCentralUnitEntity(string tenantId, string unitId = null)
        {
            return new CentralUnit
            {
                Id = string.IsNullOrEmpty(unitId) ? Guid.NewGuid().ToString() : unitId,
                TenantId = tenantId,
                Name = this.Name,
                Sensors = this.Sensors
            };
        }
    }
}
