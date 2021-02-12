using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class ErrorDataResult<T>:DataResult<T>
    {
        public ErrorDataResult(T data, string message) : base(data, false, message) //all of them
        {

        }
        public ErrorDataResult(T data) : base(data, false) //only data
        {

        }
        public ErrorDataResult(string message) : base(default, false, message) //only message
        {

        }
        public ErrorDataResult() : base(default, false) //nothing
        {

        }
    }
}
