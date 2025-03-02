using Curriculos.DTOs;
using Curriculos.Models;

namespace Curriculos.Services
{
    public interface ICurriculumService
    {
        public Task<List<Curriculum>> GetAllAsync();
        public Task<Curriculum> GetByIdAsync(int id);
        public Task PostAsync(CurriculumDTO curriculum);
        public Task<Curriculum> UpdateAsync(CurriculumDTO curriculum, int id);
        public Task<bool> DeleteAsync(int id);
    }
}
