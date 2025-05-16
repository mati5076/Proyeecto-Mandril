Documentacion Proyecto Mandril
Programas usados para la creacion de la Api:
C#
.NEt8
PostGreSql
Yarp para el proxy inverso


Endpoints para el microservicio de Mandrill:
Para el Post seria /api/Mandrill 
Para el Get seria /api/Mandrill/
Para el Get por Id seria /api/Mandrill/1 (aqui listarias solo el primer Id) 



Endpoints para el microservicio de Especie
Para el Post seria /api/Especie
Para el Get seria /api/Especie/
Para el Get por Id seria /api/Especie/1 (aqui listarias solo el primer Id) 

uso de Yarp para poder usarlo se debe tener el microservicio que tiene el yarp y el que quieres que se comunique por ejemplo 
microservicio de especiemandril y webaplication2 ese es el que tiene el yarp , entonces para poder hacer la comunicacion se debe
hacer lo siguiente: http://localhost:5127/v1/Especie y aqui te muestra el json del microservicio de especies.Tambien esta otro microservicio que es Mandrill, seria  igual que el anterior pero cambiando /v1/ por /api/ , http://localhost:5127/api/Mandrill


para tener los datos en la base de datos se debe hacer estos comandos 
haciendo cd en la carpeta de inventario 
dotnet ef database update

