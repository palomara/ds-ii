use master
go
drop database cadastro
go
create database cadastro
go
use cadastro



create table tb_funcionario(
	id int not null identity(1,1),
	nmFuncionario varchar(50) not null,
	email varchar(180),
	telefone varchar(30),
	endereco varchar(180)
	
	PRIMARY KEY(id)
)

INSERT INTO tb_funcionario(nmFUncionario) values('TESTE') 

select * from tb_funcionario  where nmFuncionario = 'luis'
 
insert into tb_funcionario(nmFuncionario,email,endereco,telefone) values('teste','teste','teste','teste')