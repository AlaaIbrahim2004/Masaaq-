using AutoMapper;
using BusinessAccessLayes.Services.Interfaces;
using BusinessLogic.Services.Interfaces;
using DataAccessLayer.Models.Levels;
using DataAccessLayer.Repositories.UnitOfWork;
using Shared.DataTransferObjects.Level;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAccessLayes.Services.Classes
{
    public class LevelService(IUnitOfWork unitOfWork, IMapper mapper, IAttachmentService _attach) : ILevelService
    {
        public async Task<CreateOrUpdateLevelDto> CreateLevel(CreateOrUpdateLevelDto level)
        {
            var repo = unitOfWork.GetRepository<Level,int>();
            var CreatedLevel = mapper.Map<Level>(level);
            CreatedLevel.PicUrl = _attach.Upload(level.PicUrl, "Levels");
             await repo.AddAsync(CreatedLevel);
            await unitOfWork.SaveChangesAsync();
            return level;
        }

        public async Task<bool> DeleteLevel(int levelId)
        {
            var repo = unitOfWork.GetRepository<Level, int>();
            var level = await repo.GetByIdAsync(levelId);
             repo.Delete(level);
            await unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<List<LevelDto>> GetAllLevels()
        {
            var repo = unitOfWork.GetRepository<Level, int>();
            var levels = await repo.GetAllAsync();
            return mapper.Map<List<LevelDto>>(levels);
        }

        public async Task<LevelDto> GetLevelById(int levelId)
        {
            var repo = unitOfWork.GetRepository<Level, int>();
            var Level = await  repo.GetByIdAsync(levelId)??throw new Exception($"the level with this id {levelId} is not found");

            return mapper.Map<LevelDto>(Level);
        }

        public async Task<CreateOrUpdateLevelDto> UpdateLevel(CreateOrUpdateLevelDto level, int id)
        {
            var repo = unitOfWork.GetRepository<Level, int>();
            var Updatedleve = await repo.GetByIdAsync(id);
            Updatedleve = mapper.Map(level, Updatedleve);
            if (level.PicUrl != null) { 
            Updatedleve.PicUrl = _attach.Upload(level.PicUrl , "Levels");
            }
            repo.Update(Updatedleve);
            await unitOfWork.SaveChangesAsync();
            return level;
        }
    }
}
