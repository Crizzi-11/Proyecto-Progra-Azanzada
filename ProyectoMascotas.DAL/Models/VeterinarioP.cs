using System;
using System.Collections.Generic;

namespace ProyectoMascotas.DAL.Models;

public partial class VeterinarioP
{
    public int IdVeterinarioP { get; set; }

    public string NombreVet { get; set; } = null!;

    public string PrimApellido { get; set; } = null!;

    public string SegApellido { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public virtual ICollection<Cita> Cita { get; set; } = new List<Cita>();
}
