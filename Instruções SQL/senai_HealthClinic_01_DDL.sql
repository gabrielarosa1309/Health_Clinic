--DDL Database Definition Language

--criar banco de dados
CREATE DATABASE Health_Clinic_TM
USE Health_Clinic_TM

--criar tabelas
CREATE TABLE tb_TiposUsuario
(
	IdTipoUsuario INT PRIMARY KEY IDENTITY,
	TituloTipoUsuario VARCHAR(50) NOT NULL
)

CREATE TABLE tb_Especialidades
(
	IdEspecialidade INT PRIMARY KEY IDENTITY,
	TituloEspecialidade VARCHAR(50) NOT NULL
)

CREATE TABLE tb_PlanosDeSaude
(
	IdPlanoSaude INT PRIMARY KEY IDENTITY,
	TituloPlanoSaude VARCHAR(50)  NOT NULL
)

CREATE TABLE tb_Clinicas
(
	IdClinica INT PRIMARY KEY IDENTITY,
	NomeFantasia VARCHAR(50) NOT NULL,
	RazaoSocial VARCHAR(50) NOT NULL UNIQUE,
	CNPJ VARCHAR(14) NOT NULL UNIQUE,
	Endereco VARCHAR(100) NOT NULL,
	HorarioAbertura VARCHAR(5) NOT NULL,
	HorarioFechamento VARCHAR(5) NOT NULL
)

CREATE TABLE tb_Usuarios
(
	IdUsuario INT PRIMARY KEY IDENTITY,
	IdTipoUsuario INT FOREIGN KEY REFERENCES tb_TiposUsuario(IdTipoUsuario) NOT NULL,
	NomeUsuario VARCHAR(100) NOT NULL,
	CPF VARCHAR(10) NOT NULL UNIQUE,
	Email VARCHAR(100) NOT NULL UNIQUE,
	Senha VARCHAR(100) NOT NULL
)

ALTER TABLE tb_Usuarios
ALTER COLUMN CPF VARCHAR(11) NOT NULL 

CREATE TABLE tb_Pacientes
(
	IdPaciente INT PRIMARY KEY IDENTITY,
	IdUsuario INT FOREIGN KEY REFERENCES tb_Usuarios(IdUsuario) NOT NULL,
	IdPlanoSaude INT FOREIGN KEY REFERENCES tb_PlanosDeSaude(IdPlanoSaude) NOT NULL,
	Idade VARCHAR(3) NOT NULL,
	DataNascimento VARCHAR(10) NOT NULL
)

CREATE TABLE tb_Medicos
(
	IdMedico INT PRIMARY KEY IDENTITY,
	IdUsuario INT FOREIGN KEY REFERENCES tb_Usuarios(IdUsuario) NOT NULL,
	IdEspecialidade INT FOREIGN KEY REFERENCES tb_Especialidades(IdEspecialidade) NOT NULL,
	CRM VARCHAR(6) NOT NULL UNIQUE
)

ALTER TABLE tb_Medicos
ALTER COLUMN CRM VARCHAR(8) NOT NULL 

ALTER TABLE tb_Medicos
ADD IdClinica INT FOREIGN KEY REFERENCES tb_Clinicas(IdClinica) NOT NULL

CREATE TABLE tb_Consultas
(
	IdConsulta INT PRIMARY KEY IDENTITY,
	IdClinica INT FOREIGN KEY REFERENCES tb_Clinicas(IdClinica) NOT NULL,
	IdPaciente INT FOREIGN KEY REFERENCES tb_Pacientes(IdPaciente) NOT NULL,
	IdMedico INT FOREIGN KEY REFERENCES tb_Medicos(IdMedico) NOT NULL,
	DataConsulta DATE NOT NULL,
	HorarioConsulta TIME NOT NULL,
	DescricaoConsulta TEXT NOT NULL
)

CREATE TABLE tb_Feedbacks
(
	IdFeedback INT PRIMARY KEY IDENTITY,
	IdPaciente INT FOREIGN KEY REFERENCES tb_Pacientes(IdPaciente) NOT NULL,
	IdConsulta INT FOREIGN KEY REFERENCES tb_Consultas(IdConsulta) NOT NULL,
	Comentario TEXT NOT NULL
)