using mini_ecommerce_backend.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mini_ecommerce_backend.Domain.DTOs.Request
{
    public class OrederRequest
    {   
        public int NumberOfItems { get; set; }
        public CustomerRequest customerRequest { get; set; }
        public List<Product> itemRequests { get; set; }
    }
}
