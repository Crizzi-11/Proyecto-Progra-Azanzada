using System;
using System.Collections.Generic;

namespace ProyectoMascotas.DAL.Models;

public partial class TiposMascota
{
    public int IdTipoMascota { get; set; }

    public string Tipo { get; set; } = null!;

    public virtual ICollection<Mascota> Mascota { get; set; } = new List<Mascota>();

    public virtual ICollection<Raza> Razas { get; set; } = new List<Raza>();
}
