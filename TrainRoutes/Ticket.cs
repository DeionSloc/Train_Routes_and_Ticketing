using System.ComponentModel.Design;
using System.Formats.Asn1;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using Locomotive;

public class Ticket
{
    private static int s_ticketNumber = 0000000000;
    private static readonly double Tax = 0.088;
    public string ticketNumber { get; }
    public double Price { get; set; }
    public string Origin { get; set; }
    public string Destination { get; set; }
    public string TravelClass { get; set; }
    public double TotalAmount { get; set; }
    public double SalesPrice { get; set; }
    private List<Receipt> _allReceipts = new List<Receipt>();
    public Dictionary<string, double> travelClass = new Dictionary<string, double>
    {
        {"Coach", 450.00},
        {"Business", 675.00},
        {"Premium", 900.00},
        {"Roomette", 1325.00},
        {"Room", 1750.00},
        {"Family Room", 2175.00},
    };

    public Ticket(string origin, string destination, string travelClass)
    {
        Origin = origin;
        Destination = destination;
        TravelClass = travelClass;
        ticketNumber = s_ticketNumber.ToString();
        s_ticketNumber++;
    }
    public double purchaseTicket(DateTime date)
    {
        if (!travelClass.ContainsKey(TravelClass))
        {
            throw new ArgumentException("Invalid travel class.");
        }            
            Price = travelClass[TravelClass];
            double tax = Math.Round(Price * Tax, 2);
            double totalAmount = Price + tax;
            TotalAmount = Math.Round(totalAmount, 2);
        
        var receipt = new Receipt(Price, tax, Origin, Destination, TravelClass, date);
        _allReceipts.Add(receipt);
        return TotalAmount;
    }

    public string getReceipt()
    {
        var report = new System.Text.StringBuilder();
        report.AppendLine("Price\tTax\tTotal\tOrigin\t\t\tStop\t\t\tTravel Class\tDate");
        foreach(var item in _allReceipts)
        {
            report.AppendLine($"{item.Price}\t{item.tax}\t{TotalAmount}\t{item.Origin}\t\t{item.Destination}\t\t{item.TravelClass}\t{item.date.ToShortDateString()}");
        }

        return report.ToString();
    }
}