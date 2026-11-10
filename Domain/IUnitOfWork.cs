using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public interface IUnitOfWork
    {
        public Task SaveChanges();
    }
}
