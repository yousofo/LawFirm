using LawFirm.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawFirm.Application.Lawyers.Dtos
{
    public class LawyerDto
    {
        public int Id { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
        public string Category { get; set; } = default!;
        public bool IsAvailable { get; set; } = default!;
        public string? City { get; set; }
    }
}
