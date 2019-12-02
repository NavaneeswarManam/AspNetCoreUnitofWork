using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace UnitofWork.Environment
{
    public class EnvironmentConfig : IEnvironmentConfig
    {

        public EnvironmentConfig(IConfiguration configuration)
        {
            IndiaConnectionString = configuration["ConnectionStrings:IndiaDB"];
            DenmarkString = configuration["ConnectionStrings:DenmarkDB"];
            UKString = configuration["ConnectionStrings:UKDB"];
        }

        /// <inheritdoc />
        public string IndiaConnectionString { get; }

        /// <inheritdoc />
        public string DenmarkString { get; }

        /// <inheritdoc />
        public string UKString { get; }
    }
}
