namespace IngatlanCentrum.Model
{
    /// <summary>
    /// Ingatlanügynök modell
    /// </summary>
    public class Ugynok
    {
        public string Id { get; set; }
        public string Jelszo { get; set; }
        public string Vezeteknev { get; set; }
        public string Keresztnev { get; set; }
        public string Telefonszam { get; set; }
        public string Jogosultsag { get; set; }
        public bool Aktiv { get; set; }

        public override string ToString()
        {
            return $"{Id} {Jelszo} {Vezeteknev} {Keresztnev} {Telefonszam} {Jogosultsag} {Aktiv}";
        }
    }
}
