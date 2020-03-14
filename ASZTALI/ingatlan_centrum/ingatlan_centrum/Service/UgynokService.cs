using System.Collections.Generic;
using System;
using IngatlanCentrum.Model;
using IngatlanCentrum.Config;
using IngatlanCentrum.Exceptions;

namespace IngatlanCentrum.Service
{
    /// <summary>
    /// Ügynök szolgáltatások
    /// </summary>
    public class UgynokService
    {
        /// <summary>
        /// Adattár
        /// </summary>
        private Repository.Repository repository;

        /// <summary>
        /// Konstruktor
        /// </summary>
        public UgynokService()
        {
            repository = new Repository.Repository();
        }

        /// <summary>
        /// Ügynök azonosítása az alkalmazásban.
        /// Ha helyes felhasználónév-jelszó párost ad meg az ügynök, akkor sikeres a munkamenet nyomkövetés beállítása - 
        /// ellenkező esetben kivétel képződik.
        /// </summary>
        /// <param name="azonosito">Ügynök azonosítója</param>
        /// <param name="jelszo">Ügynök jelszava</param>
        /// <exception cref="Exception"></exception>
        public bool AzonositUgynok(string azonosito, string jelszo)
        {
            foreach (Ugynok ugynok in GetUgynokok())
            {
                if (ugynok.Id == azonosito && ugynok.Jelszo == jelszo)
                {
                    Munkamenet.UgynokAzonosito = ugynok.Id;
                    Munkamenet.UgynokJogosultsag = ugynok.Jogosultsag;
                    Munkamenet.UgynokNeve = $"{ugynok.Vezeteknev} {ugynok.Keresztnev}";
                    return true;
                }
            }

            throw new UgynokException("Nem megfelelő ügynök azonosító vagy jelszó!");
        }

        public List<Ugynok> GetUgynokok()
        {
            return repository.GetUgynokok();
        }

        public void HozzaadUgynok(Ugynok ugynok)
        {
            repository.HozzaadUgynok(ugynok);
        }

        public void ModositUgynok(Ugynok ugynok)
        {
            repository.ModositUgynok(ugynok);
        }

        public Ugynok GetUgynok(string azonosito)
        {
            foreach (Ugynok ugynok in GetUgynokok())
            {
                if (ugynok.Id == azonosito)
                {
                    return ugynok;
                }
            }

            throw new UgynokException("Nem található a keresett azonosítóval rendelkező ügynök!");
        }
    }
}
