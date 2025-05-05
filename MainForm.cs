using System;
using System.Drawing;
using System.Windows.Forms;
using FuzzyWashingMachine.Engine;
using FuzzyWashingMachine.Visualization;

namespace FuzzyWashingMachine
{
    public partial class MainForm : Form
    {
        private FuzzyInferenceSystem _fis;
        private FuzzyVisualizer _visualizer;

        public MainForm()
        {
            InitializeComponent();
            InitializeFuzzySystem();
            _visualizer = new FuzzyVisualizer();
        }

        private void InitializeFuzzySystem()
        {
            _fis = new FuzzyInferenceSystem();
            _fis.Initialize();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                // Get input values from sliders
                double sensitivity = (double)trackSensitivity.Value;
                double dirtiness = (double)trackDirtiness.Value;
                double loadAmount = (double)trackLoadAmount.Value;

                // Update input values display
                lblSensitivityValue.Text = sensitivity.ToString("0.0");
                lblDirtinessValue.Text = dirtiness.ToString("0.0");
                lblLoadAmountValue.Text = loadAmount.ToString("0.0");

                // Process the inputs through FIS
                var results = _fis.Process(sensitivity, dirtiness, loadAmount);

                // Display results
                DisplayResults(results);

                // Update rule visualization
                UpdateRuleVisualization();

                // Show membership function charts
                UpdateMembershipFunctionCharts();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Processing Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisplayResults(FuzzyInferenceResult results)
        {
            // Display crisp output values
            lblDetergentAmountValue.Text = results.CrispDetergentAmount.ToString("0.00") + " ml";
            lblWashingTimeValue.Text = results.CrispWashingTime.ToString("0.00") + " min";
            lblSpinSpeedValue.Text = results.CrispSpinSpeed.ToString("0.00");

            // Display weighted average results
            lblWADetergentValue.Text = results.WeightedAverageDetergentAmount.ToString("0.00") + " ml";
            lblWAWashingTimeValue.Text = results.WeightedAverageWashingTime.ToString("0.00") + " min";
            lblWASpinSpeedValue.Text = results.WeightedAverageSpinSpeed.ToString("0.00");

            // Update progress bars
            progressDetergent.Value = (int)Math.Min(100, (results.CrispDetergentAmount / 300.0) * 100);
            progressWashTime.Value = (int)Math.Min(100, results.CrispWashingTime);
            progressSpinSpeed.Value = (int)Math.Min(100, results.CrispSpinSpeed * 10);
        }

        private void UpdateRuleVisualization()
        {
            // Clear the rule panel
            panelRules.Controls.Clear();

            // Get activated rules
            var activatedRules = _fis.GetActivatedRules();

            int yPos = 10;
            foreach (var rule in activatedRules)
            {
                Label lblRule = new Label
                {
                    Text = rule.ToString(),
                    Location = new Point(10, yPos),
                    AutoSize = true,
                    Font = new Font("Segoe UI", 9)
                };

                if (rule.ActivationLevel > 0)
                {
                    lblRule.ForeColor = Color.Green;
                    lblRule.Font = new Font("Segoe UI", 9, FontStyle.Bold);
                    lblRule.Text += $" (Activation: {rule.ActivationLevel:F2})";
                }
                else
                {
                    lblRule.ForeColor = Color.Gray;
                }

                panelRules.Controls.Add(lblRule);
                yPos += 25;
            }
        }

        private void UpdateMembershipFunctionCharts()
        {
            // Update input charts
            _visualizer.DrawInputMembershipFunctions(chartSensitivity, _fis.Sensitivity, trackSensitivity.Value);
            _visualizer.DrawInputMembershipFunctions(chartDirtiness, _fis.Dirtiness, trackDirtiness.Value);
            _visualizer.DrawInputMembershipFunctions(chartLoadAmount, _fis.LoadAmount, trackLoadAmount.Value);

            // Update output charts
            _visualizer.DrawOutputMembershipFunctions(chartDetergentAmount, _fis.DetergentAmount);
            _visualizer.DrawOutputMembershipFunctions(chartWashingTime, _fis.WashingTime);
            _visualizer.DrawOutputMembershipFunctions(chartSpinSpeed, _fis.SpinSpeed);
        }

        private void trackSensitivity_Scroll(object sender, EventArgs e)
        {
            lblSensitivityValue.Text = trackSensitivity.Value.ToString("0.0");
            _visualizer.DrawInputMembershipFunctions(chartSensitivity, _fis.Sensitivity, trackSensitivity.Value);
        }

        private void trackDirtiness_Scroll(object sender, EventArgs e)
        {
            lblDirtinessValue.Text = trackDirtiness.Value.ToString("0.0");
            _visualizer.DrawInputMembershipFunctions(chartDirtiness, _fis.Dirtiness, trackDirtiness.Value);
        }

        private void trackLoadAmount_Scroll(object sender, EventArgs e)
        {
            lblLoadAmountValue.Text = trackLoadAmount.Value.ToString("0.0");
            _visualizer.DrawInputMembershipFunctions(chartLoadAmount, _fis.LoadAmount, trackLoadAmount.Value);
        }
    }
}