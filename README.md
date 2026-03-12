Clase Particle:

 - Se inicializa con un ángulo, una velocidad, un tiempo de vida máximo y una gravedad. Un contador interno también cuenta el tiempo que lleva viva.
 - Del ángulo se sacan los componentes x e y iniciales de la velocidad, luego accesibles desde ParticlesController para calcular su posición

Clase ParticlesController:

 - Contiene una lista de Particle. Puede llenar esa lista con una "amount" especificada usando el método CreateParticleExplotion, y también puede actualizar la posición de partículas con UpdateParticlePosition.
 - Recorre la lista de partículas y actualiza su posición con UpdateParticlePosition, usando su propio contador interno de tiempo. Antes de recorrer la lista, se eliminan las referencias nulas que puedan quedar de anteriores partículas eliminadas.

  CreateParticleExplotion:
    - Rellena la lista interna con referencias a nuevas instancias del prefab de partícula. Usa el valor de velocidad y vida máxima de ParticlesController y les añade un rango aleatorio con ayuda de una función RandomizeValue. El ángulo es completamente aleatorio, y la gravedad siempre es fija.

  UpdateParticlePosition:
    - Calcula el recorrido uniforme (en x e y) y el acelerado mediante la gravedad en y acorde al contador interno de tiempo de la propia partícula p usada como argumento.
    - Calcula para cada partícula si su vida ha superado el límite y destruye el gameObject cuando se da el caso.
    
