using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DtoModels.Requests
{
    public class StudentList
    {
        public int Id { get; set; }
        public string StudentId { get; set; }
        public int? EducationYearClassroomId { get; set; }
    }
}
