using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Projekt2_Nowalski57295
{
    internal class FiguryGeometryczne
    {
        public class Punkt
        {
            const int anDomyslnyRozmiarPunktu = 20;
            protected int anX;
            protected int anY;
            protected int anGruboscLinii;
            protected Color anKolor;
            protected bool anWidoczny; // true - widoczny, false - nie

            protected Color anKolorTla;
            protected DashStyle anStylLinii;

            public Punkt (int anx, int any)
            {
                //inicjowanie pól(atrybutów) klasy Punkt na podstawie wartości parametrów aktualnych konstruktora
                anX = anx;
                anY = any;
                //wartości domyślne
                anKolor = Color.Black;
                anKolorTla = Color.White;
                anStylLinii = DashStyle.Solid;
                anGruboscLinii = anDomyslnyRozmiarPunktu;
                anWidoczny = false;
            }
            public Punkt (int anx, int any, Color anKolor): this(anx, any)
            //this (x, y) to przekazanie parametrów do zadeklarowanego konstruktora dwuargumentowego w tej samej klasie Punkt
            {
                //inicjowanie pól(argumentów) klasy Punkt na podstawie wartości parametrów aktualnych konstruktora
                this.anKolor = anKolor;//wpisanie do pola egzemplarza klasy Punkt wartości trzeciego parametru tego konstruktora
            }
            public Punkt(int anx, int any, Color anKolor, int anRozmiarPunktu): this(anx, any, anKolor)
            //this (x, y) to przekazanie parametrów do zadeklarowanego konstruktora trzyargumentowego w tej samej klasie Punkt
            {
                //inicjowanie pól(argumentów) klasy Punkt na podstawie wartości parametrów aktualnych konstruktora
                anGruboscLinii = anRozmiarPunktu;
            }
            public Punkt(int anx, int any, Color anKolor, DashStyle anStylLinii, int anRozmiarPunktu) : this(anx, any, anKolor)
            {
                //inicjowanie pól(argumentów) klasy Punkt na podstawie wartości parametrów aktualnych konstruktora
                this.anStylLinii = anStylLinii;
                anGruboscLinii = anRozmiarPunktu;
            }
            /*public Point Lokalizacja
            {
                get { return new Point(X, Y); }
                set {  new Point(X, Y); }
            }*/
            public virtual void UaktualnijXY(int anx, int any)
            {
                this.anX = anx;
                this.anY = any;
            }
            //przeciążenie metody: UaktualnijXY() dla innego sposobu przekazywania argumentów
            public virtual void UaktualnijXY(Point anNowaLokalizacja)
            {
                anX = anNowaLokalizacja.X;
                anY = anNowaLokalizacja.Y;
            }
            public void UstalAtrubutyGraficzne(Color anKolorLinii, DashStyle anStylLinii, int anGruboscLinii)
            {
                anKolor = anKolorLinii;
                this.anStylLinii = anStylLinii;
                this.anGruboscLinii = anGruboscLinii;
            }
            //przeciążenie metody UstalAtrubutyGraficzne()
            public void UstalAtrubutyGraficzne(Color anKolortla)
            {
                this.anKolorTla = anKolortla;
            }
            protected void UStalStylLinii(DashStyle anStylLinii)
            {
                this.anStylLinii = anStylLinii;
            }
            public virtual void Wykresl(Graphics anRysownica)
            {
                //wykreslanie punktu jako wypełnionego okręgu
                SolidBrush Pedzel = new SolidBrush(anKolor);
                anRysownica.FillEllipse(Pedzel, anX - anGruboscLinii / 2, anY - anGruboscLinii / 2, anGruboscLinii, anGruboscLinii);
                anWidoczny = true;
                Pedzel.Dispose();
            }
            public virtual void Wymaz(Control anKontrolka, Graphics anRysownica)
            {
                if (this.anWidoczny)
                {
                    //gdy punkt jest widoczny to mozemy go wykreslic
                    //wypełniony okrąg (elips) w kolorze tła kontrolki,
                    //na której został utworzony egzemplarz powierzchni graficznej
                    SolidBrush Pedzel = new SolidBrush(anKontrolka.BackColor);
                    anRysownica.FillEllipse(Pedzel, anX - anGruboscLinii / 2, anY - anGruboscLinii / 2, anGruboscLinii, anGruboscLinii);
                    anWidoczny = false;
                    Pedzel.Dispose();
                }
            }
            public virtual void PrzesunDoNowegoXY(Control anKontrolka, Graphics anRysownica, Point anNowaLokalizacja)
            {
                UaktualnijXY(anNowaLokalizacja);
                Wykresl(anRysownica);
            }
            //przeciążenie metody: PrzesunDoNowegoXY(), dla innego sposobu przekazywania parametrów
            public virtual void PrzesunDoNowegoXY(Control anKontrolka, Graphics anRysownica, int anx, int any)
            {
                UaktualnijXY(anx, any);
                Wykresl(anRysownica);
            }
        }
        public class Linia : Punkt
        {
            //deklaracje dla przechowania współrzędnyc końca linii
            int anXk, anYk;//deklaracje prywatne, gdyż klasa nie będzie klasą bazową dla innych klas potomnych

            public Linia (int anXp, int anYp, int anXk, int anYk) : base(anXp, anYp)
            {
                this.anXk = anXk;
                this.anYk = anYk;
            }
            public Linia(int anXp, int anYp, int anXk, int anYk, Color anKolorLinii, DashStyle anStylLinii, 
                         int anGruboscLinii) : base(anXp, anYp, anKolorLinii, anStylLinii, anGruboscLinii)
            {
                this.anXk=anXk;
                this.anYk=anYk;
            }
            public override void Wykresl(Graphics anRysownica)
            {
                //deklaracja i utworzenie egzemplarza pióra oraz
                //ustawienie koloru linii i jej grubości
                Pen Pioro = new Pen(anKolor, this.anGruboscLinii);
                //ustawienie stylu linii
                Pioro.DashStyle = anStylLinii;
                //Wykreślenie linii
                anRysownica.DrawLine(Pioro, anX, anY, anXk, anYk);
                anWidoczny = true; //linia została wykreślina
                Pioro.Dispose();//zwolnienie zasobów graficznych (Pióra)
            }
            public override void Wymaz(Control anKontrolka, Graphics anRysownica)
            {
                //gdy linia jest widoczna, to wymazujemy ją wykreślając "nową"
                //linię w kolorze tła kontrolki, na której został utworzony egzemplarz powierzchni graficznej
                if (anWidoczny)
                {   //deklaracja i utworzenie egzemplarza pióra w kolorze tła
                    //kontrolki oraz ustawienie grubości i stylu linii
                    Pen Pioro = new Pen(anKontrolka.BackColor, this.anGruboscLinii);
                    //ustawienie stylu linii
                    Pioro.DashStyle = anStylLinii;
                    //Wykreślenie linii
                    anRysownica.DrawLine(Pioro, anX, anY, anXk, anYk);
                    anWidoczny = false; //linia została wykreślina
                    Pioro.Dispose();//zwolnienie zasobów graficznych (Pióra)
                }
            }
            public override void PrzesunDoNowegoXY(Control anKontrolka, Graphics anRysownica, int anx, int any)
            {
                //deklaracja zmiennych dla wyznaczenia wektora przesunięcia
                int dx, dy;
                //wyznaczenie przyrostu zmian współrzędnej X oraz Y
                if (anx > anX)
                    dx = anx - anX;
                else
                    dx = anX - anx;
                if(any > anY)
                    dy = any - anY;
                else 
                    dy = anY - any;
                //zmiana (uaktualnienie) współrzędnej początku linii
                anX = anx;
                anY = any;
                //zmiana (uaktualnienie) współrzędnych końca linii tak, aby nie wychodziły
                //poza obszar powierzchni graficznej
                anXk = (anXk + dx) % anKontrolka.Width;
                anYk = (anYk + dy) % anKontrolka.Height;
                //wykreślenie linii o uaktualnionych współrzędnych początku i końca linii
                Wykresl(anRysownica);
            }
        }
        public class Elipsa : Punkt
        {
            protected int anOsDuza, anOsMala;//oś duża i oś mała elipsy
            //deklaracje chronione, gdyż klasa Eklipsa jest klasą bazową dla klasy Okrąg

            public Elipsa(int anx, int any, int anOsDuza, int anOsMala) : base(anx, any)
            {
                this.anOsDuza = anOsDuza;
                this.anOsMala = anOsMala;
            }
            public Elipsa(int anx, int any, int anOsDuza, int anOsMala, Color anKolorLinii, DashStyle anStylLinii, 
                          int anGruboscLinii) : base(anx, any, anKolorLinii, anStylLinii, anGruboscLinii)
            {
                this.anOsDuza = anOsDuza;
                this.anOsMala = anOsMala;
            }
            public override void Wykresl(Graphics anRysownica)
            {
                //deklaracja i utworzenie egzemplarza pióra oraz ustawienie koloru linii i jej grubości
                Pen Pioro = new Pen(anKolor, this.anGruboscLinii);
                //formatowanie pióra (gdzie zmienna: StylLinii jest zadeklarowana w klasie bazowej Punkt)
                Pioro.DashStyle = anStylLinii;
                //wykreślenie elipsy
                anRysownica.DrawEllipse(Pioro, anX, anY, anOsDuza, anOsMala);
                anWidoczny = true; //elipsa została wykreślina
                Pioro.Dispose(); //zwolnienie pióra
            }
            public override void Wymaz(Control anKontrolka, Graphics anRysownica)
            {
                //gdy elipsa jest widoczna, to wymazujemy ją wykreślając "nową"
                //elipsę w kolorze tła kontrolki, na której został utworzony egzemplarz powierzchni graficznej
                if (this.anWidoczny)
                {
                    //deklaracja i utworzenie egzemplarza pióra w kolorze tła kontrolki
                    //oraz ustawienie grubości i stylu linii
                    Pen Pioro = new Pen(anKontrolka.BackColor, this.anGruboscLinii);
                    Pioro.DashStyle = anStylLinii;
                    //wymazanie elipsy (czyli wykreślenie elipsy w kolorze tła kontrolki
                    anRysownica.DrawEllipse(Pioro, anX, anY, anOsDuza, anOsMala);
                    anWidoczny = false;
                    Pioro.Dispose();
                }
            }
        }
        public class Okrag : Elipsa
        {
            protected int anPromien;
            //deklaracja chroniona, gdyż klasa Okrąg może być klasą bazową dla innych klas potomnych (takich jak łuk okręgu)
            //czyli dla innych figur geometrycznych

            public Okrag(int anx, int any, int anPromien) : base(anx, any, 2 * anPromien, 2 * anPromien)
            {
                this.anPromien = anPromien;
            }
            public Okrag(int anx, int any, int anPromien, Color anKolorLinii, DashStyle anStylLinii,
                         int anGruboscLinii) : base(anx, any, 2 * anPromien, 2 * anPromien, anKolorLinii, anStylLinii, anGruboscLinii)
            {
                this.anPromien = anPromien;
            }
            public override void Wymaz(Control anKontrolka, Graphics anRysownica)
            {
                //gdy okrąg jest widoczny, to wymazujemy go wykreślając "nowy" okrąg w kolorze tła kontrolki, na
                //której został utworzony egzemplarz powierzchni graficznej
                if (this.anWidoczny)
                {
                    //deklaracja i utworzenie egzemplarza pióra w kolorze tła kontrolki
                    //oraz ustawienie grubości i stylu linii
                    Pen Pioro = new Pen(anKontrolka.BackColor, this.anGruboscLinii);
                    Pioro.DashStyle = anStylLinii;
                    //wymazanie okręgu (czyli wykreślenie okręgu w kolorze tła kontrolki)
                    anRysownica.DrawEllipse(Pioro, anX, anY, 2 * anPromien, 2 * anPromien);
                    anWidoczny = false;
                    Pioro.Dispose();
                }
            }
        }
        //pozostałe deklaracje klas dla figur nieregularnych : prostokąt...

        //deklaracja klasy  dla linii ciągłej kreślonej myszą
        public class LiniaKreslonaMysza : Punkt
        {
            //deklaracja listy punktów linii ciągłej
            List<Point> anListaPunktów = new List<Point>();
            //deklaracja konstruktorów klasy LiniaKreslonaMysza
            public LiniaKreslonaMysza(Point anPoczątekLinii) : base(anPoczątekLinii.X, anPoczątekLinii.Y)
            {
                //dodanie do listy punktów LiniaPunktów
                anListaPunktów.Add(anPoczątekLinii);
            }
            public LiniaKreslonaMysza(Point anPunkt, Color anKolor, DashStyle anStylLinii, int anGrubośćLinii)
                : base( anPunkt.X, anPunkt.Y, anKolor, anGrubośćLinii)
            {

            }

            //deklaracja metod
            public void DodajNowyPunktKreslonejLinii(Point anNowyPunkt)
            {
                anListaPunktów.Add(anNowyPunkt);
            }
            public override void UaktualnijXY(int anx, int any)
            {
                if (anListaPunktów.Count < 1)
                {
                    //lista jest pusta
                    return;
                }
                //realizacja operacji UaktualnijXY wymaga zmiany położenia wszystkich punktów wykreślonej linii
                //deklaracja zmiennych pomocniczych dla wyznaczenia przyrostu zmian współrzędnej x oraz y
                int PrzyrostX = anListaPunktów[0].X - anx;
                int PrzyrostY = anListaPunktów[0].Y - any;
                //zmiana położenia wszystkich punktów linii kreślonej myszą
                for (int i = 0; i < anListaPunktów.Count; i++)
                {
                    anListaPunktów[i] = new Point (anListaPunktów[i].X - PrzyrostX,anListaPunktów[i].Y - PrzyrostY);
                }
            }
            public override void Wykresl(Graphics anRysownica)
            {
                //deklaracjapomocniczej tablicy dla wpisanie wspłrzędnych wszystkich punktów wykreślinej linii myszą
                Point[] TablicaPunktów = new Point[anListaPunktów.Count];
                //przepisanie współrzędnych wszystkich punktów wykreślinej linii myszą
                for (int i = 0; i < anListaPunktów.Count; i++)
                    TablicaPunktów[i] = anListaPunktów[i];
                //wykreślenie linii której współrzędne punktów są wpisane ddo tablicy TablicaPunktów
                Pen Pióro = new Pen(anKolor, anGruboscLinii);
                Pióro.DashStyle = anStylLinii;
                //wykreślenie lini, w której współrzędne punktów są zapisane w TablicaPunktów
                anRysownica.DrawLines(Pióro, TablicaPunktów);
            }
            public override void Wymaz(Control anKontrolka, Graphics anRysownica)
            {
                //deklaracjapomocniczej tablicy dla wpisanie wspłrzędnych wszystkich punktów wykreślinej linii myszą
                Point[] anTablicaPunktów = new Point[anListaPunktów.Count];
                //przepisanie współrzędnych wszystkich punktów wykreślinej linii myszą
                for (int ani = 0; ani < anListaPunktów.Count; ani++)
                    anTablicaPunktów[ani] = anListaPunktów[ani];
                //deklaracja pióra do wymazywanie
                Pen anPióroGumka = new Pen(anKontrolka.BackColor, anGruboscLinii);
                anPióroGumka.DashStyle = anStylLinii;
                //wymazanie lini, w której współrzędne punktów są zapisane w TablicaPunktów
                anRysownica.DrawLines(anPióroGumka, anTablicaPunktów);
            }

            //deklaracja metod nadpisujących metody wirtualne klasy Punkt
        }
        public class Kwadrat:Linia
        {
            //zmienne wierzchołków kwadratu
            int anXk, anYk;
            public Kwadrat(int anXp,int anYp, int anXk, int anYk): base(anXp, anYp, anXk, anYk)
            {
                this.anXk = anXk;
                this.anYk = anYk;
            }
            public Kwadrat(int anXp, int anYp, int anXk, int anYk, Color anKolorLinii, DashStyle anStylLinii,
                         int anGruboscLinii): base(anXp, anYp, anXk, anYk, anKolorLinii, anStylLinii, anGruboscLinii)
            {
                this.anXk = anXk;
                this.anYk = anYk;
            }
            public override void Wykresl(Graphics anRysownica)
            {
                //deklaracja i utworzenie egzemplarza pióra oraz
                //ustawienie koloru linii i jej grubości
                Pen Pioro = new Pen(anKolor, this.anGruboscLinii);
                //ustawienie stylu linii
                Pioro.DashStyle = anStylLinii;
                //Wykreślenie linii
                anRysownica.DrawRectangle(Pioro, anX, anY, anXk, anXk);
                anWidoczny = true; //kwadrat został wykreśliny
                Pioro.Dispose();//zwolnienie zasobów graficznych (Pióra)
            }
            public override void Wymaz(Control anKontrolka, Graphics anRysownica)
            {
                //gdy kwadrat jest widoczny, to wymazujemy go wykreślając "nowy"
                //kwadrat w kolorze tła kontrolki, na której został utworzony egzemplarz powierzchni graficznej
                if (anWidoczny)
                {   //deklaracja i utworzenie egzemplarza pióra w kolorze tła
                    //kontrolki oraz ustawienie grubości i stylu linii kwadratu
                    Pen Pioro = new Pen(anKontrolka.BackColor, this.anGruboscLinii);
                    //ustawienie stylu linii kwadratu
                    Pioro.DashStyle = anStylLinii;
                    //Wykreślenie kwadratu
                    anRysownica.DrawRectangle(Pioro, anX, anY, anXk, anXk);
                    anWidoczny = false; //linia została wykreślina
                    Pioro.Dispose();//zwolnienie zasobów graficznych (Pióra)
                }
            }
            public override void PrzesunDoNowegoXY(Control anKontrolka, Graphics anRysownica, int anx, int any)
            {
                //deklaracja zmiennych dla wyznaczenia wektora przesunięcia
                int dx, dy;
                //wyznaczenie przyrostu zmian współrzędnej X oraz Y
                if (anx > anX)
                    dx = anx - anX;
                else
                    dx = anX - anx;
                if (any > anY)
                    dy = any - anY;
                else
                    dy = anY - any;
                //zmiana (uaktualnienie) współrzędnej początku kwadratu
                anX = anx;
                anY = any;
                //zmiana (uaktualnienie) współrzędnych końca linii tak, aby nie wychodziły
                //poza obszar powierzchni graficznej
                anXk = (anXk + dx) % anKontrolka.Width;
                anYk = (anYk + dy) % anKontrolka.Height;
                //wykreślenie linii o uaktualnionych współrzędnych początku i końca linii
                Wykresl(anRysownica);
            }
        }
        public class Ośmiokąt:Punkt
        {
            public ushort anLiczbaPunktowKontrolnych
            {
                get;
                set;
            }
            public List<Point> anPunktyOśmiokąta = new List<Point>();
            int anPromienPunktuKontrolnego = 5;

            Font anFontOpisuPunktow = new Font("Arial", 8, FontStyle.Italic);

            public Ośmiokąt(Graphics anRysownica, Pen anPióro, Point anXYpunktu) :
                base(anXYpunktu.X, anXYpunktu.Y, anPióro.Color, anPióro.DashStyle, (int)(anPióro.Width))
            {
                anPunktyOśmiokąta.Add(anXYpunktu);
                using (SolidBrush Pędzel = new SolidBrush(anPióro.Color))
                {
                    //pierwszy punkt
                    anRysownica.FillEllipse(Pędzel, anXYpunktu.X - anPromienPunktuKontrolnego,
                        anXYpunktu.Y - anPromienPunktuKontrolnego, 2 * anPromienPunktuKontrolnego, 2 * anPromienPunktuKontrolnego);
                }
            }
            //deklaracja metody do dodawanie kolejnych punktów kontrolnych
            public void DodajNowyPunktKontrolny(Point anXYpunktu, Graphics anRysownica)
            {
                anPunktyOśmiokąta.Add(anXYpunktu);
                using (SolidBrush Pędzel = new SolidBrush(Color.Red))
                {
                    Pędzel.Color = anKolor;

                    anRysownica.FillEllipse(Pędzel, anXYpunktu.X - anPromienPunktuKontrolnego,
                        anXYpunktu.Y - anPromienPunktuKontrolnego, 2 * anPromienPunktuKontrolnego, 2 * anPromienPunktuKontrolnego);

                }
                //sprawdzenie czy jest to już 8 punkt kontrolny
                if (anPunktyOśmiokąta.Count == 8)
                    Wykresl(anRysownica);
            }
            //nadpisywanie metod
            public override void Wykresl(Graphics anRysownica)
            {
                using (Pen Pióro = new Pen(anKolor, anGruboscLinii))
                {
                    Pióro.DashStyle = anStylLinii;
                    //deklaracja i utworzenie egzemplarza tablicy dla punktóww kontrolnych
                    Point[] PunktyKontrolne = new Point[anPunktyOśmiokąta.Count];
                    //przepisanie do tablicy  PunktyKontrolne wszystkich punktów z listy PunktyKontrolneKrzywejBeziera
                    for (ushort i = 0; i < anPunktyOśmiokąta.Count; i++)
                    {
                        PunktyKontrolne[i] = new Point(anPunktyOśmiokąta[i].X, anPunktyOśmiokąta[i].Y);
                    }
                    //wykreślenie krzywej Beziera
                    anRysownica.DrawPolygon(Pióro, PunktyKontrolne);
                    anWidoczny = true;
                }

            }
            public override void Wymaz(Control anKontrolka, Graphics anRysownica)
            {
                if (anWidoczny)
                {
                    using (Pen Pióro = new Pen(anKontrolka.BackColor, anGruboscLinii))
                    {
                        Pióro.DashStyle = anStylLinii;
                        //deklaracja pomocniczej tablicy dla chwilowego przechowania współrzędnych 
                        //punktów kontrolnych Krzywej Beziera
                        Point[] PunktyŁamanejRysowanie = new Point[anPunktyOśmiokąta.Count];
                        for (int i = 0; i < anPunktyOśmiokąta.Count; i++)
                        {
                            PunktyŁamanejRysowanie[i] = new Point(anPunktyOśmiokąta[i].X,
                                                                anPunktyOśmiokąta[i].Y);
                        }
                        //wykreślenie krzywej beziera w kolorze tła, czyli jej wymazanie
                        anRysownica.DrawPolygon(Pióro, PunktyŁamanejRysowanie);
                        anWidoczny = false;
                    }

                }

            }
            public override void UaktualnijXY(int anx, int any)
            {
                //deklaracje dla wyznaczenia przyrostów zmian wartości współrędnych X i Y
                int PrzyrostX = anPunktyOśmiokąta[0].X - anx;
                int PrzyrostY = anPunktyOśmiokąta[0].Y - any;
                //zmainy lokalizacji krzywej
                for (int i = 0; i < anPunktyOśmiokąta.Count; i++)
                {
                    anPunktyOśmiokąta[i] = new Point(anPunktyOśmiokąta[i].X - PrzyrostX,
                                                                 anPunktyOśmiokąta[i].Y - PrzyrostY);
                }
            }

        }
        public class FillOśmiokąt : Punkt
        {
            public ushort anLiczbaPunktowKontrolnych//
            {
                get;
                set;
            }
            public List<Point> anPunktyOśmiokąta = new List<Point>();
            int anPromienPunktuKontrolnego = 5;

            Font anFontOpisuPunktow = new Font("Arial", 8, FontStyle.Italic);

            public FillOśmiokąt(Graphics anRysownica, Pen anPióro, Point anXYpunktu, SolidBrush anPędzel) :
                base(anXYpunktu.X, anXYpunktu.Y, anPióro.Color, anPióro.DashStyle, (int)(anPióro.Width))
            {
                anPunktyOśmiokąta.Add(anXYpunktu);
                
                
                //pierwszy punkt
                anRysownica.FillEllipse(anPędzel, anXYpunktu.X - anPromienPunktuKontrolnego,
                anXYpunktu.Y - anPromienPunktuKontrolnego, 2 * anPromienPunktuKontrolnego, 2 * anPromienPunktuKontrolnego);
                
            }
            //deklaracja metody do dodawanie kolejnych punktów kontrolnych
            public void DodajNowyPunktKontrolny(Point anXYpunktu, Graphics anRysownica)
            {
                anPunktyOśmiokąta.Add(anXYpunktu);
                using (SolidBrush anPędzel = new SolidBrush(Color.Red))
                {
                    anPędzel.Color = anKolor;

                    anRysownica.FillEllipse(anPędzel, anXYpunktu.X - anPromienPunktuKontrolnego,
                        anXYpunktu.Y - anPromienPunktuKontrolnego, 2 * anPromienPunktuKontrolnego, 2 * anPromienPunktuKontrolnego);

                }
                //sprawdzenie czy jest to już 8 punkt kontrolny
                if (anPunktyOśmiokąta.Count == 8)
                    Wykresl(anRysownica);
            }
            //nadpisywanie metod
            public override void Wykresl(Graphics anRysownica)
            {
                using (SolidBrush anPędzel = new SolidBrush(anKolor)) 
                {
                    
                    //deklaracja i utworzenie egzemplarza tablicy dla punktóww kontrolnych
                    Point[] anPunktyKontrolne = new Point[anPunktyOśmiokąta.Count];
                    //przepisanie do tablicy  PunktyKontrolne wszystkich punktów z listy PunktyKontrolneKrzywejBeziera
                    for (ushort ani = 0; ani < anPunktyOśmiokąta.Count; ani++)
                    {
                        anPunktyKontrolne[ani] = new Point(anPunktyOśmiokąta[ani].X, anPunktyOśmiokąta[ani].Y);
                    }
                    //wykreślenie krzywej Beziera
                    anRysownica.FillPolygon(anPędzel, anPunktyKontrolne);
                    anWidoczny = true;
                }

            }
            public override void Wymaz(Control Kontrolka, Graphics Rysownica)
            {
                if (anWidoczny)
                {
                    using (SolidBrush anPędzel = new SolidBrush(Kontrolka.BackColor))
                    {

                        //deklaracja i utworzenie egzemplarza tablicy dla punktóww kontrolnych
                        Point[] anPunktyKontrolne = new Point[anPunktyOśmiokąta.Count];
                        //przepisanie do tablicy  PunktyKontrolne wszystkich punktów z listy PunktyKontrolneKrzywejBeziera
                        for (ushort ani = 0; ani < anPunktyOśmiokąta.Count; ani++)
                        {
                            anPunktyKontrolne[ani] = new Point(anPunktyOśmiokąta[ani].X, anPunktyOśmiokąta[ani].Y);
                        }
                        //wykreślenie krzywej Beziera
                        Rysownica.FillPolygon(anPędzel, anPunktyKontrolne);
                        anWidoczny =false;
                    }

                }

            }
            public override void UaktualnijXY(int anx, int any)
            {
                //deklaracje dla wyznaczenia przyrostów zmian wartości współrędnych X i Y
                int anPrzyrostX = anPunktyOśmiokąta[0].X - anx;
                int anPrzyrostY = anPunktyOśmiokąta[0].Y - any;
                //zmainy lokalizacji krzywej
                for (int ani = 0; ani < anPunktyOśmiokąta.Count; ani++)
                {
                    anPunktyOśmiokąta[ani] = new Point(anPunktyOśmiokąta[ani].X - anPrzyrostX,
                                                                 anPunktyOśmiokąta[ani].Y - anPrzyrostY);
                }
            }

        }
        public class Prostokąt : Kwadrat
        {
            //zmienne wierzchołków kwadratu
            int anXk, anYk;
            public Prostokąt(int anXp, int anYp, int anXk, int anYk) : base(anXp, anYp, anXk, anYk)
            {
                this.anXk = anXk;
                this.anYk = anYk;
            }
            public Prostokąt(int anXp, int anYp, int anXk, int anYk, Color anKolorLinii, DashStyle anStylLinii,
                         int anGruboscLinii) : base(anXp, anYp, anXk, anYk, anKolorLinii, anStylLinii, anGruboscLinii)
            {
                this.anXk = anXk;
                this.anYk = anYk;
            }
            public override void Wykresl(Graphics anRysownica)
            {
                //deklaracja i utworzenie egzemplarza pióra oraz
                //ustawienie koloru linii i jej grubości
                Pen anPioro = new Pen(anKolor, this.anGruboscLinii);
                //ustawienie stylu linii
                anPioro.DashStyle = anStylLinii;
                //Wykreślenie linii
                anRysownica.DrawRectangle(anPioro, anX, anY, anXk, anYk);
                anWidoczny = true; //kwadrat został wykreśliny
                anPioro.Dispose();//zwolnienie zasobów graficznych (Pióra)
            }
            public override void Wymaz(Control anKontrolka, Graphics anRysownica)
            {
                //gdy kwadrat jest widoczny, to wymazujemy go wykreślając "nowy"
                //kwadrat w kolorze tła kontrolki, na której został utworzony egzemplarz powierzchni graficznej
                if (anWidoczny)
                {   //deklaracja i utworzenie egzemplarza pióra w kolorze tła
                    //kontrolki oraz ustawienie grubości i stylu linii kwadratu
                    Pen anPioro = new Pen(anKontrolka.BackColor, this.anGruboscLinii);
                    //ustawienie stylu linii kwadratu
                    anPioro.DashStyle = anStylLinii;
                    //Wykreślenie kwadratu
                    anRysownica.DrawLine(anPioro, anX, anY, anXk, anYk);
                    anWidoczny = false; //linia została wykreślina
                    anPioro.Dispose();//zwolnienie zasobów graficznych (Pióra)
                }
            }
            public override void PrzesunDoNowegoXY(Control anKontrolka, Graphics anRysownica, int anx, int any)
            {
                //deklaracja zmiennych dla wyznaczenia wektora przesunięcia
                int andx, andy;
                //wyznaczenie przyrostu zmian współrzędnej X oraz Y
                if (anx > anX)
                    andx = anx - anX;
                else
                    andx = anX - anx;
                if (any > anY)
                    andy = any - anY;
                else
                    andy = anY - any;
                //zmiana (uaktualnienie) współrzędnej początku kwadratu
                anX = anx;
                anY = any;
                //zmiana (uaktualnienie) współrzędnych końca linii tak, aby nie wychodziły
                //poza obszar powierzchni graficznej
                anXk = (anXk + andx) % anKontrolka.Width;
                anYk = (anYk + andy) % anKontrolka.Height;
                //wykreślenie linii o uaktualnionych współrzędnych początku i końca linii
                Wykresl(anRysownica);
            }
        }
        public class Koło : Okrag
        {
          
            //deklaracja chroniona, gdyż klasa Okrąg może być klasą bazową dla innych klas potomnych (takich jak łuk okręgu)
            //czyli dla innych figur geometrycznych

            public Koło(int anx, int any, int anPromien) : base(anx, any, anPromien)
            {
                this.anPromien = anPromien;
            }
            public Koło(int anx, int any, int anPromien, Color anKolorLinii, DashStyle anStylLinii,
                         int anGruboscLinii) : base( anx, any, anPromien, anKolorLinii, anStylLinii,
                          anGruboscLinii)
            {
                this.anPromien = anPromien;
            }
            public override void Wymaz(Control anKontrolka, Graphics anRysownica)
            {
                //gdy okrąg jest widoczny, to wymazujemy go wykreślając "nowy" okrąg w kolorze tła kontrolki, na
                //której został utworzony egzemplarz powierzchni graficznej
                if (this.anWidoczny)
                {
                    //deklaracja i utworzenie egzemplarza pióra w kolorze tła kontrolki
                    //oraz ustawienie grubości i stylu linii
                    SolidBrush anPędzel = new SolidBrush(anKontrolka.BackColor);
                    //wymazanie okręgu (czyli wykreślenie okręgu w kolorze tła kontrolki)
                    anRysownica.FillEllipse(anPędzel, anX, anY, 2 * anPromien, 2 * anPromien);
                    anWidoczny = false;
                    anPędzel.Dispose();
                }
            }
            public override void Wykresl(Graphics anRysownica)
            {
                //deklaracja i utworzenie egzemplarza pióra oraz ustawienie koloru linii i jej grubości
                SolidBrush anPędzel = new SolidBrush(anKolorTla);
                //formatowanie pióra (gdzie zmienna: StylLinii jest zadeklarowana w klasie bazowej Punkt)
                //wykreślenie elipsy
                anRysownica.FillEllipse(anPędzel, anX, anY, anOsDuza, anOsMala);
                anWidoczny = true; //elipsa została wykreślina
                anPędzel.Dispose(); //zwolnienie pióra
            }
        }
        public class PełnyKwadrat : Linia
        {
            //zmienne wierzchołków kwadratu
            int anXk, anYk;
            public PełnyKwadrat(int anXp, int anYp, int anXk, int anYk) : base(anXp, anYp, anXk, anYk)
            {
                this.anXk = anXk;
                this.anYk = anYk;
            }
            public PełnyKwadrat(int anXp, int anYp, int anXk, int anYk, Color anKolorLinii, DashStyle anStylLinii,
                         int anGruboscLinii) : base(anXp, anYp, anXk, anYk, anKolorLinii, anStylLinii, anGruboscLinii)
            {
                this.anXk = anXk;
                this.anYk = anYk;
            }
            public override void Wykresl(Graphics anRysownica)
            {
                //deklaracja i utworzenie egzemplarza pióra oraz
                //ustawienie koloru linii i jej grubości
                SolidBrush anPędzel = new SolidBrush(anKolor);
                //Wykreślenie linii
                anRysownica.FillRectangle(anPędzel, anX, anY, anXk, anYk);
                anWidoczny = true; //kwadrat został wykreśliny
                anPędzel.Dispose();//zwolnienie zasobów graficznych (Pióra)
            }
            public override void Wymaz(Control anKontrolka, Graphics anRysownica)
            {
                //gdy kwadrat jest widoczny, to wymazujemy go wykreślając "nowy"
                //kwadrat w kolorze tła kontrolki, na której został utworzony egzemplarz powierzchni graficznej
                if (anWidoczny)
                {   //deklaracja i utworzenie egzemplarza pióra w kolorze tła
                    //kontrolki oraz ustawienie grubości i stylu linii kwadratu
                    SolidBrush anPędzel = new SolidBrush(anKolor);
                    //Wykreślenie linii
                    anRysownica.FillRectangle(anPędzel, anX, anY, anXk, anYk);
                    anWidoczny = false; //linia została wykreślina
                    anPędzel.Dispose();//zwolnienie zasobów graficznych (Pióra)
                }
            }
            public override void PrzesunDoNowegoXY(Control anKontrolka, Graphics anRysownica, int anx, int any)
            {
                //deklaracja zmiennych dla wyznaczenia wektora przesunięcia
                int andx, andy;
                //wyznaczenie przyrostu zmian współrzędnej X oraz Y
                if (anx > anX)
                    andx = anx - anX;
                else
                    andx = anX - anx;
                if (any > anY)
                    andy = any - anY;
                else
                    andy = anY - any;
                //zmiana (uaktualnienie) współrzędnej początku kwadratu
                anX = anx;
                anY = any;
                //zmiana (uaktualnienie) współrzędnych końca linii tak, aby nie wychodziły
                //poza obszar powierzchni graficznej
                anXk = (anXk + andx) % anKontrolka.Width;
                anYk = (anYk + andy) % anKontrolka.Height;
                //wykreślenie linii o uaktualnionych współrzędnych początku i końca linii
                Wykresl(anRysownica);
            }
        }
        public class KrzywaBeziera: Punkt
        {
            public List<Point> anPunktyKontrolneKrzywejBeziera = new List<Point>();
            int anPromienPunktuKontrolnego = 5;
            public ushort anLiczbaPunktowKontrolnych//
            {
                get;
                set;
            }

            Font anFontOpisuPunktow = new Font("Arial", 8, FontStyle.Italic);
           /* public KrzywaBeziera(Graphics Rysownica, Pen Pióro, Point XYpunktu) :
                base(XYpunktu.X, XYpunktu.Y, Pióro.Color, (int)(Pióro.Width))
            {
                PunktyKontrolneKrzywejBeziera.Add(XYpunktu);
                using (SolidBrush Pędzel = new SolidBrush(Pióro.Color))
                {
                    //pierwszy punkt
                    Rysownica.FillEllipse(Pędzel, XYpunktu.X - PromienPunktuKontrolnego,
                        XYpunktu.Y - PromienPunktuKontrolnego, 2 * PromienPunktuKontrolnego, 2 * PromienPunktuKontrolnego);
                    Rysownica.DrawString("P" + (PunktyKontrolneKrzywejBeziera.Count - 1).ToString(),
                        FontOpisuPunktow, Pędzel, PunktyKontrolneKrzywejBeziera[PunktyKontrolneKrzywejBeziera.Count - 1]);
                }
            }*/
            public KrzywaBeziera(Graphics anRysownica, Pen anPióro, Point anXYpunktu) :
                base(anXYpunktu.X, anXYpunktu.Y, anPióro.Color, anPióro.DashStyle, (int)(anPióro.Width))
            {
                anPunktyKontrolneKrzywejBeziera.Add(anXYpunktu);
                using (SolidBrush anPędzel = new SolidBrush(anPióro.Color))
                {
                    //pierwszy punkt
                    anRysownica.FillEllipse(anPędzel, anXYpunktu.X - anPromienPunktuKontrolnego,
                        anXYpunktu.Y - anPromienPunktuKontrolnego, 2 * anPromienPunktuKontrolnego, 2 * anPromienPunktuKontrolnego);
                    anRysownica.DrawString("P" + (anPunktyKontrolneKrzywejBeziera.Count - 1).ToString(),
                        anFontOpisuPunktow, anPędzel, anPunktyKontrolneKrzywejBeziera[anPunktyKontrolneKrzywejBeziera.Count - 1]);
                }
            }
            //deklaracja metody do dodawanie kolejnych punktów kontrolnych
            public virtual void DodajNowyPunktKontrolny(Point anXYpunktu, Graphics anRysownica)
                {
                    anPunktyKontrolneKrzywejBeziera.Add(anXYpunktu);
                    using (SolidBrush anPędzel = new SolidBrush(Color.Red))
                    {
                    //pierwszy punkt
                    if (anPunktyKontrolneKrzywejBeziera.Count == 1 || anPunktyKontrolneKrzywejBeziera.Count == 4)
                    {
                        anPędzel.Color = anKolor;
                    }
                        anRysownica.FillEllipse(anPędzel, anXYpunktu.X - anPromienPunktuKontrolnego,
                            anXYpunktu.Y - anPromienPunktuKontrolnego, 2 * anPromienPunktuKontrolnego, 2 * anPromienPunktuKontrolnego);
                        anRysownica.DrawString("P" + (anPunktyKontrolneKrzywejBeziera.Count - 1).ToString(),
                            anFontOpisuPunktow, anPędzel, anPunktyKontrolneKrzywejBeziera[anPunktyKontrolneKrzywejBeziera.Count - 1]);
                    }
                    //sprawdzenie czy jest to już 4 punkt kontrolny
                    if (anPunktyKontrolneKrzywejBeziera.Count == 4)
                        Wykresl(anRysownica);
                }
            //nadpisywanie metod
            public override void Wykresl(Graphics anRysownica)
            {
                using (Pen anPióro = new Pen(anKolor, anGruboscLinii))
                {
                    anPióro.DashStyle = anStylLinii;
                    //deklaracja i utworzenie egzemplarza tablicy dla punktóww kontrolnych
                    Point[] anPunktyKontrolne = new Point[anPunktyKontrolneKrzywejBeziera.Count];
                    //przepisanie do tablicy  PunktyKontrolne wszystkich punktów z listy PunktyKontrolneKrzywejBeziera
                    for (ushort ani = 0; ani < anPunktyKontrolneKrzywejBeziera.Count; ani++)
                    {
                        anPunktyKontrolne[ani] = new Point(anPunktyKontrolneKrzywejBeziera[ani].X, anPunktyKontrolneKrzywejBeziera[ani].Y);
                    }
                    //wykreślenie krzywej Beziera
                    anRysownica.DrawBezier(anPióro, anPunktyKontrolne[0], anPunktyKontrolne[1], 
                                                anPunktyKontrolne[2], anPunktyKontrolne[3]);
                    anWidoczny = true;
                }

            }
            public override void Wymaz(Control anKontrolka, Graphics anRysownica)
            {
                if (anWidoczny)
                {
                    using (Pen anPióro = new Pen(anKontrolka.BackColor, anGruboscLinii))
                    {
                        anPióro.DashStyle = anStylLinii;
                        //deklaracja pomocniczej tablicy dla chwilowego przechowania współrzędnych 
                        //punktów kontrolnych Krzywej Beziera
                        Point[] anPunktyKrzywejBeziera = new Point[anPunktyKontrolneKrzywejBeziera.Count];
                        for (int ani = 0; ani < anPunktyKontrolneKrzywejBeziera.Count; ani++)
                        {
                            anPunktyKrzywejBeziera[ani] = new Point(anPunktyKontrolneKrzywejBeziera[ani].X,
                                                                anPunktyKontrolneKrzywejBeziera[ani].Y);
                        }
                        //wykreślenie krzywej beziera w kolorze tła, czyli jej wymazanie
                        anRysownica.DrawBezier(anPióro, anPunktyKrzywejBeziera[0], anPunktyKrzywejBeziera[1],
                                                anPunktyKrzywejBeziera[2], anPunktyKrzywejBeziera[3]);
                        anWidoczny = false;
                    }

                }
                
            }
            public override void UaktualnijXY(int anx, int any)
            {
                //deklaracje dla wyznaczenia przyrostów zmian wartości współrędnych X i Y
                int PrzyrostX = anPunktyKontrolneKrzywejBeziera[0].X - anx;
                int PrzyrostY = anPunktyKontrolneKrzywejBeziera[0].Y - any;
                //zmainy lokalizacji krzywej
                for (int ani = 0; ani < anPunktyKontrolneKrzywejBeziera.Count; ani++)
                {
                    anPunktyKontrolneKrzywejBeziera[ani] = new Point(anPunktyKontrolneKrzywejBeziera[ani].X - PrzyrostX,
                                                                 anPunktyKontrolneKrzywejBeziera[ani].Y - PrzyrostY);
                }
            }
           
        }
        public class Łamana: Punkt
        {
            public ushort anLiczbaPunktowKontrolnych//
            {
                get;
                set;
            }
            public List<Point> anPunktyŁamanej = new List<Point>();
            int anPromienPunktuKontrolnego = 5;

            Font anFontOpisuPunktow = new Font("Arial", 8, FontStyle.Italic);
            
            public Łamana(Graphics anRysownica, Pen anPióro, Point anXYpunktu) :
                base(anXYpunktu.X, anXYpunktu.Y, anPióro.Color, anPióro.DashStyle, (int)(anPióro.Width))
            {
                anPunktyŁamanej.Add(anXYpunktu);
                using (SolidBrush anPędzel = new SolidBrush(anPióro.Color))
                {
                    //pierwszy punkt
                    anRysownica.FillEllipse(anPędzel, anXYpunktu.X - anPromienPunktuKontrolnego,
                        anXYpunktu.Y - anPromienPunktuKontrolnego, 2 * anPromienPunktuKontrolnego, 2 * anPromienPunktuKontrolnego);
                }
            }
            //deklaracja metody do dodawanie kolejnych punktów kontrolnych
            public void DodajNowyPunktKontrolny(Point anXYpunktu, Graphics anRysownica)
            {
                anPunktyŁamanej.Add(anXYpunktu);
                using (SolidBrush anPędzel = new SolidBrush(Color.Red))
                {
                    anPędzel.Color = anKolor;
                    
                    anRysownica.FillEllipse(anPędzel, anXYpunktu.X - anPromienPunktuKontrolnego,
                        anXYpunktu.Y - anPromienPunktuKontrolnego, 2 * anPromienPunktuKontrolnego, 2 * anPromienPunktuKontrolnego);
          
                }
                //sprawdzenie czy jest to już 6 punkt kontrolny
                if (anPunktyŁamanej.Count == 6)
                    Wykresl(anRysownica);
            }
            //nadpisywanie metod
            public override void Wykresl(Graphics anRysownica)
            {
                using (Pen anPióro = new Pen(anKolor, anGruboscLinii))
                {
                    anPióro.DashStyle = anStylLinii;
                    //deklaracja i utworzenie egzemplarza tablicy dla punktóww kontrolnych
                    Point[] anPunktyKontrolne = new Point[anPunktyŁamanej.Count];
                    //przepisanie do tablicy  PunktyKontrolne wszystkich punktów z listy PunktyKontrolneKrzywejBeziera
                    for (ushort ani = 0; ani < anPunktyŁamanej.Count; ani++)
                    {
                        anPunktyKontrolne[ani] = new Point(anPunktyŁamanej[ani].X, anPunktyŁamanej[ani].Y);
                    }
                    //wykreślenie krzywej Beziera
                    anRysownica.DrawClosedCurve(anPióro, anPunktyKontrolne);
                    anWidoczny = true;
                }

            }
            public override void Wymaz(Control anKontrolka, Graphics anRysownica)
            {
                if (anWidoczny)
                {
                    using (Pen anPióro = new Pen(anKontrolka.BackColor, anGruboscLinii))
                    {
                        anPióro.DashStyle = anStylLinii;
                        //deklaracja pomocniczej tablicy dla chwilowego przechowania współrzędnych 
                        //punktów kontrolnych Krzywej Beziera
                        Point[] anPunktyŁamanejRysowanie = new Point[anPunktyŁamanej.Count];
                        for (int ani = 0; ani < anPunktyŁamanej.Count; ani++)
                        {
                            anPunktyŁamanejRysowanie[ani] = new Point(anPunktyŁamanej[ani].X,
                                                                anPunktyŁamanej[ani].Y);
                        }
                        //wykreślenie krzywej beziera w kolorze tła, czyli jej wymazanie
                        anRysownica.DrawPolygon(anPióro, anPunktyŁamanejRysowanie);
                        anWidoczny = false;
                    }

                }

            }
            public override void UaktualnijXY(int anx, int any)
            {
                //deklaracje dla wyznaczenia przyrostów zmian wartości współrędnych X i Y
                int anPrzyrostX = anPunktyŁamanej[0].X - anx;
                int anPrzyrostY = anPunktyŁamanej[0].Y - any;
                //zmainy lokalizacji krzywej
                for (int ani = 0; ani < anPunktyŁamanej.Count; ani++)
                {
                    anPunktyŁamanej[ani] = new Point(anPunktyŁamanej[ani].X - anPrzyrostX,
                                                                 anPunktyŁamanej[ani].Y - anPrzyrostY);
                }
            }


        }

    }
}
