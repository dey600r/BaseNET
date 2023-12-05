﻿using BASE.AppCore.Services;
using BASE.AppCore.Services.Security;
using BASE.Common.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace BASE.WebApi.Controllers.Vehicle
{
	public class VehicleTypeController : BaseAuthorizeController
	{
		IVehicleTypeService _vehicleTypeService;

		public VehicleTypeController(IVehicleTypeService vehicleTypeService, ILogger<BaseController> logger, IJwtGenerator jwtGenerator) : base(logger, jwtGenerator)
		{
			_vehicleTypeService = vehicleTypeService;
		}

		[HttpGet]
		public ActionResult<IEnumerable<VehicleTypeModel>> Get()
		{
			try
			{
				return Ok(_vehicleTypeService.GetAll());
			}
			catch (Exception ex)
			{
				Log(ex.Message, LogLevel.Error);
				return BadRequest(ex.Message);
			}
		}
	}
}
