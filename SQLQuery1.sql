use master
go

if db_id('mydb2') is not null
begin
	drop database mydb2
end
go

create database mydb2
go

use mydb2
go

create table cargo(
idcargo int primary key identity,
nombre nvarchar(100),
desripcion nvarchar(500)
)
go

create table empleado(
idempleado int primary key identity,
idcargo int foreign key references cargo(idcargo),
nombre nvarchar(100),
edad int, salario decimal(10,2)
)
go

create table pago(
idpago int primary key identity,
idempleado int foreign key references empleado(idempleado),
fechapago datetime2 default current_timestamp,
totalpago decimal(10, 2)
)
go

select idcargo,nombre from cargo
union
select idcargo, nombre from empleado
go

<<<<<<< HEAD
--insert into empleado(nombre, idcargo, edad, salario)
--values('Alberto Mendoza', 1, 26, 600)
--go

select * from cargo;
select * from empleado;
go

--update empleado set idcargo = 2 where idempleado = 7;
--go

select * from pago;
go

select salario from empleado
union
select totalpago from pago
go
=======
select * from cargo;
select * from empleado;
go
>>>>>>> e8050a770c73a93de5266fc8aed70ebda7e8532f
