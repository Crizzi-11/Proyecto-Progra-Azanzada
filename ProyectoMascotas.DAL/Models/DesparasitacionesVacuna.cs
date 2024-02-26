using System;
using System.Collections.Generic;

namespace ProyectoMascotas.DAL.Models;

public partial class DesparasitacionesVacuna
{
    public int IdDesparacitacion { get; set; }

    public int IdMascota { get; set; }

    public string Tipo { get; set; } = null!;

    public DateOnly? Fecha { get; set; }

    public string Producto { get; set; } = null!;

    public virtual Mascota IdMascotaNavigation { get; set; } = null!;
}
