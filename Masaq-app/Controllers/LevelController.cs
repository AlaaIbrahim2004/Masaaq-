using BusinessAccessLayes.ServiceManagers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.DataTransferObjects.Level;

namespace Masaq_app.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LevelController(IServiceManager _serviceManager) : ControllerBase
    {
       [HttpGet("GetAllLevels")]
       public async Task<ActionResult<List<LevelDto>>> GetAllLevels()
        {
            var levels = await _serviceManager.LevelService.GetAllLevels();
            return Ok(levels);
        }



        [HttpGet("Level/{id:int}")]
        public async Task<ActionResult<LevelDto>> GetLevelById(int id)
        {
            var level = await _serviceManager.LevelService.GetLevelById(id);
            return Ok(level);
        }


        [HttpPost("CreateLevel")]
        public async Task<ActionResult<CreateOrUpdateLevelDto>> CreateLevel(CreateOrUpdateLevelDto level)
        {
            var Createdlevel = await _serviceManager.LevelService.CreateLevel(level);
            return Ok(Createdlevel);
        }


        [HttpPut("UpdateLevel")]
        public async Task<ActionResult<CreateOrUpdateLevelDto>> UpdateLevel([FromForm]CreateOrUpdateLevelDto level , int id)
        {
            var updatedlevel = await _serviceManager.LevelService.UpdateLevel(level, id);
            return Ok(updatedlevel);
        }


        [HttpDelete("DeleteLevel")]

        public async Task<bool> DeleteLevel(int id)
        {
           return  await _serviceManager.LevelService.DeleteLevel(id);
        }
 


    }
}
