using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concretes;

namespace Business.Dtos.Responses
{
    public class GetProductByIdResponse
    {
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }
        public string? QuantityPerUnit { get; set; }
    }
}
