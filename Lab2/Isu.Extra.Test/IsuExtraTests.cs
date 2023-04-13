using Isu.Extra.Entities.Faculty;
using Isu.Extra.Entities.Lessons;
using Isu.Extra.Entities.Student;
using Isu.Extra.Service;
using Xunit;
namespace Isu.Extra.Test
{
    public class IsuExtraTests
    {
        private IsExtraService _isuExtra = new IsExtraService();

        [Fact]
        public void AddNewOgnp()
        {
            var newOgnp = new Ognp("Programming", 1, "ITiP");
            _isuExtra.AddOgnp(newOgnp);
            Assert.Contains(newOgnp, _isuExtra.GetOgnpList());
        }

        [Fact]
        public void AddStudentToOgnp()
        {
            var newLesson1 = new Lessons(1, 228, "Petrov");
            var newSceduleForGroup = new Schedule();
            var newSceduleForFlow = new Schedule();
            var newGroup = new GradeGroup("Bio", newSceduleForGroup, 15, 30, "m31111");
            var newStudent = new GradeStudent("Dani", 123, newGroup);
            var newOgnp = new Ognp("Programming", 1, "ITiP");
            var newFlow = new Flow(newOgnp, newSceduleForFlow);
            _isuExtra.AddFlow(newOgnp, newFlow);
            _isuExtra.AddStudentToOgnp(newOgnp, newFlow, newStudent);
            Assert.Contains(newFlow, newOgnp.GetFlowList());
            Assert.Contains(newStudent, newFlow.GetStudentsListOnFlow());
        }

        [Fact]
        public void RemoveFromOgnp()
        {
            var flowList = new List<Flow>();
            var newSceduleForGroup = new Schedule();
            var newSceduleForFlow = new Schedule();
            var newGroup = new GradeGroup("Bio", newSceduleForGroup, 15, 30, "m31111");
            var newOgnp = new Ognp("Programming", 1, "ITiP");
            var newFlow1 = new Flow(newOgnp, newSceduleForFlow);
            var newStudent1 = new GradeStudent("Dani", 111, newGroup);
            _isuExtra.AddFlow(newOgnp, newFlow1);
            _isuExtra.AddStudentToOgnp(newOgnp, newFlow1, newStudent1);
            Assert.Contains(newStudent1, newFlow1.GetStudentsListOnFlow());
            _isuExtra.EscapeFromOgnp(newStudent1, newOgnp, newFlow1);
            int a = flowList.Count;
            Assert.Equal(0, a);
        }

        [Fact]
        public void GetFlows()
        {
            var newSceduleForFlow = new Schedule();
            var flowList = new List<Flow>();
            var newOgnp = new Ognp("Programming", 1, "ITiP");
            var newFlow1 = new Flow(newOgnp, newSceduleForFlow);
            var newFlow2 = new Flow(newOgnp, newSceduleForFlow);
            var newFlow3 = new Flow(newOgnp, newSceduleForFlow);
            _isuExtra.AddFlow(newOgnp, newFlow1);
            _isuExtra.AddFlow(newOgnp, newFlow2);
            _isuExtra.AddFlow(newOgnp, newFlow3);
            flowList = _isuExtra.GetOgnpsFlows(newOgnp);
            Assert.Contains(newFlow1, flowList);
            Assert.Contains(newFlow2, flowList);
            Assert.Contains(newFlow3, flowList);
        }

        [Fact]
        public void GetStudentsList()
        {
            var newSceduleForFlow = new Schedule();
            var studList = new List<GradeStudent>();
            var newGroup = new GradeGroup("Bio", newSceduleForFlow, 15, 30, "m31111");
            var newOgnp = new Ognp("Programming", 1, "ITiP");
            var newFlow1 = new Flow(newOgnp, newSceduleForFlow);
            _isuExtra.AddFlow(newOgnp, newFlow1);
            var newStudent1 = new GradeStudent("Dani", 111, newGroup);
            var newStudent2 = new GradeStudent("Vani", 222, newGroup);
            var newStudent3 = new GradeStudent("Rani", 333, newGroup);
            _isuExtra.AddStudentToOgnp(newOgnp, newFlow1, newStudent1);
            _isuExtra.AddStudentToOgnp(newOgnp, newFlow1, newStudent2);
            _isuExtra.AddStudentToOgnp(newOgnp, newFlow1, newStudent3);
            studList = _isuExtra.GetStudentsFromOgnpFlow(newFlow1);
            int a = studList.Count;
            Assert.Equal(3, a);
        }

        [Fact]
        public void GetListWithZeroOgnp()
        {
            var newSceduleForFlow = new Schedule();
            var studList = new List<GradeStudent>();
            var newGroup = new GradeGroup("Biology", newSceduleForFlow, 15, 30, "m31111");
            var newStudent1 = new GradeStudent("Dani", 111, newGroup);
            var newStudent2 = new GradeStudent("Zani", 222, newGroup);
            var newStudent3 = new GradeStudent("Mani", 333, newGroup);
            _isuExtra.AddGradeStudent(newStudent1, newGroup);
            _isuExtra.AddGradeStudent(newStudent2, newGroup);
            _isuExtra.AddGradeStudent(newStudent3, newGroup);
            studList = _isuExtra.GetStudentsWithZeroOgnp(newGroup);
            Assert.Contains(newStudent1, studList);
            Assert.Contains(newStudent2, studList);
            Assert.Contains(newStudent3, studList);
        }
    }
}