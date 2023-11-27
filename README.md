# NetChallenge

## Consideraciones iniciales

La solución se realizó respetando todas las indicaciones en cuanto a reglas de negocio y técnicas exigidas (salvo excepciones particulares que se informarán en el apartado correspondiente).

## Modificaciones realizadas

### Jerarquia de la solución

Los archivos originales de la solución que no requerían modificación no se modificaron, aunque se realizó una re-jerarquización de proyectos y carpetas con el propósito de brindar legibilidad y una arquitectura afin a un esquema DDD (Domain-Driven Design), sin escalar a lo purista considerando la complejidad de la solución.

### InMemory

Debido a que la base de datos en memoria a diferencia de una base de datos tradicional (p. ej. SQL Server), omite validaciones establecidas tanto en el modelo como en cada entidad, se realiza una ejecución previa de las validaciones con el fin de prevenir resultados inesperados.

Del mismo modo, la solución realiza la obtención de los datos de dos formas particulares:

- **Síncrono vs. Asíncrono:** Tradicionalmente cuando invocamos servicios externos o bases de datos, para manejar la ejecución externa en tiempo y forma (ademas de detenerla fácilmente) usamos asincronismo. En éste caso no es necesario independientemente de las restricciones que la solución imponga en materia de interfaces.

- **IEnumerable vs. IQueryable:** Cuando consultamos a una base de datos lo último que necesitamos es que se ejecute la consulta, por tal razón se emplea un IQueryable. Además de las limitaciones de la propuesta, al ser una base de datos en memoria es suficiente manejarlo como IEnumerable.

## Oportunidades descartadas

### Arquitectura CQRS

Considerando lo disponible, donde podemos apreciar endpoints destinados exclusivamente a obtención de datos así como también otros de impactos de registros (por ejemplo: obtener ubicaciones y agregar ubicaciones), complementar la solución usando CQRS (MediatR: Request, Responses, Query/Command Handler) para mejorar la legibilidad interna tenía sentido, aunque ésto impactaba de lleno en los "Dto" y el tratamiento de los mismos, ya que la existencia de OfficeRentalService dejaba de tener sentido y el mismo era necesario de acuerdo al enunciado pese a asegurar el acoplamiento de la solución, además de impactar en los Tests existentes que tampoco debían modificarse.

### Mapper

Realizar un mapeo del request a la entidad, o de la entidad al response suele dejar mucho codigo a la vista que podria ser abstraido con un AutoMapper con la intención de brindar una vista "syntax sugar". No obstante, si consideramos que era necesario modificar los Tests para poder inyectarlo, entonces se decidió realizar de manera manual.

## Aclaraciones importantes

### Pruebas unitarias

Si bien no se realizaron modificaciones, se necesita que cada método se ejecute por separado y no juntos ya que podrian entrar en conflicto los casos de uno con el otro. 

Es recomendable correr de a 1 test a fin de validar la veracidad, debido a que el Teardown (IDisposable aquí) no se ejecuta hasta completado el fixture entero, lo cual no arregla el problema de raíz