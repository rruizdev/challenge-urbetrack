# challenge-urbetrack
Desafío técnico de la empresa Urbetrack.

## Ramas
En cada branch, vas a encontrar una versión distinta del desafío, a saber:

### `original`
El enunciado original, sin modificaciones tal como lo envìan. La solución está realizada con dos bibliotecas de clases en .NET Standard 2.0, el cual ya no corre con el actual Visual Studio 2022. Es instalar una versión antigua, o adaptarla a .NET 6 como mínimo.

### `resolution`
El enunciado resuelto, aunque convertido en Web API (vía ASP.NET Core). Se pueden ver varios ejemplos resueltos de manera similar en GitHub, pero resuelto por personas que tampoco entraron.

### `memory-database` (incluye README.md con más detalles)
El enunciado resuelto, aunque convertido en una solución que lee una base de datos InMemory. También convertido a Web API.
En éste se puede demostrar manejo correcto de ORM y base de datos, aunque ellos lo rechazan porque "no corren los tests" (si leyeran que de manera individual si... 🤦‍♂️).

### `memory-database-v2` (stay tuned)
Similar al anterior, aunque con los tests modificados para que pueda correrlo integrando a una base de datos similar de forma conjunta.

## Virtudes y defectos
### Mantener una colección en memoria (`resolution`)
 - 👍 Se puede resolver rápidamente
 - 👍 Las pruebas unitarias pueden correr en síncrono y de manera ágil
 - 👎 Resolverlo rápidamente puede implicar omitir buenas prácticas en materia de arquitectura
 - 👎 No se pueden demostrar capacidades en Bases de Datos y manejo de ORMs

 ### Emplear una Base de Datos InMemory (`memory-database`)
 - 👍 Se pueden demostrar capacidades en ORM
 - 👍 Las pruebas unitarias corren bien de manera individual
 - 👎 Tiene un costo extra de tiempo implementarlo
 - 👎 Requiere modificar las pruebas unitarias para poder generar una base de datos apta para cada caso, o definir una rutina separada para cada uno (a revisar en `memory-database-v2`).


**¡Buena suerte! 🫡**
