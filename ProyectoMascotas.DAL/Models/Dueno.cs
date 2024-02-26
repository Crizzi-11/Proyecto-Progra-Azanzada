using System;
using System.Collections.Generic;

namespace ProyectoMascotas.DAL.Models;

public partial class Dueno
{
    public int CodigoUsuario { get; set; }

    public string NombreDueno { get; set; } = null!;

    public string PrimApellido { get; set; } = null!;

    public string SegApellido { get; set; } = null!;

    public string Telefono { get; set; } = null!;

    public DateOnly FechaCreacion { get; set; }

    public DateOnly FechaModificacion { get; set; }

    public string ListaCitas { get; set; } = null!;

    public virtual ICollection<Cita> Cita { get; set; } = new List<Cita>();

    public virtual ICollection<Mascota> Mascota { get; set; } = new List<Mascota>();
}
