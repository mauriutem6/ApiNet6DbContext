using System.ComponentModel.DataAnnotations.Schema;

namespace apinet6.Models
{
    

    public class Marca
    {
        public Int64 id { get; set; }
        public string? descripcion { get; set; }
        public bool? habilitado { get; set; }
    }
}
