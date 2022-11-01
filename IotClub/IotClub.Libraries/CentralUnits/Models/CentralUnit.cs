using IotClub.Libraries.SensorsConfiguration.Models;
using System.Text.Json.Serialization;

namespace IotClub.Libraries.CentralUnits.Models
{
    public class CentralUnit
    {
        /// <summary>
        /// Partition key for cosmos
        /// </summary>
        public string Pk => this.TenantId;
        /// <summary>
        /// Unique identifier of the central unit
        /// </summary>
        public string Id { get; set; }
        /// <summary>
        /// Id of the tenant to which the central unit belongs
        /// </summary>
        public string TenantId { get; set; }
        /// <summary>
        /// Name given to the central unit
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Sensors configuration attached to the central unit
        /// </summary>
        public List<SensorConfiguration> Sensors { get; set; } = new List<SensorConfiguration>();
    }
}
