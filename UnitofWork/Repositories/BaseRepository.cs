using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using UnitofWork.Repositories.Infrastructure;

namespace UnitofWork.Repositories
{
    public class BaseRepository
    {
        private IDbConnectionFactory _dbConnectionFactory;

        #region Ctor
        public BaseRepository(IDbConnectionFactory dbConnectionFactory)
        {
            _dbConnectionFactory = dbConnectionFactory;
        }

        #endregion


        #region Public Members
        public IDbConnection Connection
        {
            get
            {
                return _dbConnectionFactory.GetConnection();
            }
        }
        #endregion
    }
}
