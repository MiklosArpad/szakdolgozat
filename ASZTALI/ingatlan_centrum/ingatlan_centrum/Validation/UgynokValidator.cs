using IngatlanCentrum.Exceptions;
using IngatlanCentrum.Model;

namespace IngatlanCentrum.Validation
{
    public static class UgynokValidator
    {
        public static void Validate(Ugynok ugynok)
        {
            if (UgynokNeveKisbetuvelKezdodik(ugynok.Vezeteknev) || UgynokNeveKisbetuvelKezdodik(ugynok.Keresztnev))
            {
                throw new UgynokException("Ügynök vezeték- vagy keresztneve nem kezdődhet kisbetűvel!");
            }

            if (UgynokNeveSzamotTartalmaz(ugynok.Vezeteknev) || UgynokNeveSzamotTartalmaz(ugynok.Keresztnev))
            {
                throw new UgynokException("Ügynök vezeték- vagy keresztneve nem tartalmazhat számot!");
            }
        }

        private static bool UgynokNeveKisbetuvelKezdodik(string nev)
        {
            if (char.IsLower(nev[0]))
            {
                return true;
            }

            return false;
        }

        private static bool UgynokNeveSzamotTartalmaz(string nev)
        {
            foreach (char karakter in nev)
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
