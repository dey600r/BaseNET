﻿using AutoMapper;
using Microservice.MaintenanceApi.Core.Dtos;
using Microservice.MaintenanceApi.Core.Helpers;
using Microservice.MaintenanceApi.Infraestructure.Context;
using Microservice.MaintenanceApi.Infraestructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Microservice.MaintenanceApi.Infraestructure.Repository
{
	public class ConfigurationRepository : IConfigurationRepository
	{
		private readonly DBContext _dbContext;
		private readonly IMapper _mapper;
		private readonly IHttpContextAccessor _httpContextAccessor;

		public ConfigurationRepository(DBContext dbContext, IMapper mapper, IHttpContextAccessor httpContextAccessor)
		{
			_dbContext = dbContext;
			_mapper = mapper;
			_httpContextAccessor = httpContextAccessor;
		}

		public IEnumerable<ConfigurationModel> GetAll()
		{
			return _dbContext.Configurations.AsNoTracking().Select(x => _mapper.Map<ConfigurationModel>(x)).ToList();
		}

		public ConfigurationModel Add(ConfigurationModel entity) => Add(new List<ConfigurationModel>() { entity }).FirstOrDefault();

		public IEnumerable<ConfigurationModel> Add(IEnumerable<ConfigurationModel> entities)
		{
			try
			{
				if (entities == null || !entities.Any())
					throw new Exception("No data to add configuration");

				List<Configuration> results = new List<Configuration>();
				foreach (ConfigurationModel item in entities)
				{
					var itemMapped = _mapper.Map<Configuration>(item);
					itemMapped.CreatedUser = CommonHelper.GetUserSesion(_httpContextAccessor);
					itemMapped.CreatedDate = DateTime.UtcNow;
					_dbContext.Entry(itemMapped).State = EntityState.Added;
					results.Add(_dbContext.Set<Configuration>().Add(itemMapped).Entity);
				}
				_dbContext.SaveChanges();
				return results.Select(item => _mapper.Map<ConfigurationModel>(item));
			}
			catch (Exception ex)
			{
				throw new Exception("AddingConfiguration", ex);
			}
		}
	}
}
