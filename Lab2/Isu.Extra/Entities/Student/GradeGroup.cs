using System.Text.RegularExpressions;

using Isu.Extra.Entities.Lessons;

namespace Isu.Extra.Entities.Student;

public class GradeGroup
{
    private readonly List<GradeStudent> _newGroupList = new List<GradeStudent>();
    private string _faculty;
    public GradeGroup(string faculty, Schedule schedule, int groupsize, int maxgroupsize, string groupname)
        /*: base(groupsize, maxgroupsize, groupname)*/
    {
        _faculty = faculty;
        GetSchedule = schedule;
    }

    public Schedule GetSchedule { get; set; }

    public string GetFacultyName()
    {
        return _faculty;
    }

    public void AddStudentToTheGroup(GradeStudent newSudent)
    {
        _newGroupList.Add(newSudent);
    }

    public List<GradeStudent> GetStudentsList()
    {
        return _newGroupList;
    }
}