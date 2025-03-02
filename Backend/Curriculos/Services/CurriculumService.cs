using Curriculos.Context;
using Curriculos.DTOs;
using Curriculos.Models;
using Curriculos.Services.Mapping;
using Microsoft.EntityFrameworkCore;

namespace Curriculos.Services
{
    public class CurriculumService : ICurriculumService
    {
        private readonly AppDbContext _context;
        private readonly MappingToClass _mapper;
        public CurriculumService(AppDbContext context)
        {
            _context = context;
            _mapper = new MappingToClass();
        }
        public async Task<List<Curriculum>> GetAllAsync()
        {
            return await _context.Curriculums.ToListAsync();
        }
        public async Task<Curriculum> GetByIdAsync(int id)
        {
            return await _context.Curriculums.FirstOrDefaultAsync(c => c.Id.Equals(id));
        }
        public async Task PostAsync(CurriculumDTO curriculum)
        {
            var curriculumMapped = _mapper.DTOToClass(curriculum);

            await _context.Curriculums.AddAsync(curriculumMapped);

            await _context.SaveChangesAsync();
        }
        public async Task<Curriculum> UpdateAsync(CurriculumDTO curriculum, int id)
        {
            var curriculumMapped = _mapper.DTOToClass(curriculum);

            curriculumMapped.Id = id;

            _context.Update(curriculumMapped);

            await _context.SaveChangesAsync();

            return curriculumMapped;
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var curriculum = await GetByIdAsync(id);

            if (curriculum is null) return false;

            _context.Remove(curriculum);

            await _context.SaveChangesAsync();

            return true;
        }

    }
}
