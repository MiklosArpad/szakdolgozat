using IngatlanCentrum.Exceptions;
using IngatlanCentrum.Model;

namespace IngatlanCentrum.Validation
{
    public static class EladoValidator
    {
        /// <summary>
        /// Eladó modellt ellenőrző metódus
        /// </summary>
        /// <param name="elado">Eladó</param>
        /// <exception cref="EladoException"></exception>
        public static void Validate(Elado elado)
        {
            if (UresE(elado.Adoazonosito))
            {
                throw new EladoException("Eladó adóazonosítója nem lehet üres!");
            }

            if (!AdoazonositoMegfeleloHosszuE(elado.Adoazonosito))
            {
                throw new EladoException("Eladó adószonosítója 10 karakter hosszúnak kell lennie!");
            }

            if (UresE(elado.Vezeteknev) || UresE(elado.Keresztnev))
            {
                throw new EladoException("Eladó vezeték- vagy keresztneve nem lehet üres!");
            }

            if (UresE(elado.Telepules))
            {
                throw new EladoException("Eladó települése nem lehet üres!");
            }

            if (UresE(elado.Lakcim))
            {
                throw new EladoException("Eladó lakcíme nem lehet üres!");
            }

            if (UresE(elado.Telefonszam))
            {
                throw new EladoException("Eladó telefonszáma nem lehet üres!");
            }

            if (UresE(elado.Email))
            {
                throw new EladoException("Eladó e-mail címe nem lehet üres!");
            }

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
        }

        private static bool UresE(string bemenet)
        {
            if (string.IsNullOrEmpty(bemenet))
            {
                return true;
            }

            return false;
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
