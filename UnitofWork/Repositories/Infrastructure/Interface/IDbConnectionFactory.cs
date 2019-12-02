using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace UnitofWork.Repositories.Infrastructure
{
    public interface IDbConnectionFactory
    {
        IDbConnection GetConnection();
    }
}
