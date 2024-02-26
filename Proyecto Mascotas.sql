
CREATE DATABASE ProyectoMascotas;

USE ProyectoMascotas;


-- Tabla de Tipos de Mascota
CREATE TABLE TiposMascota (
    IdTipoMascota INT PRIMARY KEY,
    Tipo VARCHAR(50) NOT NULL
);

-- Tabla de Razas
CREATE TABLE Razas (
    IdRaza INT PRIMARY KEY,
    Raza VARCHAR(50) NOT NULL,
    IdTipoMascota INT NOT NULL,
    FOREIGN KEY (IdTipoMascota) REFERENCES TiposMascota(IdTipoMascota)
);

-- Tabla de Clientes
CREATE TABLE Dueno (
    CodigoUsuario INT PRIMARY KEY,
    NombreDueno VARCHAR(100) NOT NULL,
	PrimApellido VARCHAR(100) NOT NULL,
	SegApellido VARCHAR(100) NOT NULL,
	Telefono VARCHAR(100) NOT NULL,
	FechaCreacion Date NOT NULL,
	FechaModificacion DATE NOT NULL,
	ListaCitas VARCHAR(100) NOT NULL,
);

-- Tabla de Mascotas
CREATE TABLE Mascotas (
    IdMascota INT PRIMARY KEY,
    Nombre VARCHAR(100) NOT NULL,
    IdTipoMascota INT NOT NULL,
    IdRaza INT NOT NULL,
    Genero VARCHAR(10) NOT NULL,
    Edad INT NOT NULL,
    Peso DECIMAL(5,2) NOT NULL,
    Imagen varbinary(max) NOT NULL,
    CodigoUsuario INT NOT NULL,
    CodigoUsuarioCreacion INT NOT NULL,
    FechaCreacion DATE,
    CodigoUsuarioModificacion INT NOT NULL,
    FechaModificacion DATE,
    FOREIGN KEY (IdTipoMascota) REFERENCES TiposMascota(IdTipoMascota),
    FOREIGN KEY (IdRaza) REFERENCES Razas(IdRaza),
    FOREIGN KEY (CodigoUsuario) REFERENCES Dueno(CodigoUsuario)
);
-- Tabla de Padecimientos
CREATE TABLE Padecimientos (
    IdPadecimiento INT PRIMARY KEY,
    IdMascota INT NOT NULL,
    Padecimiento VARCHAR(100) NOT NULL,
    FOREIGN KEY (IdMascota) REFERENCES Mascotas(IdMascota)
);

-- Tabla de DesparasitacionesVacunas
CREATE TABLE DesparasitacionesVacunas (
    IdDesparacitacion INT PRIMARY KEY,
    IdMascota INT NOT NULL,
    Tipo VARCHAR(20) NOT NULL,
    Fecha DATE,
    Producto VARCHAR(100) NOT NULL,
    FOREIGN KEY (IdMascota) REFERENCES Mascotas(IdMascota)
);

-- Tabla de VETERINARIO PRINCIPAL

CREATE TABLE VeterinarioP (
    IdVeterinarioP INT PRIMARY KEY,
	NombreVet VARCHAR(100) NOT NULL,
	PrimApellido VARCHAR(100) NOT NULL,
	SegApellido VARCHAR(100) NOT NULL,
	Telefono VARCHAR(100) NOT NULL,
	Correo VARCHAR(100) NOT NULL
);

CREATE TABLE VeterinarioS (
    IdVeterinarioS INT PRIMARY KEY,
	NombreVet VARCHAR(100) NOT NULL,
	PrimApellido VARCHAR(100) NOT NULL,
	SegApellido VARCHAR(100) NOT NULL,
	Telefono VARCHAR(100) NOT NULL,
	Correo VARCHAR(100) NOT NULL
);

-- Tabla de CITAS

CREATE TABLE Citas (
    CitaID INT PRIMARY KEY,
    FechaHora DATETIME,
    Detalle VARCHAR(300),
    Diagnostico VARCHAR(300),
    ListaMedicamentos VARCHAR(300), 
    Estado VARCHAR(25),  
	CodigoUsuario INT NOT NULL,
	IdMascota INT NOT NULL,
	IdVeterinarioP INT NOT NULL,
	IdVeterinarioS INT NOT NULL
	FOREIGN KEY (CodigoUsuario) REFERENCES Dueno(CodigoUsuario),
	FOREIGN KEY (IdMascota) REFERENCES Mascotas(IdMascota),
	FOREIGN KEY (IdVeterinarioP) REFERENCES VeterinarioP(IdVeterinarioP),
	FOREIGN KEY (IdVeterinarioS) REFERENCES VeterinarioS(IdVeterinarioS)

);

-- Tabla de Administrador
CREATE TABLE Administracion (
    IdAdm INT PRIMARY KEY,
    NombreAdm VARCHAR(100) NOT NULL,
    Contrasena VARCHAR(30) NOT NULL,
    Rol VARCHAR(20) NOT NULL, 
    ImagenUsuario varbinary(max), 
    UltimaConexion DATETIME,
    EstadoUsuario VARCHAR(20) NOT NULL 
);