using System;
using System.Collections.Generic;
using System.Text;
using Templ4te.V1.Data.Context;
using Templ4te.V1.Domain.Interfaces;

namespace Templ4te.V1.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly ContextEFC _context;

        public UnitOfWork(ContextEFC context)
        {
            _context = context;
        }


        public int Commit()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
