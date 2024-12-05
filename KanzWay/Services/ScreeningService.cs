using KanzWay.Custom;

namespace KanzWay.Services;
public class ScreeningService : IScreeningService
{
    public List<string> GetScreeningList(int number)
    {
        if (number <= 0)
            throw new InvalidNumberException("Number Must Start 1");

        var screeningList = Enumerable.Range(1, number)
            .Select(i =>
                (i % 3 == 0 && i % 5 == 0) ? "KanzWay" :
                (i % 3 == 0) ? "Kanz" :
                (i % 5 == 0) ? "Way" :
                i.ToString()
            ).ToList();
        return screeningList;
    }

}

