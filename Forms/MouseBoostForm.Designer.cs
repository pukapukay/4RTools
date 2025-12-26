namespace _4RTools.Forms
{
    partial class MouseBoostForm
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
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.lblToggleKey = new System.Windows.Forms.Label();
            this.txtToggleKey = new System.Windows.Forms.TextBox();
            this.lblMoveSpeed = new System.Windows.Forms.Label();
            this.numMoveSpeed = new System.Windows.Forms.NumericUpDown();
            this.lblDescription = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numMoveSpeed)).BeginInit();
            this.SuspendLayout();
            // 
            // chkEnabled
            // 
            this.chkEnabled.AutoSize = true;
            this.chkEnabled.Location = new System.Drawing.Point(20, 20);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(138, 17);
            this.chkEnabled.TabIndex = 0;
            this.chkEnabled.Text = "Enable MouseBoost";
            this.chkEnabled.UseVisualStyleBackColor = true;
            // 
            // lblToggleKey
            // 
            this.lblToggleKey.AutoSize = true;
            this.lblToggleKey.Location = new System.Drawing.Point(20, 60);
            this.lblToggleKey.Name = "lblToggleKey";
            this.lblToggleKey.Size = new System.Drawing.Size(66, 13);
            this.lblToggleKey.TabIndex = 1;
            this.lblToggleKey.Text = "Toggle Key:";
            // 
            // txtToggleKey
            // 
            this.txtToggleKey.Location = new System.Drawing.Point(100, 57);
            this.txtToggleKey.Name = "txtToggleKey";
            this.txtToggleKey.Size = new System.Drawing.Size(100, 20);
            this.txtToggleKey.TabIndex = 2;
            // 
            // lblMoveSpeed
            // 
            this.lblMoveSpeed.AutoSize = true;
            this.lblMoveSpeed.Location = new System.Drawing.Point(20, 100);
            this.lblMoveSpeed.Name = "lblMoveSpeed";
            this.lblMoveSpeed.Size = new System.Drawing.Size(90, 13);
            this.lblMoveSpeed.TabIndex = 3;
            this.lblMoveSpeed.Text = "Move Speed (ms):";
            // 
            // numMoveSpeed
            // 
            this.numMoveSpeed.Location = new System.Drawing.Point(120, 98);
            this.numMoveSpeed.Maximum = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numMoveSpeed.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMoveSpeed.Name = "numMoveSpeed";
            this.numMoveSpeed.Size = new System.Drawing.Size(80, 20);
            this.numMoveSpeed.TabIndex = 4;
            this.numMoveSpeed.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(20, 140);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(340, 39);
            this.lblDescription.TabIndex = 5;
            this.lblDescription.Text = "MouseBoost sends mouse movement messages to the game client\r\nusing PostMessage. Hold down the toggle key to boost mouse\r\nresponse in the game.";
            // 
            // MouseBoostForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 274);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.numMoveSpeed);
            this.Controls.Add(this.lblMoveSpeed);
            this.Controls.Add(this.txtToggleKey);
            this.Controls.Add(this.lblToggleKey);
            this.Controls.Add(this.chkEnabled);
            this.Name = "MouseBoostForm";
            this.Text = "MouseBoostForm";
            ((System.ComponentModel.ISupportInitialize)(this.numMoveSpeed)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkEnabled;
        private System.Windows.Forms.Label lblToggleKey;
        private System.Windows.Forms.TextBox txtToggleKey;
        private System.Windows.Forms.Label lblMoveSpeed;
        private System.Windows.Forms.NumericUpDown numMoveSpeed;
        private System.Windows.Forms.Label lblDescription;
    }
}
