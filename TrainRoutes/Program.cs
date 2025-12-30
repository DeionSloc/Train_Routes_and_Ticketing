﻿using Locomotive;

var ticket1 = new Ticket("Virginia Beach, VA", "New York, NY", "Premium");
var ticket2 = new Ticket("Raleigh, NC", "Yonkers, NY", "Business");
var ticket3 = new Ticket("Atlanta, Georgia", "Miami, FL", "Room");
var ticket4 = new Ticket("Orlando, FL", "Charleston, SC", "Coach");
var ticket5 = new Ticket("Richmond, VA", "Pittsburgh, PA", "Family Room");
var ticket6 = new Ticket("Columbus, OH", "Aurora, CO", "Roomette");

ticket1.purchaseTicket(DateTime.Now);
ticket2.purchaseTicket(DateTime.Today);
ticket3.purchaseTicket(DateTime.Now);
ticket4.purchaseTicket(DateTime.Today);
ticket5.purchaseTicket(DateTime.Today);
ticket6.purchaseTicket(DateTime.Today);

Console.WriteLine(ticket1.getReceipt());
Console.WriteLine(ticket2.getReceipt());
Console.WriteLine(ticket3.getReceipt());
Console.WriteLine(ticket4.getReceipt());
Console.WriteLine(ticket5.getReceipt());
Console.WriteLine(ticket6.getReceipt());

