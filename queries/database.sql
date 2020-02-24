CREATE DATABASE AppEmpresaDB;
GO

USE AppEmpresaDB;
GO

CREATE SCHEMA Core;
GO

CREATE TABLE AppEmpresaDB.Core.Companies(
	CNPJ VARCHAR(14) PRIMARY KEY,
	CompanyName VARCHAR(80) NOT NULL,
	StateCode VARCHAR(2) NOT NULL,
	CreateDate DATETIME NOT NULL 
);
GO