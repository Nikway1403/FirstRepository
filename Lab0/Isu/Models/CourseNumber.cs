using Isu.Exceptions;

namespace Isu.Models;

public class CourseNumber
{
    private const byte Mincourse = 0;
    private const byte Maxcourse = 4;
    public CourseNumber(byte coursemumber)
    {
        if (coursemumber <= Mincourse || coursemumber > Maxcourse)
        {
            throw new CourseNumberException("Invalid course number");
        }

        StudCourseNumber = coursemumber;
    }

    public byte StudCourseNumber { get; }
}