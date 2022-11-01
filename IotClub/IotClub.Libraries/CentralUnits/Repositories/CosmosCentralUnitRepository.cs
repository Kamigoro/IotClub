using IotClub.Libraries.CentralUnits.Models;
using IotClub.Libraries.SensorsConfiguration.Models;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
using System.Net;

namespace IotClub.Libraries.CentralUnits.Repositories
{
    public class CosmosCentralUnitRepository : ICentralUnitRepository
    {
        private readonly Container _centralUnitContainer;
        public CosmosCentralUnitRepository(IConfiguration configuration, CosmosClient cosmosClient)
        {
            var databaseId = configuration["cosmos:central-unit:database"] ?? "CentralUnitManagement";
            var containerId = configuration["cosmos:central-unit:configuration-container"] ?? "Configuration";
            _centralUnitContainer = cosmosClient.GetContainer(databaseId, containerId);
        }
        public async Task<CentralUnit?> StoreCentralUnitAsync(CentralUnit centralUnit)
        {
            var centralUnitCreationResponse = await _centralUnitContainer.CreateItemAsync(centralUnit);
            return centralUnitCreationResponse.Resource;
        }
        public async Task<CentralUnit?> GetCentralUnitByIdAsync(string tenantId, string unitId)
        {
            try
            {
                var centralUnitCosmosResponse = await _centralUnitContainer.ReadItemAsync<CentralUnit>(unitId, new PartitionKey(tenantId));
                return centralUnitCosmosResponse.Resource;
            }
            catch(CosmosException ex)
            {
                if(ex.StatusCode == HttpStatusCode.NotFound)
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
        }
        public async Task<CentralUnit?> UpdateCentralUnitAsync(string tenantId, string unitId, CentralUnit centralUnit)
        {
            try
            {
                var updateCosmosResponse = await _centralUnitContainer.ReplaceItemAsync(centralUnit, unitId, new PartitionKey(tenantId));
                return updateCosmosResponse.Resource;
            }
            catch (CosmosException ex)
            {
                if (ex.StatusCode == HttpStatusCode.NotFound)
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
        }
        public async Task<bool> DeleteCentralUnitAsync(string tenantId, string unitId)
        {
            var deleteCosmosResponse = await _centralUnitContainer.DeleteItemAsync<CentralUnit>(unitId, new PartitionKey(tenantId),
                new ItemRequestOptions { EnableContentResponseOnWrite = false });
            return deleteCosmosResponse.StatusCode == HttpStatusCode.NoContent;
        }
        public async Task<SensorConfiguration?> StoreSensorConfigurationAsync(string tenantId, string centralUnitId, SensorConfiguration sensorConfiguration)
        {
            try
            {
                var centralUnitCosmosResponse = await _centralUnitContainer.ReadItemAsync<CentralUnit>(centralUnitId, new PartitionKey(tenantId));
                var centralUnit = centralUnitCosmosResponse.Resource;

                var existingSensor = centralUnit.Sensors.FirstOrDefault(s => s.Position == sensorConfiguration.Position);
                if (existingSensor != null)
                    centralUnit.Sensors.Remove(existingSensor);

                centralUnit.Sensors.Add(sensorConfiguration);
                await _centralUnitContainer.ReplaceItemAsync(centralUnit, centralUnitId, new PartitionKey(tenantId), 
                    new ItemRequestOptions { EnableContentResponseOnWrite = false});

                return sensorConfiguration;
            }
            catch (CosmosException ex)
            {
                if (ex.StatusCode == HttpStatusCode.NotFound)
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
        }
        public async Task<SensorConfiguration?> GetSensorConfigurationByPositionAsync(string tenantId, string centralUnitId, int sensorPosition)
        {
            try
            {
                var centralUnitCosmosResponse = await _centralUnitContainer.ReadItemAsync<CentralUnit>(centralUnitId, new PartitionKey(tenantId));
                var centralUnit = centralUnitCosmosResponse.Resource;

                return centralUnit.Sensors.First(s => s.Position == sensorPosition);
            }
            catch (CosmosException ex)
            {
                if (ex.StatusCode == HttpStatusCode.NotFound)
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
        }
        public async Task<SensorConfiguration[]?> GetSensorsConfigurationAsync(string tenantId, string centralUnitId)
        {
            try
            {
                var centralUnitCosmosResponse = await _centralUnitContainer.ReadItemAsync<CentralUnit>(centralUnitId, new PartitionKey(tenantId));
                var centralUnit = centralUnitCosmosResponse.Resource;

                return centralUnit.Sensors.ToArray();
            }
            catch (CosmosException ex)
            {
                if (ex.StatusCode == HttpStatusCode.NotFound)
                {
                    return null;
                }
                else
                {
                    throw;
                }
            }
        }
    }
}
