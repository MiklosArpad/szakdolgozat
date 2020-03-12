namespace IngatlanCentrum.Model
{
    /// <summary>
    /// Eladó modell
    /// </summary>
    public class Elado
    {
        public string Adoazonosito { get; set; }
        public string Vezeteknev { get; set; }
        public string Keresztnev { get; set; }
        public string Telepules { get; set; }
        public string Lakcim { get; set; }
        public string Telefonszam { get; set; }
        public string Email { get; set; }

        public override string ToString()
        {
            return $"{Adoazonosito} {Vezeteknev} {Keresztnev} {Telepules} {Lakcim} {Telefonszam} {Email}";
        }
    }
}
