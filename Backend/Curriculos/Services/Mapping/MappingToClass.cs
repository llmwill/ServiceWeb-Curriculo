using Curriculos.DTOs;
using Curriculos.Models;

namespace Curriculos.Services.Mapping
{
    public class MappingToClass
    {
        public Curriculum DTOToClass(CurriculumDTO dto)
        {
            return new Curriculum
            {
                Name = dto.Name,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                Formation = dto.Formation,
            };
        }
    }
}
