using System;
using System.Collections.Generic;

namespace ProyectoMascotas.DAL.Models;

public partial class Padecimiento
{
    public int IdPadecimiento { get; set; }

    public int IdMascota { get; set; }

    public string Padecimiento1 { get; set; } = null!;

    public virtual Mascota IdMascotaNavigation { get; set; } = null!;
}
