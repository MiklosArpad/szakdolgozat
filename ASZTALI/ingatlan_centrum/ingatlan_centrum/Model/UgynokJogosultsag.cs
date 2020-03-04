namespace IngatlanCentrum.Model
{
    /// <summary>
    /// Ügynök jogosultság modell
    /// </summary>
    public class UgynokJogosultsag
    {
        public string Elnevezes { get; set; }
        public string Leiras { get; set; }

        public override string ToString()
        {
            return $"{Elnevezes} {Leiras}";
        }
    }
}
