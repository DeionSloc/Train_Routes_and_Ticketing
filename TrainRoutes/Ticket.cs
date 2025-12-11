using System.Text.RegularExpressions;
using Locomotive;

public class Ticket
{
    private static int s_ticketNumber = 0000000000;
    private static double Tax = 0.088;
    public string ticketNumber { get; }
    public double Price { get; set; }
    public string Destination { get; set; }
    public string TravelClass { get; set; }
    public double TotalAmount {get; set; }

    public Ticket(string destination, string travelClass)
    {
        Destination = destination;
        TravelClass = travelClass;
        ticketNumber = s_ticketNumber.ToString();
        s_ticketNumber++;
    }

    private List<Receipt> _allReceipts = new List<Receipt>();

    public void purchaseTicket(double price, DateTime date)
    {
        Price = price;
        double tax = Price * Tax;
        tax = Math.Round(tax, 2);
        double totalAmount = Price + tax;
        TotalAmount = Math.Round(totalAmount, 2);
        if(price <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(price), "Ticket price can't be empty");
        }

        var receipt = new Receipt(price, tax, Destination, TravelClass, date);
        _allReceipts.Add(receipt);
    }

    public string getReceipt()
    {
        var report = new System.Text.StringBuilder();
        double price = 0;
        report.AppendLine("Price\tTax\tTotal\tStop\tTravel Class\tDate");
        foreach(var item in _allReceipts)
        {
            report.AppendLine($"{TotalAmount}\t{item.Tax}\t{item.Price}\t{item.Destination}\t{item.TravelClass}\t{item.date.ToShortDateString()}");
        }

        return report.ToString();
    }
}