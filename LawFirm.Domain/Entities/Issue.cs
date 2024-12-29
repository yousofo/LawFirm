using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawFirm.Domain.Entities
{
    public class Issue
    {
        public int Id { get; set; }
        public int LawyerId {  get; set; }
        public string Description { get; set; } = default!;
        public decimal Price  { get; set; } 

    }
}
