namespace FullStackCI.Models
{
    public class RespuestaHacienda
    {
        public string Nombre { get; set; }
        public string TipoIdentificacion { get; set; }
        public Regimen Regimen { get; set; }
        public Situacion Situacion { get; set; }
        public List<Actividad> Actividades { get; set; }
    }
}
