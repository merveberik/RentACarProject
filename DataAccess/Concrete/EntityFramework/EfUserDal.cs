using Core.DataAccess.EntityFramework;
using DataAccess.Absrtact;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, CarsTableContext>, IUserDal
    {
    }
}
