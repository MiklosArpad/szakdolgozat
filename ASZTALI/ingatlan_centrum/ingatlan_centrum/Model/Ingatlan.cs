﻿namespace IngatlanCentrum.Model
{
    /// <summary>
    /// Ingatlan modell
    /// </summary>
    public class Ingatlan
    {
        public string HelyrajziSzam { get; set; }
        public string Telepules { get; set; }
        public int Alapterulet { get; set; }
        public int SzobakSzama { get; set; }
        public string Kategoria { get; set; }
        public string Allapot { get; set; }
        public Elado Elado { get; set; }

        public override string ToString()
        {
            return $"{HelyrajziSzam} {Telepules} {Alapterulet} {SzobakSzama} {Kategoria} {Allapot} {Elado}";
        }
    }
}
