using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Piskvorky
{
    public partial class Hraci_plocha : UserControl
    {
        private int velokost_hraci_plochy = 19;
        public int Velikost_hraci_plochy
        {
            get { return velokost_hraci_plochy; }
            set
            {
                if (aktivni_hra == false)
                {
                    velokost_hraci_plochy = value;
                }
                Refresh();
            }
        }

        private int velikost_policka = 20;
        public int Velikost_policka
        {
            get { return velikost_policka; }
            set
            {
                velikost_policka = value;
                Refresh();
            }
        }

        private Stav_pole aktualni_hrac = Stav_pole.Krizek;

        private Stav_pole Protivnik
        {
            get 
            {
                if (aktualni_hrac == Stav_pole.Krizek)
                {
                    return Stav_pole.Kolecko;
                }
                if (aktualni_hrac == Stav_pole.Kolecko)
                {
                    return Stav_pole.Krizek;
                }            
                    throw new Exception ("Prazde pole neni hrac");                             
            }
        }

        private Vypocet muj_vyypocet;

        private Vypocet Muj_vypocet
        {
            get
            {
                if (muj_vyypocet == null)
                {
                    muj_vyypocet = new Vypocet(velokost_hraci_plochy);
                }
                return muj_vyypocet;
            }
            set
            {
                muj_vyypocet = value;
            }
        }

        private Color barva_mrizky = Color.Black;
        public Color Barva_mrizky
        {
            get { return barva_mrizky; }
            set
            {
                pero_pro_mrizku = null;
                barva_mrizky = value;
                Refresh();
            }
        }

        private Pen pero_pro_mrizku;
        public Pen Pero_pro_mrizku
        {
            get
            {
                if (pero_pro_mrizku == null)
                {
                    pero_pro_mrizku = new Pen(barva_mrizky);
                }
                return pero_pro_mrizku;
            }
        }
        private Pen pero_pro_krizek;
        public Pen Pero_pro_krizek
        {
            get
            {
                if (pero_pro_krizek == null)
                {
                    pero_pro_krizek = new Pen(barva_krizku);
                }
                return pero_pro_krizek;
            }
        }  
        
        private Pen pero_pro_kolecko;
        public Pen Pero_pro_kolecko
        {
            get
            {
                if (pero_pro_kolecko == null)
                {
                    pero_pro_kolecko = new Pen(barva_kolecka);
                }
                return pero_pro_kolecko;
            }
        }

        private Color barva_krizku = Color.Red;
        private Color barva_kolecka = Color.Green;

        private bool aktivni_hra = false;


        public Hraci_plocha()
        {
            InitializeComponent();
        }
        public void Start_hry ()
        {
            Muj_vypocet = null;
            aktivni_hra = true;
            Refresh();
        }

        private void Hraci_plocha_Paint(object sender, PaintEventArgs e)
        {
            Vykresleni_mrizky(e.Graphics);
            Vykresleni_figurek(e.Graphics);
        }

        private void Hraci_plocha_MouseClick(object sender, MouseEventArgs e)
        {
            int x = (e.X) / velikost_policka;
            int y = (e.Y) / velikost_policka;

            if ( aktivni_hra == false)
            {
                return;
            }

            if (!(Muj_vypocet.klik_na_hraci_plochu(x, y)))
            {
                return;
            }
            if (Muj_vypocet.Rozlozeni_figurek[x, y] != Stav_pole.Volne)
            {
                return;
            }
            Vysledek_hry vysledek = Muj_vypocet.Pridani_tahu(x, y, aktualni_hrac);
            Refresh();
            if (vysledek == Vysledek_hry.Vyhra)
            {
                aktivni_hra = false;
                MessageBox.Show("Vyhral " + aktualni_hrac);
            }
            else if (vysledek == Vysledek_hry.Remiza)
            {
                aktivni_hra = false;
                MessageBox.Show("Remiza");
            }
            aktualni_hrac = Protivnik;
            
        }



        private void Vykresleni_mrizky(Graphics g)
        {
            for (int i = 0; i <= velokost_hraci_plochy;i++)
            {
                g.DrawLine(Pero_pro_mrizku, 0, i * velikost_policka, velokost_hraci_plochy * velikost_policka, i * velikost_policka);  // Vodorovne cary
                g.DrawLine(Pero_pro_mrizku, i * velikost_policka, 0 , i * velikost_policka, velokost_hraci_plochy * velikost_policka);      // Svisle cary
            }
        }    
        
        private void Vykresleni_figurky(Graphics g, Stav_pole figurka, int x, int y)
        {
            if (!(Muj_vypocet.klik_na_hraci_plochu(x,y)))
            {
                throw new Exception("Souradnice jsou mimo hraci plochu.");
            }
            if (figurka == Stav_pole.Krizek)
            {
                g.DrawLine(Pero_pro_krizek, x * velikost_policka + 1, y * velikost_policka + 1, x * velikost_policka + velikost_policka - 1, y * velikost_policka + velikost_policka - 1);
                g.DrawLine(Pero_pro_krizek, x * velikost_policka + 1, y * velikost_policka + velikost_policka - 1, x * velikost_policka + velikost_policka - 1, y * velikost_policka + 1);
            }
            if (figurka == Stav_pole.Kolecko)
            {
                g.DrawEllipse(Pero_pro_kolecko, x * velikost_policka + 1, y * velikost_policka + 1, velikost_policka - 2, velikost_policka - 2);
            }
        }

        private void Vykresleni_figurek(Graphics g) // Projde pole a do kazdeho pole zakresli typ pole (kolecko, krizek nebo volne)
        {
            for (int x =0;x<velokost_hraci_plochy;x++)
            {
                for (int y = 0;y<Velikost_hraci_plochy;y++)
                {
                    Vykresleni_figurky(g, Muj_vypocet.Rozlozeni_figurek[x, y], x, y);
                }
            }
        }


    }

}
