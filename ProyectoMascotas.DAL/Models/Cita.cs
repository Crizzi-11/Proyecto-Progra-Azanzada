using System;
using System.Collections.Generic;

namespace ProyectoMascotas.DAL.Models;

public partial class Cita
{
    public int CitaId { get; set; }

    public DateTime? FechaHora { get; set; }

    public string? Detalle { get; set; }

    public string? Diagnostico { get; set; }

    public string? ListaMedicamentos { get; set; }

    public string? Estado { get; set; }

    public int CodigoUsuario { get; set; }

    public int IdMascota { get; set; }

    public int IdVeterinarioP { get; set; }

    public int IdVeterinarioS { get; set; }

    public virtual Dueno CodigoUsuarioNavigation { get; set; } = null!;

    public virtual Mascota IdMascotaNavigation { get; set; } = null!;

    public virtual VeterinarioP IdVeterinarioPNavigation { get; set; } = null!;

    public virtual VeterinarioS IdVeterinarioSNavigation { get; set; } = null!;
}
