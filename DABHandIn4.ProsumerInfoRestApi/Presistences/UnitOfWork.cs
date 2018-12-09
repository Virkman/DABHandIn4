using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DABHandIn4.ProsumerInfoRestApi.Core;
using DABHandIn4.ProsumerInfoRestApi.Core.Repositories;
using DABHandIn4.ProsumerInfoRestApi.Entities;
using DABHandIn4.ProsumerInfoRestApi.Presistences.Repositories;

namespace DABHandIn4.ProsumerInfoRestApi.Presistences
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Forbrug = new Repository<Forbrug>(_context);
            PersonAntal = new Repository<PersonAntal>(_context);
            Prosumer = new Repository<Prosumer>(_context);
        }

        ~UnitOfWork()
        {
            Complete();
        }

        public IRepository<Forbrug> Forbrug { get; }
        public IRepository<PersonAntal> PersonAntal { get; }
        public IRepository<Prosumer> Prosumer { get; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
