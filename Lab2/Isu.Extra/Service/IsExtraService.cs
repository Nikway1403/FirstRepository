using Isu.Extra.Entities.Faculty;
using Isu.Extra.Entities.Lessons;
using Isu.Extra.Entities.Student;
using Isu.Extra.Exceptions;

namespace Isu.Extra.Service;

public class IsExtraService : IIsExtraService
{
    private List<Ognp> _ognps = new List<Ognp>();
    private List<GradeGroup> _groups = new List<GradeGroup>();

    public void AddGradeGroup(GradeGroup group)
    {
        _groups.Add(group);
    }

    public void AddGradeStudent(GradeStudent newStudent, GradeGroup group)
    {
        group.AddStudentToTheGroup(newStudent);
    }

    public List<Ognp> GetOgnpList()
    {
        return _ognps;
    }

    public void AddFlow(Ognp ognp, Flow newflow)
    {
      ognp.CreatingFlow(newflow);
    }

    public void AddOgnp(Ognp ognp)
    {
        if (_ognps.Contains(ognp))
        {
            throw new IsuExeption("This ognp is already exist");
        }

        _ognps.Add(ognp);
    }

    public void AddStudentToOgnp(Ognp ognp, Flow flow, GradeStudent newStudent)
    {
        if (ognp.GetFaculty == newStudent.GetStudentGroup().GetFacultyName())
        {
            throw new IsuExeption("Cannot to add student to his faculty ognp");
        }

        CheckSchedule(newStudent.GetStudentGroup(), flow);
        flow.GetStudentsListOnFlow().Add(newStudent);
        newStudent.AddToOgnpFlow(ognp);
    }

    public List<Flow> GetOgnpsFlows(Ognp ognpToFind)
    {
        return ognpToFind.GetFlowList();
    }

    public List<GradeStudent> GetStudentsFromOgnpFlow(Flow flowToFind)
    {
        return flowToFind.GetStudentsListOnFlow();
    }

    public List<GradeStudent> GetStudentsWithZeroOgnp(GradeGroup group)
    {
        var zeroOgnpList = new List<GradeStudent>();
        foreach (GradeStudent student in group.GetStudentsList())
        {
            if (student.CheckIsStudentInOgnp() == false)
            {
                zeroOgnpList.Add(student);
            }
        }

        return zeroOgnpList;
    }

    public void EscapeFromOgnp(GradeStudent student, Ognp ognp, Flow flow)
    {
        student.EscapeFromOgnp(ognp);
        flow.GetStudentsListOnFlow().Remove(student);
    }

    public void AddStudentToGroup(GradeStudent newStudent, GradeGroup group)
    {
        group.GetStudentsList().Add(newStudent);
    }

    /////////////////////////////////////////////////////////////////////////////////////////////////////
    public void AddNewLessonToGroup(Lessons newLesson, int weekday, GradeGroup group)
    {
        group.GetSchedule.AddLesson(weekday, newLesson);
    }

    public void AddNewLessonToFlow(Flow flow, int weekday, Lessons newLesson)
    {
        flow.AddLesson(weekday, newLesson);
    }

    public void CheckSchedule(GradeGroup group, Flow flow)
    {
        foreach (var schedule in flow.GetFlowLessons().GetSchedule())
        {
            var lessonsInGroup = group.GetSchedule.GetSchedule()[schedule.Key];
            foreach (var lessons in schedule.Value)
            {
                foreach (var lessonGroup in lessonsInGroup)
                {
                    if (lessons.LessonNumber == lessonGroup.LessonNumber)
                    {
                        throw new IsuExeption("Lessons intersect");
                    }
                }
            }
        }
    }
}