using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DABHandIn4.TraderInfoRestApi.Core.Repositories;
using DABHandIn4.TraderInfoRestApi.Models;

namespace DABHandIn4.TraderInfoRestApi.Core
{
    public interface IUnitOfWork
    {
        IRepository<Fremtidige> Fremtidige { get; set; }
        IRepository<HistorikOgAktuel> HistorikOgAktuel { get; set; }
    }
}
