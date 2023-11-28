using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCoreProject.Application.Contract.Product
{
    public class ProductSearchModel
    {
        public string Name { get; set; }
        public bool IsRemoved { get; set; }
    }
}
