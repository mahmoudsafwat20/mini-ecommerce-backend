using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mini_ecommerce_backend.Domain.DTOs.Request
{
    public class PaginatedRequest
    {
        public int PageNumber { get; set; } = 0;
        public int PageSize { get; set; } = 0;
        public string? KeyWord { get; set; }
    }
}
