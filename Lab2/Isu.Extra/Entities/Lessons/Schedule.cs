using Isu.Extra.Exceptions;

namespace Isu.Extra.Entities.Lessons;

public class Schedule
{
   private Dictionary<int, List<Lessons>> _schedule = new Dictionary<int, List<Lessons>>();

   public void AddLesson(int weekday, Lessons newLesson)
   {
      if (weekday > 7 || weekday <= 0)
      {
         throw new IsuExeption("Your weekday is unavailable");
      }

      _schedule[weekday].Add(newLesson);
   }

   public Dictionary<int, List<Lessons>> GetSchedule()
   {
      return _schedule;
   }
}