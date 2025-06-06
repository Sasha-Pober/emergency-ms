﻿using Analytics.Entity;
using Domain.Entities.Analytics;

namespace Analytics;

public class AnalysisHelper
{
    public static AnalyticsResponse GetAnalytics(IEnumerable<RegionAnalytics> info)
    {
        IList<double> weights = [0.4, 0.3, 0.2, 0.1];

        double v = 0.5;

        var (results, bestAlternatives) = CalculateVIKOR(info.ToList(), weights, v);

        return new AnalyticsResponse
        {
            Results = results,
            BestAlternatives = bestAlternatives
        };

    }

    static (IList<AnalyticsResult>, IList<AnalyticsResult>) CalculateVIKOR(List<RegionAnalytics> info, IList<double> weights, double v)
    {
        double[,] matrix = new double[info.Count, weights.Count];

        for (int i = 0; i < info.Count; i++)
        {
            matrix[i, 0] = info[i].TotalCasualties;
            matrix[i, 1] = info[i].TotalInjured;
            matrix[i, 3] = info[i].TotalHours;
            matrix[i, 2] = info[i].TotalLoss;
        }

        for (int i = 0; i < info.Count; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                Console.Write($"{matrix[i, j]} ");
            }
            Console.WriteLine();
        }

        int n = matrix.GetLength(0); //alternatives count
        int m = matrix.GetLength(1); //criterias count

        var fstar = new double[m];
        var fminus = new double[m];


        for (int j = 0; j < m; j++)
        {
            var column = Enumerable.Range(0, n).Select(i => matrix[i, j]);
            fstar[j] = column.Min();
            fminus[j] = column.Max();
        }

        var S = new double[n];
        var R = new double[n];

        for (int i = 0; i < n; i++)
        {
            double sum = 0;
            double max = double.MinValue;
            for (int j = 0; j < m; j++)
            {
                double norm = (fstar[j] - matrix[i, j]) / (fstar[j] - fminus[j]);
                double weighted = norm * weights[j];
                sum += weighted;
                max = Math.Max(max, weighted);
            }
            S[i] = sum;
            R[i] = max;
        }

        double SStar = S.Min(), SMinus = S.Max();
        double RStar = R.Min(), RMinus = R.Max();

        var results = new List<AnalyticsResult>();

        for (int i = 0; i < n; i++)
        {
            double q = (v * (S[i] - SStar) / (SMinus - SStar))
                     + ((1 - v) * (R[i] - RStar) / (RMinus - RStar));

            results.Add(new AnalyticsResult
            {
                Name = $"Alt {i + 1}",
                S = S[i],
                R = R[i],
                Q = q
            });
        }

        results = results.OrderBy(r => r.Q).ToList();

        var bestAlternatives = GetBestAlternatives(results);

        foreach (var result in results)
        {
            Console.WriteLine($"{result.Name}, S: {result.S}, R: {result.R}, Q: {result.Q}");
        }

        foreach (var result in bestAlternatives)
        {
            Console.WriteLine($"Best alternative: {result.Name}, S: {result.S}, R: {result.R}, Q: {result.Q}");
        }

        return (results, bestAlternatives);
    }

    static bool AcceptableAdvantage(IList<AnalyticsResult> results, double DQ)
    {
        Console.WriteLine($"Advantage {results[1].Q - results[0].Q >= DQ}");
        return results[1].Q - results[0].Q >= DQ;
    }

    static bool AcceptableStability(IList<AnalyticsResult> results, double DQ)
    {
        var rangeByS = results.OrderBy(r => r.S).ToList();
        var rangeByR = results.OrderBy(r => r.R).ToList();

        Console.WriteLine($"{rangeByS[0].Name} {rangeByR[0].Name} {results[0].Name}");

        return rangeByS[0].Name == results[0].Name || rangeByR[0].Name == results[0].Name;
    }

    static IList<AnalyticsResult> GetBestAlternatives(IList<AnalyticsResult> results)
    {
        double DQ = 1 / (results.Count - 1);
        var IsAcceptableAdvantage = AcceptableAdvantage(results, DQ);
        var IsAcceptableStability = AcceptableStability(results, DQ);

        Console.WriteLine($"AcceptableAdvantage: {IsAcceptableAdvantage}");
        Console.WriteLine($"AcceptableStability: {IsAcceptableStability}");

        if (IsAcceptableAdvantage && IsAcceptableStability)
        {
            return results.Take(1).ToList();
        }
        else if (IsAcceptableAdvantage && !IsAcceptableStability)
        {
            return results.Take(2).ToList();
        }
        else if (!IsAcceptableAdvantage && IsAcceptableStability)
        {
            return results.TakeWhile(r => r.Q - results[0].Q < DQ).ToList();
        }
        else
        {
            return results;
        }

    }



}
