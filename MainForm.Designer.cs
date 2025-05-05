using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace FuzzyWashingMachine
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();

            // Main Form
            this.SuspendLayout();
            this.Text = "Fuzzy Washing Machine Controller";
            this.Size = new System.Drawing.Size(1200, 800);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            // Input Panel
            this.panelInput = new Panel();
            this.panelInput.Location = new Point(20, 20);
            this.panelInput.Size = new Size(350, 250);
            this.panelInput.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(this.panelInput);

            Label lblInputTitle = new Label();
            lblInputTitle.Text = "Inputs";
            lblInputTitle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblInputTitle.Location = new Point(10, 10);
            lblInputTitle.AutoSize = true;
            this.panelInput.Controls.Add(lblInputTitle);

            // Sensitivity Input
            Label lblSensitivity = new Label();
            lblSensitivity.Text = "Sensitivity:";
            lblSensitivity.Location = new Point(10, 50);
            lblSensitivity.Size = new Size(100, 20);
            this.panelInput.Controls.Add(lblSensitivity);

            this.lblSensitivityValue = new Label();
            this.lblSensitivityValue.Text = "5.0";
            this.lblSensitivityValue.Location = new Point(310, 50);
            this.lblSensitivityValue.Size = new Size(30, 20);
            this.lblSensitivityValue.TextAlign = ContentAlignment.TopRight;
            this.panelInput.Controls.Add(this.lblSensitivityValue);

            this.trackSensitivity = new TrackBar();
            this.trackSensitivity.Location = new Point(110, 45);
            this.trackSensitivity.Size = new Size(200, 45);
            this.trackSensitivity.Minimum = 0;
            this.trackSensitivity.Maximum = 10;
            this.trackSensitivity.Value = 5;
            this.trackSensitivity.TickFrequency = 1;
            this.trackSensitivity.Scroll += new EventHandler(this.trackSensitivity_Scroll);
            this.panelInput.Controls.Add(this.trackSensitivity);

            // Dirtiness Input
            Label lblDirtiness = new Label();
            lblDirtiness.Text = "Dirtiness:";
            lblDirtiness.Location = new Point(10, 100);
            lblDirtiness.Size = new Size(100, 20);
            this.panelInput.Controls.Add(lblDirtiness);

            this.lblDirtinessValue = new Label();
            this.lblDirtinessValue.Text = "5.0";
            this.lblDirtinessValue.Location = new Point(310, 100);
            this.lblDirtinessValue.Size = new Size(30, 20);
            this.lblDirtinessValue.TextAlign = ContentAlignment.TopRight;
            this.panelInput.Controls.Add(this.lblDirtinessValue);

            this.trackDirtiness = new TrackBar();
            this.trackDirtiness.Location = new Point(110, 95);
            this.trackDirtiness.Size = new Size(200, 45);
            this.trackDirtiness.Minimum = 0;
            this.trackDirtiness.Maximum = 10;
            this.trackDirtiness.Value = 5;
            this.trackDirtiness.TickFrequency = 1;
            this.trackDirtiness.Scroll += new EventHandler(this.trackDirtiness_Scroll);
            this.panelInput.Controls.Add(this.trackDirtiness);

            // Load Amount Input
            Label lblLoadAmount = new Label();
            lblLoadAmount.Text = "Load Amount:";
            lblLoadAmount.Location = new Point(10, 150);
            lblLoadAmount.Size = new Size(100, 20);
            this.panelInput.Controls.Add(lblLoadAmount);

            this.lblLoadAmountValue = new Label();
            this.lblLoadAmountValue.Text = "5.0";
            this.lblLoadAmountValue.Location = new Point(310, 150);
            this.lblLoadAmountValue.Size = new Size(30, 20);
            this.lblLoadAmountValue.TextAlign = ContentAlignment.TopRight;
            this.panelInput.Controls.Add(this.lblLoadAmountValue);

            this.trackLoadAmount = new TrackBar();
            this.trackLoadAmount.Location = new Point(110, 145);
            this.trackLoadAmount.Size = new Size(200, 45);
            this.trackLoadAmount.Minimum = 0;
            this.trackLoadAmount.Maximum = 10;
            this.trackLoadAmount.Value = 5;
            this.trackLoadAmount.TickFrequency = 1;
            this.trackLoadAmount.Scroll += new EventHandler(this.trackLoadAmount_Scroll);
            this.panelInput.Controls.Add(this.trackLoadAmount);

            // Calculate Button
            this.btnCalculate = new Button();
            this.btnCalculate.Text = "Calculate";
            this.btnCalculate.Location = new Point(120, 200);
            this.btnCalculate.Size = new Size(120, 35);
            this.btnCalculate.BackColor = SystemColors.Highlight;
            this.btnCalculate.ForeColor = Color.White;
            this.btnCalculate.FlatStyle = FlatStyle.Flat;
            this.btnCalculate.Click += new EventHandler(this.btnCalculate_Click);
            this.panelInput.Controls.Add(this.btnCalculate);

            // Output Panel
            this.panelOutput = new Panel();
            this.panelOutput.Location = new Point(20, 280);
            this.panelOutput.Size = new Size(350, 250);
            this.panelOutput.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(this.panelOutput);

            Label lblOutputTitle = new Label();
            lblOutputTitle.Text = "Outputs (Centroid)";
            lblOutputTitle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblOutputTitle.Location = new Point(10, 10);
            lblOutputTitle.AutoSize = true;
            this.panelOutput.Controls.Add(lblOutputTitle);

            // Detergent Amount Output
            Label lblDetergentAmount = new Label();
            lblDetergentAmount.Text = "Detergent Amount:";
            lblDetergentAmount.Location = new Point(10, 50);
            lblDetergentAmount.Size = new Size(120, 20);
            this.panelOutput.Controls.Add(lblDetergentAmount);

            this.lblDetergentAmountValue = new Label();
            this.lblDetergentAmountValue.Text = "0.0 ml";
            this.lblDetergentAmountValue.Location = new Point(270, 50);
            this.lblDetergentAmountValue.Size = new Size(70, 20);
            this.lblDetergentAmountValue.TextAlign = ContentAlignment.TopRight;
            this.panelOutput.Controls.Add(this.lblDetergentAmountValue);

            this.progressDetergent = new ProgressBar();
            this.progressDetergent.Location = new Point(130, 50);
            this.progressDetergent.Size = new Size(130, 20);
            this.progressDetergent.Minimum = 0;
            this.progressDetergent.Maximum = 100;
            this.panelOutput.Controls.Add(this.progressDetergent);

            // Washing Time Output
            Label lblWashingTime = new Label();
            lblWashingTime.Text = "Washing Time:";
            lblWashingTime.Location = new Point(10, 90);
            lblWashingTime.Size = new Size(120, 20);
            this.panelOutput.Controls.Add(lblWashingTime);

            this.lblWashingTimeValue = new Label();
            this.lblWashingTimeValue.Text = "0.0 min";
            this.lblWashingTimeValue.Location = new Point(270, 90);
            this.lblWashingTimeValue.Size = new Size(70, 20);
            this.lblWashingTimeValue.TextAlign = ContentAlignment.TopRight;
            this.panelOutput.Controls.Add(this.lblWashingTimeValue);

            this.progressWashTime = new ProgressBar();
            this.progressWashTime.Location = new Point(130, 90);
            this.progressWashTime.Size = new Size(130, 20);
            this.progressWashTime.Minimum = 0;
            this.progressWashTime.Maximum = 100;
            this.panelOutput.Controls.Add(this.progressWashTime);

            // Spin Speed Output
            Label lblSpinSpeed = new Label();
            lblSpinSpeed.Text = "Spin Speed:";
            lblSpinSpeed.Location = new Point(10, 130);
            lblSpinSpeed.Size = new Size(120, 20);
            this.panelOutput.Controls.Add(lblSpinSpeed);

            this.lblSpinSpeedValue = new Label();
            this.lblSpinSpeedValue.Text = "0.0";
            this.lblSpinSpeedValue.Location = new Point(270, 130);
            this.lblSpinSpeedValue.Size = new Size(70, 20);
            this.lblSpinSpeedValue.TextAlign = ContentAlignment.TopRight;
            this.panelOutput.Controls.Add(this.lblSpinSpeedValue);

            this.progressSpinSpeed = new ProgressBar();
            this.progressSpinSpeed.Location = new Point(130, 130);
            this.progressSpinSpeed.Size = new Size(130, 20);
            this.progressSpinSpeed.Minimum = 0;
            this.progressSpinSpeed.Maximum = 100;
            this.panelOutput.Controls.Add(this.progressSpinSpeed);

            // Weighted Average Results
            Label lblWATitle = new Label();
            lblWATitle.Text = "Weighted Average Results";
            lblWATitle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            lblWATitle.Location = new Point(10, 170);
            lblWATitle.Size = new Size(200, 20);
            this.panelOutput.Controls.Add(lblWATitle);

            Label lblWADetergent = new Label();
            lblWADetergent.Text = "Detergent:";
            lblWADetergent.Location = new Point(20, 195);
            lblWADetergent.Size = new Size(100, 20);
            this.panelOutput.Controls.Add(lblWADetergent);

            this.lblWADetergentValue = new Label();
            this.lblWADetergentValue.Text = "0.0 ml";
            this.lblWADetergentValue.Location = new Point(120, 195);
            this.lblWADetergentValue.Size = new Size(70, 20);
            this.panelOutput.Controls.Add(this.lblWADetergentValue);

            Label lblWAWashingTime = new Label();
            lblWAWashingTime.Text = "Time:";
            lblWAWashingTime.Location = new Point(200, 195);
            lblWAWashingTime.Size = new Size(50, 20);
            this.panelOutput.Controls.Add(lblWAWashingTime);

            this.lblWAWashingTimeValue = new Label();
            this.lblWAWashingTimeValue.Text = "0.0 min";
            this.lblWAWashingTimeValue.Location = new Point(250, 195);
            this.lblWAWashingTimeValue.Size = new Size(70, 20);
            this.panelOutput.Controls.Add(this.lblWAWashingTimeValue);

            Label lblWASpinSpeed = new Label();
            lblWASpinSpeed.Text = "Spin:";
            lblWASpinSpeed.Location = new Point(20, 220);
            lblWASpinSpeed.Size = new Size(50, 20);
            this.panelOutput.Controls.Add(lblWASpinSpeed);

            this.lblWASpinSpeedValue = new Label();
            this.lblWASpinSpeedValue.Text = "0.0";
            this.lblWASpinSpeedValue.Location = new Point(70, 220);
            this.lblWASpinSpeedValue.Size = new Size(50, 20);
            this.panelOutput.Controls.Add(this.lblWASpinSpeedValue);

            // Rules Panel
            this.panelRules = new Panel();
            this.panelRules.Location = new Point(20, 540);
            this.panelRules.Size = new Size(350, 220);
            this.panelRules.BorderStyle = BorderStyle.FixedSingle;
            this.panelRules.AutoScroll = true;
            this.Controls.Add(this.panelRules);

            Label lblRulesTitle = new Label();
            lblRulesTitle.Text = "Activated Rules";
            lblRulesTitle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblRulesTitle.Location = new Point(10, 10);
            lblRulesTitle.AutoSize = true;
            this.panelRules.Controls.Add(lblRulesTitle);

            // Membership Function Charts
            // Input membership function charts
            this.chartSensitivity = new Chart();
            this.chartSensitivity.Location = new Point(390, 20);
            this.chartSensitivity.Size = new Size(380, 180);
            this.chartSensitivity.BorderlineColor = Color.Black;
            this.chartSensitivity.BorderlineDashStyle = ChartDashStyle.Solid;
            this.chartSensitivity.BorderlineWidth = 1;
            chartArea1 = new ChartArea();
            chartArea1.Name = "ChartArea1";
            chartArea1.AxisX.Title = "Sensitivity";
            chartArea1.AxisY.Title = "Membership";
            chartArea1.AxisX.Minimum = 0;
            chartArea1.AxisX.Maximum = 10;
            chartArea1.AxisY.Minimum = 0;
            chartArea1.AxisY.Maximum = 1;
            this.chartSensitivity.ChartAreas.Add(chartArea1);
            this.Controls.Add(this.chartSensitivity);

            this.chartDirtiness = new Chart();
            this.chartDirtiness.Location = new Point(390, 210);
            this.chartDirtiness.Size = new Size(380, 180);
            this.chartDirtiness.BorderlineColor = Color.Black;
            this.chartDirtiness.BorderlineDashStyle = ChartDashStyle.Solid;
            this.chartDirtiness.BorderlineWidth = 1;
            chartArea2 = new ChartArea();
            chartArea2.Name = "ChartArea1";
            chartArea2.AxisX.Title = "Dirtiness";
            chartArea2.AxisY.Title = "Membership";
            chartArea2.AxisX.Minimum = 0;
            chartArea2.AxisX.Maximum = 10;
            chartArea2.AxisY.Minimum = 0;
            chartArea2.AxisY.Maximum = 1;
            this.chartDirtiness.ChartAreas.Add(chartArea2);
            this.Controls.Add(this.chartDirtiness);

            this.chartLoadAmount = new Chart();
            this.chartLoadAmount.Location = new Point(390, 400);
            this.chartLoadAmount.Size = new Size(380, 180);
            this.chartLoadAmount.BorderlineColor = Color.Black;
            this.chartLoadAmount.BorderlineDashStyle = ChartDashStyle.Solid;
            this.chartLoadAmount.BorderlineWidth = 1;
            chartArea3 = new ChartArea();
            chartArea3.Name = "ChartArea1";
            chartArea3.AxisX.Title = "Load Amount";
            chartArea3.AxisY.Title = "Membership";
            chartArea3.AxisX.Minimum = 0;
            chartArea3.AxisX.Maximum = 10;
            chartArea3.AxisY.Minimum = 0;
            chartArea3.AxisY.Maximum = 1;
            this.chartLoadAmount.ChartAreas.Add(chartArea3);
            this.Controls.Add(this.chartLoadAmount);

            // Output membership function charts
            this.chartDetergentAmount = new Chart();
            this.chartDetergentAmount.Location = new Point(780, 20);
            this.chartDetergentAmount.Size = new Size(380, 180);
            this.chartDetergentAmount.BorderlineColor = Color.Black;
            this.chartDetergentAmount.BorderlineDashStyle = ChartDashStyle.Solid;
            this.chartDetergentAmount.BorderlineWidth = 1;
            chartArea4 = new ChartArea();
            chartArea4.Name = "ChartArea1";
            chartArea4.AxisX.Title = "Detergent Amount";
            chartArea4.AxisY.Title = "Membership";
            chartArea4.AxisX.Minimum = 0;
            chartArea4.AxisX.Maximum = 300;
            chartArea4.AxisY.Minimum = 0;
            chartArea4.AxisY.Maximum = 1;
            this.chartDetergentAmount.ChartAreas.Add(chartArea4);
            this.Controls.Add(this.chartDetergentAmount);

            this.chartWashingTime = new Chart();
            this.chartWashingTime.Location = new Point(780, 210);
            this.chartWashingTime.Size = new Size(380, 180);
            this.chartWashingTime.BorderlineColor = Color.Black;
            this.chartWashingTime.BorderlineDashStyle = ChartDashStyle.Solid;
            this.chartWashingTime.BorderlineWidth = 1;
            chartArea5 = new ChartArea();
            chartArea5.Name = "ChartArea1";
            chartArea5.AxisX.Title = "Washing Time";
            chartArea5.AxisY.Title = "Membership";
            chartArea5.AxisX.Minimum = 0;
            chartArea5.AxisX.Maximum = 100;
            chartArea5.AxisY.Minimum = 0;
            chartArea5.AxisY.Maximum = 1;
            this.chartWashingTime.ChartAreas.Add(chartArea5);
            this.Controls.Add(this.chartWashingTime);

            this.chartSpinSpeed = new Chart();
            this.chartSpinSpeed.Location = new Point(780, 400);
            this.chartSpinSpeed.Size = new Size(380, 180);
            this.chartSpinSpeed.BorderlineColor = Color.Black;
            this.chartSpinSpeed.BorderlineDashStyle = ChartDashStyle.Solid;
            this.chartSpinSpeed.BorderlineWidth = 1;
            chartArea6 = new ChartArea();
            chartArea6.Name = "ChartArea1";
            chartArea6.AxisX.Title = "Spin Speed";
            chartArea6.AxisY.Title = "Membership";
            chartArea6.AxisX.Minimum = 0;
            chartArea6.AxisX.Maximum = 10;
            chartArea6.AxisY.Minimum = 0;
            chartArea6.AxisY.Maximum = 1;
            this.chartSpinSpeed.ChartAreas.Add(chartArea6);
            this.Controls.Add(this.chartSpinSpeed);

            // Process Info Panel
            this.panelProcessInfo = new Panel();
            this.panelProcessInfo.Location = new Point(390, 590);
            this.panelProcessInfo.Size = new Size(770, 170);
            this.panelProcessInfo.BorderStyle = BorderStyle.FixedSingle;
            this.panelProcessInfo.AutoScroll = true;
            this.Controls.Add(this.panelProcessInfo);

            Label lblProcessTitle = new Label();
            lblProcessTitle.Text = "Fuzzy Inference Process";
            lblProcessTitle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblProcessTitle.Location = new Point(10, 10);
            lblProcessTitle.AutoSize = true;
            this.panelProcessInfo.Controls.Add(lblProcessTitle);

            Label lblProcessInfo = new Label();
            lblProcessInfo.Text = "1. Inputs are fuzzified using membership functions\n" +
                                  "2. Rules are evaluated to determine activation levels\n" +
                                  "3. Activated rules produce fuzzy output sets\n" +
                                  "4. Aggregation combines all output fuzzy sets\n" +
                                  "5. Defuzzification produces crisp output values";
            lblProcessInfo.Location = new Point(20, 40);
            lblProcessInfo.Size = new Size(730, 100);
            lblProcessInfo.Font = new Font("Segoe UI", 10);
            this.panelProcessInfo.Controls.Add(lblProcessInfo);

            this.ResumeLayout(false);
        }

        #endregion

        private Panel panelInput;
        private Panel panelOutput;
        private Panel panelRules;
        private Panel panelProcessInfo;

        private TrackBar trackSensitivity;
        private TrackBar trackDirtiness;
        private TrackBar trackLoadAmount;

        private Label lblSensitivityValue;
        private Label lblDirtinessValue;
        private Label lblLoadAmountValue;

        private Label lblDetergentAmountValue;
        private Label lblWashingTimeValue;
        private Label lblSpinSpeedValue;

        private Label lblWADetergentValue;
        private Label lblWAWashingTimeValue;
        private Label lblWASpinSpeedValue;

        private ProgressBar progressDetergent;
        private ProgressBar progressWashTime;
        private ProgressBar progressSpinSpeed;

        private Button btnCalculate;

        private Chart chartSensitivity;
        private Chart chartDirtiness;
        private Chart chartLoadAmount;
        private Chart chartDetergentAmount;
        private Chart chartWashingTime;
        private Chart chartSpinSpeed;
    }
}