namespace Locomotive;

public record Receipt(double Price, double tax, string Origin, string Destination, string TravelClass, DateTime date);