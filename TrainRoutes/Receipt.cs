namespace Locomotive;

public record Receipt(double Price, double Tax, string Origin, string Destination, string TravelClass, DateTime date);