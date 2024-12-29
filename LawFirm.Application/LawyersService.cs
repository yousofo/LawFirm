using AutoMapper;
using LawFirm.Application.Lawyers.Dtos;
using LawFirm.Domain.Entities;
using LawFirm.Domain.Repos;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LawFirm.Application
{
    public class LawyersService(ILawyersRepo lawyersRepo, ILogger<LawyersService> logger, IMapper mapper)
    {
        public async Task<IEnumerable<LawyerDto>> GetLawyers()
        {
            logger.LogInformation("Getting lawyers (with love)");

            var lawyers = await lawyersRepo.GetLawyers();
            var lawyersDtos = mapper.Map<IEnumerable<LawyerDto>>(lawyers);

            return lawyersDtos;
        }

        public async Task<LawyerDto?> GetLawyer(int id)
        {
            logger.LogInformation("Getting lawyer (with love)");

            var lawyer = await lawyersRepo.GetLawyer(id);
            var lawyerDto = mapper.Map<LawyerDto?>(lawyer);

            return lawyerDto;
        }

        public async Task<bool> DeleteLawyer(int id)
        {
            logger.LogInformation("deleting lawyer (with love)");

            return await lawyersRepo.DeleteLawyer(id);
           
        }

        public async Task<int> CreateLawyer(LawyerDto lawyerDto)
        {
            logger.LogInformation("Creating lawyer (with love)");
            var lawyer = mapper.Map<Lawyer>(lawyerDto);
            var id = await lawyersRepo.CreateLawyer(lawyer);
            return id;
        }
        public async Task<int> UpdateLawyer(LawyerDto lawyerDto)
        {
            logger.LogInformation("updating lawyer (with love)");

            var lawyer = mapper.Map<Lawyer>(lawyerDto);
            int id = await lawyersRepo.UpdateLawyer(lawyer);
            return id;
        }
    }
}
