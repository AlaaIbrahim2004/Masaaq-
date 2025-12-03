using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects.Level
{
    public class LevelDto
    {
        public int Id { get; set; }
        public int LevelNumber { get; set; }
        public int NumberOfStudents { get; set; }
        public string AcademicYear { get; set; }
        public string? name { get; set; }

        public string? PicUrl { get; set; }
    }
}
