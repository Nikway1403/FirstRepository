namespace Isu.Extra.Entities.Lessons;

public class Lessons
{
    public Lessons(int lessonNumber, int classroom, string professorName)
    {
        LessonNumber = lessonNumber;
        ClassRoomNumber = classroom;
        ProfessorName = professorName;
    }

    public int ClassRoomNumber { get; }
    public int LessonNumber { get; }
    public string ProfessorName { get; }
}