using IngatlanCentrum.Database;

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
            adatbazis = MySQL.Connect("SERVER=127.0.0.1; DATABASE=ingatlan_centrum; UID=root; PASSWORD=; PORT=3306; SslMode=None;");
        }
    }
}
