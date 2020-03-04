namespace IngatlanCentrum.Model
{
    /// <summary>
    /// Ingatlan kategória modell
    /// </summary>
    public class IngatlanKategoria
    {
        public string Elnevezes { get; set; }

        public override string ToString()
        {
            return $"{Elnevezes}";
        }
    }
}
