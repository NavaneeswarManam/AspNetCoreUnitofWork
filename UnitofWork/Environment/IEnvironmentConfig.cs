using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitofWork.Environment
{
    public interface IEnvironmentConfig
    {
        /// <summary>
        /// Gets the india connection string.
        /// </summary>
        /// <value>
        /// The india connection string.
        /// </value>
        string IndiaConnectionString { get; }

        /// <summary>
        /// Gets the denmark string.
        /// </summary>
        /// <value>
        /// The denmark string.
        /// </value>
        string DenmarkString { get; }

        /// <summary>
        /// Gets the uk string.
        /// </summary>
        /// <value>
        /// The uk string.
        /// </value>
        string UKString { get; }
    }
}
