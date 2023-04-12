namespace Isu.Exceptions;

public class CourseNumberException : Exception
{
   public CourseNumberException() { }

   public CourseNumberException(string coursenumber)

      : base($"Invalid course number")
   {
   }

   public CourseNumberException(string message, Exception z)
      : base(message, z)
   {
   }
}
