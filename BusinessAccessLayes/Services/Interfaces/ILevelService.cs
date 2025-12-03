using Shared.DataTransferObjects.Level;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayes.Services.Interfaces
{
    public interface ILevelService
    {
        public Task<CreateOrUpdateLevelDto> UpdateLevel(CreateOrUpdateLevelDto level, int id);
        public Task<LevelDto> GetLevelById(int levelId);
        public Task<List<LevelDto>> GetAllLevels();
        public Task<bool> DeleteLevel(int levelId);

        public Task<CreateOrUpdateLevelDto> CreateLevel(CreateOrUpdateLevelDto level);
    }
}
