using System.Formats.Asn1;
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
    public double CoachPrice { get; set; }
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
        
        if(travelClass.ContainsKey("Coach"))
        {
            price = travelClass["Coach"];
            Price = price;
            double tax = Price * Tax;
            tax = Math.Round(tax, 2);
            double totalAmount = Price + tax;
            TotalAmount = Math.Round(totalAmount, 2);
        }
        else if(travelClass.ContainsKey("Premium"))
        {
            price = travelClass["Premium"];
            Price = price;
            double tax = Price * Tax;
            tax = Math.Round(tax, 2);
            double totalAmount = Price + tax;
            TotalAmount = Math.Round(totalAmount, 2);
        }
        else if(travelClass.ContainsKey("Roomette"))
        {
            price = travelClass["Roomette"];
            Price = price;
            double tax = Price * Tax;
            tax = Math.Round(tax, 2);
            double totalAmount = Price + tax;
            TotalAmount = Math.Round(totalAmount, 2);
        }
        else if(travelClass.ContainsKey("Roomette"))
        {
            price = travelClass["Roomette"];
            Price = price;
            double tax = Price * Tax;
            tax = Math.Round(tax, 2);
            double totalAmount = Price + tax;
            TotalAmount = Math.Round(totalAmount, 2);
        }
         else if(travelClass.ContainsKey("Room"))
        {
            price = travelClass["Room"];
            Price = price;
            double tax = Price * Tax;
            tax = Math.Round(tax, 2);
            double totalAmount = Price + tax;
            TotalAmount = Math.Round(totalAmount, 2);
        }
         else if(travelClass.ContainsKey("Family Room"))
        {
            price = travelClass["Family Room"];
            Price = price;
            double tax = Price * Tax;
            tax = Math.Round(tax, 2);
            double totalAmount = Price + tax;
            TotalAmount = Math.Round(totalAmount, 2);
        }
        else
        {
            throw new ArgumentOutOfRangeException(nameof(price), "Ticket price can't be empty");
        }


        var receipt = new Receipt(price, Tax, Origin, Destination, TravelClass, date);
        _allReceipts.Add(receipt);
    }

    public string getReceipt()
    {
        var report = new System.Text.StringBuilder();
        report.AppendLine("Price\tTax\tTotal\tOrigin\t\t\tStop\t\tTravel Class\tDate");
        foreach(var item in _allReceipts)
        {
            report.AppendLine($"{item.Price}\t{item.Tax}\t{TotalAmount}\t{item.Origin}\t{item.Destination}\t{item.TravelClass}\t{item.date.ToShortDateString()}");
        }

        return report.ToString();
    }
}