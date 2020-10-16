using Field.DAL.Persistence.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Field.DAL.Persistence.Factories
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork Create();
    }
}
