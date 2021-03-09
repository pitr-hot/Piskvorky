using System;
using System.Collections.Generic;
using System.Text;

namespace Piskvorky
{
    public class Vypocet
    {
        private int velikost_hraci_plochy = 19;
        private Stav_pole[,] rozlozeni_figurek;
        public Stav_pole[,] Rozlozeni_figurek
        {
            get
            {
                if (rozlozeni_figurek == null)
                    Vycisteni_plochy();
                return rozlozeni_figurek;
            }
        }
        private int[,] znamenka_smeru;
        private int celkovy_pocet_moznych_rad;

        private int souvisla_delka_figurek_pro_vyhru = 5;
        private int [,,,] figurky_v_rade;
        public int [,,,] Figurky_v_rade
        {
            get
            {
                if (figurky_v_rade == null)
                {
                    Vycisteni_figurek_v_rade();                  
                }
                return figurky_v_rade;
            }
        }

        public Vypocet (int velikost_hraci_desky)
        {
            this.velikost_hraci_plochy = velikost_hraci_desky;
            znamenka_smeru = new int[(int)Smer_hry.Severo_vychod + 1, (int)Souradnice.Y + 1] { { -1, 0 }, { -1, -1 }, { 0, -1 }, { 1, -1 } };
        }

        public void Vycisteni_plochy() // Vytvoreni pole kde kazde pole je volne
        {
            rozlozeni_figurek = new Stav_pole[velikost_hraci_plochy, velikost_hraci_plochy];
            for (int x = 0; x < velikost_hraci_plochy; x++)
            {
                for (int y = 0; y < velikost_hraci_plochy; y++)
                {
                    rozlozeni_figurek[x, y] = Stav_pole.Volne;
                }
            }
        }
        private void Vycisteni_figurek_v_rade()
        {
            figurky_v_rade = new int [velikost_hraci_plochy, velikost_hraci_plochy,(int)Smer_hry.Severo_vychod +1,(int) Stav_pole.Kolecko + 1];
            for (int x = 0; x < velikost_hraci_plochy; x++)
            {
                for (int y = 0; y < velikost_hraci_plochy; y++)
                {
                    foreach (Smer_hry smer in Enum.GetValues(typeof(Smer_hry)))                        // projde vsechny smery v enumu Smer hry
                    {
                        for (Stav_pole stav = Stav_pole.Krizek; stav <= Stav_pole.Kolecko; stav++)
                        {
                            figurky_v_rade [x, y, (int)smer, (int) stav] = 0;
                        }
                    }

                }
            }
            celkovy_pocet_moznych_rad = 4 * ((2 * velikost_hraci_plochy - (souvisla_delka_figurek_pro_vyhru - 1)) * (velikost_hraci_plochy - (souvisla_delka_figurek_pro_vyhru - 1)));

        }

        public bool klik_na_hraci_plochu (int x, int y)
        {
            return (x < velikost_hraci_plochy && x >= 0 && y < velikost_hraci_plochy && y >= 0);
        }

        public Vysledek_hry Pridani_tahu (int x, int y, Stav_pole hrac)
        {
            Vysledek_hry vysledek = Vysledek_hry.Pokracovat;
            foreach (Smer_hry smer in Enum.GetValues(typeof(Smer_hry))) 
            {

                for (int i=0; i< souvisla_delka_figurek_pro_vyhru;i++)
                {
                    int smer_horizontalni = znamenka_smeru[(int)smer, (int)Souradnice.X];
                    int smer_vertikalni = znamenka_smeru[(int)smer, (int)Souradnice.Y];
                    int poziceX = x + i * smer_horizontalni;
                    int poziceY = y + i * smer_vertikalni;
                    if (((smer_horizontalni ==-1 && poziceX>=0 && poziceX<= velikost_hraci_plochy - souvisla_delka_figurek_pro_vyhru) || (smer_horizontalni == 1 && poziceX >= souvisla_delka_figurek_pro_vyhru-1 && poziceX < velikost_hraci_plochy) || (smer_horizontalni ==0)) &&
                        ((smer_vertikalni == -1 && poziceY >= 0 && poziceY <= velikost_hraci_plochy - souvisla_delka_figurek_pro_vyhru) || (smer_vertikalni == 1 && poziceY >= souvisla_delka_figurek_pro_vyhru - 1 && poziceY < velikost_hraci_plochy) || (smer_vertikalni == 0)))
                    {
                        vysledek = Zapocitej_tah(ref Figurky_v_rade[poziceX, poziceY, (int)smer, (int) hrac]);
                        if (vysledek !=Vysledek_hry.Pokracovat)
                        {
                            break;
                        }
                    }
                }
                if (vysledek != Vysledek_hry.Pokracovat)
                {
                    break;
                }
            }
            Rozlozeni_figurek[x, y] = hrac;
            if (vysledek == Vysledek_hry.Pokracovat && celkovy_pocet_moznych_rad <=0)
            {
                vysledek = Vysledek_hry.Remiza;
            }
                return vysledek;
        }

        private Vysledek_hry Zapocitej_tah (ref int pocet_v_rade)
        {
            pocet_v_rade++;
            if (pocet_v_rade == 1)
            {
                celkovy_pocet_moznych_rad--;
            }
            if(pocet_v_rade == souvisla_delka_figurek_pro_vyhru)
            {
                return Vysledek_hry.Vyhra;
            }
            return Vysledek_hry.Pokracovat;
        }
    }
}
