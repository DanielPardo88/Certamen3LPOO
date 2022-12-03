using DataCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelos.Mantenedor
{
    public class Regiones : IDataEntity
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string provincias { get; set; }
        public string comunas { get; set; }
        public string ciudades { get; set; }        
        public data Data { get; set; }
        public List<Parametros> parametros { get; set; }
        public Regiones()
        {
            Data = new data();
            parametros = new List<Parametros>();
        }
    }
}
