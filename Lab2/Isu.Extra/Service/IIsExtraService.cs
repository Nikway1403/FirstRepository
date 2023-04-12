using Isu.Extra.Entities.Faculty;
using Isu.Extra.Entities.Student;

namespace Isu.Extra.Service;

public interface IIsExtraService
{
    public void AddGradeGroup(GradeGroup group);
    public void AddGradeStudent(GradeStudent newStudent, GradeGroup group);
    public List<Ognp> GetOgnpList();
    public void AddFlow(Ognp ognp, Flow newflow);
    public void AddStudentToOgnp(Ognp ognp, Flow flow, GradeStudent newStudent);
}