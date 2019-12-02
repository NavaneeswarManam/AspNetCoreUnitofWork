
using System;
using UnitofWork.Repositories.Interface;

namespace UnitofWork.Repositories.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbConnectionFactory _connectionFactory;
        Func<string, IDbConnectionFactory> _fuccconnectionFactory;
        #region ctor
        public UnitOfWork(Func<string, IDbConnectionFactory> fuccconnectionFactory)
        {
            _fuccconnectionFactory = fuccconnectionFactory;
        }
        #endregion

        /// <summary>
        /// Gets the connection.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns></returns>
        public IUnitOfWork GetConn(string type)
        {
            _connectionFactory = _fuccconnectionFactory(type);
            return this;
        }

        private IState _state;
        public IState State
        {
            get
            {
                if (this._state == null)
                {
                    this._state = new State(_connectionFactory);
                }
                return _state;
            }
        }
    }
}
