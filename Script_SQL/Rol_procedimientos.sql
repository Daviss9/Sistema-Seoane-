-- Inserto los Roles de Usuario
Insert into rol(nombre) values ('ADMINISTRADOR')
Insert into rol(nombre) values ('ALMACENERO')
Insert into rol(nombre) values ('VENDEDOR')
go
select * from rol
go
-- Procedimiento Almacenado Listar Rol
create proc rol_listar
as
select idrol, nombre from rol
where estado = 1
go

exec rol_listar