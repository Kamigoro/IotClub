using IotClub.Libraries.CentralUnits.Models;
using IotClub.Libraries.SensorsConfiguration.Models;

namespace IotClub.Libraries.CentralUnits.Repositories
{
    public class InMemoryCentralUnitRepository : ICentralUnitRepository
    {
        private List<CentralUnit> _centralUnits = new List<CentralUnit>();

        public Task<CentralUnit> StoreCentralUnitAsync(CentralUnit centralUnit)
        {
            _centralUnits.Add(centralUnit);
            return Task.FromResult(centralUnit);
        }
        public Task<CentralUnit> GetCentralUnitByIdAsync(string tenantId, string unitId)
        {
            return Task.FromResult(_centralUnits.FirstOrDefault(cu => cu.TenantId == tenantId && cu.Id == unitId));
        }
        public Task<CentralUnit> UpdateCentralUnitAsync(string tenantId, string unitId, CentralUnit centralUnit)
        {
            var cu = _centralUnits.FirstOrDefault(cu => cu.TenantId == tenantId && cu.Id == unitId);
            if(cu != null)
            {
                _centralUnits.Remove(cu);
                _centralUnits.Add(centralUnit);
                return Task.FromResult(centralUnit);
            }
            return Task.FromResult((CentralUnit)null);
        }
        public Task<bool> DeleteCentralUnitAsync(string tenantId, string unitId)
        {
            var cu = _centralUnits.FirstOrDefault(cu => cu.TenantId == tenantId && cu.Id == unitId);
            if(cu != null)
            {
                return Task.FromResult(_centralUnits.Remove(cu));
            }
            return Task.FromResult(false);
        }
        public Task<SensorConfiguration> StoreSensorConfigurationAsync(string tenantId, string centralUnitId, SensorConfiguration sensorConfiguration)
        {
            var cu = _centralUnits.FirstOrDefault(cu => cu.TenantId == tenantId && cu.Id == centralUnitId);
            if(cu == null)
                return Task.FromResult((SensorConfiguration)null);

            var existingSensor = cu.Sensors.FirstOrDefault(s => s.Position == sensorConfiguration.Position);
            if (existingSensor != null)
                cu.Sensors.Remove(existingSensor);

            cu.Sensors.Add(sensorConfiguration);
            return Task.FromResult(sensorConfiguration);
        }
        public Task<SensorConfiguration> GetSensorConfigurationByPositionAsync(string tenantId, string centralUnitId, int sensorPosition)
        {
            var cu = _centralUnits.FirstOrDefault(cu => cu.TenantId == tenantId && cu.Id == centralUnitId);
            if (cu != null)
            {
                var existingSensorConfig = cu.Sensors.FirstOrDefault(sc => sc.Position == sensorPosition);
                return Task.FromResult(existingSensorConfig);
            }
            return Task.FromResult((SensorConfiguration)null);
        }
        public Task<SensorConfiguration[]> GetSensorsConfigurationAsync(string tenantId, string centralUnitId)
        {
            var cu = _centralUnits.FirstOrDefault(cu => cu.TenantId == tenantId && cu.Id == centralUnitId);
            if (cu != null)
            {
                return Task.FromResult(cu.Sensors.ToArray());
            }
            return Task.FromResult((SensorConfiguration[])null);
        }
    }
}
