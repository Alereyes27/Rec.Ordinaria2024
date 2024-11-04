using Refuerzo2024.Model.Conexion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refuerzo2024.Model.DTO
{
    internal class DTOFacultades : dbContext
    {
            private string idFacultad;
            private string nombreFacultad;

            public string IdFacultad { get => idFacultad; set => idFacultad = value; }
            public string NombreFacultad { get => nombreFacultad; set => nombreFacultad = value; }
    }
}
