﻿using IngatlanCentrum.Exceptions;
using IngatlanCentrum.Model;
using System.Collections.Generic;

namespace IngatlanCentrum.Service
{
    /// <summary>
    /// Ügynök jogosultság szolgáltatások
    /// </summary>
    public class UgynokJogosultsagService
    {
        /// <summary>
        /// Adattár
        /// </summary>
        private Repository.Repository repository;

        /// <summary>
        /// Konstruktor
        /// </summary>
        public UgynokJogosultsagService()
        {
            repository = new Repository.Repository();
        }

        public List<UgynokJogosultsag> GetUgynokJogosultsagok()
        {
            return repository.GetUgynokJogosultsagok();
        }

        public UgynokJogosultsag GetUgynokJogosultsag(string elnevezes)
        {
            foreach (UgynokJogosultsag ugynokJogosultsag in GetUgynokJogosultsagok())
            {
                if (ugynokJogosultsag.Elnevezes == elnevezes)
                {
                    return ugynokJogosultsag;
                }
            }

            throw new UgynokJogosultsagException($"Nem található ügynök jogosultság ilyen elnevezéssel: {elnevezes}");
        }
    }
}
