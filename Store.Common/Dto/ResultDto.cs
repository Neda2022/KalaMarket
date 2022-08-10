using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Common.Dto
{
    public class ResultDto
    {
        public string Message { get; set; }
        public bool Success { get; set; }
    }
    public class ResultDto<T>
    {
        public string Message { get; set; }
        public bool Success { get; set; }
        public T Data { get; set; }
     
    }
}
