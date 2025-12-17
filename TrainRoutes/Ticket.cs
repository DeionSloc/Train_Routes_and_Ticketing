using System.Text.RegularExpressions;
using Locomotive;

public class Ticket
{
    private static int s_ticketNumber = 0000000000;
    private static double Tax = 0.088;
    public string ticketNumber { get; }
    public double Price { get; set; }
    public string Origin { get; set; }
    public string Destination { get; set; }
    public string TravelClass { get; set; }
    public double TotalAmount { get; set; }
    public Dictionary<string, double> travelClass = new Dictionary<string, double>();

    public Ticket(string origin, string destination, string travelClass)
    {
        Origin = origin;
        Destination = destination;
        TravelClass = travelClass;
        ticketNumber = s_ticketNumber.ToString();
        s_ticketNumber++;
    }

    private List<Receipt> _allReceipts = new List<Receipt>();

    public void purchaseTicket(DateTime date)
    {
        double price = 0;
        travelClass.Add("Coach", 450.00);
        travelClass.Add("Business", 675.00);
        travelClass.Add("Premium", 900.00);
        travelClass.Add("Roomette", 1325.00);
        travelClass.Add("Room", 1750.00);
        travelClass.Add("Family Room", 2175.00);

        // if (travelClass.ContainsKey("Coach"))
        // {
        //     price = Convert.ToDouble(travelClass.Values);
        // }

        try
        {
            Console.WriteLine("value = {0}.",
            travelClass["Coach"]);
            Console.WriteLine("value = {0}.",
            travelClass["Business"]);
            Console.WriteLine("value = {0}.",
            travelClass["Premium"]);
            Console.WriteLine("value = {0}.",
            travelClass["Roomette"]);
            Console.WriteLine("value = {0}.",
            travelClass["Room"]);
            Console.WriteLine("value = {0}.",
            travelClass["Family Room"]);
        }
        catch(KeyNotFoundException)
        {
            Console.WriteLine("Value not found");
        }

        Price = price;
        double tax = Price * Tax;
        tax = Math.Round(tax, 2);
        double totalAmount = Price + tax;
        TotalAmount = Math.Round(totalAmount, 2);
        if(price <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(price), "Ticket price can't be empty");
        }

        var receipt = new Receipt(price, tax, Origin, Destination, TravelClass, date);
        _allReceipts.Add(receipt);
    }

    public string getReceipt()
    {
        var report = new System.Text.StringBuilder();
        double price = 0;
        report.AppendLine("Price\tTax\tTotal\tOrigin\t\t\tStop\t\tTravel Class\tDate");
        foreach(var item in _allReceipts)
        {
            report.AppendLine($"{item.Price}\t{item.Tax}\t{TotalAmount}\t{item.Origin}\t{item.Destination}\t{item.TravelClass}\t{item.date.ToShortDateString()}");
        }

        return report.ToString();
    }
}