PedidosApp_CatalinaCorrea_SammyArteaga

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
   - Bicicleta si es accesorio, peso < 2 kg y no urgente (estrategia ecológica)

3. Se calcula el costo de envío en función de la distancia y el transporte.

4. Se guarda el pedido usando una instancia Singleton ('RegistroPedidos'), que mantiene una lista global de todos los pedidos registrados.

5. El usuario puede ver el historial de pedidos en un formulario secundario llamado 'Historial'. Este formulario contiene:
      - Un DataGridView que muestra los pedidos guardados.
      - Un ComboBox para filtrar los pedidos por tipo de entrega (Dron, Motocicleta, Camión, Bicicleta o Todos).

   
Patrones de diseño utilizados
- Strategy: Permite intercambiar el método de entrega sin modificar la clase 'Pedido'.
- Factory Method: Se usa en 'EntregaFactory' para encapsular la lógica de selección del transporte.
- Singleton: Se usa en 'RegistroPedidos' para asegurar que solo exista una instancia que almacene todos los pedidos.

Reglas de negocio implementadas

Regla 1: Reglas generales de transporte
      - Si el producto es "tecnología" y es urgente => Dron
      - Si el producto es "accesorio" => Motocicleta
      - Si el producto es "componente" o si el peso supera los 10kg => Camión

Captura con producto de tecnología y urgente
      ![tecnologia](https://github.com/user-attachments/assets/9afdacd9-2bd1-4113-9152-1dba919a1351)

Captura con producto de tecnología, no urgente
![tecnologia_nour](https://github.com/user-attachments/assets/7a391ecc-5108-41d5-b479-2028dbf67dc0)
  
Regla 2: Tarifas por tipo de entrega
      - Dron: 20 * km
      - Motocicleta: 10 * km
      - Camión: 5 * km

Captura con producto de accesorio
![accesorio](https://github.com/user-attachments/assets/cdde90fa-125c-4b15-8f1c-0cb057f23d19)

Captura con producto de componente
![camion](https://github.com/user-attachments/assets/212fb28e-389b-443f-a033-60f23897ee34)
      
Regla 3: Agregar una nueva estrategia de entrega ecológica (Bicicleta)
      - Condición: producto tipo accesorio, peso < 2 kg y no urgente
      - Costo: 3 * 

Captura nueva entrega en Bicicleta
![Bicicleta](https://github.com/user-attachments/assets/26eaa545-86d4-442d-ad8c-5fad7102c35d)

      
Regla 4: Mostrar el historial de pedidos
      - Formulario con un DataGridView que presenta los pedidos almacenados en RegistroPedidos.

Se accede al historial desde el botón "Mostrar pedidos"
![Captura de pantalla 2025-04-29 172143](https://github.com/user-attachments/assets/181c6b6c-2124-4c7c-a6ef-0e568c1c571f)

      
Regla 5: Filtrar el historial por tipo de entrega
      - Se implementa un ComboBox en el formulario de historial para seleccionar entre los distintos tipos de entrega.

Se filtra por "Todos"
![buscarTodos](https://github.com/user-attachments/assets/0a0228b0-2b52-411c-963a-8a0717575887)

Se filtra por "Dron"
![buscarDron](https://github.com/user-attachments/assets/9e6424a0-2b92-4009-9168-aa698eeacf5e)

Se filtra por "Motocicleta"
![buscarMotocicleta](https://github.com/user-attachments/assets/914ba5ec-5253-4057-912e-42c6a87d6cf1)

Se filtra por "Camión"
![buscarCamion](https://github.com/user-attachments/assets/a97614dd-c550-40a7-b109-0066410c5665)

Se filtra por "Bicicleta"
![buscarBicicleta](https://github.com/user-attachments/assets/bb472a73-93de-4f5c-9f4e-73823b683d08)


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
