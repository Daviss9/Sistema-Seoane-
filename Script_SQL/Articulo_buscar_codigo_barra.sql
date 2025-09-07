create proc articulo_buscar_codigo
@valor varchar(50)
as
select idarticulo,codigo,nombre,precio_venta,stock from articulo
where codigo = @valor
go