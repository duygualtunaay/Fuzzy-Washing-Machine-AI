using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms.DataVisualization.Charting;
using FuzzyWashingMachine.Engine;

namespace FuzzyWashingMachine.Visualization
{
    /// <summary>
    /// Visualizes fuzzy sets and membership functions
    /// </summary>
    public class FuzzyVisualizer
    {
        // Color mapping for fuzzy sets
        private readonly Dictionary<string, Color> _colorMap = new Dictionary<string, Color>
        {
            // Input set colors
            { "Durable", Color.DarkBlue },
            { "Medium", Color.RoyalBlue },
            { "Sensitive", Color.LightBlue },
            { "Low", Color.Green },
            { "High", Color.Red },
            
            // Output set colors
            { "VeryLow", Color.LightGreen },
            { "Short", Color.LightGreen },
            { "Gentle", Color.LightGreen },
            { "NormalGentle", Color.LightSeaGreen },
            { "NormalStrong", Color.OrangeRed },
            { "Long", Color.DarkRed },
            { "Strong", Color.DarkRed },
            { "VeryHigh", Color.DarkRed }
        };

        // Vertical line for current input value
        private readonly Series _currentValueLine = new Series
        {
            ChartType = SeriesChartType.Line,
            Color = Color.Black,
            BorderWidth = 2,
            BorderDashStyle = ChartDashStyle.Dash
        };

        /// <summary>
        /// Draws input membership functions with the current input value highlighted
        /// </summary>
        public void DrawInputMembershipFunctions(Chart chart, FuzzyVariable variable, double currentValue)
        {
            chart.Series.Clear();
            chart.Titles.Clear();

            // Add title
            chart.Titles.Add(new Title
            {
                Text = variable.Name,
                Docking = Docking.Top,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            });

            // Draw each fuzzy set
            foreach (var fuzzySet in variable.GetFuzzySets())
            {
                var series = new Series(fuzzySet.Name)
                {
                    ChartType = SeriesChartType.Line,
                    Color = GetColorForSet(fuzzySet.Name),
                    BorderWidth = 2
                };

                var points = fuzzySet.GetPoints(variable.MinValue, variable.MaxValue);
                foreach (var point in points)
                {
                    series.Points.AddXY(point.Key, point.Value);
                }

                chart.Series.Add(series);

                // Add area fill
                var fillSeries = new Series(fuzzySet.Name + "_fill")
                {
                    ChartType = SeriesChartType.Area,
                    Color = Color.FromArgb(50, GetColorForSet(fuzzySet.Name)),
                    BorderWidth = 0
                };

                foreach (var point in points)
                {
                    fillSeries.Points.AddXY(point.Key, point.Value);
                }

                chart.Series.Add(fillSeries);
            }

            // Draw current value line
            _currentValueLine.Points.Clear();
            _currentValueLine.Points.AddXY(currentValue, 0);
            _currentValueLine.Points.AddXY(currentValue, 1);
            chart.Series.Add(_currentValueLine);

            // Draw current membership degrees
            var membershipDegrees = variable.Fuzzify(currentValue);
            foreach (var degree in membershipDegrees)
            {
                if (degree.Value > 0)
                {
                    // Point series
                    var pointSeries = new Series(degree.Key + "_point")
                    {
                        ChartType = SeriesChartType.Point,
                        Color = GetColorForSet(degree.Key),
                        MarkerSize = 10,
                        MarkerStyle = MarkerStyle.Circle
                    };

                    pointSeries.Points.AddXY(currentValue, degree.Value);
                    chart.Series.Add(pointSeries);

                    // Label series
                    var labelSeries = new Series(degree.Key + "_label")
                    {
                        ChartType = SeriesChartType.Point,
                        IsVisibleInLegend = false,
                        MarkerSize = 0
                    };

                    labelSeries.Points.AddXY(currentValue, degree.Value);

                    var labelPoint = labelSeries.Points[labelSeries.Points.Count - 1];
                    labelPoint.Label = degree.Value.ToString("F2");
                    labelPoint.LabelForeColor = GetColorForSet(degree.Key);
                    // DataPoint sýnýfý Font özelliði desteklemez

                    chart.Series.Add(labelSeries);
                }
            }
        }

        /// <summary>
        /// Draws output membership functions
        /// </summary>
        public void DrawOutputMembershipFunctions(Chart chart, FuzzyVariable variable)
        {
            chart.Series.Clear();
            chart.Titles.Clear();

            chart.Titles.Add(new Title
            {
                Text = variable.Name,
                Docking = Docking.Top,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            });

            foreach (var fuzzySet in variable.GetFuzzySets())
            {
                var series = new Series(fuzzySet.Name)
                {
                    ChartType = SeriesChartType.Line,
                    Color = GetColorForSet(fuzzySet.Name),
                    BorderWidth = 2
                };

                var points = fuzzySet.GetPoints(variable.MinValue, variable.MaxValue);
                foreach (var point in points)
                {
                    series.Points.AddXY(point.Key, point.Value);
                }

                chart.Series.Add(series);

                var fillSeries = new Series(fuzzySet.Name + "_fill")
                {
                    ChartType = SeriesChartType.Area,
                    Color = Color.FromArgb(50, GetColorForSet(fuzzySet.Name)),
                    BorderWidth = 0
                };

                foreach (var point in points)
                {
                    fillSeries.Points.AddXY(point.Key, point.Value);
                }

                chart.Series.Add(fillSeries);
            }
        }

        /// <summary>
        /// Gets a color for a fuzzy set based on mapping or generates a new one
        /// </summary>
        private Color GetColorForSet(string setName)
        {
            if (_colorMap.ContainsKey(setName))
                return _colorMap[setName];

            Random rnd = new Random(setName.GetHashCode());
            return Color.FromArgb(rnd.Next(0, 255), rnd.Next(0, 255), rnd.Next(0, 255));
        }
    }
}
