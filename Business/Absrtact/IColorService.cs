using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Absrtact
{
    public interface IColorService
    {
        List<Color> GetAll();
        Color GetByColorId(int id);
    }
}
