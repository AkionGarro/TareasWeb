using System;
using System.Collections.Generic;

namespace Lab1.Models;

public partial class EmpleadoHabilidad
{
    public int IdHabilidad { get; set; }

    public int IdEmpleado { get; set; }

    public string NombreHabilidad { get; set; } = null!;

    public virtual Empleado IdEmpleadoNavigation { get; set; } = null!;
}
