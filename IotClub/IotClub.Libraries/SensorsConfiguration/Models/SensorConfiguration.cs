namespace IotClub.Libraries.SensorsConfiguration.Models
{
    public class SensorConfiguration
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
    }
}
