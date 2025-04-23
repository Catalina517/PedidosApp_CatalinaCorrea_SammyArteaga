PedidosApp_CatalinaCorrea

Descripción
Este proyecto es una aplicación de escritorio creada con Windows Forms en C# que permite calcular el método de entrega y el costo del envío de un pedido para la tienda virtual TechExpress, aplicando patrones de diseño como Strategy, Factory Method y Singleton.

Funcionamiento general
1. El usuario ingresa:
   - Nombre del cliente
   - Tipo de producto ('tecnología', 'accesorio' o 'componente')
   - Si es urgente o no
   - Peso del producto
   - Distancia de entrega en kilómetros

2. Según las reglas de negocio, se selecciona automáticamente un medio de transporte:
   - Dron si es tecnología y urgente
   - Motocicleta si es accesorio o por defecto
   - Camión si es componente o el peso supera los 10 kg

3. Se calcula el costo de envío en función de la distancia y el transporte.

4. Se guarda el pedido usando una instancia Singleton ('RegistroPedidos'), que mantiene una lista global de todos los pedidos registrados.

Patrones de diseño utilizados
- Strategy: Permite intercambiar el método de entrega sin modificar la clase 'Pedido'.
- Factory Method: Se usa en 'EntregaFactory' para encapsular la lógica de selección del transporte.
- Singleton: Se usa en 'RegistroPedidos' para asegurar que solo exista una instancia que almacene todos los pedidos.


Preguntas de comprensión
1. ¿Qué ventaja tiene usar una interfaz en vez de una clase directa?
La interfaz nos da más libertad. Podemos tener varias formas de entregar los pedidos (dron, moto, camión...) sin tener que cambiar el código principal. Solo creamos nuevas clases que hagan lo que la interfaz pide, y ya. Es más limpio y fácil de mantener.

2. ¿Por qué no pusimos la lógica de entrega dentro de la clase Pedido?
Porque no es su trabajo. La clase Pedido solo debería guardar los datos del pedido, no decidir cómo se entrega. Para eso está el Factory, que se encarga de eso. Así cada cosa hace lo que le toca, y no se mezclan responsabilidades.

3. ¿Cuál principio SOLID fue clave aquí y por qué?
El más importante fue el de abierto/cerrado. El código está "abierto" para agregar cosas nuevas (como otro tipo de entrega), pero "cerrado" para modificar lo que ya funciona. Así evitamos dañar lo que ya está bien hecho.

4. Si queremos agregar entregas ecológicas en bicicleta, ¿qué harías?
Fácil. Creo una clase nueva que se llame EntregaBicicleta y le pongo la lógica. Luego actualizo el Factory para que la devuelva cuando sea un pedido ecológico. Y listo, sin tocar las otras entregas.

5. ¿Cómo ayudan estos patrones a mantener el sistema?
Nos hacen la vida más fácil. Con estos patrones el código no se vuelve un enredo. Todo está separado, ordenado y es más sencillo de entender o cambiar si toca. También ayuda cuando más personas trabajan en el mismo proyecto.

6. ¿Cuándo usarías Singleton en la vida real?
Cuando solo debe haber una sola instancia de algo. Por ejemplo, como hicimos con RegistroPedidos. No tendría sentido tener mil listas de pedidos distintas. Mejor tener solo una para que todos la usen.


Archivos del proyecto
- Código fuente (.cs)
- Capturas de pantalla del formulario en funcionamiento
- Este archivo 
