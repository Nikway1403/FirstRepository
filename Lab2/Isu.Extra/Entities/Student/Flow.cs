using Isu.Extra.Entities.Faculty;
using Isu.Extra.Entities.Lessons;
using Isu.Extra.Exceptions;

namespace Isu.Extra.Entities.Student;

public class Flow
{
    private const int MaxStudentsInFlow = 30;
    private const int MaxCountsFlows = 9;
    private static int _flowNumber = 1;
    private readonly List<GradeStudent> _flowStudents = new List<GradeStudent>();
    private Schedule _schedule;
    private Ognp _ognp;

    public Flow(Ognp ognp, Schedule flowSchedule)
    {
        _schedule = flowSchedule;
        _ognp = ognp;
        FlowNumber = _flowNumber;
        if (_flowNumber >= MaxCountsFlows)
        {
            throw new IsuExeption("You reached max flow counts");
        }

        _flowNumber++;
    }

    public int FlowNumber { get; }

    public Ognp GetOgnp()
    {
        return _ognp;
    }

    public Schedule GetFlowLessons()
    {
        return _schedule;
    }

    public int GetFlowNumber()
    {
        return _flowNumber;
    }

    public void AddLesson(int weekday, Lessons.Lessons lesson)
    {
        _schedule.AddLesson(weekday, lesson);
    }

    public bool IsFull()
    {
        return _flowStudents.Count == MaxStudentsInFlow;
    }

    public List<GradeStudent> GetStudentsListOnFlow()
    {
        return _flowStudents;
    }
}