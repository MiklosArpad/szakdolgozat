using IngatlanCentrum.Exceptions;
using IngatlanCentrum.Model;

namespace IngatlanCentrum.Validation
{
    public static class UgynokValidator
    {
        public static void Validate(Ugynok ugynok)
        {
            if (UresE(ugynok.Id))
            {
                throw new UgynokException("Ügynök azonosítója nem lehet üres!");
            }

            if (TartalmazEKisbetut(ugynok.Id))
            {
                throw new UgynokException("Ügynök azonosítója nem tartalmazhat kisbetűt!");
            }

            if (!TartalmazESzamot(ugynok.Id))
            {
                throw new UgynokException("Ügynök azonosítójának tartalmaznia kell számot!");
            }

            if (MeghatarozottSzamuKaraktertTartalmazE(ugynok.Id, 6))
            {
                throw new UgynokException("Ügynök azonosítójának 6 karaktert kell tartalmazzon!");
            }

            if (UresE(ugynok.Vezeteknev) || UresE(ugynok.Keresztnev))
            {
                throw new UgynokException("Ügynök vezeték- vagy keresztneve nem lehet üres!");
            }

            if (UresE(ugynok.Telefonszam))
            {
                throw new UgynokException("Ügynök telefonszáma nem lehet üres!");
            }

            if (UresE(ugynok.Jogosultsag))
            {
                throw new UgynokException("Ügynök jogosultsága nem lehet üres!");
            }

            if (UgynokNeveKisbetuvelKezdodik(ugynok.Vezeteknev) || UgynokNeveKisbetuvelKezdodik(ugynok.Keresztnev))
            {
                throw new UgynokException("Ügynök vezeték- vagy keresztneve nem kezdődhet kisbetűvel!");
            }

            if (UgynokNeveSzamotTartalmaz(ugynok.Vezeteknev) || UgynokNeveSzamotTartalmaz(ugynok.Keresztnev))
            {
                throw new UgynokException("Ügynök vezeték- vagy keresztneve nem tartalmazhat számot!");
            }

            if (TartalmazEBetut(ugynok.Telefonszam))
            {
                throw new UgynokException("Ügynök telefonszáma nem tartalmazhat betűt!");
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

        private static bool UresE(string bemenet)
        {
            if (string.IsNullOrEmpty(bemenet))
            {
                return true;
            }

            return false;
        }

        private static bool TartalmazESzamot(string bemenet)
        {
            foreach (char karakter in bemenet)
            {
                if (char.IsDigit(karakter))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool TartalmazEBetut(string bemenet)
        {
            foreach (char karakter in bemenet)
            {
                if (char.IsLetter(karakter))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool TartalmazEKisbetut(string bemenet)
        {
            foreach (char karakter in bemenet)
            {
                if (char.IsLower(karakter))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool MeghatarozottSzamuKaraktertTartalmazE(string bemenet, int katakterekSzama)
        {
            if (bemenet.Length > katakterekSzama)
            {
                return true;
            }

            return false;
        }
    }
}
