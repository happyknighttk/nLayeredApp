using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Responses
{
    public class DeletedProductResponse
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public DateTime DeletedDate { get; set; }
    }
}
