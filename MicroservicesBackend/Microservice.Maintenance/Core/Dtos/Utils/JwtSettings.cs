﻿namespace Microservice.MaintenanceApi.Core.Dtos.Utils
{
	public class JwtSettings
	{
		public string Issuer { get; set; }
		public string Audience { get; set; }
		public string Key { get; set; }
	}
}
