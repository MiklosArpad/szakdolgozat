using IngatlanCentrum.Exceptions;
using IngatlanCentrum.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IngatlanCentrum.Validation
{
    public static class HirdetesValidator
    {
        /// <summary>
        /// Hirdetés modellt ellenőrző metódus
        /// </summary>
        /// <param name="hirdetes">Hirdetés</param>
        /// <exception cref="HirdetesException"></exception>
        public static void Validate(Hirdetes hirdetes)
        {
            if (UresE(hirdetes.Cim))
            {
                throw new HirdetesException("Hirdetés címe nem lehet üres!");
            }

            if (UresE(hirdetes.Leiras))
            {
                throw new HirdetesException("Hirdetés leírása nem lehet üres!");
            }

            if (!HirdetesLeirasaMeghatarozottKaraktertTartalmazE(hirdetes.Leiras))
            {
                throw new Exception("Hirdetés leírása üres vagy meghaladja az 500 karaktert!");
            }

            if (ArKisebbENullanalVagyNulla(hirdetes.Ar))
            {
                throw new Exception("A meghirdetett ár nem lehet nulla vagy negatív szám!");
            }

            if (ArTartalmazEBetut(hirdetes.Ar.ToString()))
            {
                throw new Exception("A meghirdetett ár nem tartalmazhat betűt!");
            }
        }

        private static bool UresE(string bemenet)
        {
            if (string.IsNullOrEmpty(bemenet))
            {
                return true;
            }

            return false;
        }

        private static bool HirdetesLeirasaMeghatarozottKaraktertTartalmazE(string leiras)
        {
            if (leiras.Length < 500 && leiras.Length > 0)
            {
                return true;
            }

            return false;
        }

        private static bool ArKisebbENullanalVagyNulla(int ar)
        {
            if (ar <= 0)
            {
                return true;
            }

            return false;
        }

        private static bool ArTartalmazEBetut(string ar)
        {
            foreach (char karakter in ar)
            {
                if (char.IsLetter(karakter))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
