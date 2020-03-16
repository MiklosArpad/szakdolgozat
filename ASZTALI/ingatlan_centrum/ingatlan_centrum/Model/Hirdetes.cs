namespace IngatlanCentrum.Model
{
    /// <summary>
    /// Hirdetés modell
    /// </summary>
    public class Hirdetes
    {
        public int Id { get; set; }
        public string Cim { get; set; }
        public string Leiras { get; set; }
        public int Ar { get; set; }
        public Ingatlan Ingatlan { get; set; }
        public Ugynok Ugynok { get; set; }
        public string Datum { get; set; }
        public bool Aktiv { get; set; }

        public override string ToString()
        {
            return $"{Id} {Cim} {Leiras} {Ar} {Ingatlan} {Ugynok} {Datum} {Aktiv}";
        }
    }
}
