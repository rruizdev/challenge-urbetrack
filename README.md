# NetChallenge

## Consideraciones iniciales

La soluci�n se realiz� respetando todas las indicaciones en cuanto a reglas de negocio y t�cnicas exigidas (salvo excepciones particulares que se informar�n en el apartado correspondiente).

## Modificaciones realizadas

### Jerarquia de la soluci�n

Los archivos originales de la soluci�n que no requer�an modificaci�n no se modificaron, aunque se realiz� una re-jerarquizaci�n de proyectos y carpetas con el prop�sito de brindar legibilidad y una arquitectura afin a un esquema DDD (Domain-Driven Design), sin escalar a lo purista considerando la complejidad de la soluci�n.

### InMemory

Debido a que la base de datos en memoria a diferencia de una base de datos tradicional (p. ej. SQL Server), omite validaciones establecidas tanto en el modelo como en cada entidad, se realiza una ejecuci�n previa de las validaciones con el fin de prevenir resultados inesperados.

Del mismo modo, la soluci�n realiza la obtenci�n de los datos de dos formas particulares:

- **S�ncrono vs. As�ncrono:** Tradicionalmente cuando invocamos servicios externos o bases de datos, para manejar la ejecuci�n externa en tiempo y forma (ademas de detenerla f�cilmente) usamos asincronismo. En �ste caso no es necesario independientemente de las restricciones que la soluci�n imponga en materia de interfaces.

- **IEnumerable vs. IQueryable:** Cuando consultamos a una base de datos lo �ltimo que necesitamos es que se ejecute la consulta, por tal raz�n se emplea un IQueryable. Adem�s de las limitaciones de la propuesta, al ser una base de datos en memoria es suficiente manejarlo como IEnumerable.

## Oportunidades descartadas

### Arquitectura CQRS

Considerando lo disponible, donde podemos apreciar endpoints destinados exclusivamente a obtenci�n de datos as� como tambi�n otros de impactos de registros (por ejemplo: obtener ubicaciones y agregar ubicaciones), complementar la soluci�n usando CQRS (MediatR: Request, Responses, Query/Command Handler) para mejorar la legibilidad interna ten�a sentido, aunque �sto impactaba de lleno en los "Dto" y el tratamiento de los mismos, ya que la existencia de OfficeRentalService dejaba de tener sentido y el mismo era necesario de acuerdo al enunciado pese a asegurar el acoplamiento de la soluci�n, adem�s de impactar en los Tests existentes que tampoco deb�an modificarse.

### Mapper

Realizar un mapeo del request a la entidad, o de la entidad al response suele dejar mucho codigo a la vista que podria ser abstraido con un AutoMapper con la intenci�n de brindar una vista "syntax sugar". No obstante, si consideramos que era necesario modificar los Tests para poder inyectarlo, entonces se decidi� realizar de manera manual.

## Aclaraciones importantes

### Pruebas unitarias

Si bien no se realizaron modificaciones, se necesita que cada m�todo se ejecute por separado y no juntos ya que podrian entrar en conflicto los casos de uno con el otro. 

Es recomendable correr de a 1 test a fin de validar la veracidad, debido a que el Teardown (IDisposable aqu�) no se ejecuta hasta completado el fixture entero, lo cual no arregla el problema de ra�z