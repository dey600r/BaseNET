﻿using Microservice.VehicleApi.Core.Dtos;

namespace Microservice.VehicleApi.Infraestructure.Repository
{
	public interface IConfigurationRepository
	{
		public IEnumerable<ConfigurationModel> GetAll();
		public ConfigurationModel Add(ConfigurationModel entity);
		public IEnumerable<ConfigurationModel> Add(IEnumerable<ConfigurationModel> entities);

	}
}
