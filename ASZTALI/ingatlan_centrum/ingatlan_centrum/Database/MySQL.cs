using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace IngatlanCentrum.Database
{
    /// <summary>
    /// MySQL adatbázis kapcsolódást, adatlekérdezés és adatmanipulációs műveleteket megvalósító egyke osztály
    /// </summary>
    public sealed class MySQL
    {
        /// <summary>
        /// Ezen osztály egyke példánya
        /// </summary>
        private static MySQL instance;

        /// <summary>
        /// Adatbázis kapcsolatot létrehozó mező
        /// </summary>
        private MySqlConnection connection;

        /// <summary>
        /// SQL utasítást vágrehajtó mező
        /// </summary>
        private MySqlCommand command;

        /// <summary>
        /// Adatszerkezeteket adattal feltöltő osztály egy példánya
        /// </summary>
        private MySqlDataAdapter dataAdapter;

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="connectionString">Kapcsolatinicializáló karakterlánc</param>
        private MySQL(string connectionString)
        {
            connection = new MySqlConnection(connectionString);
        }

        /// <summary>
        /// Az egyke MySQL adatbázis kapcsolódásást létrehozó metódus
        /// </summary>
        /// <param name="connectionString">Kapcsolatleíró karakterlánc</param>
        /// <returns>Az egyke példánnyal tér vissza a metódus</returns>
        /// <exception cref="Exception"></exception>
        public static MySQL Connect(string connectionString)
        {
            try
            {
                return instance ?? (instance = new MySQL(connectionString));
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Adatbázis kapcsolatot megnyitó metódus
        /// </summary>
        /// <exception cref="MySqlException"></exception>
        /// <exception cref="Exception"></exception>
        private void OpenConnection()
        {
            try
            {
                if (connection.State == ConnectionState.Closed)
                {
                    connection.Open();
                }
            }
            catch (MySqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Adatbázis kapcsolatot lezáró metódus
        /// </summary>
        /// <exception cref="MySqlException"></exception>
        /// <exception cref="Exception"></exception>
        private void CloseConnection()
        {
            try
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
            catch (MySqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// SELECT utasítást végrehajtó metódus
        /// </summary>
        /// <param name="query">SQL utasítás</param>
        /// <returns>Adatokkal feltöltött DataTable adatszerkezettel tér vissza a metódus</returns>
        /// <exception cref="MySqlException"></exception>
        /// <exception cref="Exception"></exception>
        public DataTable DQL(string query)
        {
            try
            {
                OpenConnection();

                command = new MySqlCommand(query, connection);
                dataAdapter = new MySqlDataAdapter(command);

                DataTable table = new DataTable();
                dataAdapter.Fill(table);

                return table;
            }
            catch (MySqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                CloseConnection();
            }
        }

        /// <summary>
        /// INSERT, UPDATE, DELETE utasítást végrehajtó metódus
        /// </summary>
        /// <param name="query">SQL utasítás</param>
        /// <exception cref="MySqlException"></exception>
        /// <exception cref="Exception"></exception>
        public void DML(string query)
        {
            try
            {
                OpenConnection();

                command = new MySqlCommand(query, connection);
                command.Prepare();
                command.ExecuteNonQuery();
            }
            catch (MySqlException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                CloseConnection();
            }
        }
    }
}
