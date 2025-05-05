using System;
using System.Collections.Generic;
using System.Text;

namespace FuzzyWashingMachine.Engine
{
    /// <summary>
    /// Represents a fuzzy rule with antecedents and consequents
    /// </summary>
    public class FuzzyRule
    {
        private readonly Dictionary<string, string> _antecedents = new Dictionary<string, string>();
        private readonly Dictionary<string, string> _consequents = new Dictionary<string, string>();
        public double ActivationLevel { get; private set; }

        public FuzzyRule()
        {
            ActivationLevel = 0.0;
        }

        /// <summary>
        /// Adds an if-condition to the rule
        /// </summary>
        public void AddAntecedent(string variableName, string fuzzySetName)
        {
            _antecedents[variableName] = fuzzySetName;
        }

        /// <summary>
        /// Adds a then-action to the rule
        /// </summary>
        public void AddConsequent(string variableName, string fuzzySetName)
        {
            _consequents[variableName] = fuzzySetName;
        }

        /// <summary>
        /// Evaluates the rule with the given input values and returns the activation level
        /// </summary>
        public double Evaluate(Dictionary<string, Dictionary<string, double>> fuzzifiedInputs)
        {
            if (_antecedents.Count == 0)
                return 0.0;

            // Apply AND operator (minimum) to all antecedents
            double minActivation = double.MaxValue;

            foreach (var antecedent in _antecedents)
            {
                string variableName = antecedent.Key;
                string fuzzySetName = antecedent.Value;

                if (!fuzzifiedInputs.ContainsKey(variableName) || 
                    !fuzzifiedInputs[variableName].ContainsKey(fuzzySetName))
                {
                    return 0.0; // Rule not applicable
                }

                double membershipDegree = fuzzifiedInputs[variableName][fuzzySetName];
                minActivation = Math.Min(minActivation, membershipDegree);
            }

            // Store activation level for this rule
            ActivationLevel = minActivation;
            return ActivationLevel;
        }

        /// <summary>
        /// Gets all consequents of this rule
        /// </summary>
        public IReadOnlyDictionary<string, string> GetConsequents()
        {
            return _consequents;
        }

        /// <summary>
        /// Gets a human-readable representation of the rule
        /// </summary>
        public override string ToString()
        {
            StringBuilder builder = new StringBuilder("IF ");
            
            // Add antecedents
            int i = 0;
            foreach (var antecedent in _antecedents)
            {
                if (i > 0) builder.Append(" AND ");
                builder.Append($"{antecedent.Key} is {antecedent.Value}");
                i++;
            }
            
            // Add consequents
            builder.Append(" THEN ");
            i = 0;
            foreach (var consequent in _consequents)
            {
                if (i > 0) builder.Append(" AND ");
                builder.Append($"{consequent.Key} is {consequent.Value}");
                i++;
            }
            
            return builder.ToString();
        }
    }
}