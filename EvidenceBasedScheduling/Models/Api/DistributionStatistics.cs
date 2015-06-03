namespace EvidenceBasedScheduling.Models.Api
{
    public class DistributionStatistics<T>
        where T : struct
    {
        public T? Median { get; set; }
        public T? Quartile3 { get; set; }
        public T? Quartile1 { get; set; }
        public T Max { get; set; }
        public T Min { get; set; }
    }
}