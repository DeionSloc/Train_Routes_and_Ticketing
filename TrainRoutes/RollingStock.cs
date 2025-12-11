namespace Locomotive;
    public class RollingStock
{
    private static double s_gauge = 4.5;
    public string Gauge { get; }
    public int Speed { get; set; }
    public string Locomotive { get; set; }
    public string Line { get; set; }

    public RollingStock(int speed, string locomotive, string line)
    {
        Speed = speed;
        Locomotive = locomotive;
        Line = line;
        Gauge = s_gauge.ToString();
    }
}
