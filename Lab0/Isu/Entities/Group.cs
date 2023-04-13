using Isu.Exceptions;
using Isu.Models;

namespace Isu.Entities;

public class Group
{
    public Group(int groupsize, int maxgroupsize, string groupname)
    {
        Maxgroupsize = maxgroupsize;
        GroupSize = groupsize;
        Groupname = groupname;
        Coursenumber = Convert.ToInt16(groupname.Substring(2, 1));
        StudentList = new List<Student>();
        if (maxgroupsize - groupsize <= 0)
        {
            throw new GroupException("Группа уже полная");
        }

        if (groupname == null)
        {
            throw new WrongGroupNameException("Группа должна быть названа");
        }
    }

    public List<Student> StudentList { get;  }

    public int Maxgroupsize { get; }
    public int GroupSize { get; }
    public string Groupname { get; }
    public int Coursenumber { get; }

    public void AddStudent(Student student)
    {
        if (StudentList.Count == Maxgroupsize)
        {
            throw new MaximumStudException("Максимально допустимое количество студентов в группе уже достигнуто");
        }

        if (!StudentList.Contains(student))
        {
            StudentList.Add(student);
        }
        else
        {
            throw new AddToGroupException("Студент уже принадлежит группе");
        }
    }

    public void KickStudent(Student student)
    {
        if (!StudentList.Contains(student))
        {
            throw new KickFromGroupException("Студент не числится ни в одной группе чтобы его убрать из нее");
        }
        else
        {
            StudentList.Remove(student);
        }
    }
}