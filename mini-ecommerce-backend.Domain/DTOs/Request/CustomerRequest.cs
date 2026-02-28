using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mini_ecommerce_backend.Domain.DTOs.Request
{
    public class CustomerRequest
    {
        public string Name { get; set; }= string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
    }
}
