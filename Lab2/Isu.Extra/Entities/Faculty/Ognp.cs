using Isu.Extra.Entities.Student;
using Isu.Extra.Exceptions;

namespace Isu.Extra.Entities.Faculty;

public class Ognp
{
    private List<Flow> _flowsList = new List<Flow>();
    private int _number;
    public Ognp(string ognpName, int number, string megaFaculty)
    {
        GetOgnpName = ognpName;
        _number = number;
        GetFaculty = megaFaculty;
    }

    public string GetFaculty { get; }
    public string GetOgnpName { get; }
    public int GetCourseNumber()
    {
        return _number;
    }

    public void CreatingFlow(Flow newFlow)
    {
        if (_flowsList.Contains(newFlow))
        {
            throw new IsuExeption("This flow is already exist");
        }

        _flowsList.Add(newFlow);
    }

    public List<Flow> GetFlowList()
    {
        return _flowsList;
    }
}