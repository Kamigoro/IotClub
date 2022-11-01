using IotClub.Libraries.CentralUnits.Models;
using IotClub.Libraries.SensorsConfiguration.Models;

namespace IotClub.Api.Contracts.V1.Responses
{
    public class CentralUnitReponse
    {
        /// <summary>
        /// Unique identifier of the central unit
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Name given to the central unit
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Sensors configuration attached to the central unit
        /// </summary>
        public List<SensorConfiguration> Sensors { get; set; }
        
        public static CentralUnitReponse FromCentralUnitEntity(CentralUnit centralUnitEntity)
        {
            return new CentralUnitReponse
            {
                Id = centralUnitEntity.Id,
                Name = centralUnitEntity.Name,
                Sensors = centralUnitEntity.Sensors
            };
        }
    }
}
