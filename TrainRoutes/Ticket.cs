using System.Text.RegularExpressions;
using Locomotive;

public class Ticket
{
    private static int ticketNumber = 0000000000;
    private static double Tax = 0.088;
    public double Price { get; set; }
    public string? Destination { get; set; }
    public string TravelClass { get; set; }
    public double TotalAmount {get; set; }

    public Ticket(string destination, string travelClass)
    {
        Destination = destination;
        TravelClass = travelClass;
        ticketNumber++;
    }

    public void purchaseTicket(double price, DateTime date)
    {
        Price = price;
        double tax = Price * Tax;
        double totalAmount = Price + tax;
        TotalAmount = totalAmount;
        if(price <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(price), "Ticket price can't be empty");
        }
    }
}