using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        public static IResult Run(params IResult[] logics) //params=> birden çok parametre, virgül kullanarak, kullanabiliriz demektir. logics=> iş kuralı demektir
        {
            foreach (var logic in logics)
            {
                if (logic.Success) //başarısız olana bakıyoruz.
                {
                    return logic;
                }
            }
            return null;
        }
    }
}
