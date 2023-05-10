using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;//nowa do rysowania
//dodanie przestrzeni nazw klasy FiguryGeometryczne, która udostępni deklaracje klas
//using static Projekt2_Nowalski57295.FiguryGeometryczne;
//udostępnienie przestrzeni naazw dla potrzeb grafiki 2D
using System.Drawing.Drawing2D;

namespace Projekt2_Nowalski57295
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //ustawienie stanu braku aktywności przycisków Maksymalizacji i Minimalizacji
            this.MinimizeBox = false;
            this.MaximizeBox = false;
        }

        private void btnRysowanieFigur_Click(object sender, EventArgs e)
        {
            //sprawdzenie, czy był już utworzony egzemplarz formularza RysowanieFigur
            foreach (Form anFormX in Application.OpenForms)
                if (anFormX.Name == "RysowanieFigur_Nowalski")
                {
                    //ukrycie bierzącego
                    Hide();
                    //odsłonięcie znalezionego
                    anFormX.Show();
                    return;
                }
            
            //utworzenie egzemplarza formularza do którego chcemy przejść
            RysowanieFigur_Nowalski anQQQ = new RysowanieFigur_Nowalski();
            //ukrycie bierzącego formularza
            this.Hide();
            //Odsłonięcie formularza nowego
            anQQQ.Show();
        }

        private void btnKreslenieFigurMysz_Click(object sender, EventArgs e)
        {
            //sprawdzenie, czy był już utworzony egzemplarz formularza KreślenieFigur_Linii_Nowalski
            foreach (Form anFormX in Application.OpenForms)
                if (anFormX.Name == "KreślenieFigur_Linii_Nowalski")
                {
                    //ukrycie bierzącego
                    Hide();
                    //odsłonięcie znalezionego
                    anFormX.Show();
                    return;
                }


            //utworzenie egzemplarza formularza do którego chcemy przejść
            KreślenieFigur_Linii_Nowalski anQQQ = new KreślenieFigur_Linii_Nowalski();
            //ukrycie bierzącego formularza
            this.Hide();
            //Odsłonięcie formularza nowego
            anQQQ.Show();
        }

    }
}
