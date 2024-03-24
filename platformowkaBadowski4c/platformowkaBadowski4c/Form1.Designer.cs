namespace platformowkaBadowski4c
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            coins = new Label();
            keys = new Label();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(937, 351);
            panel1.TabIndex = 0;
            // 
            // coins
            // 
            coins.AutoSize = true;
            coins.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            coins.Location = new Point(970, 27);
            coins.Name = "coins";
            coins.Size = new Size(100, 28);
            coins.TabIndex = 0;
            coins.Text = "Monety: 0";
            // 
            // keys
            // 
            keys.AutoSize = true;
            keys.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            keys.Location = new Point(970, 91);
            keys.Name = "keys";
            keys.Size = new Size(88, 28);
            keys.TabIndex = 1;
            keys.Text = "Klucze: 0";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1183, 561);
            Controls.Add(keys);
            Controls.Add(coins);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "Form1";
            Text = "Squareformer";
            KeyPress += Form1_KeyPress;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label coins;
        private Label keys;
    }
}