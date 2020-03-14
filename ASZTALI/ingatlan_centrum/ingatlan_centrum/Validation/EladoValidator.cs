using IngatlanCentrum.Exceptions;
using IngatlanCentrum.Model;

namespace IngatlanCentrum.Validation
{
    public static class EladoValidator
    {
        public static void Validate(Elado elado)
        {
            if (EladoNeveKisbetuvelKezdodik(elado.Vezeteknev) || EladoNeveKisbetuvelKezdodik(elado.Keresztnev))
            {
                throw new EladoException("Eladó vezeték- vagy keresztneve nem kezdődhet kisbetűvel!");
            }

            if (EladoNeveSzamotTartalmaz(elado.Vezeteknev) || EladoNeveSzamotTartalmaz(elado.Keresztnev))
            {
                throw new EladoException("Eladó vezeték- vagy keresztneve nem tartalmazhat számot!");
            }

            if (AdoazonositoTartalmazEBetut(elado.Adoazonosito))
            {
                throw new EladoException("Eladó adóazonosítója nem tartalmazhat betűt!");
            }

            if (!AdoazonositoMegfeleloHosszuE(elado.Adoazonosito))
            {
                throw new EladoException("Eladó adószonosítója 10 karakter hosszúnak kell lennie!");
            }
        }

        private static bool EladoNeveKisbetuvelKezdodik(string nev)
        {
            if (char.IsLower(nev[0]))
            {
                return true;
            }

            return false;
        }

        private static bool EladoNeveSzamotTartalmaz(string nev)
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

        private static bool AdoazonositoTartalmazEBetut(string adoazonosito)
        {
            foreach (char karakter in adoazonosito)
            {
                if (char.IsLetter(karakter))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool AdoazonositoMegfeleloHosszuE(string adoazonosito)
        {
            if (adoazonosito.Length == 10)
            {
                return true;
            }

            return false;
        }
    }
}
