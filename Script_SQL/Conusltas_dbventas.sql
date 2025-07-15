exec categoria_listar
-- inserto registros en Categorias

exec categoria_insertar 'lacteos','productos lacteos en general'
exec categoria_insertar  'menestras', 'menestras en general'
exec categoria_insertar  'bebidas', 'bebdidas en general'
exec categoria_insertar  'legumbres', 'legumbres en general'
exec categoria_insertar  'vestuario', 'vestuario para dama y caballero'
exec categoria_insertar  'calzado', 'calzado para dama y caballero'


select 'David' + '_'+ 'Sullca' as 'MI NOMBRE'

EXEC categoria_buscar 'leg' 

exec categoria_actualizar  3,'libreria','libreria en general'

exec categoria_eliminar 7

exec categoria_desactivar 6

exec categoria_insertar 'calzado','calzado en general'