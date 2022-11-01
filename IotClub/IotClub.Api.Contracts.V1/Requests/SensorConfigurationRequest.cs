using IotClub.Libraries.SensorsConfiguration.Models;
using System.ComponentModel.DataAnnotations;

namespace IotClub.Api.Contracts.V1.Requests
{
    public class SensorConfigurationRequest
    {
        /// <summary>
        /// Given name for the sensor
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// Unit the measurement are taken in
        /// </summary>
        [Required]
        public string Unit { get; set; }
        /// <summary>
        /// Brief description of the sensor
        /// </summary>
        public string Description { get; set; }

        public SensorConfiguration ToSensorConfigurationEntity(int position)
        {
            return new SensorConfiguration
            {
                Position = position,
                Name = this.Name,
                Unit = this.Unit,
                Description = this.Description
            };
        }
    }
}
