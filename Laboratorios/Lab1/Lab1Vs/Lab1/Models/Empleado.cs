using System;
using System.Collections.Generic;

namespace Lab1.Models;

public partial class Empleado
{
    public int IdEmpleado { get; set; }

    public string NombreCompleto { get; set; } = null!;

    public string? Cedula { get; set; }

    public string? Correo { get; set; }

    public DateTime? FechaNacimiento { get; set; }

    public DateTime FechaIngreso { get; set; }

    public int? IdJefe { get; set; }

    public int IdArea { get; set; }

    public byte[]? Foto { get; set; }

    public virtual ICollection<EmpleadoHabilidad> EmpleadoHabilidads { get; } = new List<EmpleadoHabilidad>();

    public virtual Area IdAreaNavigation { get; set; } = null!;

    public virtual Empleado? IdJefeNavigation { get; set; }

    public virtual ICollection<Empleado> InverseIdJefeNavigation { get; } = new List<Empleado>();
}
