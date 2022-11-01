using IotClub.Libraries.CentralUnits.Models;
using IotClub.Libraries.SensorsConfiguration.Models;

namespace IotClub.Libraries.CentralUnits.Repositories
{
    public interface ICentralUnitRepository
    {
        /// <summary>
        /// Create a new <see cref="CentralUnit">central unit</see> in the store.
        /// </summary>
        /// <param name="centralUnit">The initial <see cref="CentralUnit">central unit</see> configuration.</param>
        /// <returns>The <see cref="CentralUnit">central unit</see> configuration stored.</returns>
        Task<CentralUnit> StoreCentralUnitAsync(CentralUnit centralUnit);
        /// <summary>
        /// Retrieve a <see cref="CentralUnit">central unit</see> by its tenant and unique id.
        /// </summary>
        /// <param name="tenantId"></param>
        /// <param name="unitId"></param>
        /// <returns>The <see cref="CentralUnit">central unit</see> configuration stored.</returns>
        Task<CentralUnit> GetCentralUnitByIdAsync(string tenantId, string unitId);
        /// <summary>
        /// Update an existing <see cref="CentralUnit">central unit</see> in the store.
        /// </summary>
        /// <param name="tenantId"></param>
        /// <param name="unitId"></param>
        /// <param name="centralUnit">The updated <see cref="CentralUnit">central unit</see> configuration.</param>
        /// <returns>The <see cref="CentralUnit">central unit</see> configuration updated.</returns>
        Task<CentralUnit> UpdateCentralUnitAsync(string tenantId, string unitId, CentralUnit centralUnit);
        /// <summary>
        /// Delete an existing <see cref="CentralUnit">central unit</see> in the store.
        /// </summary>
        /// <param name="tenantId"></param>
        /// <param name="unitId"></param>
        /// <returns>True if the <see cref="CentralUnit">central unit</see> has been deleted, False if it has not been deleted.</returns>
        Task<bool> DeleteCentralUnitAsync(string tenantId, string unitId);
        /// <summary>
        /// Add a <see cref="CentralUnit">central unit</see> to a <see cref="CentralUnit">central unit</see>. 
        /// If there's already an existing <see cref="SensorConfiguration">sensor configuration</see> on the position, it is replaced.
        /// </summary>
        /// <param name="tenantId"></param>
        /// <param name="centralUnitId"></param>
        /// <param name="sensorConfiguration"></param>
        /// <returns>The <see cref="SensorConfiguration">sensor configuration</see> stored.</returns>
        Task<SensorConfiguration> StoreSensorConfigurationAsync(string tenantId, string centralUnitId, SensorConfiguration sensorConfiguration);
        /// <summary>
        /// Gets the <see cref="SensorConfiguration">sensor configuration</see> at a certain position on the <see cref="CentralUnit">central unit</see>.
        /// </summary>
        /// <param name="tenantId"></param>
        /// <param name="centralUnitId"></param>
        /// <param name="sensorPosition"></param>
        /// <returns>The <see cref="SensorConfiguration">sensor configuration</see> stored.</returns>
        Task<SensorConfiguration> GetSensorConfigurationByPositionAsync(string tenantId, string centralUnitId, int sensorPosition);
        /// <summary>
        /// Get all the <see cref="SensorConfiguration">sensors configurations</see> on the central unit.
        /// </summary>
        /// <param name="tenantId"></param>
        /// <param name="centralUnitId"></param>
        /// <returns>The <see cref="SensorConfiguration">sensors configurations</see> stored.</returns>
        Task<SensorConfiguration[]> GetSensorsConfigurationAsync(string tenantId, string centralUnitId);
    }
}
