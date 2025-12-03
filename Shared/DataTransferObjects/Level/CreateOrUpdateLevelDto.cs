using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.Level
{
    public class CreateOrUpdateLevelDto
    {
        public int LevelNumber { get; set; }
        public int NumberOfStudents { get; set; }
        public string AcademicYear { get; set; }
        public string? name { get; set; }

        public IFormFile? PicUrl { get; set; }
        public string? Description { get; set; }
    }
}
