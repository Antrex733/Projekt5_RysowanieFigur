namespace Projekt2_Nowalski57295
{
    partial class RysowanieFigur_Nowalski
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
            this.lblN = new System.Windows.Forms.Label();
            this.pbRysownica = new System.Windows.Forms.PictureBox();
            this.txtN = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.chlbFiguryGeometryczne = new System.Windows.Forms.CheckedListBox();
            this.lblMenu = new System.Windows.Forms.Label();
            this.btnResetujRysowanieFigur = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnPrzesunLosowo = new System.Windows.Forms.Button();
            this.btnLosujAtrybuty = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.btnWłączenieSlajdera = new System.Windows.Forms.Button();
            this.btnWyłączenieSlajdera = new System.Windows.Forms.Button();
            this.gbTrybyPokazu = new System.Windows.Forms.GroupBox();
            this.txtIndeksTablicyTFG = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rdbManualny = new System.Windows.Forms.RadioButton();
            this.rdbAutomatyczny = new System.Windows.Forms.RadioButton();
            this.btnNastępny = new System.Windows.Forms.Button();
            this.btnPoprzedni = new System.Windows.Forms.Button();
            this.btnPowrot = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbRysownica)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.gbTrybyPokazu.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblN
            // 
            this.lblN.AutoSize = true;
            this.lblN.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblN.Location = new System.Drawing.Point(47, 53);
            this.lblN.Name = "lblN";
            this.lblN.Size = new System.Drawing.Size(113, 34);
            this.lblN.TabIndex = 1;
            this.lblN.Text = "Podaj liczbę figur \r\ngeometrycznych";
            // 
            // pbRysownica
            // 
            this.pbRysownica.Location = new System.Drawing.Point(195, 12);
            this.pbRysownica.Name = "pbRysownica";
            this.pbRysownica.Size = new System.Drawing.Size(850, 474);
            this.pbRysownica.TabIndex = 2;
            this.pbRysownica.TabStop = false;
            // 
            // txtN
            // 
            this.txtN.Location = new System.Drawing.Point(50, 100);
            this.txtN.Name = "txtN";
            this.txtN.Size = new System.Drawing.Size(100, 20);
            this.txtN.TabIndex = 3;
            // 
            // btnStart
            // 
            this.btnStart.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnStart.Location = new System.Drawing.Point(12, 135);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(177, 45);
            this.btnStart.TabIndex = 4;
            this.btnStart.Text = "START\r\n(wykreśl figury)";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // chlbFiguryGeometryczne
            // 
            this.chlbFiguryGeometryczne.FormattingEnabled = true;
            this.chlbFiguryGeometryczne.Items.AddRange(new object[] {
            "Punkt",
            "Linia",
            "Elipsa",
            "Okrąg",
            "Prostokąt",
            "Kwadrat"});
            this.chlbFiguryGeometryczne.Location = new System.Drawing.Point(1074, 77);
            this.chlbFiguryGeometryczne.Name = "chlbFiguryGeometryczne";
            this.chlbFiguryGeometryczne.Size = new System.Drawing.Size(198, 289);
            this.chlbFiguryGeometryczne.TabIndex = 5;
            // 
            // lblMenu
            // 
            this.lblMenu.AutoSize = true;
            this.lblMenu.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblMenu.Location = new System.Drawing.Point(1071, 23);
            this.lblMenu.Name = "lblMenu";
            this.lblMenu.Size = new System.Drawing.Size(203, 51);
            this.lblMenu.TabIndex = 6;
            this.lblMenu.Text = "Zaznacz figury geometryczne, \r\nktóre mają być losowane i \r\nwyświetlanena planszy " +
    "graficznej";
            // 
            // btnResetujRysowanieFigur
            // 
            this.btnResetujRysowanieFigur.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnResetujRysowanieFigur.Location = new System.Drawing.Point(1074, 372);
            this.btnResetujRysowanieFigur.Name = "btnResetujRysowanieFigur";
            this.btnResetujRysowanieFigur.Size = new System.Drawing.Size(198, 50);
            this.btnResetujRysowanieFigur.TabIndex = 7;
            this.btnResetujRysowanieFigur.Text = "Resetuj\r\n(ustaw stan początkowy)";
            this.btnResetujRysowanieFigur.UseVisualStyleBackColor = true;
            this.btnResetujRysowanieFigur.Click += new System.EventHandler(this.btnResetujRysowanieFigur_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // btnPrzesunLosowo
            // 
            this.btnPrzesunLosowo.Enabled = false;
            this.btnPrzesunLosowo.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnPrzesunLosowo.Location = new System.Drawing.Point(12, 195);
            this.btnPrzesunLosowo.Name = "btnPrzesunLosowo";
            this.btnPrzesunLosowo.Size = new System.Drawing.Size(177, 51);
            this.btnPrzesunLosowo.TabIndex = 8;
            this.btnPrzesunLosowo.Text = "Przesuń do lokalizacji wybranej losowo";
            this.btnPrzesunLosowo.UseVisualStyleBackColor = true;
            this.btnPrzesunLosowo.Click += new System.EventHandler(this.btnPrzesunLosowo_Click);
            // 
            // btnLosujAtrybuty
            // 
            this.btnLosujAtrybuty.Enabled = false;
            this.btnLosujAtrybuty.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnLosujAtrybuty.Location = new System.Drawing.Point(12, 264);
            this.btnLosujAtrybuty.Name = "btnLosujAtrybuty";
            this.btnLosujAtrybuty.Size = new System.Drawing.Size(177, 63);
            this.btnLosujAtrybuty.TabIndex = 9;
            this.btnLosujAtrybuty.Text = "Wylosuj nowe atrybuty graficzne i przesuń do losowej lokalizacji";
            this.btnLosujAtrybuty.UseVisualStyleBackColor = true;
            this.btnLosujAtrybuty.Click += new System.EventHandler(this.btnLosujAtrybuty_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tag = "0";
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // btnWłączenieSlajdera
            // 
            this.btnWłączenieSlajdera.Enabled = false;
            this.btnWłączenieSlajdera.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnWłączenieSlajdera.Location = new System.Drawing.Point(12, 378);
            this.btnWłączenieSlajdera.Name = "btnWłączenieSlajdera";
            this.btnWłączenieSlajdera.Size = new System.Drawing.Size(177, 51);
            this.btnWłączenieSlajdera.TabIndex = 10;
            this.btnWłączenieSlajdera.Text = "Włączenie slajdera";
            this.btnWłączenieSlajdera.UseVisualStyleBackColor = true;
            this.btnWłączenieSlajdera.Click += new System.EventHandler(this.btnWłączenieSlajdera_Click);
            // 
            // btnWyłączenieSlajdera
            // 
            this.btnWyłączenieSlajdera.Enabled = false;
            this.btnWyłączenieSlajdera.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnWyłączenieSlajdera.Location = new System.Drawing.Point(12, 435);
            this.btnWyłączenieSlajdera.Name = "btnWyłączenieSlajdera";
            this.btnWyłączenieSlajdera.Size = new System.Drawing.Size(177, 51);
            this.btnWyłączenieSlajdera.TabIndex = 11;
            this.btnWyłączenieSlajdera.Text = "Wyłączenie slajdera";
            this.btnWyłączenieSlajdera.UseVisualStyleBackColor = true;
            this.btnWyłączenieSlajdera.Click += new System.EventHandler(this.btnWyłączenieSlajdera_Click);
            // 
            // gbTrybyPokazu
            // 
            this.gbTrybyPokazu.Controls.Add(this.txtIndeksTablicyTFG);
            this.gbTrybyPokazu.Controls.Add(this.label1);
            this.gbTrybyPokazu.Controls.Add(this.rdbManualny);
            this.gbTrybyPokazu.Controls.Add(this.rdbAutomatyczny);
            this.gbTrybyPokazu.Controls.Add(this.btnNastępny);
            this.gbTrybyPokazu.Controls.Add(this.btnPoprzedni);
            this.gbTrybyPokazu.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gbTrybyPokazu.Location = new System.Drawing.Point(210, 492);
            this.gbTrybyPokazu.Name = "gbTrybyPokazu";
            this.gbTrybyPokazu.Size = new System.Drawing.Size(542, 128);
            this.gbTrybyPokazu.TabIndex = 12;
            this.gbTrybyPokazu.TabStop = false;
            this.gbTrybyPokazu.Text = "Tryb pokazu figur geometrycznych";
            // 
            // txtIndeksTablicyTFG
            // 
            this.txtIndeksTablicyTFG.Enabled = false;
            this.txtIndeksTablicyTFG.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txtIndeksTablicyTFG.Location = new System.Drawing.Point(416, 72);
            this.txtIndeksTablicyTFG.Name = "txtIndeksTablicyTFG";
            this.txtIndeksTablicyTFG.Size = new System.Drawing.Size(100, 25);
            this.txtIndeksTablicyTFG.TabIndex = 16;
            this.txtIndeksTablicyTFG.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtIndeksTablicyTFG.TextChanged += new System.EventHandler(this.txtIndeksTablicyTFG_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(413, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 34);
            this.label1.TabIndex = 15;
            this.label1.Text = "Indeks figury \r\nw tablicy TFG";
            // 
            // rdbManualny
            // 
            this.rdbManualny.AutoSize = true;
            this.rdbManualny.Location = new System.Drawing.Point(6, 72);
            this.rdbManualny.Name = "rdbManualny";
            this.rdbManualny.Size = new System.Drawing.Size(245, 21);
            this.rdbManualny.TabIndex = 1;
            this.rdbManualny.Text = "Manualny (sterowany przyciskami)";
            this.rdbManualny.UseVisualStyleBackColor = true;
            // 
            // rdbAutomatyczny
            // 
            this.rdbAutomatyczny.AutoSize = true;
            this.rdbAutomatyczny.Checked = true;
            this.rdbAutomatyczny.Location = new System.Drawing.Point(6, 45);
            this.rdbAutomatyczny.Name = "rdbAutomatyczny";
            this.rdbAutomatyczny.Size = new System.Drawing.Size(244, 21);
            this.rdbAutomatyczny.TabIndex = 0;
            this.rdbAutomatyczny.TabStop = true;
            this.rdbAutomatyczny.Text = "Automatyczny (sterowany zegarem)";
            this.rdbAutomatyczny.UseVisualStyleBackColor = true;
            // 
            // btnNastępny
            // 
            this.btnNastępny.Enabled = false;
            this.btnNastępny.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnNastępny.Location = new System.Drawing.Point(279, 21);
            this.btnNastępny.Name = "btnNastępny";
            this.btnNastępny.Size = new System.Drawing.Size(97, 45);
            this.btnNastępny.TabIndex = 13;
            this.btnNastępny.Text = "Następny";
            this.btnNastępny.UseVisualStyleBackColor = true;
            this.btnNastępny.Click += new System.EventHandler(this.btnNastępny_Click);
            // 
            // btnPoprzedni
            // 
            this.btnPoprzedni.Enabled = false;
            this.btnPoprzedni.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnPoprzedni.Location = new System.Drawing.Point(279, 78);
            this.btnPoprzedni.Name = "btnPoprzedni";
            this.btnPoprzedni.Size = new System.Drawing.Size(97, 44);
            this.btnPoprzedni.TabIndex = 14;
            this.btnPoprzedni.Text = "Poprzedni";
            this.btnPoprzedni.UseVisualStyleBackColor = true;
            this.btnPoprzedni.Click += new System.EventHandler(this.btnPoprzedni_Click);
            // 
            // btnPowrot
            // 
            this.btnPowrot.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnPowrot.Location = new System.Drawing.Point(1074, 428);
            this.btnPowrot.Name = "btnPowrot";
            this.btnPowrot.Size = new System.Drawing.Size(198, 52);
            this.btnPowrot.TabIndex = 24;
            this.btnPowrot.Text = "Powrót do formularza głównego";
            this.btnPowrot.UseVisualStyleBackColor = true;
            this.btnPowrot.Click += new System.EventHandler(this.btnPowrot_Click);
            // 
            // RysowanieFigur_Nowalski
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1328, 644);
            this.Controls.Add(this.btnPowrot);
            this.Controls.Add(this.gbTrybyPokazu);
            this.Controls.Add(this.btnWyłączenieSlajdera);
            this.Controls.Add(this.btnWłączenieSlajdera);
            this.Controls.Add(this.btnLosujAtrybuty);
            this.Controls.Add(this.btnPrzesunLosowo);
            this.Controls.Add(this.btnResetujRysowanieFigur);
            this.Controls.Add(this.lblMenu);
            this.Controls.Add(this.chlbFiguryGeometryczne);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.txtN);
            this.Controls.Add(this.pbRysownica);
            this.Controls.Add(this.lblN);
            this.Name = "RysowanieFigur_Nowalski";
            this.Text = "Wieloformularzowy prezenter fiugr geometrycznych";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RysowanieFigur_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RysowanieFigur_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pbRysownica)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.gbTrybyPokazu.ResumeLayout(false);
            this.gbTrybyPokazu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblN;
        private System.Windows.Forms.PictureBox pbRysownica;
        private System.Windows.Forms.TextBox txtN;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.CheckedListBox chlbFiguryGeometryczne;
        private System.Windows.Forms.Label lblMenu;
        private System.Windows.Forms.Button btnResetujRysowanieFigur;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.Button btnPrzesunLosowo;
        private System.Windows.Forms.Button btnLosujAtrybuty;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnPoprzedni;
        private System.Windows.Forms.Button btnNastępny;
        private System.Windows.Forms.GroupBox gbTrybyPokazu;
        private System.Windows.Forms.RadioButton rdbManualny;
        private System.Windows.Forms.RadioButton rdbAutomatyczny;
        private System.Windows.Forms.Button btnWyłączenieSlajdera;
        private System.Windows.Forms.Button btnWłączenieSlajdera;
        private System.Windows.Forms.TextBox txtIndeksTablicyTFG;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPowrot;
    }
}