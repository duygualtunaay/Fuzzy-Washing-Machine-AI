using System;
using System.Collections.Generic;

namespace FuzzyWashingMachine.Engine
{
    /// <summary>
    /// Represents a fuzzy set with a name and membership function
    /// </summary>
    public class FuzzySet
    {
        public string Name { get; }
        private IMembershipFunction _membershipFunction;

        public FuzzySet(string name, IMembershipFunction membershipFunction)
        {
            Name = name;
            _membershipFunction = membershipFunction;
        }

        /// <summary>
        /// Calculates the membership degree of a crisp value in this fuzzy set
        /// </summary>
        public double GetMembershipDegree(double crispValue)
        {
            return _membershipFunction.Calculate(crispValue);
        }

        /// <summary>
        /// Returns points for visualization of the membership function
        /// </summary>
        public List<KeyValuePair<double, double>> GetMembershipPoints(double min, double max, int pointCount = 100)
        {
            List<KeyValuePair<double, double>> points = new List<KeyValuePair<double, double>>();
            double step = (max - min) / (pointCount - 1);

            for (int i = 0; i < pointCount; i++)
            {
                double x = min + (i * step);
                double y = GetMembershipDegree(x);
                points.Add(new KeyValuePair<double, double>(x, y));
            }

            return points;
        }

        /// <summary>
        /// Gets the centroid of this fuzzy set over the given range
        /// </summary>
        public double GetCentroid(double min, double max, int resolution = 100)
        {
            double step = (max - min) / resolution;
            double numerator = 0.0;
            double denominator = 0.0;

            for (int i = 0; i <= resolution; i++)
            {
                double x = min + (i * step);
                double y = GetMembershipDegree(x);
                numerator += x * y;
                denominator += y;
            }

            if (Math.Abs(denominator) < 0.000001)
                return (min + max) / 2; // Default to middle if denominator is close to zero

            return numerator / denominator;
        }

        /// <summary>
        /// Gets the x-y coordinates that define this membership function for visualization
        /// </summary>
        public List<KeyValuePair<double, double>> GetPoints(double minX, double maxX, int pointCount = 100)
        {
            return _membershipFunction.GetPoints(minX, maxX, pointCount);
        }
    }

    /// <summary>
    /// Interface for all membership function types
    /// </summary>
    public interface IMembershipFunction
    {
        double Calculate(double x);
        List<KeyValuePair<double, double>> GetPoints(double minX, double maxX, int pointCount = 100);
    }

    /// <summary>
    /// Triangle membership function implementation
    /// </summary>
    public class TriangleMembershipFunction : IMembershipFunction
    {
        private readonly double _a, _b, _c;

        public TriangleMembershipFunction(double a, double b, double c)
        {
            _a = a;
            _b = b;
            _c = c;
        }

        public double Calculate(double x)
        {
            if (x <= _a || x >= _c)
                return 0;
            if (x <= _b)
                return (x - _a) / (_b - _a);
            return (_c - x) / (_c - _b);
        }

        public List<KeyValuePair<double, double>> GetPoints(double minX, double maxX, int pointCount = 100)
        {
            var points = new List<KeyValuePair<double, double>>();
            
            // Only include key points plus enough intermediate points
            points.Add(new KeyValuePair<double, double>(_a, 0));
            points.Add(new KeyValuePair<double, double>(_b, 1));
            points.Add(new KeyValuePair<double, double>(_c, 0));
            
            return points;
        }
    }

    /// <summary>
    /// Trapezoidal membership function implementation
    /// </summary>
    public class TrapezoidMembershipFunction : IMembershipFunction
    {
        private readonly double _a, _b, _c, _d;

        public TrapezoidMembershipFunction(double a, double b, double c, double d)
        {
            _a = a;
            _b = b;
            _c = c;
            _d = d;
        }

        public double Calculate(double x)
        {
            if (x <= _a || x >= _d)
                return 0;
            if (x >= _b && x <= _c)
                return 1;
            if (x < _b)
                return (x - _a) / (_b - _a);
            return (_d - x) / (_d - _c);
        }

        public List<KeyValuePair<double, double>> GetPoints(double minX, double maxX, int pointCount = 100)
        {
            var points = new List<KeyValuePair<double, double>>();
            
            // Only include key points for trapezoid
            points.Add(new KeyValuePair<double, double>(_a, 0));
            points.Add(new KeyValuePair<double, double>(_b, 1));
            points.Add(new KeyValuePair<double, double>(_c, 1));
            points.Add(new KeyValuePair<double, double>(_d, 0));
            
            return points;
        }
    }
}