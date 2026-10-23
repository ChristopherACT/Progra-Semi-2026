-- Script opcional: la aplicacion ya crea todo esto automaticamente al iniciar.
-- Puede ejecutarlo en SQL Server Management Studio si prefiere crearlo a mano.

IF DB_ID('db_proyecto_USSS004525') IS NULL
    CREATE DATABASE db_proyecto_USSS004525;
GO

USE db_proyecto_USSS004525;
GO

IF OBJECT_ID('usuarios_USSS004525', 'U') IS NULL
CREATE TABLE usuarios_USSS004525 (
    idUsuario INT IDENTITY(1,1) PRIMARY KEY,   -- int a_i (auto incremento)
    usuario   VARCHAR(35) NOT NULL,
    clave     VARCHAR(35) NOT NULL,
    nombre    VARCHAR(65) NOT NULL,
    direccion VARCHAR(85) NULL,                -- dirección
    telefono  VARCHAR(9)  NULL                 -- teléfono
);
GO

INSERT INTO usuarios_USSS004525 (usuario, clave, nombre, direccion, telefono) VALUES
('usuario01', 'Clave123', 'Maria Lopez',     'Usulutan, El Salvador',       '7777-0001'),
('usuario02', 'Clave456', 'Carlos Martinez', 'San Miguel, El Salvador',     '7777-0002'),
('usuario03', 'Clave789', 'Ana Hernandez',   'Santiago de Maria, Usulutan', '7777-0003');
GO
