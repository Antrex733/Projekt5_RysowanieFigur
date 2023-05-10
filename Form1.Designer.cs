namespace Projekt2_Nowalski57295
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSlajder = new System.Windows.Forms.Button();
            this.btnKreslenieFigurMysz = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.SuspendLayout();
            // 
            // btnSlajder
            // 
            this.btnSlajder.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnSlajder.Location = new System.Drawing.Point(262, 263);
            this.btnSlajder.Name = "btnSlajder";
            this.btnSlajder.Size = new System.Drawing.Size(458, 115);
            this.btnSlajder.TabIndex = 1;
            this.btnSlajder.Text = "Prezentacja figur ze slajderem";
            this.btnSlajder.UseVisualStyleBackColor = true;
            this.btnSlajder.Click += new System.EventHandler(this.btnRysowanieFigur_Click);
            // 
            // btnKreslenieFigurMysz
            // 
            this.btnKreslenieFigurMysz.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnKreslenieFigurMysz.Location = new System.Drawing.Point(778, 266);
            this.btnKreslenieFigurMysz.Name = "btnKreslenieFigurMysz";
            this.btnKreslenieFigurMysz.Size = new System.Drawing.Size(458, 115);
            this.btnKreslenieFigurMysz.TabIndex = 2;
            this.btnKreslenieFigurMysz.Text = "Kreślenie figur i linii ";
            this.btnKreslenieFigurMysz.UseVisualStyleBackColor = true;
            this.btnKreslenieFigurMysz.Click += new System.EventHandler(this.btnKreslenieFigurMysz_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1490, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1490, 667);
            this.Controls.Add(this.btnKreslenieFigurMysz);
            this.Controls.Add(this.btnSlajder);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Wieloformularzowwy prezenter fiugr geometrycznych";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSlajder;
        private System.Windows.Forms.Button btnKreslenieFigurMysz;
        private System.Windows.Forms.MenuStrip menuStrip1;
    }
}

