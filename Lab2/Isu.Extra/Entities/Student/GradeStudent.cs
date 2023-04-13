using Isu.Extra.Entities.Faculty;
using Isu.Extra.Exceptions;

namespace Isu.Extra.Entities.Student;

public class GradeStudent
{
    private const int StudentMaxCountOfOgnp = 2;
    private List<Ognp> listWithStudentOgnps = new List<Ognp>();
    private string _name;
    private int _id;
    private GradeGroup _group;

    public GradeStudent(string name, int id, GradeGroup group)
    {
        _name = name;
        _id = id;
        _group = group;
    }

    public int GetStudentId()
    {
        return _id;
    }

    public string GetStudentName()
    {
        return _name;
    }

    public GradeGroup GetStudentGroup()
    {
        return _group;
    }

    public void AddToOgnpFlow(Ognp newOgnp)
    {
        if (listWithStudentOgnps.Count == StudentMaxCountOfOgnp)
        {
            throw new IsuExeption("Student has too many ognps");
        }

        listWithStudentOgnps.Add(newOgnp);
    }

    public void EscapeFromOgnp(Ognp oldOgnp)
    {
        if (!listWithStudentOgnps.Contains(oldOgnp))
        {
            throw new IsuExeption("Student does't study in this ognp");
        }

        listWithStudentOgnps.Remove(oldOgnp);
    }

    public bool CheckIsStudentInOgnp()
    {
        if (listWithStudentOgnps.Count == 0)
        {
            return false;
        }

        return true;
    }
}