using Isu.Exceptions;
using Isu.Models;

namespace Isu.Entities;

public class Student
{
    private const int MaxStudId = 999999;
    private const int MinStudId = 100000;

    public Student(string name, int studId, GroupName groupName)
    {
        if (studId < MinStudId || studId > MaxStudId)
        {
            throw new IdException();
        }

        if (name == null)
        {
            throw new WrongStudNameException();
        }

        Name = name;
        StudId = studId;
        GroupofName = groupName;
    }

    public GroupName GroupofName { get;  }

    public string Name
    {
        get;
    }

    public int StudId { get; }

    public void ChangeGroup(string name)
    {
        GroupofName.StudGroupName = name;
    }
}