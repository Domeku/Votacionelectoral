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


INSERT INTO Roles (Nombre) VALUES (N'Admin'), (N'Votante');

-- Padrones
INSERT INTO Padrones (Nombre) VALUES (N'Mesa 1');
INSERT INTO Padrones (Nombre) VALUES (N'Mesa 2');
-- Mesa 1 queda con PadronID = 1
-- Mesa 2 queda con PadronID = 2

-- Configuracion de votacion activa para ambas mesas (24 horas desde ahora)
INSERT INTO ConfiguracionVotacion (FechaInicio, FechaFin, VotacionActiva, PadronID)
VALUES (SYSUTCDATETIME(), DATEADD(HOUR, 24, SYSUTCDATETIME()), 1, 1);

INSERT INTO ConfiguracionVotacion (FechaInicio, FechaFin, VotacionActiva, PadronID)
VALUES (SYSUTCDATETIME(), DATEADD(HOUR, 24, SYSUTCDATETIME()), 1, 2);



-- Planchas para Mesa 1
INSERT INTO Planchas (Nombre, Eslogan, PadronID)
VALUES (N'Plancha Azul', N'Por un futuro mejor', 1);

INSERT INTO Planchas (Nombre, Eslogan, PadronID)
VALUES (N'Plancha Verde', N'Unidos por el cambio', 1);
-- Planchas para Mesa 2
INSERT INTO Planchas (Nombre, Eslogan, PadronID)
VALUES (N'Plancha Azul', N'Por un futuro mejor', 2);

INSERT INTO Planchas (Nombre, Eslogan, PadronID)
VALUES (N'Plancha Verde', N'Unidos por el cambio', 2);




-- Candidatos Plancha Azul (PlanchaID = 1)
INSERT INTO Candidatos (Nombre, Puesto, PlanchaID) VALUES (N'Carlos Pérez',     N'Presidente',        1);
INSERT INTO Candidatos (Nombre, Puesto, PlanchaID) VALUES (N'Ana García',        N'VicePresidente',    1);
INSERT INTO Candidatos (Nombre, Puesto, PlanchaID) VALUES (N'Luis Martínez',     N'Secretario General',1);
INSERT INTO Candidatos (Nombre, Puesto, PlanchaID) VALUES (N'María López',       N'Tesorero',          1);

-- Candidatos Plancha Verde (PlanchaID = 2)
INSERT INTO Candidatos (Nombre, Puesto, PlanchaID) VALUES (N'Pedro Rodríguez',   N'Presidente',        2);
INSERT INTO Candidatos (Nombre, Puesto, PlanchaID) VALUES (N'Sofía Herrera',     N'VicePresidente',    2);
INSERT INTO Candidatos (Nombre, Puesto, PlanchaID) VALUES (N'Diego Morales',     N'Secretario General',2);
INSERT INTO Candidatos (Nombre, Puesto, PlanchaID) VALUES (N'Valentina Cruz',    N'Tesorero',          2);



-- Verificacion final
SELECT * FROM Padrones;
SELECT * FROM Planchas;
SELECT * FROM Candidatos;
SELECT * FROM ConfiguracionVotacion;

SELECT p.PlanchaID, p.Nombre AS Plancha, c.Nombre AS Candidato, c.Puesto
FROM Planchas p
LEFT JOIN Candidatos c ON c.PlanchaID = p.PlanchaID
ORDER BY p.PlanchaID;