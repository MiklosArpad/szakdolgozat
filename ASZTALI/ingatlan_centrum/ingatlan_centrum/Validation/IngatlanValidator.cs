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

            if (UresE(ingatlan.Kategoria))
            {
                throw new IngatlanException("Ingatlan kategóriája nem lehet üres!");
            }

            if (UresE(ingatlan.Allapot))
            {
                throw new IngatlanException("Ingatlan állapota nem lehet üres!");
            }

            if (!HelyrajziSzamTartalmazSzamot(ingatlan.HelyrajziSzam))
            {
                throw new IngatlanException("Helyrajszi számnak tartalmaznia kell számot!");
            }

            if (HelyrajziSzamKisbetutTartalmaz(ingatlan.HelyrajziSzam))
            {
                throw new IngatlanException("Amennyiben a helyrajzi szám tartalmaz betűt, nagybetűvel kell feltüntetni!");
            }

            if (AlapteruletKisebbENullanalVagyNulla(ingatlan.Alapterulet))
            {
                throw new IngatlanException("Ingatlan alapterülete nem lehet nulla vagy negatív szám!");
            }

            if (AlapteruletTartalmazEBetut(ingatlan.Alapterulet.ToString()))
            {
                throw new IngatlanException("Ingatlan alapterülete nem tartalmazhat betűt!");
            }
        }

        private static bool HelyrajziSzamKisbetutTartalmaz(string helyrajziSzam)
        {
            foreach (char karakter in helyrajziSzam)
            {
                if (char.IsLower(karakter))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool UresE(string bemenet)
        {
            if (string.IsNullOrEmpty(bemenet))
            {
                return true;
            }

            return false;
        }

        private static bool AlapteruletKisebbENullanalVagyNulla(int alapterulet)
        {
            if (alapterulet <= 0)
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

        private static bool HelyrajziSzamTartalmazSzamot(string helyrajziSzam)
        {
            foreach (char karakter in helyrajziSzam)
            {
                if (char.IsDigit(karakter))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
