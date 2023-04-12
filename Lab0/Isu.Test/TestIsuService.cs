using Isu.Entities;
using Isu.Exceptions;
using Isu.Models;
using Isu.Services;
using Xunit;

namespace Isu.Test;

public class TestIsuService
{
    private IsuService _service = new ();
    [Fact]
    public void AddStudentToGroup_StudentHasGroupAndGroupContainsStudent()
    {
        Group group = _service.AddGroup("Z3213");
        Student student = _service.AddStudent(group, "Koval");
        Assert.Contains(student, group.StudentList);
        Assert.Equal(student.GroupofName.StudGroupName, group.Groupname);
    }

    [Fact]
    public void ReachMaxStudentPerGroup_ThrowException()
    {
        Group group = _service.AddGroup("m31111");
        Student student1 = _service.AddStudent(group, "Gjora");
        Student student2 = _service.AddStudent(group, "Evga");
        Student student3 = _service.AddStudent(group, "Max");
        Assert.Throws<MaximumStudException>(() => _service.AddStudent(group, "Piter"));
    }

    [Fact]
    public void CreateGroupWithInvalidName_ThrowException()
    {
        Assert.Throws<WrongGroupNameException>(() => _service.AddGroup("999Za999"));
    }

    [Fact]
    public void TransferStudentToAnotherGroup_GroupChanged()
    {
        Group group1 = _service.AddGroup("M21112");
        Group group2 = _service.AddGroup("P32212");
        Student student1 = _service.AddStudent(group1, "Piter");
        _service.ChangeStudentGroup(student1, group2);
        Assert.Equal(student1.GroupofName.StudGroupName, group2.Groupname);
    }
}