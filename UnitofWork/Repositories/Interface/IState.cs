using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UnitofWork.Repositories.Interface
{
    public interface IState
    {
        List<string> GetStates();
    }
}
