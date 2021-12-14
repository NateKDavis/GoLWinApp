
namespace GoLWinApp
{
    partial class ModalDialogAge
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
            this.AgeOK = new System.Windows.Forms.Button();
            this.AgeCancel = new System.Windows.Forms.Button();
            this.DeathAgeNum = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.DeathAgeNum)).BeginInit();
            this.SuspendLayout();
            // 
            // AgeOK
            // 
            this.AgeOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.AgeOK.Location = new System.Drawing.Point(297, 126);
            this.AgeOK.Name = "AgeOK";
            this.AgeOK.Size = new System.Drawing.Size(75, 23);
            this.AgeOK.TabIndex = 1;
            this.AgeOK.Text = "OK";
            this.AgeOK.UseVisualStyleBackColor = true;
            // 
            // AgeCancel
            // 
            this.AgeCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.AgeCancel.Location = new System.Drawing.Point(216, 126);
            this.AgeCancel.Name = "AgeCancel";
            this.AgeCancel.Size = new System.Drawing.Size(75, 23);
            this.AgeCancel.TabIndex = 2;
            this.AgeCancel.Text = "Cancel";
            this.AgeCancel.UseVisualStyleBackColor = true;
            // 
            // DeathAgeNum
            // 
            this.DeathAgeNum.Location = new System.Drawing.Point(157, 47);
            this.DeathAgeNum.Name = "DeathAgeNum";
            this.DeathAgeNum.Size = new System.Drawing.Size(120, 20);
            this.DeathAgeNum.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(93, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Death Age";
            // 
            // ModalDialogAge
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 161);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.DeathAgeNum);
            this.Controls.Add(this.AgeCancel);
            this.Controls.Add(this.AgeOK);
            this.Name = "ModalDialogAge";
            this.Text = "ModalDialogAge";
            ((System.ComponentModel.ISupportInitialize)(this.DeathAgeNum)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox CellDeath;
        private System.Windows.Forms.Button AgeOK;
        private System.Windows.Forms.Button AgeCancel;
        private System.Windows.Forms.NumericUpDown DeathAgeNum;
        private System.Windows.Forms.Label label1;
    }
}