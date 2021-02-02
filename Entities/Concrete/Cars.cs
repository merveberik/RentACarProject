using Entities.Absrtact;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Cars : IEntity
    {
        public int CarId { get; set; }
        public int BrandId { get; set; }
        public string Color { get; set; }
        public int ModelYear { get; set; }
        public int DailyPrice { get; set; }
        public string Description { get; set; }
    }
}
