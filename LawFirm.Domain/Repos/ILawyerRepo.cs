using LawFirm.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawFirm.Domain.Repos
{
    public interface ILawyersRepo
    {
        Task<IEnumerable<Lawyer>> GetLawyers();
        Task<Lawyer?> GetLawyer(int id);
        Task<int> CreateLawyer(Lawyer lawyer);
        Task<bool> DeleteLawyer(int id);
        Task<int> UpdateLawyer(Lawyer lawyer);
    }
}
