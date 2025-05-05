using System;
using System.Collections.Generic;
using System.Linq;

namespace FuzzyWashingMachine.Engine
{
    /// <summary>
    /// Represents the complete fuzzy washing machine inference system
    /// </summary>
    public class FuzzyInferenceSystem
    {
        // Input variables
        public FuzzyVariable Sensitivity { get; private set; }
        public FuzzyVariable Dirtiness { get; private set; }
        public FuzzyVariable LoadAmount { get; private set; }

        // Output variables
        public FuzzyVariable DetergentAmount { get; private set; }
        public FuzzyVariable WashingTime { get; private set; }
        public FuzzyVariable SpinSpeed { get; private set; }

        // Rules
        private List<FuzzyRule> _rules = new List<FuzzyRule>();

        // Fuzzified inputs and output activations
        private Dictionary<string, Dictionary<string, double>> _fuzzifiedInputs = 
            new Dictionary<string, Dictionary<string, double>>();
        private Dictionary<string, Dictionary<string, double>> _outputActivations = 
            new Dictionary<string, Dictionary<string, double>>();

        // Results storage
        public FuzzyInferenceResult LastResult { get; private set; }

        public FuzzyInferenceSystem()
        {
            LastResult = new FuzzyInferenceResult();
        }

        /// <summary>
        /// Initializes the fuzzy system with variables, sets, and rules
        /// </summary>
        public void Initialize()
        {
            InitializeVariables();
            InitializeRules();
        }

        /// <summary>
        /// Initializes input and output variables with their fuzzy sets
        /// </summary>
        private void InitializeVariables()
        {
            // Initialize input variables
            Sensitivity = new FuzzyVariable("Sensitivity", 0, 10);
            Sensitivity.AddFuzzySet(new FuzzySet("Durable", new TrapezoidMembershipFunction(0, 0, 3, 5)));
            Sensitivity.AddFuzzySet(new FuzzySet("Medium", new TriangleMembershipFunction(3, 5, 7)));
            Sensitivity.AddFuzzySet(new FuzzySet("Sensitive", new TrapezoidMembershipFunction(5, 7, 10, 10)));

            Dirtiness = new FuzzyVariable("Dirtiness", 0, 10);
            Dirtiness.AddFuzzySet(new FuzzySet("Low", new TrapezoidMembershipFunction(0, 0, 3, 5)));
            Dirtiness.AddFuzzySet(new FuzzySet("Medium", new TriangleMembershipFunction(3, 5, 7)));
            Dirtiness.AddFuzzySet(new FuzzySet("High", new TrapezoidMembershipFunction(5, 7, 10, 10)));

            LoadAmount = new FuzzyVariable("LoadAmount", 0, 10);
            LoadAmount.AddFuzzySet(new FuzzySet("Low", new TrapezoidMembershipFunction(0, 0, 3, 5)));
            LoadAmount.AddFuzzySet(new FuzzySet("Medium", new TriangleMembershipFunction(3, 5, 7)));
            LoadAmount.AddFuzzySet(new FuzzySet("High", new TrapezoidMembershipFunction(5, 7, 10, 10)));

            // Initialize output variables
            DetergentAmount = new FuzzyVariable("DetergentAmount", 0, 300);
            DetergentAmount.AddFuzzySet(new FuzzySet("VeryLow", new TrapezoidMembershipFunction(0, 0, 30, 60)));
            DetergentAmount.AddFuzzySet(new FuzzySet("Low", new TriangleMembershipFunction(30, 75, 120)));
            DetergentAmount.AddFuzzySet(new FuzzySet("Medium", new TriangleMembershipFunction(90, 150, 210)));
            DetergentAmount.AddFuzzySet(new FuzzySet("High", new TriangleMembershipFunction(180, 225, 270)));
            DetergentAmount.AddFuzzySet(new FuzzySet("VeryHigh", new TrapezoidMembershipFunction(240, 270, 300, 300)));

            WashingTime = new FuzzyVariable("WashingTime", 0, 100);
            WashingTime.AddFuzzySet(new FuzzySet("Short", new TrapezoidMembershipFunction(0, 0, 20, 35)));
            WashingTime.AddFuzzySet(new FuzzySet("Medium", new TriangleMembershipFunction(25, 50, 75)));
            WashingTime.AddFuzzySet(new FuzzySet("Long", new TrapezoidMembershipFunction(65, 80, 100, 100)));

            SpinSpeed = new FuzzyVariable("SpinSpeed", 0, 10);
            SpinSpeed.AddFuzzySet(new FuzzySet("Gentle", new TrapezoidMembershipFunction(0, 0, 1, 3)));
            SpinSpeed.AddFuzzySet(new FuzzySet("NormalGentle", new TriangleMembershipFunction(2, 3.5, 5)));
            SpinSpeed.AddFuzzySet(new FuzzySet("Medium", new TriangleMembershipFunction(4, 5, 6)));
            SpinSpeed.AddFuzzySet(new FuzzySet("NormalStrong", new TriangleMembershipFunction(5, 6.5, 8)));
            SpinSpeed.AddFuzzySet(new FuzzySet("Strong", new TrapezoidMembershipFunction(7, 9, 10, 10)));
        }

        /// <summary>
        /// Initializes all 27 rules for the washing machine controller
        /// </summary>
        private void InitializeRules()
        {
            // Rule 1: IF Sensitivity is Sensitive AND Dirtiness is Low AND LoadAmount is Low 
            // THEN DetergentAmount is VeryLow AND WashingTime is Short AND SpinSpeed is Gentle
            var rule1 = new FuzzyRule();
            rule1.AddAntecedent("Sensitivity", "Sensitive");
            rule1.AddAntecedent("Dirtiness", "Low");
            rule1.AddAntecedent("LoadAmount", "Low");
            rule1.AddConsequent("DetergentAmount", "VeryLow");
            rule1.AddConsequent("WashingTime", "Short");
            rule1.AddConsequent("SpinSpeed", "Gentle");
            _rules.Add(rule1);

            // Rule 2: IF Sensitivity is Sensitive AND Dirtiness is Low AND LoadAmount is Medium 
            // THEN DetergentAmount is Low AND WashingTime is Short AND SpinSpeed is Gentle
            var rule2 = new FuzzyRule();
            rule2.AddAntecedent("Sensitivity", "Sensitive");
            rule2.AddAntecedent("Dirtiness", "Low");
            rule2.AddAntecedent("LoadAmount", "Medium");
            rule2.AddConsequent("DetergentAmount", "Low");
            rule2.AddConsequent("WashingTime", "Short");
            rule2.AddConsequent("SpinSpeed", "Gentle");
            _rules.Add(rule2);

            // Rule 3: IF Sensitivity is Sensitive AND Dirtiness is Low AND LoadAmount is High 
            // THEN DetergentAmount is Medium AND WashingTime is Medium AND SpinSpeed is Gentle
            var rule3 = new FuzzyRule();
            rule3.AddAntecedent("Sensitivity", "Sensitive");
            rule3.AddAntecedent("Dirtiness", "Low");
            rule3.AddAntecedent("LoadAmount", "High");
            rule3.AddConsequent("DetergentAmount", "Medium");
            rule3.AddConsequent("WashingTime", "Medium");
            rule3.AddConsequent("SpinSpeed", "Gentle");
            _rules.Add(rule3);

            // Rule 4: IF Sensitivity is Sensitive AND Dirtiness is Medium AND LoadAmount is Low 
            // THEN DetergentAmount is Low AND WashingTime is Medium AND SpinSpeed is Gentle
            var rule4 = new FuzzyRule();
            rule4.AddAntecedent("Sensitivity", "Sensitive");
            rule4.AddAntecedent("Dirtiness", "Medium");
            rule4.AddAntecedent("LoadAmount", "Low");
            rule4.AddConsequent("DetergentAmount", "Low");
            rule4.AddConsequent("WashingTime", "Medium");
            rule4.AddConsequent("SpinSpeed", "Gentle");
            _rules.Add(rule4);

            // Rule 5: IF Sensitivity is Sensitive AND Dirtiness is Medium AND LoadAmount is Medium 
            // THEN DetergentAmount is Medium AND WashingTime is Medium AND SpinSpeed is NormalGentle
            var rule5 = new FuzzyRule();
            rule5.AddAntecedent("Sensitivity", "Sensitive");
            rule5.AddAntecedent("Dirtiness", "Medium");
            rule5.AddAntecedent("LoadAmount", "Medium");
            rule5.AddConsequent("DetergentAmount", "Medium");
            rule5.AddConsequent("WashingTime", "Medium");
            rule5.AddConsequent("SpinSpeed", "NormalGentle");
            _rules.Add(rule5);

            // Rule 6: IF Sensitivity is Sensitive AND Dirtiness is Medium AND LoadAmount is High 
            // THEN DetergentAmount is High AND WashingTime is Medium AND SpinSpeed is NormalGentle
            var rule6 = new FuzzyRule();
            rule6.AddAntecedent("Sensitivity", "Sensitive");
            rule6.AddAntecedent("Dirtiness", "Medium");
            rule6.AddAntecedent("LoadAmount", "High");
            rule6.AddConsequent("DetergentAmount", "High");
            rule6.AddConsequent("WashingTime", "Medium");
            rule6.AddConsequent("SpinSpeed", "NormalGentle");
            _rules.Add(rule6);

            // Rule 7: IF Sensitivity is Sensitive AND Dirtiness is High AND LoadAmount is Low 
            // THEN DetergentAmount is Medium AND WashingTime is Long AND SpinSpeed is NormalGentle
            var rule7 = new FuzzyRule();
            rule7.AddAntecedent("Sensitivity", "Sensitive");
            rule7.AddAntecedent("Dirtiness", "High");
            rule7.AddAntecedent("LoadAmount", "Low");
            rule7.AddConsequent("DetergentAmount", "Medium");
            rule7.AddConsequent("WashingTime", "Long");
            rule7.AddConsequent("SpinSpeed", "NormalGentle");
            _rules.Add(rule7);

            // Rule 8: IF Sensitivity is Sensitive AND Dirtiness is High AND LoadAmount is Medium 
            // THEN DetergentAmount is High AND WashingTime is Long AND SpinSpeed is NormalGentle
            var rule8 = new FuzzyRule();
            rule8.AddAntecedent("Sensitivity", "Sensitive");
            rule8.AddAntecedent("Dirtiness", "High");
            rule8.AddAntecedent("LoadAmount", "Medium");
            rule8.AddConsequent("DetergentAmount", "High");
            rule8.AddConsequent("WashingTime", "Long");
            rule8.AddConsequent("SpinSpeed", "NormalGentle");
            _rules.Add(rule8);

            // Rule 9: IF Sensitivity is Sensitive AND Dirtiness is High AND LoadAmount is High 
            // THEN DetergentAmount is VeryHigh AND WashingTime is Long AND SpinSpeed is Medium
            var rule9 = new FuzzyRule();
            rule9.AddAntecedent("Sensitivity", "Sensitive");
            rule9.AddAntecedent("Dirtiness", "High");
            rule9.AddAntecedent("LoadAmount", "High");
            rule9.AddConsequent("DetergentAmount", "VeryHigh");
            rule9.AddConsequent("WashingTime", "Long");
            rule9.AddConsequent("SpinSpeed", "Medium");
            _rules.Add(rule9);

            // Rules for Medium Sensitivity

            // Rule 10: IF Sensitivity is Medium AND Dirtiness is Low AND LoadAmount is Low 
            // THEN DetergentAmount is VeryLow AND WashingTime is Short AND SpinSpeed is NormalGentle
            var rule10 = new FuzzyRule();
            rule10.AddAntecedent("Sensitivity", "Medium");
            rule10.AddAntecedent("Dirtiness", "Low");
            rule10.AddAntecedent("LoadAmount", "Low");
            rule10.AddConsequent("DetergentAmount", "VeryLow");
            rule10.AddConsequent("WashingTime", "Short");
            rule10.AddConsequent("SpinSpeed", "NormalGentle");
            _rules.Add(rule10);

            // Rule 11: IF Sensitivity is Medium AND Dirtiness is Low AND LoadAmount is Medium 
            // THEN DetergentAmount is Low AND WashingTime is Short AND SpinSpeed is Medium
            var rule11 = new FuzzyRule();
            rule11.AddAntecedent("Sensitivity", "Medium");
            rule11.AddAntecedent("Dirtiness", "Low");
            rule11.AddAntecedent("LoadAmount", "Medium");
            rule11.AddConsequent("DetergentAmount", "Low");
            rule11.AddConsequent("WashingTime", "Short");
            rule11.AddConsequent("SpinSpeed", "Medium");
            _rules.Add(rule11);

            // Rule 12: IF Sensitivity is Medium AND Dirtiness is Low AND LoadAmount is High 
            // THEN DetergentAmount is Medium AND WashingTime is Medium AND SpinSpeed is Medium
            var rule12 = new FuzzyRule();
            rule12.AddAntecedent("Sensitivity", "Medium");
            rule12.AddAntecedent("Dirtiness", "Low");
            rule12.AddAntecedent("LoadAmount", "High");
            rule12.AddConsequent("DetergentAmount", "Medium");
            rule12.AddConsequent("WashingTime", "Medium");
            rule12.AddConsequent("SpinSpeed", "Medium");
            _rules.Add(rule12);

            // Rule 13: IF Sensitivity is Medium AND Dirtiness is Medium AND LoadAmount is Low 
            // THEN DetergentAmount is Low AND WashingTime is Medium AND SpinSpeed is NormalGentle
            var rule13 = new FuzzyRule();
            rule13.AddAntecedent("Sensitivity", "Medium");
            rule13.AddAntecedent("Dirtiness", "Medium");
            rule13.AddAntecedent("LoadAmount", "Low");
            rule13.AddConsequent("DetergentAmount", "Low");
            rule13.AddConsequent("WashingTime", "Medium");
            rule13.AddConsequent("SpinSpeed", "NormalGentle");
            _rules.Add(rule13);

            // Rule 14: IF Sensitivity is Medium AND Dirtiness is Medium AND LoadAmount is Medium 
            // THEN DetergentAmount is Medium AND WashingTime is Medium AND SpinSpeed is Medium
            var rule14 = new FuzzyRule();
            rule14.AddAntecedent("Sensitivity", "Medium");
            rule14.AddAntecedent("Dirtiness", "Medium");
            rule14.AddAntecedent("LoadAmount", "Medium");
            rule14.AddConsequent("DetergentAmount", "Medium");
            rule14.AddConsequent("WashingTime", "Medium");
            rule14.AddConsequent("SpinSpeed", "Medium");
            _rules.Add(rule14);

            // Rule 15: IF Sensitivity is Medium AND Dirtiness is Medium AND LoadAmount is High 
            // THEN DetergentAmount is High AND WashingTime is Medium AND SpinSpeed is NormalStrong
            var rule15 = new FuzzyRule();
            rule15.AddAntecedent("Sensitivity", "Medium");
            rule15.AddAntecedent("Dirtiness", "Medium");
            rule15.AddAntecedent("LoadAmount", "High");
            rule15.AddConsequent("DetergentAmount", "High");
            rule15.AddConsequent("WashingTime", "Medium");
            rule15.AddConsequent("SpinSpeed", "NormalStrong");
            _rules.Add(rule15);

            // Rule 16: IF Sensitivity is Medium AND Dirtiness is High AND LoadAmount is Low 
            // THEN DetergentAmount is Medium AND WashingTime is Long AND SpinSpeed is Medium
            var rule16 = new FuzzyRule();
            rule16.AddAntecedent("Sensitivity", "Medium");
            rule16.AddAntecedent("Dirtiness", "High");
            rule16.AddAntecedent("LoadAmount", "Low");
            rule16.AddConsequent("DetergentAmount", "Medium");
            rule16.AddConsequent("WashingTime", "Long");
            rule16.AddConsequent("SpinSpeed", "Medium");
            _rules.Add(rule16);

            // Rule 17: IF Sensitivity is Medium AND Dirtiness is High AND LoadAmount is Medium 
            // THEN DetergentAmount is High AND WashingTime is Long AND SpinSpeed is NormalStrong
            var rule17 = new FuzzyRule();
            rule17.AddAntecedent("Sensitivity", "Medium");
            rule17.AddAntecedent("Dirtiness", "High");
            rule17.AddAntecedent("LoadAmount", "Medium");
            rule17.AddConsequent("DetergentAmount", "High");
            rule17.AddConsequent("WashingTime", "Long");
            rule17.AddConsequent("SpinSpeed", "NormalStrong");
            _rules.Add(rule17);

            // Rule 18: IF Sensitivity is Medium AND Dirtiness is High AND LoadAmount is High 
            // THEN DetergentAmount is VeryHigh AND WashingTime is Long AND SpinSpeed is Strong
            var rule18 = new FuzzyRule();
            rule18.AddAntecedent("Sensitivity", "Medium");
            rule18.AddAntecedent("Dirtiness", "High");
            rule18.AddAntecedent("LoadAmount", "High");
            rule18.AddConsequent("DetergentAmount", "VeryHigh");
            rule18.AddConsequent("WashingTime", "Long");
            rule18.AddConsequent("SpinSpeed", "Strong");
            _rules.Add(rule18);

            // Rules for Durable Sensitivity

            // Rule 19: IF Sensitivity is Durable AND Dirtiness is Low AND LoadAmount is Low 
            // THEN DetergentAmount is VeryLow AND WashingTime is Short AND SpinSpeed is Medium
            var rule19 = new FuzzyRule();
            rule19.AddAntecedent("Sensitivity", "Durable");
            rule19.AddAntecedent("Dirtiness", "Low");
            rule19.AddAntecedent("LoadAmount", "Low");
            rule19.AddConsequent("DetergentAmount", "VeryLow");
            rule19.AddConsequent("WashingTime", "Short");
            rule19.AddConsequent("SpinSpeed", "Medium");
            _rules.Add(rule19);

            // Rule 20: IF Sensitivity is Durable AND Dirtiness is Low AND LoadAmount is Medium 
            // THEN DetergentAmount is Low AND WashingTime is Short AND SpinSpeed is NormalStrong
            var rule20 = new FuzzyRule();
            rule20.AddAntecedent("Sensitivity", "Durable");
            rule20.AddAntecedent("Dirtiness", "Low");
            rule20.AddAntecedent("LoadAmount", "Medium");
            rule20.AddConsequent("DetergentAmount", "Low");
            rule20.AddConsequent("WashingTime", "Short");
            rule20.AddConsequent("SpinSpeed", "NormalStrong");
            _rules.Add(rule20);

            // Rule 21: IF Sensitivity is Durable AND Dirtiness is Low AND LoadAmount is High 
            // THEN DetergentAmount is Medium AND WashingTime is Medium AND SpinSpeed is Strong
            var rule21 = new FuzzyRule();
            rule21.AddAntecedent("Sensitivity", "Durable");
            rule21.AddAntecedent("Dirtiness", "Low");
            rule21.AddAntecedent("LoadAmount", "High");
            rule21.AddConsequent("DetergentAmount", "Medium");
            rule21.AddConsequent("WashingTime", "Medium");
            rule21.AddConsequent("SpinSpeed", "Strong");
            _rules.Add(rule21);

            // Rule 22: IF Sensitivity is Durable AND Dirtiness is Medium AND LoadAmount is Low 
            // THEN DetergentAmount is Low AND WashingTime is Medium AND SpinSpeed is Medium
            var rule22 = new FuzzyRule();
            rule22.AddAntecedent("Sensitivity", "Durable");
            rule22.AddAntecedent("Dirtiness", "Medium");
            rule22.AddAntecedent("LoadAmount", "Low");
            rule22.AddConsequent("DetergentAmount", "Low");
            rule22.AddConsequent("WashingTime", "Medium");
            rule22.AddConsequent("SpinSpeed", "Medium");
            _rules.Add(rule22);

            // Rule 23: IF Sensitivity is Durable AND Dirtiness is Medium AND LoadAmount is Medium 
            // THEN DetergentAmount is Medium AND WashingTime is Medium AND SpinSpeed is NormalStrong
            var rule23 = new FuzzyRule();
            rule23.AddAntecedent("Sensitivity", "Durable");
            rule23.AddAntecedent("Dirtiness", "Medium");
            rule23.AddAntecedent("LoadAmount", "Medium");
            rule23.AddConsequent("DetergentAmount", "Medium");
            rule23.AddConsequent("WashingTime", "Medium");
            rule23.AddConsequent("SpinSpeed", "NormalStrong");
            _rules.Add(rule23);

            // Rule 24: IF Sensitivity is Durable AND Dirtiness is Medium AND LoadAmount is High 
            // THEN DetergentAmount is High AND WashingTime is Medium AND SpinSpeed is Strong
            var rule24 = new FuzzyRule();
            rule24.AddAntecedent("Sensitivity", "Durable");
            rule24.AddAntecedent("Dirtiness", "Medium");
            rule24.AddAntecedent("LoadAmount", "High");
            rule24.AddConsequent("DetergentAmount", "High");
            rule24.AddConsequent("WashingTime", "Medium");
            rule24.AddConsequent("SpinSpeed", "Strong");
            _rules.Add(rule24);

            // Rule 25: IF Sensitivity is Durable AND Dirtiness is High AND LoadAmount is Low 
            // THEN DetergentAmount is Medium AND WashingTime is Long AND SpinSpeed is NormalStrong
            var rule25 = new FuzzyRule();
            rule25.AddAntecedent("Sensitivity", "Durable");
            rule25.AddAntecedent("Dirtiness", "High");
            rule25.AddAntecedent("LoadAmount", "Low");
            rule25.AddConsequent("DetergentAmount", "Medium");
            rule25.AddConsequent("WashingTime", "Long");
            rule25.AddConsequent("SpinSpeed", "NormalStrong");
            _rules.Add(rule25);

            // Rule 26: IF Sensitivity is Durable AND Dirtiness is High AND LoadAmount is Medium 
            // THEN DetergentAmount is High AND WashingTime is Long AND SpinSpeed is Strong
            var rule26 = new FuzzyRule();
            rule26.AddAntecedent("Sensitivity", "Durable");
            rule26.AddAntecedent("Dirtiness", "High");
            rule26.AddAntecedent("LoadAmount", "Medium");
            rule26.AddConsequent("DetergentAmount", "High");
            rule26.AddConsequent("WashingTime", "Long");
            rule26.AddConsequent("SpinSpeed", "Strong");
            _rules.Add(rule26);

            // Rule 27: IF Sensitivity is Durable AND Dirtiness is High AND LoadAmount is High 
            // THEN DetergentAmount is VeryHigh AND WashingTime is Long AND SpinSpeed is Strong
            var rule27 = new FuzzyRule();
            rule27.AddAntecedent("Sensitivity", "Durable");
            rule27.AddAntecedent("Dirtiness", "High");
            rule27.AddAntecedent("LoadAmount", "High");
            rule27.AddConsequent("DetergentAmount", "VeryHigh");
            rule27.AddConsequent("WashingTime", "Long");
            rule27.AddConsequent("SpinSpeed", "Strong");
            _rules.Add(rule27);
        }

        /// <summary>
        /// Processes the inputs through the fuzzy inference system
        /// </summary>
        public FuzzyInferenceResult Process(double sensitivity, double dirtiness, double loadAmount)
        {
            // 1. Fuzzify inputs
            _fuzzifiedInputs.Clear();
            _fuzzifiedInputs["Sensitivity"] = Sensitivity.Fuzzify(sensitivity);
            _fuzzifiedInputs["Dirtiness"] = Dirtiness.Fuzzify(dirtiness);
            _fuzzifiedInputs["LoadAmount"] = LoadAmount.Fuzzify(loadAmount);

            // 2. Evaluate rules and apply implications
            _outputActivations.Clear();
            _outputActivations["DetergentAmount"] = new Dictionary<string, double>();
            _outputActivations["WashingTime"] = new Dictionary<string, double>();
            _outputActivations["SpinSpeed"] = new Dictionary<string, double>();

            foreach (var rule in _rules)
            {
                double activationLevel = rule.Evaluate(_fuzzifiedInputs);
                
                if (activationLevel > 0)
                {
                    var consequents = rule.GetConsequents();
                    foreach (var consequent in consequents)
                    {
                        var variableName = consequent.Key;
                        var fuzzySetName = consequent.Value;
                        
                        // Store max activation level for each output fuzzy set (Mamdani max-min)
                        if (!_outputActivations[variableName].ContainsKey(fuzzySetName) || 
                            _outputActivations[variableName][fuzzySetName] < activationLevel)
                        {
                            _outputActivations[variableName][fuzzySetName] = activationLevel;
                        }
                    }
                }
            }

            // 3. Defuzzify outputs
            var result = new FuzzyInferenceResult
            {
                // Centroid defuzzification
                CrispDetergentAmount = DetergentAmount.DefuzzifyCentroid(_outputActivations["DetergentAmount"]),
                CrispWashingTime = WashingTime.DefuzzifyCentroid(_outputActivations["WashingTime"]),
                CrispSpinSpeed = SpinSpeed.DefuzzifyCentroid(_outputActivations["SpinSpeed"]),
                
                // Weighted average defuzzification
                WeightedAverageDetergentAmount = DetergentAmount.DefuzzifyWeightedAverage(_outputActivations["DetergentAmount"]),
                WeightedAverageWashingTime = WashingTime.DefuzzifyWeightedAverage(_outputActivations["WashingTime"]),
                WeightedAverageSpinSpeed = SpinSpeed.DefuzzifyWeightedAverage(_outputActivations["SpinSpeed"])
            };
            
            LastResult = result;
            return result;
        }

        /// <summary>
        /// Gets all rules with their activation levels
        /// </summary>
        public List<FuzzyRule> GetActivatedRules()
        {
            return _rules;
        }
    }

    /// <summary>
    /// Stores the result of the fuzzy inference process
    /// </summary>
    public class FuzzyInferenceResult
    {
        // Centroid method results
        public double CrispDetergentAmount { get; set; }
        public double CrispWashingTime { get; set; }
        public double CrispSpinSpeed { get; set; }
        
        // Weighted average method results
        public double WeightedAverageDetergentAmount { get; set; }
        public double WeightedAverageWashingTime { get; set; }
        public double WeightedAverageSpinSpeed { get; set; }
    }
}