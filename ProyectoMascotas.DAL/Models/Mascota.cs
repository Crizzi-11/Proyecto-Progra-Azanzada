using System;
using System.Collections.Generic;

namespace ProyectoMascotas.DAL.Models;

public partial class Mascota
{
    public int IdMascota { get; set; }

    public string Nombre { get; set; } = null!;

    public int IdTipoMascota { get; set; }

    public int IdRaza { get; set; }

    public string Genero { get; set; } = null!;

    public int Edad { get; set; }

    public decimal Peso { get; set; }

    public byte[] Imagen { get; set; } = null!;

    public int CodigoUsuario { get; set; }

    public int CodigoUsuarioCreacion { get; set; }

    public DateOnly? FechaCreacion { get; set; }

    public int CodigoUsuarioModificacion { get; set; }

    public DateOnly? FechaModificacion { get; set; }

    public virtual ICollection<Cita> Cita { get; set; } = new List<Cita>();

    public virtual Dueno CodigoUsuarioNavigation { get; set; } = null!;

    public virtual ICollection<DesparasitacionesVacuna> DesparasitacionesVacunas { get; set; } = new List<DesparasitacionesVacuna>();

    public virtual Raza IdRazaNavigation { get; set; } = null!;

    public virtual TiposMascota IdTipoMascotaNavigation { get; set; } = null!;

    public virtual ICollection<Padecimiento> Padecimientos { get; set; } = new List<Padecimiento>();
}
