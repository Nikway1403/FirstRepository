using Isu.Entities;
using Isu.Exceptions;
using Isu.Models;

namespace Isu.Services;

public class IsuService : IIsuService
{
    private int startCountStud = 0;
    private int maxCountStud = 3;
    private List<Group> groupList = new List<Group>();
    private List<Group> newlist = new List<Group>();
    private int StudId { get;  set; } = 100000;

    public Group AddGroup(string name)
    {
        var nameGroup = new GroupName(name);
        Group group = new Group(startCountStud, maxCountStud, nameGroup.StudGroupName);
        if (groupList.Contains(group))
        {
            throw new GroupExistException("Group already exist");
        }

        groupList.Add(group);
        return group;
    }

    public Student AddStudent(Group group, string name)
    {
        Student student = new Student(name, StudId, new GroupName(group.Groupname));
        group.AddStudent(student);
        return student;
    }

    public Student GetStudent(int id)
    {
        foreach (var student in from @group in groupList from student in @group.StudentList where id == student.StudId select student)
        {
            return student;
        }

        throw new IdExistingException();
    }

    public Student FindStudent(int id)
    {
        foreach (var student in from @group in groupList from student in @group.StudentList where id == student.StudId select student)
        {
            return student;
        }

        throw new IdExistingException();
    }

    public List<Student> FindStudents(GroupName groupName)
    {
        foreach (var group in groupList)
        {
            if (groupName.StudGroupName == group.Groupname)
            {
                return group.StudentList;
            }
        }

        throw new WrongGroupNameException();
    }

    public List<Student> FindStudents(CourseNumber courseNumber)
    {
        foreach (var group in groupList.Where(group => group.Coursenumber == courseNumber.StudCourseNumber))
        {
            return group.StudentList;
        }

        throw new CourseNumberException();
    }

    public Group FindGroup(GroupName groupName)
    {
        foreach (var group in groupList.Where(group => groupName.StudGroupName == group.Groupname))
        {
            return group;
        }

        throw new GroupException();
    }

    public List<Group> FindGroups(CourseNumber courseNumber)
    {
        foreach (var group in groupList.Where(group => group.Coursenumber == courseNumber.StudCourseNumber))
        {
            newlist.Add(group);
        }

        return newlist;
    }

    public void ChangeStudentGroup(Student student, Group newGroup)
    {
        newGroup.AddStudent(student);
        foreach (var group in groupList)
        {
            if (group.Groupname == student.GroupofName.StudGroupName)
            {
                group.KickStudent(student);
            }
        }

        student.ChangeGroup(newGroup.Groupname);
    }
}