using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitofWork.Repositories.Infrastructure;
using UnitofWork.Repositories.Interface;

namespace UnitofWork.Repositories
{
    public class State : BaseRepository, IState
    {
        public State(IDbConnectionFactory dbConnectionFactory) : base(dbConnectionFactory)
        {
        }

        public List<string> GetStates()
        {
            return new List<string> { "Ind" };
        }
    }
}
