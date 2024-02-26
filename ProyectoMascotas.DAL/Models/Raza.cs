using System;
using System.Collections.Generic;

namespace ProyectoMascotas.DAL.Models;

public partial class Raza
{
    public int IdRaza { get; set; }

    public string Raza1 { get; set; } = null!;

    public int IdTipoMascota { get; set; }

    public virtual TiposMascota IdTipoMascotaNavigation { get; set; } = null!;

    public virtual ICollection<Mascota> Mascota { get; set; } = new List<Mascota>();
}
