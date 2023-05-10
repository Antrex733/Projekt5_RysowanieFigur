using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Projekt2_Nowalski57295.FiguryGeometryczne;
namespace Projekt2_Nowalski57295
{
    public partial class KreślenieFigur_Linii_Nowalski : Form
    {
        //deklaracje stałych pomocniczych
        const int anMarginesFormularza = 2; //odstęp krawędzi formularza np. krawędzi ekranu fizucznego
        const int anMargines = 10; // odstęp od krawędzi kontrolki PictureBox
        // deklaracja powierzchni graficznej 
        Graphics anRysownica;
        // utworzenie tymczasowej rysownicy na powierzchni PictureBox
        Graphics anRysownicaTymczasowa;
        //deklaracja Punktu, któremu przypiszemy współrzędne (x, y) przy naciśnięciu lewego przycisku myszy
        Point anPunkt;
        //deklaracja pióra
        Pen anPióro;
        //deklaracja koloru figur geometrycznych
        Color anKolor = Color.Blue;
        Color anKolorWypełnienia = Color.Lime;
        //deklaracja pędzla
        SolidBrush anPędzel;
        //deklaracja pióra do kreślenia po powierzchni tymczasowej
        Pen anPióroTymczasowe;
        
        //lista ewidencji egzemplarzy kreślonych fiur geometrycznych
        List<Punkt> anLFG = new List<Punkt>();
        public KreślenieFigur_Linii_Nowalski()
        {
            InitializeComponent();
            //lokalizacja i zwymiarowanie formularza
            this.Location =
                new Point(Screen.PrimaryScreen.Bounds.X + anMarginesFormularza,
                          Screen.PrimaryScreen.Bounds.Y + anMarginesFormularza);
            this.Width = (int)(Screen.PrimaryScreen.Bounds.Width * 0.85f);
            this.Height = (int)(Screen.PrimaryScreen.Bounds.Height * 0.85f);
            //lokalizacja i zwymiarowanie formularza według podanych ustawień
            this.StartPosition = FormStartPosition.Manual;
            //ustawienie stanu braku aktywności przycisków Maksymalizacji i Minimalizacji
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            pbRysownica.Location = 
                new Point(Left + anMargines, gbGóra.Height + anMargines * 2);
            pbRysownica.Width = (int)(this.Width * 0.7f);
            pbRysownica.Height = (int)(this.Height * 0.6f);
            //ustawienie koloru tła kontrolki PictureBox
            pbRysownica.BackColor = Color.Beige;
            //ustalenie obramowania (Jedno wierszowe obramowanie) kontrolki PictureBox
            pbRysownica.BorderStyle = BorderStyle.FixedSingle;
            //utworzenie mapy bitowej i podpięcie jej do kontrolki PictureBox
            pbRysownica.Image = new Bitmap(pbRysownica.Width, pbRysownica.Height);
            //Lokalizacje pozostałyvh elementów
            gbGóra.Location =
                new Point(pbRysownica.Left + (pbRysownica.Width - gbGóra.Width) / 2, Top + anMargines);
            lblLista.Location = 
                new Point(pbRysownica.Left + pbRysownica.Width + anMargines * 7, btnPrzesunFigury.Top );
            gbFigury_Linie.Location = 
                new Point(pbRysownica.Left + pbRysownica.Width + anMargines, pbRysownica.Top);
            gbAtrybutyGraficzne.Location = 
                new Point(gbFigury_Linie.Left, gbFigury_Linie.Top + gbFigury_Linie.Height + anMargines);
            gbPozostałe.Location = new Point((int)(pbRysownica.Width * 0.2),pbRysownica.Top + pbRysownica.Height + anMargines);
            //utworzenie egzemplarza powierzchni graficznej na BitMapie?????????????????????????
            anRysownica = Graphics.FromImage(pbRysownica.Image);
            //utworzenie egzemplarza tymczasowej powierzchni graficznej na kontrolce PictureBox
            anRysownicaTymczasowa = pbRysownica.CreateGraphics();
            /* metoda CreateGraphics() klasy Control, jest dziedziczona przez wszystkie klasy 
               pochodne po klasie bazowej Control, a to oznacza, że egzemplarz powierzchni 
               graficznej możemy utowrzyć na dowolnej kontrolce, w tym na powierzchni kontrolki PictureBox 
             */

            //utworzenie egzemplarza pióra głównego
            anPunkt = Point.Empty;
            anPióro = new Pen(Color.Black, 1F);
            anPióro.DashStyle = DashStyle.Solid;
            anPióro.StartCap = LineCap.Round; //zaokrąglenie na początku linii
            anPióro.EndCap = LineCap.Round;   //zaokrąglenie na końcu linii
            //utworzenie egzemplarza pióra niebieskiego dla wizualizacji "rozciągania" kreślonej figury
            anPióroTymczasowe = new Pen(Color.Blue, 1);
            //utworzenie egzemplarza pędzla
            anPędzel = new SolidBrush(anKolorWypełnienia);
            cmbStylLinii.SelectedIndex = 0;

        }

        private void pbRysownica_MouseDown(object sender, MouseEventArgs e)
        {
            //wyświetlanie aktualnego położenia myszy
            lblx0.Text = e.Location.X.ToString();
            lbly0.Text = e.Location.Y.ToString();
            //rozpoznanie czy obsługiwanie zdarzenie jest spowodowane naciśnięciem lewego przycisku myszy
            if (e.Button == MouseButtons.Left)
            {//zapamiętanie współrzędnych punktu
                anPunkt = e.Location;
                anPióro.Color = txtKolorLinii.BackColor;
                anPióro.DashStyle = WybranyStylLinii(cmbStylLinii.SelectedIndex);
                anPióro.Width = trbSuwakGrubosciLinii.Value;
                //obsługa kontrolki dla kreślenia linii myszą
                if (rbLiniaCiągła.Checked)
                {//kontrolka została wybrana

                    //dodanie do LFG egzemplarza linii kreślnejmyszą
                    //LFG.Add(new LiniaKreslonaMysza(Punkt));
                    //wersja do uzupełnienia
                    anPióro.Color = txtKolorLinii.BackColor;
                    anPióro.DashStyle = WybranyStylLinii(cmbStylLinii.SelectedIndex);
                    anPióro.Width = trbSuwakGrubosciLinii.Value;
                    anLFG.Add(new LiniaKreslonaMysza(anPunkt, anPióro.Color, anPióro.DashStyle, (int)anPióro.Width));
                }
                
            }
        }

        DashStyle WybranyStylLinii(int i)
        {
            switch (i)
            {   
                case 0:
                    return DashStyle.Solid;
                case 1:
                    return DashStyle.Dash;
                case 2:
                    return DashStyle.Dot;
                case 3: 
                    return DashStyle.DashDot;
                case 4:
                    return DashStyle.DashDotDot;
                default:
                    return DashStyle.Solid;
            }
        }

        private void pbRysownica_MouseMove(object sender, MouseEventArgs e)
        {
            //wyświetlanie aktualnego położenia myszy
            lblx0.Text = e.Location.X.ToString();
            lbly0.Text = e.Location.Y.ToString();
            if (e.Button == MouseButtons.Left)
            {//wyświetlenie aktualnego położenia myszy
                lblx0.Text = e.Location.X.ToString();
                lbly0.Text = e.Location.Y.ToString();
                /* deklaracje zmiennych pomocniczych i wyznaczenie parametrów
               opisujących prostokąt, w którym będzie wykreślana figura geometryczna */
                int anlewyGórnyNarożnikX =
                (anPunkt.X > e.Location.X) ? e.Location.X : anPunkt.X;
                int anlewyGórnyNarożnikY =
                    (anPunkt.Y > e.Location.Y) ? e.Location.Y : anPunkt.Y;
                int anSzerokość = Math.Abs(anPunkt.X - e.Location.X);
                int anWysokość = Math.Abs(anPunkt.Y - e.Location.Y);

                if (rbPunkt.Checked)
                {
                    //punktu nie rozciągamy
                }
                if (rbLiniaProsta.Checked)
                {
                    //kreślenie linii na powierzchni tymczasowej
                    anRysownicaTymczasowa.DrawLine(anPióroTymczasowe, anPunkt.X, anPunkt.Y, e.Location.X, e.Location.Y);
                }
                if (rbLiniaCiągła.Checked)
                {
                    //rysowanie punktów
                    ((LiniaKreslonaMysza)anLFG[anLFG.Count - 1]).DodajNowyPunktKreslonejLinii(e.Location);//dlaczego taki zapis?
                }
                if (rbElipsa.Checked)
                {
                    anRysownicaTymczasowa.DrawEllipse(anPióroTymczasowe, 
                        new Rectangle(anlewyGórnyNarożnikX, anlewyGórnyNarożnikY, anSzerokość, anWysokość));
                }
                if (rbOkrąg.Checked)
                {
                    anRysownicaTymczasowa.DrawEllipse(anPióroTymczasowe, 
                        new Rectangle(anlewyGórnyNarożnikX, anlewyGórnyNarożnikY, anWysokość, anWysokość));
                }
                if(rbKwdrat.Checked)
                {
                    anRysownicaTymczasowa.DrawRectangle
                        (anPióroTymczasowe, anlewyGórnyNarożnikX, anlewyGórnyNarożnikY, anSzerokość, anSzerokość);

                }
                if (rbProstokąt.Checked)
                {
                    anRysownicaTymczasowa.DrawRectangle
                        (anPióroTymczasowe, anlewyGórnyNarożnikX, anlewyGórnyNarożnikY, anSzerokość, anWysokość);

                }
                if (rbKoło.Checked)
                {
                 
                    anRysownicaTymczasowa.FillEllipse(anPędzel,
                        new Rectangle(anlewyGórnyNarożnikX, anlewyGórnyNarożnikY, anWysokość, anWysokość));
                }
                if(rbPełnyKwadrat.Checked)
                {
                    anRysownicaTymczasowa.FillRectangle(anPędzel,
                        new Rectangle(anlewyGórnyNarożnikX, anlewyGórnyNarożnikY, anWysokość, anWysokość));
                }
                
                //itd...

                //odświeżenie powierzchni graficznej
                pbRysownica.Refresh();
            }
        }

        private void pbRysownica_MouseUp(object sender, MouseEventArgs e)
        {
            //wyświetlanie aktualnego położenia myszy
            lblx0.Text = e.Location.X.ToString();
            lbly0.Text = e.Location.Y.ToString();
            /* deklaracje zmiennych pomocniczych i wyznaczenie parametrów
               opisujących prostokąt, w którym będzie wykreślana figura geometryczna */
            int anlewyGórnyNarożnikX = 
                (anPunkt.X > e.Location.X) ? e.Location.X : anPunkt.X;
            int anlewyGórnyNarożnikY = 
                (anPunkt.Y > e.Location.Y) ? e.Location.Y : anPunkt.Y;
            int anSzerokość = Math.Abs(anPunkt.X - e.Location.X);
            int anWysokość = Math.Abs(anPunkt.Y - e.Location.Y);
            //rozpoznanie, czy zdarzenie MouseUp dotyczy lewego przycisku myszy
            if (e.Button == MouseButtons.Left)
            {
                if (rbPunkt.Checked)
                {
                    //utworzenie egzemplarza i dodanie jego referencji do LFG
                    anLFG.Add(new Punkt(anPunkt.X, anPunkt.Y));
                    //ustalenie atrybutów geometrycznych i graficznych punktu
                    anLFG[anLFG.Count - 1].UstalAtrubutyGraficzne(anKolor, anPióro.DashStyle, trbSuwakGrubosciLinii.Value);
                    //wykreślenie punktu
                    anLFG[anLFG.Count - 1].Wykresl(anRysownica);
                }
                if (rbLiniaProsta.Checked)
                {
                    //utowrzenie egzemplarza i dodanie jego referencji do LFG
                    anLFG.Add(new Linia(anPunkt.X, anPunkt.Y, e.Location.X, e.Location.Y));
                    //ustalenie atrybutów geometrycznych i graficznych linii
                    anLFG[anLFG.Count - 1].UstalAtrubutyGraficzne(anKolor, anPióro.DashStyle, trbSuwakGrubosciLinii.Value);
                    //wykreślenie linii
                    anLFG[anLFG.Count - 1].Wykresl(anRysownica);
                }
                if (rbElipsa.Checked)
                {
                    //utowrzenie egzemplarza i dodanie jego referencji do LFG
                    anLFG.Add(new Elipsa(anlewyGórnyNarożnikX, anlewyGórnyNarożnikY, anSzerokość, anWysokość));
                    //ustalenie atrybutów geometrycznych i graficznych elipsy
                    anLFG[anLFG.Count - 1].UstalAtrubutyGraficzne(anKolor, anPióro.DashStyle, trbSuwakGrubosciLinii.Value);
                    //wykreślenie elipsy
                    anLFG[anLFG.Count - 1].Wykresl(anRysownica);
                }
                if (rbOkrąg.Checked)
                {
                    //utowrzenie egzemplarza i dodanie jego referencji do LFG
                    anLFG.Add(new Okrag(anlewyGórnyNarożnikX, anlewyGórnyNarożnikY, anSzerokość / 2));
                    //ustalenie atrybutów geometrycznych i graficznych okręgu
                    anLFG[anLFG.Count - 1].UstalAtrubutyGraficzne(anKolor, anPióro.DashStyle, trbSuwakGrubosciLinii.Value);
                    //wykreślenie okręgu
                    anLFG[anLFG.Count - 1].Wykresl(anRysownica);
                }
                if (rbLiniaCiągła.Checked)
                {
                    //dodanie do listy punktów linii kreślonej myszą współrzędnych ostatniego punktu
                    ((LiniaKreslonaMysza)anLFG[anLFG.Count - 1]).DodajNowyPunktKreslonejLinii(e.Location);
                    ((LiniaKreslonaMysza)anLFG[anLFG.Count - 1]).UstalAtrubutyGraficzne(anKolor, anPióro.DashStyle, trbSuwakGrubosciLinii.Value);
                    //Rysownica.DrawCurve(Pióro, )//Rysownica.DrawLine(Pióro, Punkt, e.Location);
                    //uaktualnienie zapisu w zmiennej Punkt
                    anPunkt = e.Location;
                    anLFG[anLFG.Count - 1].Wykresl(anRysownica);
                }
                if (rbKwdrat.Checked)
                {
                    //utowrzenie egzemplarza i dodanie jego referencji do LFG
                    anLFG.Add(new Kwadrat(anlewyGórnyNarożnikX, anlewyGórnyNarożnikY, anSzerokość, anSzerokość));
                    //ustalenie atrybutów geometrycznych i graficznych okręgu
                    anLFG[anLFG.Count - 1].UstalAtrubutyGraficzne(anKolor, anPióro.DashStyle, trbSuwakGrubosciLinii.Value);
                    //wykreślenie okręgu
                    anLFG[anLFG.Count - 1].Wykresl(anRysownica);
                }
                if (rbProstokąt.Checked)
                {
                    //utowrzenie egzemplarza i dodanie jego referencji do LFG
                    anLFG.Add(new Prostokąt(anlewyGórnyNarożnikX, anlewyGórnyNarożnikY, anSzerokość, anWysokość));
                    //ustalenie atrybutów geometrycznych i graficznych okręgu
                    anLFG[anLFG.Count - 1].UstalAtrubutyGraficzne(anKolor, anPióro.DashStyle, trbSuwakGrubosciLinii.Value);
                    //wykreślenie okręgu
                    anLFG[anLFG.Count - 1].Wykresl(anRysownica);
                }
                if (rbKoło.Checked)
                {
                    anLFG.Add(new Koło(anlewyGórnyNarożnikX, anlewyGórnyNarożnikY, anSzerokość / 2));
                    anLFG[anLFG.Count - 1].UstalAtrubutyGraficzne(anKolorWypełnienia);
                    anLFG[anLFG.Count - 1].Wykresl(anRysownica);
                }
                if (rbPełnyKwadrat.Checked)
                {
                    anLFG.Add(new PełnyKwadrat(anlewyGórnyNarożnikX, anlewyGórnyNarożnikY, anSzerokość, anSzerokość));
                    //ustalenie atrybutów geometrycznych i graficznych okręgu
                    anLFG[anLFG.Count - 1].UstalAtrubutyGraficzne(anKolorWypełnienia, anPióro.DashStyle, trbSuwakGrubosciLinii.Value);
                    //wykreślenie okręgu
                    anLFG[anLFG.Count - 1].Wykresl(anRysownica);
                }
                if (rbKrzywaBeziera.Checked)
                {
                    if (gbFigury_Linie.Enabled)
                    {//to jest pierwszy punkt: P0
                        //utworzenie egzemplarza klasy KrzywaBedziera i dodanie go do LFG
                        anLFG.Add(new KrzywaBeziera(anRysownica, anPióro, anPunkt));
                        //ustawienie stanu braku aktywności dla kontenera z kontrolkami RadioButton,
                        //które są przypisane różntm figurom geometrycznym
                        gbFigury_Linie.Enabled = false;
                        //przypisanie wartości 0 dla początkowej wartości LiczbaPunktówKontrolnych,
                        //która jest zadeklarowana w klasie KrzywaBeziera
                        ((KrzywaBeziera)anLFG[anLFG.Count - 1]).anLiczbaPunktowKontrolnych = 0;  
                        
                    }
                    else
                    {//dodanie nowego punktu kontrolnego
                        ((KrzywaBeziera)anLFG[anLFG.Count - 1]).DodajNowyPunktKontrolny(e.Location, anRysownica);
                        ((KrzywaBeziera)anLFG[anLFG.Count - 1]).anLiczbaPunktowKontrolnych++;
                        //sprawdzenie, czy jest to już punkt ostatni: P3
                        if(((KrzywaBeziera)anLFG[anLFG.Count - 1]).anLiczbaPunktowKontrolnych == 3)
                        {
                            gbFigury_Linie.Enabled = true;
                            //wykreślenie krzywej Beziera
                            anLFG[anLFG.Count - 1].Wykresl(anRysownica);
                        }
                    }
                }
                if (rbDrawClosedCurve.Checked)
                {
                    if (gbFigury_Linie.Enabled)
                    {//to jest pierwszy punkt: P0
                        //utworzenie egzemplarza klasy KrzywaBedziera i dodanie go do LFG
                        anLFG.Add(new Łamana(anRysownica, anPióro, anPunkt));
                        //ustawienie stanu braku aktywności dla kontenera z kontrolkami RadioButton,
                        //które są przypisane różntm figurom geometrycznym
                        gbFigury_Linie.Enabled = false;
                        //przypisanie wartości 0 dla początkowej wartości LiczbaPunktówKontrolnych,
                        //która jest zadeklarowana w klasie KrzywaBeziera
                        ((Łamana)anLFG[anLFG.Count - 1]).anLiczbaPunktowKontrolnych = 0;
                    }
                    else
                    {//ddodanie nowego punktu kontrolnego
                        ((Łamana)anLFG[anLFG.Count - 1]).DodajNowyPunktKontrolny(e.Location, anRysownica);
                        ((Łamana)anLFG[anLFG.Count - 1]).anLiczbaPunktowKontrolnych++;
                        //sprawdzenie, czy jest to już punkt ostatni: P3
                        if (((Łamana)anLFG[anLFG.Count - 1]).anLiczbaPunktowKontrolnych == 5)
                        {
                            gbFigury_Linie.Enabled = true;
                            //wykreślenie krzywej Beziera
                            anLFG[anLFG.Count - 1].Wykresl(anRysownica);
                        }
                    }
                }
                if (rbOśmiokąt.Checked)
                {
                    if (gbFigury_Linie.Enabled)
                    {//to jest pierwszy punkt: P0
                        //utworzenie egzemplarza klasy KrzywaBedziera i dodanie go do LFG
                        anLFG.Add(new Ośmiokąt(anRysownica, anPióro, anPunkt));
                        //ustawienie stanu braku aktywności dla kontenera z kontrolkami RadioButton,
                        //które są przypisane różntm figurom geometrycznym
                        gbFigury_Linie.Enabled = false;
                        //przypisanie wartości 0 dla początkowej wartości LiczbaPunktówKontrolnych,
                        //która jest zadeklarowana w klasie Ośmiokąt
                        ((Ośmiokąt)anLFG[anLFG.Count - 1]).anLiczbaPunktowKontrolnych = 0;
                    }
                    else
                    {//ddodanie nowego punktu kontrolnego
                        ((Ośmiokąt)anLFG[anLFG.Count - 1]).DodajNowyPunktKontrolny(e.Location, anRysownica);
                        ((Ośmiokąt)anLFG[anLFG.Count - 1]).anLiczbaPunktowKontrolnych++;
                        //sprawdzenie, czy jest to już punkt ostatni: P7
                        if (((Ośmiokąt)anLFG[anLFG.Count - 1]).anLiczbaPunktowKontrolnych == 7)
                        {
                            gbFigury_Linie.Enabled = true;
                            //wykreślenie Ośmiokąta
                            anLFG[anLFG.Count - 1].Wykresl(anRysownica);
                        }
                    }
                }
                if (rbWypełnionyOśmiokąt.Checked)
                {
                    if (gbFigury_Linie.Enabled)
                    {//to jest pierwszy punkt: P0
                        //utworzenie egzemplarza klasy KrzywaBedziera i dodanie go do LFG
                        anLFG.Add(new FillOśmiokąt(anRysownica, anPióro, anPunkt, anPędzel));
                        //ustawienie stanu braku aktywności dla kontenera z kontrolkami RadioButton,
                        //które są przypisane różntm figurom geometrycznym
                        gbFigury_Linie.Enabled = false;
                        anLFG[anLFG.Count - 1].UstalAtrubutyGraficzne(anKolorWypełnienia, anPióro.DashStyle, trbSuwakGrubosciLinii.Value);
                        //przypisanie wartości 0 dla początkowej wartości LiczbaPunktówKontrolnych,
                        //która jest zadeklarowana w klasie Ośmiokąt
                        ((FillOśmiokąt)anLFG[anLFG.Count - 1]).anLiczbaPunktowKontrolnych = 0;
                    }
                    else
                    {//ddodanie nowego punktu kontrolnego
                        ((FillOśmiokąt)anLFG[anLFG.Count - 1]).DodajNowyPunktKontrolny(e.Location, anRysownica);
                        ((FillOśmiokąt)anLFG[anLFG.Count - 1]).anLiczbaPunktowKontrolnych++;
                        //sprawdzenie, czy jest to już punkt ostatni: P7
                        if (((FillOśmiokąt)anLFG[anLFG.Count - 1]).anLiczbaPunktowKontrolnych == 7)
                        {
                            gbFigury_Linie.Enabled = true;
                            //wykreślenie Ośmiokąta
                            anLFG[anLFG.Count - 1].Wykresl(anRysownica);
                        }
                    }
                }

                //odświeżenie powierzchni graficznej
                pbRysownica.Refresh();
            }
        }

        private void btnPrzesunFigury_Click(object sender, EventArgs e)
        {
            errorProvider1.Dispose();
            if (anLFG.Count < 1)
            {
                errorProvider1.SetError(btnPrzesunFigury,"ERROR - najpierw wykreśł chociaż jedną figurę");
                return;
            }
            //wyczyszczenie powierzchni graficznej
            anRysownica.Clear(pbRysownica.BackColor);
            //wyznaczenie rozmiarów powierzchni graficznej
            int anXmax = pbRysownica.Width, Ymax = pbRysownica.Height;
            //deklaracja i utworzenie egzemplarza generatora współżędnych 
            Random rnd = new Random();
            //losowe współżędne
            ushort anx, any;
            for (int ani = 0; ani < anLFG.Count; ani++)
            {
                anx = (ushort)rnd.Next(anMargines, anXmax - anMargines);
                any = (ushort)rnd.Next(anMargines, Ymax - anMargines);
                anLFG[ani].PrzesunDoNowegoXY(pbRysownica, anRysownica, anx, any);
            }
            
            pbRysownica.Refresh();
        }

        private void btnCofnij_Click(object sender, EventArgs e)
        {
            errorProvider1.Dispose();
            //sprawdzenia czy w liście LFG są umieszczone referencje do egzemplarzy figur geometrycznych
            if (anLFG.Count <= 0)
            {
                errorProvider1.SetError(btnCofnij, "ERROR - lista figur /ngeometrycznych jest pusta");
                return;
            }
            //usunięcie ostatniego elementu listy
            anLFG.RemoveAt(anLFG.Count - 1);
            //ponowne odrysowanie rysownicy
            //wyczyszczenie powierzchni graficznej
            anRysownica.Clear(pbRysownica.BackColor);
            for (int ani = 0; ani < anLFG.Count; ani++)
            {
                anLFG[ani].Wykresl(anRysownica);
            }
            pbRysownica.Refresh();
        }

        private void btnKolorLinii_Click(object sender, EventArgs e)
        {
            ColorDialog ankolor = new ColorDialog();
            ankolor.ShowDialog();
            anKolor = ankolor.Color;
            anPióro.Color = ankolor.Color;
            txtKolorLinii.BackColor = ankolor.Color;
        }

        private void btnPowrot_Click(object sender, EventArgs e)
        {
            foreach (Form anFormularz in Application.OpenForms)
            {
                if (anFormularz.Name == "Form1")
                {
                    Hide();
                    anFormularz.Show();
                    break;
                }
            }
        }

        private void KreślenieFigur_Linii_Nowalski_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult anDecyzja = 
                MessageBox.Show("Czy na pewno chcesz zakończyć działanie programu?", this.Text,
                MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (anDecyzja == DialogResult.Yes)
                e.Cancel = false;
            else
                e.Cancel = true;
        }

        private void KreślenieFigur_Linii_Nowalski_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnKolorWypełnienia_Click(object sender, EventArgs e)
        {
            ColorDialog ankolor = new ColorDialog();
            ankolor.ShowDialog();
            anPędzel.Color = ankolor.Color;
            anKolorWypełnienia = ankolor.Color;
            txtKolorWypełnienia.BackColor = ankolor.Color;
        }

        private void btnWłączPokazFigur_Click(object sender, EventArgs e)
        {
            errorProvider1.Dispose();
            int anXmax = pbRysownica.Width ;
            int anYmax = pbRysownica.Height ;

            anRysownica.Clear(pbRysownica.BackColor);
            timer1.Tag = 0;
            txtNumerFigury.Text = 0.ToString();

            if (anLFG.Count < 1)
            {
                errorProvider1.SetError(btnWyłączPokazFigur, "ERROR - najpierw wykreśl choć jedną figurę");
                return;
            }
            anLFG[0].PrzesunDoNowegoXY(pbRysownica, anRysownica, anXmax / 2, anYmax / 2);
            pbRysownica.Refresh();

            if (rbAutomatyczny.Checked)
            {
                //uaktywnienie zegara
                timer1.Enabled = true;
            }
            else
            { //stawienie stanu braku aktywności dla kontrolek slajdera manualnego
                btnNastępny.Enabled = true;
                btnPoprzedni.Enabled = true;
                txtNumerFigury.Enabled = true;
            }
            btnWłączPokazFigur.Enabled = false;
            btnWyłączPokazFigur.Enabled = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //wymazanie całej powierzchni graficznej
            anRysownica.Clear(pbRysownica.BackColor);
            //wyznaczenie rozmiarów powierzchni graficznej
            int anXmax = pbRysownica.Width;
            int anYmax = pbRysownica.Height;
            //wpisanie do kontrolki slajder indeksu TFG pokazywanej figury
            txtNumerFigury.Text = timer1.Tag.ToString();
            //wykreślenie figury o indeksie timer1.Tag w środku powierzchni graficznej
            anLFG[(int)(timer1.Tag)].PrzesunDoNowegoXY(pbRysownica, anRysownica, anXmax / 2, anYmax / 2);
            //odświeżenie pow. graficznej
            pbRysownica.Refresh();
            //ustawienie indeksu dla następnej figury do pokazu
            timer1.Tag = ((int)(timer1.Tag) + 1) % (anLFG.Count);
        }

        private void btnWyłączPokazFigur_Click(object sender, EventArgs e)
        {
            //wyczyszczenie rysownicy
            anRysownica.Clear(pbRysownica.BackColor);
            //wyłączenie zegara
            timer1.Enabled = false;
            //ustawienie indeksu na 0
            txtNumerFigury.Text = "";
            //uaktywnienie przycisku poleceń WączenieSlajdera
            btnWłączPokazFigur.Enabled = true;
            //ustawienie stanu braku aktywności dla przycisku btnWyłączenieSlajdera
            btnWyłączPokazFigur.Enabled = false;
            //uaktywnienie/brak aktywności przycisków slajdera
            rbAutomatyczny.Checked = true;
            btnNastępny.Enabled = false;
            btnPoprzedni.Enabled = false;
            txtNumerFigury.Enabled = false;
            //ponowne wykreślenie wszystkich figur "zapisanych" w TFG
            Random anrnd = new Random();
            //deklaracje pomocnicze
            int anx, any;
            //wyznaczenie rozmiarów rysownicy
            int anXmax = pbRysownica.Width;
            int anYmax = pbRysownica.Height;
            //wykreślenie wszystkich figur z TFG w losowej lokalizacji
            for (int ani = 0; ani < anLFG.Count; ani++)
            {
                //wylosowanie nowej lokalizacji: (x, y) dla i-tej figury
                anx = anrnd.Next(anMargines, anXmax - anMargines);
                any = anrnd.Next(anMargines, anYmax - anMargines);
                //zmiana lokalizacji i-tej figury geometrycznej i wykreślenie
                anLFG[ani].PrzesunDoNowegoXY(pbRysownica, anRysownica, new Point(anx, any));
            }
            //odświeżenie powierzchni graficznej
            pbRysownica.Refresh();
        }

        private void btnNastępny_Click(object sender, EventArgs e)
        {
            //deklaracja pomocnicza
            ushort anIndexFigury;
            // pobieranie z kontrolki textbox indexu aktualnie wykreślonej figury
            anIndexFigury = ushort.Parse(txtNumerFigury.Text);
            //wyznaczenie indeksu dla następnej figury
            if (anIndexFigury < anLFG.Count - 1)
            {
                anIndexFigury++;
            }
            else
            {
                anIndexFigury = 0;
            }

            //deklaracje pomocnicze
            //wyznaczenie rozmiarów rysownicy
            int Xmax = pbRysownica.Width;
            int Ymax = pbRysownica.Height;

            anRysownica.Clear(pbRysownica.BackColor);
            //zmiana lokalizacji i-tej figury geometrycznej i wykreślenie
            anLFG[anIndexFigury].PrzesunDoNowegoXY(pbRysownica, anRysownica, Xmax / 2, Ymax / 2);
            //odświeżenie powierzchni graficznej
            pbRysownica.Refresh();
            //uaktualnienie zapisu indeksu aktualnie wykreślonej figury
            txtNumerFigury.Text = anIndexFigury.ToString();
        }

        private void btnPoprzedni_Click(object sender, EventArgs e)
        {
            //deklaracja pomocnicza
            ushort anIndexFigury;
            // pobieranie z kontrolki textbox indexu aktualnie wykreślonej figury
            anIndexFigury = ushort.Parse(txtNumerFigury.Text);
            //wyznaczenie indeksu dla następnej figury
            if (anIndexFigury != 0)
            {
                anIndexFigury--;
            }
            else
            {
                anIndexFigury = (ushort)(anLFG.Count - 1);
            }

            //deklaracje pomocnicze
            //wyznaczenie rozmiarów rysownicy
            int Xmax = pbRysownica.Width;
            int Ymax = pbRysownica.Height;

            anRysownica.Clear(pbRysownica.BackColor);
            //zmiana lokalizacji i-tej figury geometrycznej i wykreślenie
            anLFG[anIndexFigury].PrzesunDoNowegoXY(pbRysownica, anRysownica, Xmax / 2, Ymax / 2);
            //odświeżenie powierzchni graficznej
            pbRysownica.Refresh();
            //uaktualnienie zapisu indeksu aktualnie wykreślonej figury
            txtNumerFigury.Text = anIndexFigury.ToString();
        }

        private void txtNumerFigury_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Dispose();
            ushort anIndeksFigury;

            if (txtNumerFigury.Text == "")
                return;
            //pobranie numeru indeksu TFG wpisanego do kontrolki TextBox
            if (!ushort.TryParse(txtNumerFigury.Text, out anIndeksFigury))
            {
                errorProvider1.SetError(txtNumerFigury, "ERROR: w zapisie " + " indeksu figury wystąpił nieprawidłowy znak");
                return;
            }
            //sprawdzenie warunku zawartość 
            if (anIndeksFigury > anLFG.Count - 1)
            {
                errorProvider1.SetError(txtNumerFigury, "ERROR: przekroczenie dopuszczalnej wartości indeksu: " + (anLFG.Count - 1).ToString());
                return;
            }
            //wyczyszczenie rysownicy
            anRysownica.Clear(pbRysownica.BackColor);
            //deklaracje pomocnicze
            //wyznaczenie rozmiarów rysownicy
            int Xmax = pbRysownica.Width;
            int Ymax = pbRysownica.Height;
            //zmiana lokalizacji i-tej figury geometrycznej i wykreślenie
            anLFG[anIndeksFigury].PrzesunDoNowegoXY(pbRysownica, anRysownica, Xmax / 2, Ymax / 2);
            //odświeżenie powierzchni graficznej
            pbRysownica.Refresh();
        }

        private void rbKrzywaBeziera_CheckedChanged(object sender, EventArgs e)
        {
            if(rbKrzywaBeziera.Checked)

                MessageBox.Show("Wykreślenie Krzywej Beziera wymaga zaznaczenia (kliknięciem) " +
                                " 4 punktów na powierzchni graficznej: Rysownicy", "Krzywa Beziera",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void rbDrawClosedCurve_CheckedChanged(object sender, EventArgs e)
        {
            if (rbDrawClosedCurve.Checked)

                MessageBox.Show("Wykreślenie zamkniętej krzywej wymaga zaznaczenia (kliknięciem) " +
                                " 6 punktów na powierzchni graficznej: Rysownicy", "Krzywa łamana",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void rbWypełnionyOśmiokąt_CheckedChanged(object sender, EventArgs e)
        {
            if (rbWypełnionyOśmiokąt.Checked)
            {
                MessageBox.Show("Wykreślenie wypełnionego ośmiokąta wymaga zaznaczenia (kliknięciem) " +
                                " 8 punktów na powierzchni graficznej: Rysownicy", "FillPolygon",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void rbOśmiokąt_CheckedChanged(object sender, EventArgs e)
        {
            if (rbOśmiokąt.Checked)
            {
                MessageBox.Show("Wykreślenie ośmiokąta wymaga zaznaczenia (kliknięciem) " +
                                " 8 punktów na powierzchni graficznej: Rysownicy", "Polygon",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
