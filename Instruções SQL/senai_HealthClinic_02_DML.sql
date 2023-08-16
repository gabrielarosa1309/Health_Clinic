--DML Database Manipulation Language

USE Health_Clinic_TM

--inserção de dados
INSERT INTO tb_TiposUsuario(TituloTipoUsuario)
VALUES ('Administrador'),('Médico'),('Paciente')

INSERT INTO tb_Especialidades(TituloEspecialidade)
VALUES ('Cardiologista'),('Neurologista'),('Oftalmologista'),('Nefrologista'),('Dermatologista'),('Ginecologista')

INSERT INTO tb_PlanosDeSaude(TituloPlanoSaude)
VALUES ('Amil'),('Bradesco'),('Qualicorp'),('Unimed'),('Medservice'),('Notredame Intermédica')

INSERT INTO tb_Clinicas(NomeFantasia,RazaoSocial,CNPJ,Endereco,HorarioAbertura,HorarioFechamento)
VALUES ('Health Clinic','Health Clinic S.A','12345678901234','Rua Niterói, 180 - São Caetano do Sul','08h00','18h00')

INSERT INTO tb_Usuarios(IdTipoUsuario,NomeUsuario,CPF,Email,Senha)
VALUES (1,'Gabriela Ramos Mariano Rosa','34587695620','gabi.ramos1309@gmail.com','Chiuaua123'),(2,'João Vitor Oliveira Santos','12332121320','joao.dermato@gmail.com','20533539Jj'),(2,'Everton Silva Araujo','45565478912','evertonaraujosenai@gmail.com','caogataoK'),(3,'Luis Henrique de jesus Correia','28586061214','luizinhogameplays@gmail.com','TmNg@1984'),(3,'Guilherme Sousa Oliveira','45839277642','guilhermedarth045@gmail.com','4444'),(3,'André Brizido Basilio','13556798812','brizidao@gmail.com','humbertinho345')

INSERT INTO tb_Pacientes(IdUsuario,IdPlanoSaude,Idade,DataNascimento)
VALUES (8,1,'22','10/07/2001'),(9,3,'18','25/03/2005'),(10,5,'19','05/08/2004')

INSERT INTO tb_Medicos(IdUsuario,IdEspecialidade,CRM,IdClinica)
VALUES (6,5,'123456SP',1),(7,2,'789012SP',1)

INSERT INTO tb_Consultas(IdClinica,IdPaciente,IdMedico,DataConsulta,HorarioConsulta,DescricaoConsulta)
VALUES (1,1,1,'2023-08-14','15:00:00','Paciente com acne severa. Tomar Roacutan.'),(1,2,1,'2023-02-16','11:45:00','Paciente com frieira no pé. Passar pomada e evitar umidade.'),(1,3,2,'2023-07-29','14:30:00','Paciente com enxaqueca. Tomar remédio.')

INSERT INTO tb_Feedbacks(IdPaciente,IdConsulta,Comentario)
VALUES (1,1,'Médico muito bom e paciente.'),(2,2,'Odiei, médico vadio, safado, cafajeste, nefasto, bobo, sapequinha, taradão, não me ajudou!'),(3,3,'Gostei da consulta, voltarei para futuro tratamento.')

--SELECTS para consultas rápidas
SELECT * FROM tb_TiposUsuario
SELECT * FROM tb_Especialidades
SELECT * FROM tb_PlanosDeSaude
SELECT * FROM tb_Clinicas
SELECT * FROM tb_Usuarios
SELECT * FROM tb_Pacientes
SELECT * FROM tb_Medicos
SELECT * FROM tb_Consultas
SELECT * FROM tb_Feedbacks