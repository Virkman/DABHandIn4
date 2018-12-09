using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DABHandIn4.TraderInfoRestApi.Core;
using DABHandIn4.TraderInfoRestApi.Core.Repositories;
using DABHandIn4.TraderInfoRestApi.Models;
using DABHandIn4.TraderInfoRestApi.Presistences.Repositories;

namespace DABHandIn4.TraderInfoRestApi.Presistences
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork()
        {
            Fremtidige = new RepositoryFrem<Fremtidige>();
            HistorikOgAktuel = new RepositoryHistorik<HistorikOgAktuel>();
        }

        public IRepository<Fremtidige> Fremtidige { get; set; }
        public IRepository<HistorikOgAktuel> HistorikOgAktuel { get; set; }
    }
}
