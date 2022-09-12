
Console.WriteLine("Hello, World!");
DateTime from = new DateTime(2022, 1, 1);
DateTime to = new DateTime(2020, 12, 30);
Console.WriteLine(IsYearDifference(from ,to, 5));
Console.WriteLine(IsDescriptionSuitable("Cisco*", "www.cisco.com*TRIAL. Cisco"));
var str = "10000000004, 10000000005";
Console.WriteLine("Phones");
Console.WriteLine("10000000004, 10000000005".Trim(' '));
var symbols = String.Join(';', "10000000004, 10000000005".Trim());//.Split(','));
   // string.Join("",
        //"10000000004, 10000000005".Split(default(string[]), StringSplitOptions.RemoveEmptyEntries));
str = str.Trim();
Console.WriteLine(str);
Console.WriteLine(symbols);
Console.WriteLine(String.Join(';', "10000000004, 10000000005".Replace(" ", "").Split(',')));
;//.Trim(',');
static bool IsYearDifference(DateTime from, DateTime to, int maxDayDifference)
{
    Console.WriteLine(Math.Abs(Math.Abs((to.Date - from.Date).Days) - 365));
    return Enumerable.Range(0, maxDayDifference + 1).Contains(Math.Abs(Math.Abs((to.Date - from.Date).Days) - 365));
}
static bool IsDescriptionSuitable(string first, string second)
{
    //String.To
    first = first.ToUpper();
    second = second.ToUpper();
    if (first.Contains(second) || second.Contains(first)) return true;
    string[] elementsFirst = first.Split('*', ' ', '.', ',');
    string[] elementsSecond = second.Split('*', ' ', '.', ',');
    elementsFirst = elementsFirst.Where(el => el.Length > 3).ToArray();
    elementsSecond = elementsSecond.Where(el => el.Length > 3).ToArray();
    Console.WriteLine("First");
    Console.WriteLine(String.Join(' ', elementsFirst));
    Console.WriteLine("Second");
    Console.WriteLine(String.Join(' ', elementsSecond));
    //return elementsFirst.SequenceEqual(elementsSecond);
    return elementsFirst.Intersect(elementsSecond).Any();
    //elementsFirst.Select( el => el.Length > 3);
}