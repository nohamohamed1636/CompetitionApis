using Core.DtoModels.Dtos;
using Core.DtoModels.Requests;
using Core.Models;
using Core.Repositories.Competitions;
using Core.Services.Competitions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Competitions
{
    public class CompetitiontargetService : ICompetitiontargetService
    {
        private readonly ICompetitionTargteRepository _competitionTargteRepository;

        public CompetitiontargetService(ICompetitionTargteRepository competitionTargteRepository)
        {
            _competitionTargteRepository = competitionTargteRepository;
        }

        public async Task<CompetitionData> CreateNewCompetitionTargetForStudent(NewCompetitionTarget NewCompetitionTarget)
        {
            var competition = new CompetitionData();
            var validation = ValidationInsert(NewCompetitionTarget);
            if (validation != "")
            {
                competition.Error = validation;
                return competition;
            }
            var perviousRecord = await _competitionTargteRepository.GetCompetitionTargetByStudentIdAndCompetitionId(NewCompetitionTarget.CompetitionId, NewCompetitionTarget.StudentId);
            if (perviousRecord != null && perviousRecord.Count() > 0) 
            {
                foreach (var item in perviousRecord)
                {
                    item.Deleted = true;
                    await _competitionTargteRepository.SaveChangesAsync();
                }
            }
            var newCompetitiontarget = new CompetitionTarget
            {
                CompetitionId = NewCompetitionTarget.CompetitionId,
                EducationYearClassroomId = NewCompetitionTarget.EducationClassRoomId,
                StudentId = NewCompetitionTarget.StudentId,
                StudentHistoryId = NewCompetitionTarget.StudentHistoryId,
                Deleted = false,
                Degree = 0,
                Solved = false
            };
            var competitionrep = await _competitionTargteRepository.AddNewCompetitionTarget(newCompetitiontarget);
            competition.CompetitionId = competitionrep.Id;
            return competition;

        }
        private string ValidationInsert(NewCompetitionTarget NewCompetitionTarget)
        {
            if (String.IsNullOrEmpty(NewCompetitionTarget.StudentId))
            {
                return "Please insert the student Id";
            }
            else if (NewCompetitionTarget.CompetitionId == default(int))
            {
                return "Please insert the competition id";
            }
            else
            {
                return "";
            }
        }




        public async Task<CompetitionData> CreateNewCompetitionTargetForStudentList(NewCompetitionTargetList NewCompetitionTarget)
        {
            var competition = new CompetitionData();
            
            
            try
            {
                if (NewCompetitionTarget.StudentLists.Count() == default(int))
                {
                    competition.Error = "Please insert at least one student";
                    return competition;
                }
                if (NewCompetitionTarget.CompetitionId == default(int))
                {
                    competition.Error = "Please insert the competition id";
                    return competition;
                }
                foreach (var item in NewCompetitionTarget.StudentLists)
                {
                    var perviousRecord = await _competitionTargteRepository.GetCompetitionTargetByStudentIdAndCompetitionId(NewCompetitionTarget.CompetitionId, item.StudentId);
                    if (perviousRecord != null && perviousRecord.Count() > 0)
                    {
                        foreach (var item1 in perviousRecord)
                        {
                            item1.Deleted = true;
                            await _competitionTargteRepository.SaveChangesAsync();
                        }
                    }
                    var newCompetitiontarget = new CompetitionTarget
                    {
                        CompetitionId = NewCompetitionTarget.CompetitionId,
                        EducationYearClassroomId = item.EducationYearClassroomId,
                        StudentId = item.StudentId,
                        StudentHistoryId = item.Id,
                        Deleted = false,
                        Degree = 0,
                        Solved = false
                    };
                    var competitionrep = await _competitionTargteRepository.AddNewCompetitionTarget(newCompetitiontarget);
                   
                }
                competition.Message = "Saved successfully";
                return competition;
            }
            catch (Exception ex)
            {

                competition.Error = ex.Message;
                return competition;
            }
        }

        public async Task<List<CompetitionStudentIndex>> GetListOfCompetitionStudentIndexUnsolved(string studentId)
        {

            var competitionrep = await _competitionTargteRepository.GetAllCompetitionTargetByStudentIdUnSolved(studentId);
            var res = competitionrep.OrderBy(d => d.Id).Select(j => new CompetitionStudentIndex
            {
                CompetitionId = j.CompetitionId,
                Title = j.Competitions.Title ,
                PublishDate = j.Competitions.PublishDate,
                DelivaryDate = j.DeliveryDate,
                HomeWorkId = j.CompetitionId,
                StartDate = j.StarDate
            });
            return res.ToList();
        }


        public async Task<CheckAttendance> UpdateStartDate(int competitionId,string studentId)
        {

            var checkec = new CheckAttendance();
            try
            {
                var competitiontarget = await _competitionTargteRepository.GetCompetitionTargetByStudentIdAndCompetitionId(competitionId, studentId);
                if (competitiontarget == null)
                {
                    return new CheckAttendance { Checked = false, Errors = "This competition not added that student" };

                }
                else
                {
                    if (competitiontarget.Count() > 0)
                    {
                        var competitionfirst = competitiontarget.FirstOrDefault();
                        if (competitionfirst.Competitions.Published == false)
                        {
                            checkec =  new CheckAttendance { Checked = false, Errors = "you can't update the start date the competition is not published" };
                        }
                        else
                        {
                            competitionfirst.StarDate = DateTime.Now;
                            await _competitionTargteRepository.SaveChangesAsync();
                            checkec = new CheckAttendance { Checked = true, Errors = "" };
                        }
                    }
                }
                return checkec;
            }
            catch (Exception ex)
            {

                return new CheckAttendance { Checked = false, Errors = ex.Message };
            } 
        }
        public async Task<StudentAttendanceList> GetStudentListForTeacher(int competitionId)
        {
            var list = new StudentAttendanceList();
            try
            {
                
                var competitionDetails =await _competitionTargteRepository.GetAllCompetitionTargetByCompetitionIdUnsolved(competitionId);
                if (competitionDetails == null)
                {
                    list.Errors = "not found data";
                }
                else
                {
                    list.AllCount = competitionDetails.Count;
                    var studentList = await _competitionTargteRepository.GetAllCompetitionTargetByCompetitionIdUnsolvedwithStartedDate(competitionId);
                    list.StartedCount = studentList.Count;
                    if (studentList.Count > 0)
                    {
                        foreach (var item in studentList)
                        {
                            list.StudentIDs.Add(item.StudentId);
                        }
                        
                    }
                }
                return list;
            }
            catch (Exception ex)
            {

                return new StudentAttendanceList { Errors = ex.Message };
            }
            
        }

        public async Task<CheckAttendance> CloseCompetitionForStudent(int competitionId)
        {
            var check = new CheckAttendance();
            try
            {
                var getunclosedCompetitiontarget = await _competitionTargteRepository.GetAllCompetitionTargetByCompetitionIdnotClosed(competitionId);
                if (getunclosedCompetitiontarget == null)
                {
                    check = new CheckAttendance { Errors = "not found unclosed competition" };

                }
                else
                {
                    foreach (var item in getunclosedCompetitiontarget)
                    {
                        item.Closed = true;
                        await _competitionTargteRepository.SaveChangesAsync();
                    }
                    check = new CheckAttendance { Checked = true};
                }
                return check;
            }
            catch (Exception ex)
            {

                return new CheckAttendance { Errors = ex.Message };
            }
        }

    }
}
