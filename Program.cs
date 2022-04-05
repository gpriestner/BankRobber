using BankRobber;

public class Program
{
    private static List<Journey> journeys = new List<Journey>();

    public static void Main()
    {
        var nodes = new Nodes();

        foreach (var node in nodes.Items) Try(new Nodes(node));

        //foreach (var journey in journeys) Console.WriteLine(journey);
        Console.WriteLine($"Total journeys: {journeys.Count}");

        var highest = journeys.MaxBy(j => j.Total);
        Console.WriteLine(highest);
    }

    public static void Try(Nodes nodes)
    {
        var journey = new Journey(nodes);
        if (journey.Distance <= 20d) journeys.Add(journey);

        var otherNodes = new Nodes();
        otherNodes.RemoveNodes(nodes);

        foreach (var node in otherNodes.Items)
        {
            var newNodes = nodes.Clone();
            newNodes.AddNode(node);
            Try(newNodes);
        }
    }
}