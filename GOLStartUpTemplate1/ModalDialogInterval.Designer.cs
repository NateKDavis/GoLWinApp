
namespace GOLStartUpTemplate1
{
    partial class ModalDialogInterval
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
            this.UniverseIntervalOK = new System.Windows.Forms.Button();
            this.UniverseIntervalCancel = new System.Windows.Forms.Button();
            this.IntervalNum = new System.Windows.Forms.NumericUpDown();
            this.UniverseIntervalLabel = new System.Windows.Forms.Label();
            this.UniverseIntervalTooltip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.IntervalNum)).BeginInit();
            this.SuspendLayout();
            // 
            // UniverseIntervalOK
            // 
            this.UniverseIntervalOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.UniverseIntervalOK.Location = new System.Drawing.Point(297, 126);
            this.UniverseIntervalOK.Name = "UniverseIntervalOK";
            this.UniverseIntervalOK.Size = new System.Drawing.Size(75, 23);
            this.UniverseIntervalOK.TabIndex = 0;
            this.UniverseIntervalOK.Text = "OK";
            this.UniverseIntervalOK.UseVisualStyleBackColor = true;
            // 
            // UniverseIntervalCancel
            // 
            this.UniverseIntervalCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.UniverseIntervalCancel.Location = new System.Drawing.Point(216, 126);
            this.UniverseIntervalCancel.Name = "UniverseIntervalCancel";
            this.UniverseIntervalCancel.Size = new System.Drawing.Size(75, 23);
            this.UniverseIntervalCancel.TabIndex = 1;
            this.UniverseIntervalCancel.Text = "Cancel";
            this.UniverseIntervalCancel.UseVisualStyleBackColor = true;
            // 
            // IntervalNum
            // 
            this.IntervalNum.Location = new System.Drawing.Point(161, 57);
            this.IntervalNum.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.IntervalNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.IntervalNum.Name = "IntervalNum";
            this.IntervalNum.Size = new System.Drawing.Size(120, 20);
            this.IntervalNum.TabIndex = 2;
            this.IntervalNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // UniverseIntervalLabel
            // 
            this.UniverseIntervalLabel.AutoSize = true;
            this.UniverseIntervalLabel.Location = new System.Drawing.Point(113, 59);
            this.UniverseIntervalLabel.Name = "UniverseIntervalLabel";
            this.UniverseIntervalLabel.Size = new System.Drawing.Size(42, 13);
            this.UniverseIntervalLabel.TabIndex = 3;
            this.UniverseIntervalLabel.Text = "Interval";
            // 
            // UniverseIntervalTooltip
            // 
            this.UniverseIntervalTooltip.Tag = "Milliseconds between each generation";
            // 
            // ModalDialogInterval
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 161);
            this.Controls.Add(this.UniverseIntervalLabel);
            this.Controls.Add(this.IntervalNum);
            this.Controls.Add(this.UniverseIntervalCancel);
            this.Controls.Add(this.UniverseIntervalOK);
            this.Name = "ModalDialogInterval";
            this.Text = "Universe Interval";
            ((System.ComponentModel.ISupportInitialize)(this.IntervalNum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button UniverseIntervalOK;
        private System.Windows.Forms.Button UniverseIntervalCancel;
        private System.Windows.Forms.NumericUpDown IntervalNum;
        private System.Windows.Forms.Label UniverseIntervalLabel;
        private System.Windows.Forms.ToolTip UniverseIntervalTooltip;
    }
}