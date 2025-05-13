using Domain.Entities.Analytics;

namespace Analytics;

public class AnalysisHelper
{
    public void GetAnalytics(IEnumerable<RegionAnalytics> info)
    {
        IList<double> weights = [0.4, 0.3, 0.2, 0.1];
        var matrix = info.Select(x => new double[]
        {
            x.TotalCasualties,
            x.TotalInjured,
            (double)x.TotalLoss,
            x.TotalHours
        }).ToArray();


    }


}
