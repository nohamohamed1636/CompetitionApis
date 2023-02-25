using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DtoModels.Dtos
{
    public class StudentAttendanceList
    {
        public int AllCount { get; set; }
        public int StartedCount { get; set; }
        public List<string> StudentIDs { get; set; }
        public string Errors { get; set; }
    }
}
