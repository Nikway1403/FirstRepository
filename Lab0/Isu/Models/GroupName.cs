using System.Globalization;
using Isu.Exceptions;

namespace Isu.Models;

public class GroupName
{
    private const byte Mincourse = 0;
    private const byte Maxcourse = 4;
    private const byte MaxFlow = 5;
    private const byte MinFlow = 1;
    private const byte MaxDirection = 5;
    private const byte MinDirection = 1;
    private const byte MaxGroup = 9;
    private const byte MinGroup = 1;

    // В моем Ису есть только 5 поток
    // А также 3 цифра это направление => [1-8]
    // Минимальный номер группы может быть 1, а максимальный 9
    public GroupName(string groupname)
    {
        if (Convert.ToInt16(groupname.Substring(1, 1)) < MinFlow || Convert.ToInt16(groupname.Substring(1, 1)) > MaxFlow)
        {
            throw new WrongGroupNameException("Неверно задано поток группы");
        }

        if (Convert.ToInt16(groupname.Substring(2, 1)) < Mincourse || Convert.ToInt16(groupname.Substring(2, 1)) > Maxcourse)
        {
            throw new WrongGroupNameException("Неверно задан курс группы");
        }

        if (Convert.ToInt16(groupname.Substring(3, 1)) < MinDirection || Convert.ToInt16(groupname.Substring(3, 1)) > MaxDirection)
        {
            throw new WrongGroupNameException("Неверно задано направление группы");
        }

        if (Convert.ToInt16(groupname.Substring(4, 1)) < MinGroup || Convert.ToInt16(groupname.Substring(4, 1)) > MaxGroup)
        {
            throw new WrongGroupNameException("Неверно задан номер группы");
        }

        StudGroupName = groupname;
    }

    public string StudGroupName { get; set; }
}
//// Группа задается номером курса B[1-5][1-4][1-5][1-9]