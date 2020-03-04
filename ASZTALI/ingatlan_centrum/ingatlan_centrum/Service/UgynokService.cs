using System.Collections.Generic;
using System;
using IngatlanCentrum.Model;

namespace IngatlanCentrum.Service
{
    public class UgynokService
    {
        private Repository.Repository repository;

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
        /// <exception cref="UgynokException"></exception>
        public bool AzonositUgynok(string azonosito, string jelszo)
        {
            foreach (Ugynok ugynok in GetUgynokok())
            {
                if (ugynok.Id == azonosito && ugynok.Jelszo == jelszo)
                {
                    return true;
                }
            }

            throw new Exception("Nem megfelelő ügynök azonosító vagy jelszó!");
        }

        public void AktivalUgynokot(string azonosito)
        {
            foreach (Ugynok ugynok in GetUgynokok())
            {
                if (ugynok.Id == azonosito && !ugynok.Aktiv)
                {
                    ugynok.Aktiv = true;
                }
            }

            throw new Exception("Ilyen azonosítójú ügynök nem létezik vagy ügynök már eleve aktivált állapotú!");
        }

        public void DeaktivalUgynokot(string azonosito)
        {
            foreach (Ugynok ugynok in GetUgynokok())
            {
                if (ugynok.Id == azonosito && ugynok.Aktiv)
                {
                    ugynok.Aktiv = false;
                }
            }

            throw new Exception("Ilyen azonosítójú ügynök nem létezik vagy ügynök már eleve deaktivált állapotú!");
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

            throw new Exception("Nem található ilyen azonosítóval rendelkező ügynök!");
        }
    }
}
