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

select * from cargo;
select * from empleado;
go
