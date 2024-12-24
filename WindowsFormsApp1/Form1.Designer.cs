namespace BoardGameUI
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.pbGameBoard = new System.Windows.Forms.PictureBox();
            this.btnRollDice = new System.Windows.Forms.Button();
            this.listBoxPlayerStatus = new System.Windows.Forms.ListBox();
            this.panelBoard = new System.Windows.Forms.Panel();
            this.DetailStatus = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbGameBoard)).BeginInit();
            this.SuspendLayout();
            // 
            // pbGameBoard
            // 
            this.pbGameBoard.Location = new System.Drawing.Point(270, -4);
            this.pbGameBoard.Name = "pbGameBoard";
            this.pbGameBoard.Size = new System.Drawing.Size(500, 500);
            this.pbGameBoard.TabIndex = 0;
            this.pbGameBoard.TabStop = false;
            // 
            // btnRollDice
            // 
            this.btnRollDice.Location = new System.Drawing.Point(1134, 108);
            this.btnRollDice.Name = "btnRollDice";
            this.btnRollDice.Size = new System.Drawing.Size(121, 61);
            this.btnRollDice.TabIndex = 2;
            this.btnRollDice.Text = "Бросить кубик";
            this.btnRollDice.UseVisualStyleBackColor = true;
            this.btnRollDice.Click += new System.EventHandler(this.btnRollDice_Click);
            // 
            // listBoxPlayerStatus
            // 
            this.listBoxPlayerStatus.FormattingEnabled = true;
            this.listBoxPlayerStatus.Location = new System.Drawing.Point(1028, 401);
            this.listBoxPlayerStatus.Name = "listBoxPlayerStatus";
            this.listBoxPlayerStatus.Size = new System.Drawing.Size(328, 95);
            this.listBoxPlayerStatus.TabIndex = 5;
            // 
            // panelBoard
            // 
            this.panelBoard.Location = new System.Drawing.Point(131, 68);
            this.panelBoard.Name = "panelBoard";
            this.panelBoard.Size = new System.Drawing.Size(686, 377);
            this.panelBoard.TabIndex = 7;
            // 
            // DetailStatus
            // 
            this.DetailStatus.FormattingEnabled = true;
            this.DetailStatus.Location = new System.Drawing.Point(1028, 268);
            this.DetailStatus.Name = "DetailStatus";
            this.DetailStatus.Size = new System.Drawing.Size(328, 95);
            this.DetailStatus.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1368, 569);
            this.Controls.Add(this.DetailStatus);
            this.Controls.Add(this.btnRollDice);
            this.Controls.Add(this.panelBoard);
            this.Controls.Add(this.listBoxPlayerStatus);
            this.Controls.Add(this.pbGameBoard);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pbGameBoard)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbGameBoard;
        private System.Windows.Forms.Button btnRollDice;
        private System.Windows.Forms.ListBox listBoxPlayerStatus;
        private System.Windows.Forms.Panel panelBoard;
        private System.Windows.Forms.ListBox DetailStatus;
    }
}

