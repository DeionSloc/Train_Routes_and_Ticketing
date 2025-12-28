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
    private static double Tax = 0.088;
    public string ticketNumber { get; }
    public double Price { get; set; }
    public string Origin { get; set; }
    public string Destination { get; set; }
    public string TravelClass { get; set; }
    public double TotalAmount { get; set; }
    public double SalesPrice { get; set; }
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

    public double purchaseTicket(DateTime date)
    {

        travelClass.Add("Coach", 450.00);
        travelClass.Add("Business", 675.00);
        travelClass.Add("Premium", 900.00);
        travelClass.Add("Roomette", 1325.00);
        travelClass.Add("Room", 1750.00);
        travelClass.Add("Family Room", 2175.00);

        foreach(var (key, value) in travelClass)
        {
            string selection = key;
            double price = value;

            if (selection == TravelClass)
            {
                return price;
            }
            
            Price = price;
            double tax = Price * Tax;
            tax = Math.Round(tax, 2);
            Tax = tax;
            double totalAmount = Price + tax;
            TotalAmount = Math.Round(totalAmount, 2);
            break;
        }

        // if(TravelClass == "Coach")
        // {
        //     double coachPrice = travelClass["Coach"];
        //     Price = coachPrice;
        //     double coachTax = Price * Tax;
        //     coachTax = Math.Round(coachTax, 2);
        //     Tax = coachTax;
        //     double totalAmount = Price + coachTax;
        //     TotalAmount = Math.Round(totalAmount, 2);
        // }
        
        // else if(TravelClass == "Business")
        // {
        //     double businessPrice = travelClass["Business"];
        //     Price = businessPrice;
        //     double businessTax = Price * Tax;
        //     businessTax = Math.Round(businessTax, 2);
        //     Tax = businessTax;
        //     double totalAmount = Price + businessTax;
        //     TotalAmount = Math.Round(totalAmount, 2);
        // }

        // else if(TravelClass == "Premium")
        // {
        //     double premiumPrice = travelClass["Premium"];
        //     Price = premiumPrice;
        //     double premiumTax = Price * Tax;
        //     premiumTax = Math.Round(premiumTax, 2);
        //     Tax = premiumTax;
        //     double totalAmount = Price + premiumTax;
        //     TotalAmount = Math.Round(totalAmount, 2);
        // }

        //  else if(TravelClass == "Roomette")
        // {
        //     double roomettePrice = travelClass["Roomette"];
        //     Price = roomettePrice;
        //     double roometteTax = Price * Tax;
        //     roometteTax = Math.Round(roometteTax, 2);
        //     Tax = roometteTax;
        //     double totalAmount = Price + roometteTax;
        //     TotalAmount = Math.Round(totalAmount, 2);
        // }

        //  else if(TravelClass == "Room")
        // {
        //     double roomPrice = travelClass["Room"];
        //     Price = roomPrice;
        //     double roomTax = Price * Tax;
        //     roomTax = Math.Round(roomTax, 2);
        //     Tax = roomTax;
        //     double totalAmount = Price + roomTax;
        //     TotalAmount = Math.Round(totalAmount, 2);
        // }

        // else
        // {
        //     double familyPrice = travelClass["Family Room"];
        //     Price = familyPrice;
        //     double familyTax = Price * Tax;
        //     familyTax = Math.Round(familyTax, 2);
        //     Tax = familyTax;
        //     double totalAmount = Price + familyTax;
        //     TotalAmount = Math.Round(totalAmount, 2);
        // }

        var receipt = new Receipt(Price, Tax, Origin, Destination, TravelClass, date);
        _allReceipts.Add(receipt);
        return TotalAmount;
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