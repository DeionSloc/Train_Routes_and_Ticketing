using Locomotive;

var train1 = new RollingStock(60, "Acela", "Jersey Sights");

var ticket1 = new Ticket("NYC", "Business");
var ticket2 = new Ticket("Yonkers", "General");
ticket1.purchaseTicket(74.99, DateTime.Now);
// ticket2.purchaseTicket(0, DateTime.Now);

Console.WriteLine($"All abord for the {train1.Line}! We'll be moving at an operating speed of {train1.Speed} mph on an {train1.Locomotive} locomotive powering the train.");
Console.WriteLine($"Your total for the trip will be {ticket1.TotalAmount}. You will be traveling to {ticket1.Destination} in {ticket1.TravelClass} class");
// Console.WriteLine(ticket2.Price);