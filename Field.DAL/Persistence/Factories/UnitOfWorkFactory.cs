using Field.DAL.Context;
using Field.DAL.Persistence.Abstract;
using Field.DAL.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Field.DAL.Persistence.Factories
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        public IUnitOfWork Create()
        {
            return new UnitOfWork();
        }
    }


}
