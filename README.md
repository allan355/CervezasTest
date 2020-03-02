# CervezasTest

API 

 

Crear usuario: 

URL: http://allan355-001-site1.itempurl.com//api/usuario/add 

POST 

Data type: json 

Ejemplo: { 

	"Entidad":{ 

		"Nombre":"Allan",//Nombre Del usuario 

		"Apellido1":"Bejarano",//apellido del usuario 

“Apellido2”:null,//opcional 

		"Alias":"allan355",//Nickname para el Login 

		"Contrasena":123,/Contraseña para el login 

		"admin":true//opcional, si no va es un usuario corriente 

	} 

} 

Respuesta: 

{ 

    "Mensaje": "OK", 

    "Entidad": null, 

    "Datos": null 

} 

Login 

URL: http://allan355-001-site1.itempurl.com//api/usuario/login 

POST 

Data type: json 

Ejemplo: { 

	"Entidad":{		"Alias":"allan355",//Nickname para el Login 

		"Contrasena":123,/Contraseña para el login	} 

} 

Respuesta: 

{ 

    "Mensaje": "OK", 

    "Entidad": { 

        "TOKEN": "A01E9BAD-0636-4B42-BCB3-B37EFBEFDE63",//Autogenerado por el sistema 

        "Id": 3//Id Usuario 

    }, 

    "Datos": null 

} 

 

Crear Cerveza: 

URL: http://allan355-001-site1.itempurl.com//api/Cerveza/add 

POST 

Data type: json 

Ejemplo: { 

	"Entidad": { 

	"Entidad":{ 

		"Marca":"Pisen", 

        "Alcohol":"4.9", 

        "TipoId":1, 

        "PaisId":1 

	} 

} 

Respuesta: 

{ 

    "Mensaje": "OK", 

    "Entidad": null, 

    "Datos": null 

} 

Obtener Todo Cerveza: 

URL: http://allan355-001-site1.itempurl.com/api/Cerveza/all 

GET 

Respuesta: 

{ 

    "Mensaje": "La cantidad de cervezas en el sistema es de 3 cervezas", 

    "Entidad": null, 

    "Datos": [ 

        { 

            "Id": 1, 

            "Marca": "Corona", 

            "Alcohol": "4.90", 

            "TipoId": 1, 

            "TipoCerveza": "Normal", 

            "PaisId": 3, 

            "Pais": "Mexico" 

        }, 

        { 

            "Id": 2, 

            "Marca": "Imperial", 

            "Alcohol": "4.90", 

            "TipoId": 1, 

            "TipoCerveza": "Normal", 

            "PaisId": 1, 

            "Pais": "Costa Rica" 

        }, 

        { 

            "Id": 3, 

            "Marca": "Pisen", 

            "Alcohol": "4.90", 

            "TipoId": 1, 

            "TipoCerveza": "Normal", 

            "PaisId": 1, 

            "Pais": "Costa Rica" 

        } 

    ] 

} 

Obtener Cerveza: 

URL: http://allan355-001-site1.itempurl.com/api/Cerveza/1 

Nota el uno se cambia por el ID al cual se va a consultar 

GET 

Respuesta: 

{ 

    "Mensaje": "", 

    "Entidad": { 

        "Id": 1, 

        "Marca": "Corona", 

        "Alcohol": "4.90", 

        "TipoId": 1, 

        "TipoCerveza": "Normal", 

        "PaisId": 3, 

        "Pais": "Mexico" 

    }, 

    "Datos": null 

} 

Agregar consumo: 

URL: http://allan355-001-site1.itempurl.com//api/Cerveza/consumo/add 

POST 

Data type: json 

Ejemplo 

{ 

	"entidad":{ 

		"UsuarioId":3,//Usuario a quien agregar 

		"CervezaId":3,//Cerveza que se registra 

		"Consumo":8//Cantidad de cervezas a registrar 

	} 

} 

Respuesta: 

{ 

    "Mensaje": "OK", 

    "Entidad": null, 

    "Datos": null 

} 

Agregar Consumo: 

URL: http://allan355-001-site1.itempurl.com//api/Cerveza/consumo?FechaInicio=2020-03-01&FechaFin=2020-03-01&id=null 

FechaInicio: Fecha de donde empezar a buscar 

FechaFin: Fecha de donde terminar a buscar 

Id:Usuario a buscar puede ser null para obtener la informacion de todos los usuarios 

POST 

Data type: json 

Ejemplo 

{ 

	"entidad":{ 

		"UsuarioId":3,//Usuario a quien agregar 

		"CervezaId":3,//Cerveza que se registra 

		"Consumo":8//Cantidad de cervezas a registrar 

	} 

} 

Respuesta: 

{ 

    "Mensaje": "OK", 

    "Entidad": null, 

    "Datos": null 

} 

 

 