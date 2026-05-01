CREATE DATABASE Votacion;

USE Votacion;

CREATE TABLE Roles (
    RolID INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(50) NOT NULL UNIQUE
);

CREATE TABLE Padrones (
    PadronID INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL UNIQUE
);

CREATE TABLE Usuarios (
    UsuarioID INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Matricula NVARCHAR(50) NOT NULL UNIQUE,
    Curso NVARCHAR(50) NOT NULL,
    Seccion NVARCHAR(20) NOT NULL,
    Contraseña VARBINARY(MAX) NOT NULL, -- hash + salt generado en Logic
    RolID INT NOT NULL,
    PadronID INT NOT NULL,
    CONSTRAINT FK_Usuarios_Roles FOREIGN KEY (RolID) REFERENCES Roles(RolID),
    CONSTRAINT FK_Usuarios_Padron FOREIGN KEY (PadronID) REFERENCES Padrones(PadronID)
);

CREATE TABLE Planchas (
    PlanchaID INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL UNIQUE,
    Eslogan NVARCHAR(255) NULL,
    LogoURL NVARCHAR(500) NULL,
    PadronID INT NOT NULL,
    CONSTRAINT FK_Planchas_Padron FOREIGN KEY (PadronID) REFERENCES Padrones(PadronID)
);

CREATE TABLE Candidatos (
    CandidatoID INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Puesto NVARCHAR(100) NOT NULL,
    PlanchaID INT NOT NULL,
    CONSTRAINT FK_Candidatos_Plancha FOREIGN KEY (PlanchaID) REFERENCES Planchas(PlanchaID)
);

CREATE TABLE Votos (
    VotoID INT IDENTITY(1,1) PRIMARY KEY,
    PlanchaID INT NULL,            -- NULL = voto nulo
    PadronID INT NOT NULL,
    FechaHora DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
    CONSTRAINT FK_Votos_Plancha FOREIGN KEY (PlanchaID) REFERENCES Planchas(PlanchaID),
    CONSTRAINT FK_Votos_Padron FOREIGN KEY (PadronID) REFERENCES Padrones(PadronID)
);

CREATE TABLE VotosAudit (
    VotoAuditID INT IDENTITY(1,1) PRIMARY KEY,
    VotoID INT NOT NULL,
    UsuarioID INT NOT NULL,
    FechaRegistro DATETIME2 NOT NULL DEFAULT SYSUTCDATETIME(),
    CONSTRAINT FK_VotosAudit_Voto FOREIGN KEY (VotoID) REFERENCES Votos(VotoID),
    CONSTRAINT FK_VotosAudit_Usuario FOREIGN KEY (UsuarioID) REFERENCES Usuarios(UsuarioID)
);

CREATE TABLE ConfiguracionVotacion (
    ConfigID INT IDENTITY(1,1) PRIMARY KEY,
    FechaInicio DATETIME2 NOT NULL,
    FechaFin DATETIME2 NOT NULL,
    VotacionActiva BIT NOT NULL DEFAULT 0,
    PadronID INT NOT NULL,
    CONSTRAINT FK_Config_Padron FOREIGN KEY (PadronID) REFERENCES Padrones(PadronID),
    CONSTRAINT CHK_Config_Fechas CHECK (FechaInicio < FechaFin)
);

-- Índices recomendados (solo sobre las tablas que dejaste)
CREATE UNIQUE INDEX IX_Usuarios_Matricula ON Usuarios(Matricula);
CREATE INDEX IX_Usuarios_PadronID ON Usuarios(PadronID);
CREATE INDEX IX_Planchas_PadronID ON Planchas(PadronID);
CREATE INDEX IX_Votos_PadronID ON Votos(PadronID);
CREATE INDEX IX_Votos_PlanchaID ON Votos(PlanchaID);
CREATE INDEX IX_VotosAudit_UsuarioID ON VotosAudit(UsuarioID);

-- Seed mínimo permitido (solo Roles según indicaste)
INSERT INTO Roles (Nombre) VALUES (N'Admin'), (N'Votante');