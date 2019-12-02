using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnitofWork.Repositories.Interface;

namespace UnitofWork.Repositories.Infrastructure
{
    public interface IUnitOfWork
    {
        IUnitOfWork GetConn(string type);

        IState State { get; }
    }
}
