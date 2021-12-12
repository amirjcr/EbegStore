using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_EBegSiteQuery.Contracts.Products
{
    public  interface IProductQuery
    {
        List<ProdcuctQueryModel> GetLatestArrivas();
    }
}
