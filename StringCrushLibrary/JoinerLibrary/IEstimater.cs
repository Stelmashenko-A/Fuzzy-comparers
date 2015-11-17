namespace JoinerLibrary
{
    public interface IEstimater
    {
        double Estimate(double metricValue, int length1, int length2);
    }
}