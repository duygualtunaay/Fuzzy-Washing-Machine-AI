using System;
using System.Collections.Generic;
using System.Linq;

namespace FuzzyWashingMachine.Engine
{
    /// <summary>
    /// Represents a fuzzy variable with its fuzzy sets and range
    /// </summary>
    public class FuzzyVariable
    {
        private readonly List<FuzzySet> _fuzzySets = new List<FuzzySet>();
        public string Name { get; }
        public double MinValue { get; }
        public double MaxValue { get; }
        
        public FuzzyVariable(string name, double minValue, double maxValue)
        {
            Name = name;
            MinValue = minValue;
            MaxValue = maxValue;
        }

        /// <summary>
        /// Adds a fuzzy set to this variable
        /// </summary>
        public void AddFuzzySet(FuzzySet fuzzySet)
        {
            _fuzzySets.Add(fuzzySet);
        }

        /// <summary>
        /// Gets all fuzzy sets defined for this variable
        /// </summary>
        public IEnumerable<FuzzySet> GetFuzzySets()
        {
            return _fuzzySets.AsReadOnly();
        }

        /// <summary>
        /// Gets a fuzzy set by name
        /// </summary>
        public FuzzySet GetFuzzySet(string name)
        {
            return _fuzzySets.FirstOrDefault(fs => fs.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        }

        /// <summary>
        /// Fuzzifies a crisp input value to get membership degrees for all fuzzy sets
        /// </summary>
        public Dictionary<string, double> Fuzzify(double crispValue)
        {
            Dictionary<string, double> membershipDegrees = new Dictionary<string, double>();
            
            foreach (var fuzzySet in _fuzzySets)
            {
                double membershipDegree = fuzzySet.GetMembershipDegree(crispValue);
                membershipDegrees[fuzzySet.Name] = membershipDegree;
            }
            
            return membershipDegrees;
        }

        /// <summary>
        /// Defuzzifies using the weighted average method
        /// </summary>
        public double DefuzzifyWeightedAverage(Dictionary<string, double> activations)
        {
            double numerator = 0.0;
            double denominator = 0.0;

            foreach (var set in _fuzzySets)
            {
                double activation = activations.ContainsKey(set.Name) ? activations[set.Name] : 0.0;
                double centroid = set.GetCentroid(MinValue, MaxValue);
                
                numerator += centroid * activation;
                denominator += activation;
            }

            if (Math.Abs(denominator) < 0.000001)
                return (MinValue + MaxValue) / 2; // Default to middle if denominator is close to zero

            return numerator / denominator;
        }

        /// <summary>
        /// Defuzzifies using the centroid method
        /// </summary>
        public double DefuzzifyCentroid(Dictionary<string, double> activations, int resolution = 100)
        {
            double step = (MaxValue - MinValue) / resolution;
            double numerator = 0.0;
            double denominator = 0.0;

            for (int i = 0; i <= resolution; i++)
            {
                double x = MinValue + (i * step);
                double aggregatedMembership = 0.0;

                // Calculate aggregated membership at point x
                foreach (var set in _fuzzySets)
                {
                    double activation = activations.ContainsKey(set.Name) ? activations[set.Name] : 0.0;
                    double membership = Math.Min(activation, set.GetMembershipDegree(x));
                    aggregatedMembership = Math.Max(aggregatedMembership, membership);
                }

                numerator += x * aggregatedMembership;
                denominator += aggregatedMembership;
            }

            if (Math.Abs(denominator) < 0.000001)
                return (MinValue + MaxValue) / 2; // Default to middle if denominator is close to zero

            return numerator / denominator;
        }
    }
}