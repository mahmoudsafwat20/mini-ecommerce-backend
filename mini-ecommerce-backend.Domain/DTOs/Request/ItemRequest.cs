using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mini_ecommerce_backend.Domain.DTOs.Request
{
    public class ItemRequest
    {
        public string name {  get; set; } = string.Empty;
        public int Quantaty {  get; set; } 
    }
}
