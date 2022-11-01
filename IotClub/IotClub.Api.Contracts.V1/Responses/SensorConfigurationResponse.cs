using IotClub.Libraries.SensorsConfiguration.Models;

namespace IotClub.Api.Contracts.V1.Responses
{
    public class SensorConfigurationResponse
    {
        /// <summary>
        /// Position occupied by the sensor on the central unit
        /// </summary>
        public int Position { get; set; }
        /// <summary>
        /// Given name for the sensor
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Unit the measurement are taken in
        /// </summary>
        public string Unit { get; set; }
        /// <summary>
        /// Brief description of the sensor
        /// </summary>
        public string Description { get; set; }

        public static SensorConfigurationResponse FromSensorConfigurationEntity(SensorConfiguration sensorConfigurationEntity)
        {
            return new SensorConfigurationResponse
            {
                Position = sensorConfigurationEntity.Position,
                Name = sensorConfigurationEntity.Name,
                Unit = sensorConfigurationEntity.Unit,
                Description = sensorConfigurationEntity.Description
            };
        }
    }
}
