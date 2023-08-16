--DQL Database Query Language

USE Health_Clinic_TM

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

--JOIN
SELECT
	tb_Consultas.IdConsulta AS [Id da Consulta],
	tb_Consultas.DataConsulta AS [Data da Consulta],
	tb_Consultas.HorarioConsulta AS [Horario da Consulta],
	tb_Clinicas.NomeFantasia AS [Clinica],
	--Nome do Paciente AS [Nome do Paciente], 
	--Nome do Medico AS [Nome do Medico],
	--Especialidade do Medico AS [Especialidade],
	tb_Medicos.CRM AS [CRM],
	tb_Consultas.DescricaoConsulta AS [Prontuário],
	tb_Feedbacks.Comentario AS [Feedback]
FROM tb_Consultas
INNER JOIN tb


