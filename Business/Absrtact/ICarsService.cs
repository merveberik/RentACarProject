using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Absrtact
{
    public interface ICarsService
    {
        List<Cars> GetAll();
    }
}
