﻿using Locomotive;

var train1 = new RollingStock(60, "Acela", "Jersey Sights");

var ticket1 = new Ticket("Virginia Beach, VA", "New York, NY", "Premium");
var ticket2 = new Ticket("Raleigh, NC", "Yonkers, NY", "Business");
ticket1.purchaseTicket(DateTime.Now);
ticket2.purchaseTicket(DateTime.Now);

Console.WriteLine($"Your ticket number is: {ticket1.ticketNumber}, and your total for the trip will be {ticket1.TotalAmount}. You will be traveling to {ticket1.Destination} in {ticket1.TravelClass} class");

Console.WriteLine($"Your ticket number is: {ticket2.ticketNumber}, and your total for the trip will be {ticket2.TotalAmount}. You will be traveling to {ticket2.Destination} in {ticket2.TravelClass} class");

Console.WriteLine(ticket1.getReceipt());
Console.WriteLine(ticket2.getReceipt());
