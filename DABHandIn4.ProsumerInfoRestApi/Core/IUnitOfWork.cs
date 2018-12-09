using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DABHandIn4.ProsumerInfoRestApi.Core.Repositories;
using DABHandIn4.ProsumerInfoRestApi.Entities;

namespace DABHandIn4.ProsumerInfoRestApi.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Forbrug> Forbrug { get; }
        IRepository<PersonAntal> PersonAntal { get; }
        IRepository<Prosumer> Prosumer { get; }
        int Complete();
    }
}
