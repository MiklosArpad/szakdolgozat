using IngatlanCentrum.Config;
using IngatlanCentrum.Database;
using System;
using System.Configuration;

namespace IngatlanCentrum.Repository
{
    public partial class Repository
    {
        /// <summary>
        /// Adatbázis csatlakozás
        /// </summary>
        private MySQL adatbazis;

        /// <summary>
        /// Adattár konsturktora.
        /// </summary>
        public Repository()
        {
            try
            {
                if (Munkamenet.SzerverTipus == "otthoni")
                {

                    adatbazis = MySQL.Connect(ConfigurationManager.ConnectionStrings["otthoni"].ConnectionString);
                }
                else
                {
                    adatbazis = MySQL.Connect(ConfigurationManager.ConnectionStrings["iskolai"].ConnectionString);
                }

                LetoltTelepuleseketAdatbazisbol();
                LetoltUgynokJogosultsagokatAdatbazisbol();
                LetoltUgynokoketAdatbazisbol();
                LetoltEladokatAdatbazisbol();
                LetoltIngatlanAllapotokatAdatbazisbol();
                LetoltIngatlanKategoriakatAdatbazisbol();
                LetoltIngatlanokatAdatbazisbol();
                LetoltHirdeteseketAdatbazisbol();
            }
            catch
            {
            }
        }
    }
}
