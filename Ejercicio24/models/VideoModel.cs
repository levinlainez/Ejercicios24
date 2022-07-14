using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace Ejercicio24.models
{
    public class VideoModel
    {
        [PrimaryKey, AutoIncrement]
        public int codigo { get; set; }

        public string ruta { get; set; }

        public string descripcion { get; set; }
    }
}
