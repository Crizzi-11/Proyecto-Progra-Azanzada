using System;
using System.Collections.Generic;

namespace ProyectoMascotas.DAL.Models;

public partial class Administracion
{
    public int IdAdm { get; set; }

    public string NombreAdm { get; set; } = null!;

    public string Contrasena { get; set; } = null!;

    public string Rol { get; set; } = null!;

    public byte[]? ImagenUsuario { get; set; }

    public DateTime? UltimaConexion { get; set; }

    public string EstadoUsuario { get; set; } = null!;
}
