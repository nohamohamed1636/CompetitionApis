using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DtoModels.Dtos
{
    public class CheckAttendance
    {
        public bool Checked { get; set; }
        public string Errors { get; set; }
    }
}
