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
	p.NomeUsuario AS [Nome do Paciente], 
	m.NomeUsuario AS [Nome do Medico],
	tb_Especialidades.TituloEspecialidade AS [Especialidade],
	tb_Medicos.CRM AS [CRM],
	tb_Consultas.DescricaoConsulta AS [Prontuário],
	tb_Feedbacks.Comentario AS [Feedback]
FROM tb_Consultas
LEFT JOIN tb_Clinicas 
ON tb_Clinicas.IdClinica = tb_Consultas.IdClinica
LEFT JOIN tb_Medicos
ON tb_Medicos.IdMedico = tb_Consultas.IdMedico
LEFT JOIN tb_Especialidades
ON tb_Especialidades.IdEspecialidade = tb_Medicos.IdEspecialidade
LEFT JOIN tb_Feedbacks
ON tb_Feedbacks.IdConsulta = tb_Consultas.IdConsulta
LEFT JOIN tb_Pacientes
ON tb_Consultas.IdPaciente = tb_Pacientes.IdPaciente
LEFT JOIN tb_Usuarios AS p
ON p.IdUsuario = tb_Pacientes.IdUsuario
LEFT JOIN tb_Usuarios AS m
ON m.IdUsuario = tb_Medicos.IdUsuario
