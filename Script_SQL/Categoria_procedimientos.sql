--Procedimiento Listar
create proc categoria_listar
as
select idcategoria as ID,nombre as Nombre,descripcion as Descripcion,estado as Estado
from categoria
order by idcategoria desc
go
-- ejecutamos el SP categoria_listar
exec categoria_listar
go

--Procedimiento Buscar
create proc categoria_buscar
@valor varchar(50)
as
select idcategoria as ID,nombre as Nombre,descripcion as Descripcion,estado as Estado
from categoria
where nombre like '%' + @valor + '%' Or descripcion like '%' + @valor + '%'
order by nombre asc
go
-- concatenacion
EXEC categoria_buscar 'beb'


--Procedimiento Insertar
create proc categoria_insertar
-- Indicamos los Parametros / variables
@nombre varchar(50),
@descripcion varchar(255)
as
insert into categoria (nombre,descripcion) values (@nombre,@descripcion)
go
-- ejecuto sp categoria_insertar
exec categoria_insertar 'bebidas','bebidas en general'
exec categoria_insertar 'legumbres','legumbres en general'
exec categoria_insertar 'utiles','utiles de escritorio'
exec categoria_insertar 'lacteos','lacteos en general'
exec categoria_insertar 'repuestos','respuestos en general'
exec categoria_insertar 'monitores','monitores en general'

--Procedimiento Actualizar
create proc categoria_actualizar
@idcategoria int,
@nombre varchar(50),
@descripcion varchar(255)
as
update categoria set nombre=@nombre,descripcion=@descripcion
where idcategoria=@idcategoria
go
-- executo categorias_ actualizar
exec categoria_actualizar 1,'licores','licores en general'
exec categoria_actualizar 6, 'computadores','computadoras en general'
--Procedimiento Eliminar
create proc categoria_eliminar
@idcategoria int
as
delete from categoria
where idcategoria=@idcategoria
go
 exec categoria_eliminar 7
--Procedimiento Desactivar
create proc categoria_desactivar
@idcategoria int
as
update categoria set estado=0
where idcategoria=@idcategoria
go
--Procedimiento Activar
create proc categoria_activar
@idcategoria int
as
update categoria set estado=1
where idcategoria=@idcategoria
go

exec categoria_desactivar 1
exec categoria_activar 1

exec categoria_listar