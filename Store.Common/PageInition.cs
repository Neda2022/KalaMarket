using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Common
{
    public static class PageInition
    {
        //Query from DataBase
       
        public static IEnumerable<TSource> ToPaged<TSource>(this IEnumerable<TSource> source, int page, int pageSize, out int rowsCount) {


            rowsCount = source.Count();
            return source.Skip((page - 1) * pageSize).Take(pageSize);
        }
        

    }
}
