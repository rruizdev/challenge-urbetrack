# Ejercicio de evaluación de candidatos .NET

## Introducción

*Se dispone de una cadena de locales de oficinas distribuidos por toda la ciudad.
Las oficinas se alquilan por hora individualmente. 
Se necesita un sistema que administre las reservas optimizando el uso de cada oficina según su capacidad y recursos disponibles (pizarra, proyector, acceso a internet, etc.).
Las reservas se hacen back-to-back, no hace falta considerar ningún tiempo entre el fin de una reserva y el inicio de la siguiente.*


## Funcionalidad requerida

La interface *IOfficeRentalService* actua como punto de entrada para todas las operaciones.


**AddLocation**<br/>
Agregar un local nuevo.

**GetLocations**<br/> 
Obtener el listado de locales.

**AddOffice**<br/> 
Agregar una oficina a un local.

**GetOffices**<br/> 
Obtener todas las oficinas de un local.

**BookOffice**<br/> 
Reservar una oficina.

**GetBookings**<br/> 
Obtener un listado de reservas de una oficina.

**GetOfficeSuggestion**<br/> 
Obtener un listado de oficinas que coincidan con las especificaciones, ordenados por conveniencia.
Las sugerencias tiene que cumplir estas condiciones:
- permitir la capacidad necesaria
- tener todos los recursos solicitados
- es preferible reservar una oficina en el barrio solicitado pero si no hay ninguna se pueden sugerir otros locales
- es preferible mantener libres las oficinas mas grandes
- es preferible mantener libres las oficinas con mas recursos de los que se requieren

Las sugerencias deben devolver todas las oficinas que cumplan las condiciones. 
Las preferencias deben establecer el orden de los resultado, siendo la primera la que mayor coincidencia tiene con la consulta.


## Proyecto

**NetChallenge/Abstractions**

Contiene las abstracciones de accesso a datos IBookingRepository, ILocationRepository y IOfficeRepository.


**NetChallenge/Domain**

Contiene las clases de negocio.

- Location: es un local que puede contener varias oficinas
    - El nombre no puede estar vacío.
    - El barrio no puede estar vacío.
    - El nombre no puede repetirse.
- Office: es una oficina dentro de un local.
    - Debe pertenecer a un local válido.
    - El nombre no puede estar vacío.
    - El nombre no puede repetirse dentro del mismo local.
    - La capacidad máxima debe ser mayor a cero.
    - Puede tener cero o más recursos disponibles.
- Booking: representa la reserva de una oficina para una fecha y un horario determinado.
    - Debe pertenecer a una oficina válida.
    - Debe tener una duración mayor a cero.
    - No se debe superponer con otras reservas de la misma oficina.
    - El usuario que hace la reserva es obligatorio.


**NetChallenge/Dto/Input**

Contiene los DTO con los parametros de entrada para cada funcionalidad.


**NetChallenge/Dto/Output**

Contiene los DTO de salida con los que se va a responder cada funcionalidad.


**NetChallenge/Exceptions**

Excepciones personalizadas.

**NetChallenge/Infrastructure**

Implementación de los _repository_.

**NetChallenge.Test**

Tests unitarios para validar la lógica implementada.



## Resultado

Se espera que el candidato haga una implementación que cumpla con la funcionalidad solicitada y pase todos los tests.

Qué se espera que se modifique:
- _Abstractions_: No face falta modificar ninguna de las interfaces.
- **Domain**: Se deben implementar las entidades de negocio siguiendo las buenas prácticas de Domain-Driven Design.
- _Dto_: No se debe modificar.
- **Infrastructure**: Se deben implementar las abstracciones de los repository. Los datos se mantienen en memoria.
- **Excepciones**: Se deben implementar las excepciones que hagan falta.
- **OfficeRentalService**: Se debe implementar toda la funcionalidad. No es necesario que toda la lógica esté en esta clase, pero sí que se respeta su interface como punto de entrada.
- _Tests_: No se pueden modificar los tests existentes. Si se requieren tests extra se puede agregar otra clase.


Cuestiones a tener en cuenta:
- Deben pasar todos los tests.
- La implementación debe resolver la funcionalidad requerida, no solamente la que está en los tests.
- No es necesario agregar referencias externas
- El código debe escribirse en inglés.
- Se deben aplicar los principios de _Clean Code_ y _SOLID_.
- Se debe implementar una capa de negocio robusta siguiendo los principios del Domain-Driven Design.
- Se debe hacer un correcto manejo de excepciones.
- Se prefiere el uso de Linq y está mal vista la iteración de colecciones para buscar datos.



Se considerará:
- Comprensión de la problemática planteada
- Calidad de la solución
- Detección de necesidades ocultas
- Prolijidad de los entregables
- Clean Code
- Principios SOLID
- Testeablidad
- Extensibilidad
- Manejo de errores
- Conceptos de Domain-Driven Design

La entrevista técnica posterior consistirá en la defensa de esta solución.