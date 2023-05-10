using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;//nowa do rysowania
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//dodanie przestrzeni nazw klasy FiguryGeometryczne, która udostępni deklaracje klas
using static Projekt2_Nowalski57295.FiguryGeometryczne;
//udostępnienie przestrzeni naazw dla potrzeb grafiki 2D
using System.Drawing.Drawing2D;
namespace Projekt2_Nowalski57295
{
    public partial class RysowanieFigur_Nowalski : Form
    {
        //deklaracja powierzchni graficznej
        Graphics anRysownica;
        //deklaracja zmiennej tablicowej (referencyjnej) TFG: Tablica Figur Geometrycznych
        Punkt[] anTFG;
        int anIndexTFG;//indeks tablicy TFG

        //deklaracje stałych pomocniczych
        const int anMarginesFormularza = 2; //odstęp krawędzi formularza np. krawędzi ekranu fizucznego
        const int anMargines = 10; // odstęp od krawędzi kontrolki PictureBox
        public RysowanieFigur_Nowalski()
        {
            InitializeComponent();

            //lokalizacja i zwymiarowanie formularza
            this.Location =
                new Point(Screen.PrimaryScreen.Bounds.X + anMarginesFormularza,
                          Screen.PrimaryScreen.Bounds.Y + anMarginesFormularza);
            this.Width = (int)(Screen.PrimaryScreen.Bounds.Width * 0.90f);
            this.Height = (int)(Screen.PrimaryScreen.Bounds.Height * 0.85f);
            //lokalizacja i zwymiarowanie formularza według podanych ustawień
            this.StartPosition = FormStartPosition.Manual;
            //ustawienie stanu braku aktywności przycisków Maksymalizacji i Minimalizacji
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            //lokalizacja i zwymiarowanie kontrolek umieszczonych na formilarzyu
            lblN.Location = 
                new Point(Left + anMarginesFormularza , Top + anMarginesFormularza + 20);
            txtN.Location = 
                new Point(lblN.Left + anMarginesFormularza, lblN.Height + anMarginesFormularza + 20);
            btnStart.Location = 
                new Point(lblN.Left, txtN.Top + txtN.Height + anMargines);
            //lokalizacja kontrolki PictureBox
            pbRysownica.Location =
                new Point(btnStart.Left + btnStart.Width + anMarginesFormularza, lblN.Top);
            pbRysownica.Width = (int)(this.Width * 0.6f);
            pbRysownica.Height = (int)(this.Height * 0.6f);
            //ustawienie koloru tła kontrolki PictureBox
            pbRysownica.BackColor = Color.Beige;
            //ustalenie obramowania (Jedno wierszowe obramowanie) kontrolki PictureBox
            pbRysownica.BorderStyle = BorderStyle.FixedSingle;
            //utworzenie mapy Bitowej i podpięcie jej do kontrolki PictureBox
            pbRysownica.Image = 
                new Bitmap(pbRysownica.Width, pbRysownica.Height);
            //lokalizacja napisu menu
            lblMenu.Location = 
                new Point(pbRysownica.Left + pbRysownica.Width + anMarginesFormularza, 
                pbRysownica.Top);
            //lokalizacja kontrolki CheckListBox
            chlbFiguryGeometryczne.Location =
                new Point(lblMenu.Left,
                lblMenu.Top + lblMenu.Height + anMarginesFormularza);
            //lokalizacja przycisku Resetuj
            btnResetujRysowanieFigur.Location = 
                new Point(chlbFiguryGeometryczne.Location.X,
                chlbFiguryGeometryczne.Location.Y + chlbFiguryGeometryczne.Height + anMarginesFormularza);
            //lokalizacja przycisku PrzesunLosowo
            btnPrzesunLosowo.Location = 
                new Point(btnStart.Left, btnStart.Top + btnStart.Height + anMargines);
            btnLosujAtrybuty.Location = 
                new Point(btnPrzesunLosowo.Left, btnPrzesunLosowo.Top + btnPrzesunLosowo.Height + anMargines);
            //lokalizacja przycisku Wł/Wył slajdera
            btnWłączenieSlajdera.Location = 
                new Point(btnStart.Left, btnLosujAtrybuty.Top + btnLosujAtrybuty.Height + anMargines * 4);
            btnWyłączenieSlajdera.Location = 
                new Point(btnStart.Left, btnWłączenieSlajdera.Top + btnWłączenieSlajdera.Height + anMargines);
            //lokalizacja GroupBoxa z trybami slajdera
            gbTrybyPokazu.Location = 
                new Point(pbRysownica.Left + (pbRysownica.Width - gbTrybyPokazu.Width)/2, pbRysownica.Top + pbRysownica.Height + anMargines);
            //lokalizacja przycisku powrót do menu
            btnPowrot.Location = 
                new Point(btnResetujRysowanieFigur.Location.X, btnResetujRysowanieFigur.Location.Y + btnResetujRysowanieFigur.Height + anMargines);
            //utworzenie egzemplarza powierzchni graficznej
            anRysownica = Graphics.FromImage(pbRysownica.Image);
        }


        private void btnPowrotDoGlownegoFormZSlajdow_Click(object sender, EventArgs e)
        {
            //odszukanie formularza głównego w kolekcji OpenForms
            foreach (Form anFormX in Application.OpenForms)
                //sprawdzenie czy znaleziony formularz FormX jest formularzem głównym
                if (anFormX.Name == "Form1")
                {
                    //ukrycie bierzącego formularza
                    Hide();
                    //odsłonięcie formularza FormX
                    anFormX.Show();
                    //wyjście z metody obsługi zdarzenia Click
                    return;
                }
            //formularz główny nie został znaleziony, to dla utrzymania ciągłości
            //działania programu tworzymy jego egzemplarz i odsłaniamy

            //utworzenie egzemplarza formularza głównego
            Form1 anFormGłówny = new Form1();
            //ukrycie bierzącego formularza
            Hide();
            anFormGłówny.Show();  
        }

        private void RysowanieFigur_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult anWynik = MessageBox.Show("Czy na pewno chcesz zakończyć działanie programu?", 
                this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            //sprawdzenie odp urzytkownika
            if (anWynik != DialogResult.Yes)
                //skasowanie zdarzenia Cancel
                e.Cancel = true;
            else
                //zdarzenie Cancel nie może być 'skasowane'
                e.Cancel= false;
        }

        private void RysowanieFigur_FormClosed(object sender, FormClosedEventArgs e)
        {
            //zamknięcie programu
            Application.Exit();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            //pełna deklaracja metody obsługi przycisku poleceć START
            //deklaracja zmiennej dla przechowania danej liczy figur
            ushort anN;
            Random anrnd = new Random();
            //zgaszenie kontrolki/komponentu errorprovider
            errorProvider1.Dispose();

            //pobranie liczby figur geometrycznych do prezentacji
            //sprawdzenie, czy została podana liczba figur
            if (String.IsNullOrEmpty(txtN.Text.Trim()))
            {   //sygnalizacja błędu
                errorProvider1.SetError(txtN, "Musisz podać liczbę" + " figur geometrycznych do prezentacji");
                //przerwanie dalszej obsługi zdarzenia Click od przycisku START
                return;
            }

            //pobranie wpisanej liczby figur geometrycznych
            if (!ushort.TryParse(txtN.Text, out anN))
            {   //sygnalizacja błędu
                errorProvider1.SetError(txtN, "Musisz podać liczbę naturalną");
                //przerwanie dalszej obsługi zdarzenia Click od przycisku START
                return;
            }

            //utworzenie egzemplarza TFG
            anTFG = new Punkt[anN];
            anIndexTFG = 0;
            //sprawdzenie, czy Użytkownik zaznaczył (wybrał) figury geometryczne
            if (chlbFiguryGeometryczne.CheckedItems.Count <= 0)
            {
                errorProvider1.SetError(chlbFiguryGeometryczne, "Musisz zaznaczyć przynajmniej" + " \njedną fugurę geometryczną");
                return;
            }
            //skopiowanie kolekcji wybranych figur geometrycznych
            CheckedListBox.CheckedItemCollection WybraneFigury =
                chlbFiguryGeometryczne.CheckedItems;
            //uswawienie stanu braku aktywności dla kontrolki chlbFiguryGeometryczne
            chlbFiguryGeometryczne.Enabled = false;
            btnWłączenieSlajdera.Enabled = true ;
            //wyznaczenie wymiarów powierzchni graficznej 
            int anXmax = pbRysownica.Width;
            int anYmax = pbRysownica.Height;
            //deklaracje pomocnicze
            int anX, anY;
            Color anKolorLinii;
            Color anKolorWypelnienia;
            int anGruboscLinii;
            int anGruboscPunktu;
            DashStyle anStylLinii;
            int anXk, anYk;
            int anOsDuza, anOsMala;
            int anPromien;
            int anWylosowanyIndeksFigury;
            //losowanie atrybutów geometrycznych i graficznych oraz tworzenie egzemplarzy
            //wybranych figur geometrycznych
            for (int i = 0; i < anN; i++)
            {
                //wylosowanie współrzędnych położenia figur geo
                anX = anrnd.Next(anMargines, anXmax - anMargines);
                anY = anrnd.Next(anMargines, anYmax - anMargines);
                
                //wylosowaie koloru linii
                anKolorLinii = Color.FromArgb(anrnd.Next(0, 256),
                                            anrnd.Next(0, 256), 
                                            anrnd.Next(0, 256), 
                                            anrnd.Next(0, 256));

                anKolorWypelnienia = Color.FromArgb(anrnd.Next(0, 256),
                                                  anrnd.Next(0, 256),
                                                  anrnd.Next(0, 256),
                                                  anrnd.Next(0, 256));
                //wylosowanie stylu linii
                switch (anrnd.Next(1, 6))
                {
                    case 1:
                        anStylLinii = DashStyle.Dash;
                        break;
                    case 2:
                        anStylLinii = DashStyle.Dot;
                        break;
                    case 3:
                        anStylLinii = DashStyle.DashDotDot;
                        break;
                    case 4:
                        anStylLinii = DashStyle.DashDot;
                        break;
                    case 5:
                        anStylLinii = DashStyle.Solid;
                        break;
                    default:
                        anStylLinii= DashStyle.Solid;
                        break;
                }
                //wylosowanie grubości linii
                anGruboscLinii = anrnd.Next(1, 10);
                anGruboscPunktu = anrnd.Next(5, 15);
                //wylosowanie figury to utworzenia jej egzemlarza i wykreślenia
                anWylosowanyIndeksFigury = anrnd.Next(WybraneFigury.Count);
                //rozpoznanie wylosowanej figury, utworzenie jej egzeplarza i wykreślenie
                switch (WybraneFigury[anWylosowanyIndeksFigury].ToString())
                {
                    case "Punkt":
                        //utworzenie egzemplarza Punktu i wpisanie jego referencji do TFG
                        anTFG[anIndexTFG] = new Punkt(anX, anY);
                        //ustawienie atrybutów geometrycznych i graficznych egzemplarzowiklasy punkt
                        anTFG[anIndexTFG].UstalAtrubutyGraficzne(anKolorWypelnienia, anStylLinii, anGruboscPunktu);
                        anTFG[anIndexTFG].Wykresl(anRysownica);
                        //zwiększenie indeksu
                        anIndexTFG++;
                        break;
                    case "Linia":
                        //wylosowanie współrzędnych końca linii
                        anXk = anrnd.Next(anMargines, anXmax - anMargines);
                        anYk = anrnd.Next(anMargines, anYmax - anMargines);
                        anTFG[anIndexTFG] = new Linia(anX, anY, anXk, anYk);
                        //ustawienie atrybutów geometrycznych i graficznych egzemplarzowi klasy punkt
                        anTFG[anIndexTFG].UstalAtrubutyGraficzne(anKolorLinii, anStylLinii, anGruboscLinii);
                        anTFG[anIndexTFG].Wykresl(anRysownica);
                        //zwiększenie indeksu
                        anIndexTFG++;
                        break;
                    case "Elipsa":
                        //wylosowaie osi dużej i małej
                        anOsDuza = anrnd.Next(anMargines, anXmax/4 - anMargines);
                        anOsMala = anrnd.Next(anMargines, anYmax/4 - anMargines);
                        anTFG[anIndexTFG] = new Elipsa(anX, anY, anOsDuza, anOsMala);
                        //ustawienie atrybutów geometrycznych i graficznych egzemplarzowi klasy elipsa
                        anTFG[anIndexTFG].UstalAtrubutyGraficzne(anKolorLinii, anStylLinii, anGruboscLinii);
                        anTFG[anIndexTFG].Wykresl(anRysownica);
                        anIndexTFG++;
                        break;
                    case "Okrąg":
                        //wylosowanie promienia
                        anPromien = anrnd.Next(anMargines, anYmax/4);
                        anTFG[anIndexTFG] = new Okrag(anX, anY, anPromien);
                        anTFG[anIndexTFG].UstalAtrubutyGraficzne(anKolorLinii, anStylLinii, anGruboscLinii);
                        anTFG[anIndexTFG].Wykresl(anRysownica);
                        anIndexTFG++;
                        break;
                    case "Kwadrat":
                        //wylosowanie współrzędnych końca linii
                        int bok = anrnd.Next(5, 80);
                        anXk = anrnd.Next(anMargines, anXmax - anMargines);
                        anYk = anrnd.Next(anMargines, anYmax - anMargines);
                        anTFG[anIndexTFG] = new Kwadrat(anX, anY, bok, bok);
                        //ustawienie atrybutów geometrycznych i graficznych egzemplarzowi klasy punkt
                        anTFG[anIndexTFG].UstalAtrubutyGraficzne(anKolorLinii, anStylLinii, anGruboscLinii);
                        anTFG[anIndexTFG].Wykresl(anRysownica);
                        //zwiększenie indeksu
                        anIndexTFG++;
                        break;
                    case "Prostokąt":
                        //wylosowanie współrzędnych końca linii
                        anXk = anrnd.Next(anMargines, anXmax - anMargines);
                        anYk = anrnd.Next(anMargines, anYmax - anMargines);
                        anTFG[anIndexTFG] = new Prostokąt(anX, anY, anrnd.Next(5, 100), anrnd.Next(5, 100));
                        //ustawienie atrybutów geometrycznych i graficznych egzemplarzowi klasy punkt
                        anTFG[anIndexTFG].UstalAtrubutyGraficzne(anKolorLinii, anStylLinii, anGruboscLinii);
                        anTFG[anIndexTFG].Wykresl(anRysownica);
                        //zwiększenie indeksu
                        anIndexTFG++;
                        break;
                   
                    //itd, itd...

                    default:
                        MessageBox.Show("Wylosowana figura: " 
                            + chlbFiguryGeometryczne.CheckedItems[anWylosowanyIndeksFigury].ToString()
                            + " nie jest jeszcze obsługiwana");
                            return;
                        
                }//od switcha
                pbRysownica.Refresh();

            }// od for (int i = 0; i < N; i++)


            //odświeżenie powierzchni graficznej
            pbRysownica.Refresh();
            //ustawienie stanu braku aktywności dla przycisków btnPrzesunLosowo i btnLosujAtyrbuty
            btnPrzesunLosowo.Enabled = true;
            btnLosujAtrybuty.Enabled = true;
            //ustawienie stanu braku aktywności dla btnStart
            btnStart.Enabled = false;

        }

        private void btnPrzesunLosowo_Click(object sender, EventArgs e)
        {
            //deklaracja i utworzenie egzemplarza liczb losowwych
            Random anrnd = new Random();
            //deklaracje zmiennych pomocniczych
            int anXp, anYp;
            int anXmax, anYmax;
            //wymazanie (oczyszczenie) powierzchni graficznej
            anRysownica.Clear(pbRysownica.BackColor);
            //wyznaczenie rozmiarów Rysownicy
            anXmax = pbRysownica.Width;
            anYmax = pbRysownica.Height;
            //losowanie nowego położenia (lokalizacji) dla wszystkich figur gometrycznych,
            //których referencje ich egzemplarzy są wpisane do tablict TFG
            for (int ani = 0; ani < anTFG.Length; ani++)
            {//wylosowanie nowego położenia dla i-tej figury geometrycznej
                anXp = anrnd.Next(anMargines, anXmax-anMargines);
                anYp = anrnd.Next(anMargines, anYmax-anMargines);
                //zmiana położenia i-tej figury geometrycznej ( i jej wykreślenie)
                anTFG[ani].PrzesunDoNowegoXY(pbRysownica, anRysownica, anXp, anYp);
            }
            //odświeżenie powierzchni graficznej
            pbRysownica.Refresh();
        }

        private void btnLosujAtrybuty_Click(object sender, EventArgs e)
        {
            //deklaracja i utworzenie egzemplarza operwatora liczb losowych
            Random anrnd = new Random();
            //deklaracje zmiennych dla przechowania wartości atrybutów geo. i graf.
            int anXp, anYp;
            Color anKolorLinii, anKolorWypełnienia;
            int anGrubośćLinii;
            DashStyle anStylLinii;
            int anXmax, anYmax;
            //oczyszczenie i wymazaniepowierzchni graficznej
            anRysownica.Clear(pbRysownica.BackColor);
            //wyznaczenie rozmiarów powierzchni graficznej
            anXmax= pbRysownica.Width;
            anYmax= pbRysownica.Height;
            //losowanie atrybutów geom... i graf... dla kolejnych figur wpisanych do tablicy TFG
            for (int ani = 0; ani < anTFG.Length; ani++)
            {
                //losowanie koloru linii
                anKolorLinii = Color.FromArgb(
                                            anrnd.Next(0, 255),
                                            anrnd.Next(0, 255),
                                            anrnd.Next(0, 255),
                                            anrnd.Next(0, 255));
                anKolorWypełnienia = Color.FromArgb(
                                            anrnd.Next(0, 255),
                                            anrnd.Next(0, 255),
                                            anrnd.Next(0, 255),
                                            anrnd.Next(0, 255));
                //wylosowanie stylu linii
                switch (anrnd.Next(1,6))
                {
                    case 1:
                        anStylLinii = DashStyle.Dash;
                        break;
                    case 2:
                        anStylLinii = DashStyle.Dot;
                        break;
                    case 3:
                        anStylLinii = DashStyle.DashDotDot;
                        break;
                    case 4:
                        anStylLinii = DashStyle.DashDot;
                        break;
                    case 5:
                        anStylLinii = DashStyle.Solid;
                        break;
                    default:
                        anStylLinii = DashStyle.Solid;
                        break;
                }
                //wylosowanie grubości linii
                anGrubośćLinii = anrnd.Next(1, anMargines);
                //ustalenie nowych atrybutów graficznych i geometrycznych dla i-tego figury geometrycznej
                anTFG[ani].UstalAtrubutyGraficzne(anKolorLinii, anStylLinii, anGrubośćLinii);
                anTFG[ani].UstalAtrubutyGraficzne(anKolorWypełnienia);
                //wylosowanie nowego położenia dla i-tej figury geometrycznej
                anXp = anrnd.Next(anMargines, anXmax - anMargines);
                anYp = anrnd.Next(anMargines, anYmax - anMargines);
                //przesunięcie i-tej figury do nowego położenia: XP i Yp
                anTFG[ani].PrzesunDoNowegoXY(pbRysownica, anRysownica, anXp, anYp);
            }
            //odświeżenie pow. graficznej
            pbRysownica.Refresh();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //wymazanie całej powierzchni graficznej
            anRysownica.Clear(pbRysownica.BackColor);
            //wyznaczenie rozmiarów powierzchni graficznej
            int anXmax = pbRysownica.Width;
            int anYmax = pbRysownica.Height;
            //wpisanie do kontrolki slajder indeksu TFG pokazywanej figury
            txtIndeksTablicyTFG.Text = timer1.Tag.ToString();
            //wykreślenie figury o indeksie timer1.Tag w środku powierzchni graficznej
            anTFG[(int)(timer1.Tag)].PrzesunDoNowegoXY(pbRysownica, anRysownica, anXmax / 2, anYmax / 2);
            //odświeżenie pow. graficznej
            pbRysownica.Refresh();
            //ustawienie indeksu dla następnej figury do pokazu
            timer1.Tag = ((int)(timer1.Tag) + 1) % (anTFG.Length);
        }

        private void btnPowrot_Click(object sender, EventArgs e)
        {
            foreach (Form anitem in Application.OpenForms)
            {
                if (anitem.Name == "Form1")
                {
                    Hide();
                    anitem.Show();
                    break;
                }
            }
        }

        private void btnResetujRysowanieFigur_Click(object sender, EventArgs e)
        {
            txtN.Text = "";
            anRysownica.Clear(pbRysownica.BackColor);
            btnPrzesunLosowo.Enabled = false;
            btnLosujAtrybuty.Enabled = false;
            chlbFiguryGeometryczne.Enabled = true;
            btnStart.Enabled = true;
            btnWłączenieSlajdera.Enabled = false;
            btnWyłączenieSlajdera.Enabled = false;
            pbRysownica.Refresh();
            //zresetowanie ComboBox z figurami geometrycznymi
            chlbFiguryGeometryczne.Items.Clear();
            chlbFiguryGeometryczne.Items.Add("Punkt");
            chlbFiguryGeometryczne.Items.Add("Linia");
            chlbFiguryGeometryczne.Items.Add("Elipsa");
            chlbFiguryGeometryczne.Items.Add("Okrąg");
            chlbFiguryGeometryczne.Items.Add("Prostokąt");
            chlbFiguryGeometryczne.Items.Add("Kwadrat");

        }

        private void btnWłączenieSlajdera_Click(object sender, EventArgs e)
        {
            //wyczyszczenie rysownicy
            anRysownica.Clear(pbRysownica.BackColor);
            //ustawienie indeksu TFG dla pokazu pierwszej figury
            timer1.Tag = 0;
            txtIndeksTablicyTFG.Text = 0.ToString();
            //wykreślenie pierwszej figury
            //wyznaczenie rozmiarów rysownicy
            int anXmax = pbRysownica.Width;
            int anYmax = pbRysownica.Height;
            //przesunięcie i wykreślenie pierwszej figury
            anTFG[0].PrzesunDoNowegoXY(pbRysownica, anRysownica, anXmax/2, anYmax/2);
            //odświeżenie powierzchni graficznej 
            pbRysownica.Refresh();
            //rozpoznanie wybranego trybu figur geometrycznych
            if (rdbAutomatyczny.Checked)
            {
                //uaktywnienie zegara
                timer1.Enabled = true;
            }
            else
            { //stawienie stanu braku aktywności dla kontrolek slajdera manualnego
                btnNastępny.Enabled = true;
                btnPoprzedni.Enabled = true;
                txtIndeksTablicyTFG.Enabled = true;
            }
            //ustawienie stanu braku aktywności dla przycisku włącz slajder
            btnWłączenieSlajdera.Enabled = false;
            //uaktywnienie przycisku btnWyłączenieSlajdera
            btnWyłączenieSlajdera.Enabled = true;
            
        }

        private void btnWyłączenieSlajdera_Click(object sender, EventArgs e)
        {
            //wyczyszczenie rysownicy
            anRysownica.Clear(pbRysownica.BackColor);
            //wyłączenie zegara
            timer1.Enabled = false;
            //ustawienie indeksu na 0
            txtIndeksTablicyTFG.Text = "";
            //uaktywnienie przycisku poleceń WączenieSlajdera
            btnWłączenieSlajdera.Enabled = true;
            //ustawienie stanu braku aktywności dla przycisku btnWyłączenieSlajdera
            btnWyłączenieSlajdera.Enabled = false;
            //uaktywnienie/brak aktywności przycisków slajdera
            rdbAutomatyczny.Checked = true;
            btnNastępny.Enabled = false;
            btnPoprzedni.Enabled = false;
            txtIndeksTablicyTFG.Enabled = false;
            //ponowne wykreślenie wszystkich figur "zapisanych" w TFG
            Random rnd = new Random();
            //deklaracje pomocnicze
            int anx, any;
            //wyznaczenie rozmiarów rysownicy
            int anXmax = pbRysownica.Width;
            int anYmax = pbRysownica.Height;
            //wykreślenie wszystkich figur z TFG w losowej lokalizacji
            for (int ani = 0; ani < anTFG.Length; ani++)
            {
                //wylosowanie nowej lokalizacji: (x, y) dla i-tej figury
                anx = rnd.Next(anMargines, anXmax - anMargines);
                any = rnd.Next(anMargines, anYmax - anMargines);
                //zmiana lokalizacji i-tej figury geometrycznej i wykreślenie
                anTFG[ani].PrzesunDoNowegoXY(pbRysownica, anRysownica, new Point(anx, any));
            }
            //odświeżenie powierzchni graficznej
            pbRysownica.Refresh();
        }

        private void btnNastępny_Click(object sender, EventArgs e)
        {
            //deklaracja pomocnicza
            ushort anIndexFigury;
            // pobieranie z kontrolki textbox indexu aktualnie wykreślonej figury
            anIndexFigury = ushort.Parse(txtIndeksTablicyTFG.Text);
            //wyznaczenie indeksu dla następnej figury
            if(anIndexFigury < anTFG.Length - 1)
            {
                anIndexFigury++;
            }
            else
            {
                anIndexFigury = 0;
            }

            //deklaracje pomocnicze
            //wyznaczenie rozmiarów rysownicy
            int anXmax = pbRysownica.Width;
            int anYmax = pbRysownica.Height;
           
            //zmiana lokalizacji i-tej figury geometrycznej i wykreślenie
            anTFG[anIndexFigury].PrzesunDoNowegoXY(pbRysownica, anRysownica, anXmax / 2, anYmax / 2);
            //odświeżenie powierzchni graficznej
            pbRysownica.Refresh();
            //uaktualnienie zapisu indeksu aktualnie wykreślonej figury
            txtIndeksTablicyTFG.Text = anIndexFigury.ToString();
        }

        private void txtIndeksTablicyTFG_TextChanged(object sender, EventArgs e)
        {
            errorProvider1.Dispose();
            ushort anIndeksFigury;

            if (txtIndeksTablicyTFG.Text == "")
                return;
            //pobranie numeru indeksu TFG wpisanego do kontrolki TextBox
            if (!ushort.TryParse(txtIndeksTablicyTFG.Text, out anIndeksFigury))
            {
                errorProvider1.SetError(txtIndeksTablicyTFG, "ERROR: w zapisie " + " indeksu figury wystąpił nieprawidłowy znak");
                return;
            }
            //sprawdzenie warunku zawartość 
            if (anIndeksFigury > anTFG.Length - 1)
            {
                errorProvider1.SetError(txtIndeksTablicyTFG, "ERROR: przekroczenie dopuszczalnej wartości indeksu: " + (anTFG.Length - 1).ToString());
                return;
            }
            //wyczyszczenie rysownicy
            anRysownica.Clear(pbRysownica.BackColor);
            //deklaracje pomocnicze
            //wyznaczenie rozmiarów rysownicy
            int anXmax = pbRysownica.Width;
            int anYmax = pbRysownica.Height;
            //zmiana lokalizacji i-tej figury geometrycznej i wykreślenie
            anTFG[anIndeksFigury].PrzesunDoNowegoXY(pbRysownica, anRysownica, anXmax / 2, anYmax / 2);
            //odświeżenie powierzchni graficznej
            pbRysownica.Refresh();
        }

        private void btnPoprzedni_Click(object sender, EventArgs e)
        {
            //deklaracja pomocnicza
            ushort anIndexFigury;
            // pobieranie z kontrolki textbox indexu aktualnie wykreślonej figury
            anIndexFigury = ushort.Parse(txtIndeksTablicyTFG.Text);
            //wyznaczenie indeksu dla następnej figury
            if (anIndexFigury != 0)
            {
                anIndexFigury--;
            }
            else
            {
                anIndexFigury = (ushort)(anTFG.Length - 1);
            }

            //deklaracje pomocnicze
            //wyznaczenie rozmiarów rysownicy
            int anXmax = pbRysownica.Width;
            int anYmax = pbRysownica.Height;

            //zmiana lokalizacji i-tej figury geometrycznej i wykreślenie
            anTFG[anIndexFigury].PrzesunDoNowegoXY(pbRysownica, anRysownica, anXmax / 2, anYmax / 2);
            //odświeżenie powierzchni graficznej
            pbRysownica.Refresh();
            //uaktualnienie zapisu indeksu aktualnie wykreślonej figury
            txtIndeksTablicyTFG.Text = anIndexFigury.ToString();
        }
    }
}
