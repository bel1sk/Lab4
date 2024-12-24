namespace BoardGameUI
{
    partial class PlayerCountForm
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.NumericUpDown numericUpDownPlayers;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.lblMessage = new System.Windows.Forms.Label();
            this.numericUpDownPlayers = new System.Windows.Forms.NumericUpDown();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPlayers)).BeginInit();
            this.SuspendLayout();
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(12, 9);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(177, 13);
            this.lblMessage.TabIndex = 0;
            this.lblMessage.Text = "Выберите количество игроков:";
            // 
            // numericUpDownPlayers
            // 
            this.numericUpDownPlayers.Location = new System.Drawing.Point(15, 35);
            this.numericUpDownPlayers.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numericUpDownPlayers.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numericUpDownPlayers.Name = "numericUpDownPlayers";
            this.numericUpDownPlayers.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownPlayers.TabIndex = 1;
            this.numericUpDownPlayers.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(15, 75);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "OK";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(110, 75);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // PlayerCountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(200, 120);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.numericUpDownPlayers);
            this.Controls.Add(this.lblMessage);
            this.Name = "PlayerCountForm";
            this.Text = "Количество игроков";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPlayers)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
