using IngatlanCentrum.Exceptions;
using IngatlanCentrum.Model;

namespace IngatlanCentrum.Validation
{
    public static class IngatlanValidator
    {
        /// <summary>
        /// Ingatlan modellt ellenőrző metódus
        /// </summary>
        /// <param name="ingatlan">Ingatlan</param>
        /// <exception cref="IngatlanException"></exception>
        public static void Validate(Ingatlan ingatlan)
        {
            if (UresE(ingatlan.HelyrajziSzam))
            {
                throw new IngatlanException("Ingatlan helyrajzi száma nem lehet üres!");
            }

            if (UresE(ingatlan.Telepules))
            {
                throw new IngatlanException("Ingatlan települése nem lehet üres!");
            }

            if (UresE(ingatlan.Alapterulet.ToString()))
            {
                throw new IngatlanException("Ingatlan  nem lehet üres!");
            }

            if (UresE(ingatlan.Kategoria))
            {
                throw new IngatlanException("Ingatlan kategóriája nem lehet üres!");
            }

            if (UresE(ingatlan.Allapot))
            {
                throw new IngatlanException("Ingatlan állapota nem lehet üres!");
            }

            if (AlapteruletKisebbENullanal(ingatlan.Alapterulet))
            {
                throw new IngatlanException("Ingatlan alapterülete nem lehet negatív szám!");
            }

            if (AlapteruletTartalmazEBetut(ingatlan.Alapterulet.ToString()))
            {
                throw new IngatlanException("Ingatlan alapterülete nem tartalmazhat betűt!");
            }

            if (!HelyrajziSzamTartalmazBetut(ingatlan.HelyrajziSzam))
            {
                throw new IngatlanException("Helyrajszi számnak tartalmaznia kell számot!");
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

        private static bool AlapteruletKisebbENullanal(int alapterulet)
        {
            if (alapterulet < 0)
            {
                return true;
            }

            return false;
        }

        private static bool AlapteruletTartalmazEBetut(string alapterulet)
        {
            foreach (char karakter in alapterulet)
            {
                if (char.IsLetter(karakter))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool HelyrajziSzamTartalmazBetut(string helyrajziSzam)
        {
            foreach (char karakter in helyrajziSzam)
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
